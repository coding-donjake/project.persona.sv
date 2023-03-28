/*
 
PERSONA 2.0

Prefered saved images per person is 5. Each image must be a unique angle ex: In image1 the person must face straight to the camera, in image2 the person must tilt his head a little bit facing top.
 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// EMGU CV
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;

// FILE STREAMING
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace PERSONA_FINAL_SUPPORT_CODES
{
    public partial class Form1 : Form
    {
        // camera capture
        public Capture videoCapture = null;
        public Mat frame = new Mat();
        public Image<Bgr, Byte> currentFrame = null;
        private Image<Bgr, Byte> detectedFace = null;

        // cascade file for face detection
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"haarcascade_frontalface_alt.xml");

        // for images
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();
        List<string> PersonsNames = new List<string>();

        // for face recognition
        LBPHFaceRecognizer recognizer = new LBPHFaceRecognizer();
        private int currentLabel = 0;
        private string currentPerson = "";
        private Image<Gray, Byte> currentPersonFace = null;
        public Form1()
        {
            InitializeComponent();
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
            label2.Text = "# of images: " + TrainedFaces.Count;

            // camera capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                // display current frame to a picture box
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(pictureBox1.Width, pictureBox1.Height, Inter.Cubic);
                pictureBox1.Image = currentFrame.Bitmap;

                // detect faces
                pictureBox3.Image = null;
                label1.Text = "# of faces: 0";
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(grayImage, grayImage);
                Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                label1.Text = "# of faces: " + faces.Length;
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

                // recognize face
                pictureBox2.Image = null;
                pictureBox4.Image = null;
                pictureBox5.Image = null;
                label3.Text = "Image #: null";
                label4.Text = "Distance: null";
                label6.Text = "Person: none";
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
                    if (currentPerson != "")
                    {
                        label3.Text = "Image #: " + currentLabel;
                        label4.Text = "Distance: " + lowDistance;
                        label6.Text = "Person: " + currentPerson;
                        Image<Bgr, Byte> labeledFrame = currentFrame.Clone();
                        CvInvoke.PutText(labeledFrame, PersonsNames[currentLabel], new Point(faces[0].X - 2, faces[0].Y - 2),
                        FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                        CvInvoke.Rectangle(labeledFrame, faces[0], new Bgr(Color.Green).MCvScalar, 2);
                        pictureBox2.Image = labeledFrame.Bitmap;
                        pictureBox5.Image = currentPersonFace.Resize(pictureBox5.Width, pictureBox5.Height, Inter.Cubic).Bitmap;
                    }
                }
                else
                {

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
            saveImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + textBox1.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
            pictureBox6.Image = saveImage.Bitmap;
            await Task.Run(() =>
            {
                // wait for saving process to complete before executing the following line
                loadSavedFaceFiles();
            });
        }
    }
}
