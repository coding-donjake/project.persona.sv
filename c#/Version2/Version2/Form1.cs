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
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"haarcascade_frontalface_default.xml");
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void processFrame(object sender, EventArgs e)
        {
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
                    }
                }
            }
        }

        private void saveFace(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + @"\SavedFaces";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            detectedFace.Resize(200, 200, Inter.Cubic).Save(path + @"\" + txtPersonName.Text + ".jpg");
            Thread.Sleep(1000);
            txtPersonName.Text = "";
        }

        private void startCameraCapture(object sender, EventArgs e)
        {
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            //videoCapture.ImageGrabbed += processFrame;
            Application.Idle += processFrame;
            // videoCapture.Start();
        }
    }
}
