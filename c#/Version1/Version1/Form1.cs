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

namespace Version1
{
    public partial class Form1 : Form
    {
        #region Variables
        // for camera capture
        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();

        // for toggle camera capture
        private bool facesDetectionEnabled = false;

        // for saving face images
        bool EnabledSaveImage = false;

        Image<Bgr, Byte> faceResult = null;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabels = new List<int>();

        // ???
        private static bool isTrained = false;

        EigenFaceRecognizer recognizer;

        List<string> PersonsNames = new List<string>();

        // load cascade file
        CascadeClassifier faceCascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            // start camera capture
            videoCapture = new Capture();
            videoCapture.ImageGrabbed += ProcessFrame;
            videoCapture.Start();
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            // video capture
            videoCapture.Retrieve(frame, 0);
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);

            // render captured frame into the picture box picCapture2
            picCapture.Image = currentFrame.Bitmap;

            // toggle start camera capture
            if (facesDetectionEnabled)
            {
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(grayImage, grayImage);
                Rectangle[] faces = faceCascadeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
                if (faces.Length > 0)
                {
                    foreach (var face in faces) {
                        // draw square around each faces
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                        // display face on picDetected
                        Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                        resultImage.ROI = face;
                        picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                        picDetected.Image = resultImage.Bitmap;

                        if (EnabledSaveImage)
                        {
                            string path = Directory.GetCurrentDirectory() + @"\TrainedImages";

                            // check and create the directory if not exists
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }

                            // save 10 images
                            for (int i = 0; i < 10; i++)
                            {
                                resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonName.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                                Thread.Sleep(1000);
                            }

                            // disable saving images
                            EnabledSaveImage = false;
                        }

                        if (btnAddPerson.InvokeRequired)
                        {
                            btnAddPerson.Invoke(new ThreadStart(delegate
                            {
                                btnAddPerson.Enabled = true;
                            }));
                        }

                        if (isTrained)
                        {
                            Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            var result = recognizer.Predict(grayFaceResult);
                            // pictureBox1.Image = grayFaceResult.Bitmap;
                            // pictureBox2.Image = TrainedFaces[result.Label].Bitmap;
                            Debug.WriteLine(result.Label + ". " + result.Distance);
                            //Here results found known faces
                            if (result.Label != -1 && result.Distance < 2000)
                            {
                                CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
                            }
                            //here results did not found any know faces
                            else
                            {
                                CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
                                    FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            }
                        }
                    }
                }
            }
            
            // render captured frame into the picture box picCapture2
            picCapture2.Image = currentFrame.Bitmap;
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            facesDetectionEnabled = true;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnAddPerson.Enabled = true;
            EnabledSaveImage = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnAddPerson.Enabled = false;
            EnabledSaveImage = true;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            TrainImagesFromDir();
        }

        private bool TrainImagesFromDir()
        {
            int ImagesCount = 0;
            int Threshold = -1;
            TrainedFaces.Clear();
            PersonsLabels.Clear();
            PersonsNames.Clear();
            try
            {
                string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
                string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Image<Gray, Byte> trainedImage = new Image<Gray, byte>(file);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabels.Add(ImagesCount);
                    string name = file.Split('\\').Last().Split('_')[0];
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);
                }
                recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
                recognizer.Train(TrainedFaces.ToArray(), PersonsLabels.ToArray());
                isTrained = true;
                Debug.WriteLine(ImagesCount);
                Debug.WriteLine(isTrained);
                return isTrained;
            }
            catch (Exception ex)
            {
                isTrained = false;
                MessageBox.Show("Error in Train Images: " + ex.Message);
                return isTrained;
            }
        }
    }
}
