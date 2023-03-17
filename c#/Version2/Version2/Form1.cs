using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Version2
{
    public partial class Form1 : Form
    {
        #region Variables
        // for camera capture
        private Capture videoCapture = null;
        Mat frame = new Mat();                          // use to store image data
        private Image<Bgr, Byte> currentFrame = null;   // current frame
        private Image<Bgr, Byte> detectedFace = null;   // detedted face

        // cascade file for face detection
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"haarcascade_frontalface_alt.xml");

        // for face recognition
        EigenFaceRecognizer recognizer;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();
        List<string> PersonsNames = new List<string>();
        private string currentPerson = "";
        private Image<Gray, Byte> currentPersonFace = null;

        // for saving face images
        private bool saving = false;
        #endregion
        public Form1()
        {
            InitializeComponent();
            loadSavedFaceFiles();
        }

        private void loadSavedFaceFiles()
        {
            int ImagesCount = 0;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\SavedFaces";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(300, 300, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    PersonsNames.Add(file.Split('\\').Last().Split('_')[0]);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + file);
                }

                if (TrainedFaces.Count() > 0)
                {
                    recognizer = new EigenFaceRecognizer(ImagesCount, Double.PositiveInfinity);
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
            label2.Text = "Saving: " + saving;
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                // takes a frame on the camera and converts it into an image object adjusting its size using picCamera size
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCamera.Width, picCamera.Height, Inter.Cubic);

                // display frame to the picture boxes
                picCamera.Image = currentFrame.Bitmap;
                picFaceDetection.Image = currentFrame.Bitmap;

                // Convert from Bgr to Gray Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);

                // Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);

                // detect faces
                Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                labelFacesCount.Text = "Faces: " + faces.Length;
                if (faces.Length > 0)
                {
                    double lowDistance = Double.PositiveInfinity;
                    foreach (var face in faces)
                    {
                        // draws a rectagle on every face detected
                        Image<Bgr, Byte> boxedFrame = currentFrame.Clone();
                        CvInvoke.Rectangle(boxedFrame, face, new Bgr(Color.Red).MCvScalar, 2);
                        picFaceDetection.Image = boxedFrame.Bitmap;

                        // display cropped area of an image obect into pictureBox1
                        detectedFace = currentFrame.Convert<Bgr, Byte>();
                        detectedFace.ROI = face;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = detectedFace.Bitmap;

                        // recognize face
                        if (PersonsNames.Count > 0 && !saving)
                        {
                            Image<Gray, Byte> grayFaceResult = detectedFace.Convert<Gray, Byte>().Resize(300, 300, Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            var result = recognizer.Predict(grayFaceResult);
                            pictureBox2.Image = grayFaceResult.Resize(pictureBox2.Width, pictureBox2.Height, Inter.Cubic).Bitmap;

                            // face recognition conditions
                            if (result.Label != -1 && !PersonsNames[result.Label].Equals("unknown"))
                            {
                                if (result.Distance < lowDistance)
                                {
                                    label1.Text = result.Label + ". " + result.Distance;
                                    currentPerson = PersonsNames[result.Label];
                                    currentPersonFace = TrainedFaces[result.Label];
                                    label3.Text = "Current person: " + currentPerson;
                                }
                            }

                            if (currentPerson != "")
                            {
                                CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                                pictureBox3.Image = currentPersonFace.Resize(pictureBox3.Width, pictureBox3.Height, Inter.Cubic).Bitmap;
                            }
                        }
                    }
                }
            }
        }

        private void saveFace()
        {
            string path = Directory.GetCurrentDirectory() + @"\SavedFaces";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Task.Factory.StartNew(() => {
                while (true)
                {
                    if (!saving)
                    {
                        break;
                    }
                    detectedFace.Convert<Gray, Byte>().Resize(300, 300, Inter.Cubic).Save(path + @"\" + txtPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                }
            });
        }

        private void startCameraCapture(object sender, EventArgs e)
        {
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            //videoCapture.ImageGrabbed += processFrame;
            Application.Idle += processFrame;
            // videoCapture.Start();
        }

        private void toggleSaveFace(object sender, EventArgs e)
        {
            if (saving)
            {
                loadSavedFaceFiles();
                saving = false;
                
            }
            else
            {
                saving = true;
                saveFace();
            }
        }
    }
}
