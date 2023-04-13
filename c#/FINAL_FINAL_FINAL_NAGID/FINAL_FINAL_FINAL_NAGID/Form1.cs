using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//EMGU CV
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;

//FILE STREAMING
using System.IO;
using System.Threading;
using System.Diagnostics;

using Npgsql;

namespace FINAL_FINAL_FINAL_NAGID
{
    public partial class Form1 : Form
    {
        //camera capture
        public Capture videoCapture = null;
        public Mat frame = new Mat();
        public Image<Bgr, Byte> currentFrame = null;
        private Image<Bgr, Byte> detectedFace = null;

        // cascade file for face detection
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"haarcascade_frontalface_default.xml");

        // for images
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();
        List<string> PersonsNames = new List<string>();

        //for face recognition
        LBPHFaceRecognizer recognizer = new LBPHFaceRecognizer();
        private int currentLabel = 0;
        private string currentPerson = "";
        private Image<Gray, Byte> currentPersonFace = null;

        private string currentID = "";

        public Form1()
        {
            InitializeComponent();
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            NpgsqlDataReader dr = sql.getRecords();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dr.Close();
            }
            loadSavedFaceFiles();
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            Application.Idle += processFrame;
        }

        private void loadSavedFaceFiles()
        {
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\saved_images";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(files[i]).Resize(300, 300, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(i);
                    PersonsNames.Add(files[i].Split('\\').Last().Split('_')[0]);
                }
                if (TrainedFaces.Count() > 0)
                {
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Train Images: " + ex.Message);
            }
        }

        private void processFrame(object sender, EventArgs e)
        {
            //camera capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                //display current frame to a picture box
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic);
                pictureBox1.Image = currentFrame.Bitmap;

                //detect faces
                pictureBox3.Image = null;
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(grayImage, grayImage);
                Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                if (faces.Length > 0)
                {
                    for (int i = 0; i < faces.Length; i++)
                    {
                        Image<Bgr, Byte> boxedFrame = currentFrame.Clone();
                        CvInvoke.Rectangle(boxedFrame, faces[i], new Bgr(Color.Blue).MCvScalar, 2);
                        pictureBox1.Image = boxedFrame.Bitmap;
                        detectedFace = currentFrame.Convert<Bgr, Byte>();
                        detectedFace.ROI = faces[i];
                        pictureBox3.Image = detectedFace.Bitmap;
                    }
                }

                //recognize face
                pictureBox2.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                label7.Text = "no face detected";
                if (faces.Length == 1 && PersonsNames.Count > 0)
                {
                    double lowDistance = Double.PositiveInfinity;
                    for (int i = 0; i < faces.Length; i++)
                    {
                        Image<Gray, Byte> grayFaceResult = detectedFace.Convert<Gray, Byte>().Resize(300, 300, Inter.Cubic);
                        CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                        pictureBox4.Image = grayFaceResult.Bitmap;
                        var result = recognizer.Predict(grayFaceResult);
                        if (result.Label != -1 && !PersonsNames[result.Label].Equals("unknown"))
                        {
                            if (result.Distance < lowDistance)
                            {
                                currentLabel = result.Label;
                                currentPerson = PersonsNames[result.Label];
                                currentPersonFace = TrainedFaces[result.Label];
                                lowDistance = result.Distance;
                            }
                        }
                    }
                    distance.Text = "distance: " + lowDistance;
                    if (currentPerson != "")
                    {
                        if (lowDistance > 42)
                        {
                            Image<Bgr, Byte> labeledFrame = currentFrame.Clone();
                            // CvInvoke.PutText(labeledFrame, "???", new Point(faces[0].X - 2, faces[0].Y - 2), FontFace.HersheyComplex, 0.8, new Bgr(Color.Red).MCvScalar);
                            label7.Text = "unknown";
                            CvInvoke.Rectangle(labeledFrame, faces[0], new Bgr(Color.Red).MCvScalar, 2);
                            pictureBox2.Image = labeledFrame.Bitmap;
                        }
                        else
                        {
                            Image<Bgr, Byte> labeledFrame = currentFrame.Clone();
                            // CvInvoke.PutText(labeledFrame, PersonsNames[currentLabel], new Point(faces[0].X - 2, faces[0].Y - 2), FontFace.HersheyComplex, 0.8, new Bgr(Color.Green).MCvScalar);
                            label7.Text = PersonsNames[currentLabel];
                            CvInvoke.Rectangle(labeledFrame, faces[0], new Bgr(Color.Green).MCvScalar, 2);
                            pictureBox2.Image = labeledFrame.Bitmap;
                            pictureBox5.Image = currentPersonFace.Resize(pictureBox5.Width, pictureBox5.Height, Inter.Cubic).Bitmap;
                        }
                    }
                }
            }
        }

        private async void saveFace(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\saved_images";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Image<Bgr, Byte> saveImage = detectedFace.Clone();
            saveImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + record.Text.Split(',')[0] + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
            pictureBox6.Image = saveImage.Bitmap;
            faceID.Text = record.Text.Split(',')[0];
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            sql.updateRecordFace(int.Parse(currentID), record.Text.Split(',')[0]);
            await Task.Run(() =>
            {
                //wait for saving process to complete before executing the following line
                loadSavedFaceFiles();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            Console.WriteLine(sql.createRecord(lastname.Text, firstname.Text, middlename.Text, department.Text, "active"));
            NpgsqlDataReader dr = sql.getRecords();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dr.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                currentID = row.Cells["record_id"].Value.ToString();
                string columnValue = "[" + row.Cells["record_id"].Value.ToString() + "]" + row.Cells["fullname"].Value.ToString();
                record.Text = columnValue;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            int record_id = sql.timeIn(label7.Text, "face");
            if (record_id == 0)
            {
                MessageBox.Show("Cannot time in. This happens when you already made a time in action or an error occured during the execution.");
            }
            else
            {
                NpgsqlDataReader dr = sql.getAttendance(record_id, DateTime.Now.ToString("yyyy-MM-dd" + " 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd" + " 23:59:59"));
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    dr.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            int record_id = sql.breakOut(label7.Text, "face");
            if (record_id == 0)
            {
                MessageBox.Show("Cannot break out. This happens when you already made a time in action or an error occured during the execution.");
            }
            else
            {
                NpgsqlDataReader dr = sql.getAttendance(record_id, DateTime.Now.ToString("yyyy-MM-dd" + " 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd" + " 23:59:59"));
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    dr.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            int record_id = sql.breakIn(label7.Text, "face");
            if (record_id == 0)
            {
                MessageBox.Show("Cannot break in. This happens when you already made a time in action or an error occured during the execution.");
            }
            else
            {
                NpgsqlDataReader dr = sql.getAttendance(record_id, DateTime.Now.ToString("yyyy-MM-dd" + " 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd" + " 23:59:59"));
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    dr.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            int record_id = sql.timeOut(label7.Text, "face");
            if (record_id == 0)
            {
                MessageBox.Show("Cannot check out. This happens when you already made a time in action or an error occured during the execution.");
            }
            else
            {
                NpgsqlDataReader dr = sql.getAttendance(record_id, DateTime.Now.ToString("yyyy-MM-dd" + " 00:00:00"), DateTime.Now.ToString("yyyy-MM-dd" + " 23:59:59"));
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    dr.Close();
                }
            }
        }
    }
}
