using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Version9
{
    public partial class Form1 : Form
    {
        private readonly CascadeClassifier faceDetector;
        private readonly VideoCapture capture;

        private Mat frame = new Mat();
        public Image<Bgr, Byte> currentFrame = null;

        public Form1()
        {
            InitializeComponent();

            // Load the Haar cascade classifier for face detection
            faceDetector = new CascadeClassifier("haarcascade_frontalface_default.xml");

            // Create a new VideoCapture object
            capture = new VideoCapture();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (capture != null) capture.Dispose();

            processFrame();
        }

        private void processFrame()
        {
            if (capture != null && capture.Ptr != IntPtr.Zero)
            {
                capture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCamera.Width, picCamera.Height, Inter.Cubic);
            }



            while (true)
            {
                // Capture a frame from the camera
                Mat frame = capture.QueryFrame();

                // Convert the frame to grayscale
                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray);

                // Detect faces in the frame
                Rectangle[] faces = faceDetector.DetectMultiScale(grayFrame, 1.2, 3, new Size(30, 30));

                // Draw rectangles around the detected faces
                foreach (Rectangle face in faces)
                {
                    CvInvoke.Rectangle(frame, face, new Bgr(Color.Red).MCvScalar, 2);
                }

                // Display the frame with the detected faces
                picCamera.Image = frame.ToBitmap;

                // Delay for a short period to allow for smooth display
                CvInvoke.WaitKey(30);
            }
        }
    }
}
