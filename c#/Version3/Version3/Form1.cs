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

namespace Version3
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

        // for face recognition
        EigenFaceRecognizer recognizer;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();
        List<string> PersonsNames = new List<string>();
        private string currentPerson = "";
        private Image<Gray, Byte> currentPersonFace = null;

        // for saving face images
        private bool saving = false;


        // data that needs to be observed
        double distanceOverImages = 0;

        public Form1()
        {
            InitializeComponent();
            loadSavedFaceFiles();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            Application.Idle += processFrame;
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
                for (int i = 0; i < files.Length; i++)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(files[i]).Resize(300, 300, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    PersonsNames.Add(files[i].Split('\\').Last().Split('_')[0]);
                    ImagesCount++;
                }

                // EigenFaceRecognizer face recognition algorithm
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
            // clear pictureBoxes
            picCamera.Image = null;
            picFocused.Image = null;
            picCompare1.Image = null;
            picCompare2.Image = null;

            // clear pictureBoxes
            picFaceDetection.Image = null;
            picFace1.Image = null;
            picFace2.Image = null;
            picFace3.Image = null;

            txtPerson.Text = "";
            txtImages.Text = TrainedFaces.Count.ToString();
            txtDistance.Text = "";
            currentPerson = "";
            currentPersonFace = null;
            distanceOverImages = 0;

            // camera capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                // takes a frame on the camera and converts it into an image object adjusting its size using picCamera size
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCamera.Width, picCamera.Height, Inter.Cubic);

                // display frame to the 2 main picture boxes
                picCamera.Image = currentFrame.Bitmap;
                picFaceDetection.Image = currentFrame.Bitmap;

                // Convert currentImage from Bgr to Gray Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);

                // Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);

                // detect faces
                Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                txtFaces.Text = faces.Length.ToString();
                if (faces.Length > 0)
                {
                    // for increasing face recognition accuracy
                    double lowDistance = Double.PositiveInfinity;

                    // faces iteration
                    for (int i = 0; i < faces.Length; i++)
                    {
                        // draws a rectagle on every face detected
                        Image<Bgr, Byte> boxedFrame = currentFrame.Clone();
                        CvInvoke.Rectangle(boxedFrame, faces[i], new Bgr(Color.Red).MCvScalar, 2);
                        picFaceDetection.Image = boxedFrame.Bitmap;

                        // display cropped area of an image obect into picFace1, picFace2, picFace3
                        detectedFace = currentFrame.Convert<Bgr, Byte>();
                        detectedFace.ROI = faces[i];
                        switch (i)
                        {
                            case 0:
                                picFace1.SizeMode = PictureBoxSizeMode.StretchImage;
                                picFace1.Image = detectedFace.Bitmap;
                                break;
                            case 1:
                                picFace2.SizeMode = PictureBoxSizeMode.StretchImage;
                                picFace2.Image = detectedFace.Bitmap;
                                break;
                            case 2:
                                picFace3.SizeMode = PictureBoxSizeMode.StretchImage;
                                picFace3.Image = detectedFace.Bitmap;
                                break;
                        }

                        // recognize face
                        if (PersonsNames.Count > 0 && !saving)
                        {
                            picFocused.SizeMode = PictureBoxSizeMode.StretchImage;
                            picFocused.Image = detectedFace.Bitmap;

                            // make a gray version of detected face and display on picCompare1
                            Image<Gray, Byte> grayFaceResult = detectedFace.Convert<Gray, Byte>().Resize(300, 300, Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            picCompare1.SizeMode = PictureBoxSizeMode.StretchImage;
                            picCompare1.Image = grayFaceResult.Bitmap;

                            // making a comparison to recognize
                            var result = recognizer.Predict(grayFaceResult);

                            // distance over # of images
                            distanceOverImages = result.Distance / TrainedFaces.Count;

                            // face recognition conditions
                            if (result.Label != -1 && !PersonsNames[result.Label].Equals("unknown"))
                            {
                                txtDistance.Text = result.Distance.ToString();
                                if (result.Distance < lowDistance && (result.Distance / TrainedFaces.Count) < 100)
                                {
                                    currentPerson = PersonsNames[result.Label];
                                    currentPersonFace = TrainedFaces[result.Label];
                                    lowDistance = result.Distance;
                                }
                                else
                                {
                                    currentPerson = "";
                                }
                            }

                            if (currentPerson != "")
                            {
                                txtPerson.Text = currentPerson;
                                CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(faces[i].X - 2, faces[i].Y - 2),
                                FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, faces[i], new Bgr(Color.Green).MCvScalar, 2);
                                picCompare2.Image = currentPersonFace.Resize(picCompare1.Width, picCompare1.Height, Inter.Cubic).Bitmap;
                            }
                        }
                    }
                }
            }
            txtStatistic1.Text = distanceOverImages.ToString();
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
                    detectedFace.Resize(300, 300, Inter.Cubic).Save(path + @"\" + txtPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                }
            });
        }

        private void toggleSaveFace(object sender, EventArgs e)
        {
            if (saving)
            {
                loadSavedFaceFiles();
                saving = false;
                btnToggleSaveFace.Text = "Start Saving Face";
            }
            else
            {
                saving = true;
                saveFace();
                btnToggleSaveFace.Text = "Stop Saving Face";
            }
        }

    }

}
