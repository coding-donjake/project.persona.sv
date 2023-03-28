// EMGU CV
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System;

namespace Version7
{

    public partial class Form1 : Form
    {

        // camera capture
        public VideoCapture capture;
        public Mat frame;

        // for face detection
        CascadeClassifier faceCascade = new CascadeClassifier("C:\\programming\\projects\\project.persona.sv\\c#\\Version7\\Version7\\bin\\Debug\\haarcascade_frontalface_alt.xml");

        // for face recognition
        LBPHFaceRecognizer recognizer = new LBPHFaceRecognizer();

        // for saving face images
        Image<Bgr, byte> detectedFace;
        public bool saving = false;

        public Form1()
        {
            InitializeComponent();
            string path = Directory.GetCurrentDirectory() + @"\SavedFaces";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (capture != null) capture.Dispose();
            capture = new VideoCapture();
            Application.Idle += processFrame;
        }

        private void processFrame(object sender, EventArgs e)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero)
            {
                frame = capture.QueryFrame();

                // display camera frames to picCamera
                Mat picCameraFrame = new Mat();
                CvInvoke.Resize(frame, picCameraFrame, picCamera.Size);
                Image<Bgr, byte> picCameraImage = picCameraFrame.ToImage<Bgr, Byte>();
                picCamera.Image = picCameraImage;

                // for face detection
                Mat picDetectionFrame = picCameraFrame.Clone();
                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(picDetectionFrame, grayFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                Rectangle[] faces = faceCascade.DetectMultiScale(grayFrame, 1.2, 3);
                foreach (Rectangle face in faces)
                {
                    CvInvoke.Rectangle(picDetectionFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                    // display face to picFocused
                    detectedFace = picCameraImage.Clone();
                    detectedFace.ROI = face;
                    detectedFace.Resize(100, Inter.Linear);
                    picFocused.Image = detectedFace;
                }

                // display detected face to picDetection
                CvInvoke.Resize(picDetectionFrame, picCameraFrame, picCamera.Size);
                Image<Bgr, byte> picDetectionImage = picDetectionFrame.ToImage<Bgr, Byte>();
                picDetection.Image = picDetectionImage;

                // clone for saving face images
                detectedFace = picDetectionImage.Clone();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saving = true;
            string path = Directory.GetCurrentDirectory() + @"\SavedFaces";
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (!saving)
                    {
                        break;
                    }
                    detectedFace.Resize(300, 300, Inter.Cubic).Save(path + @"\" + textBox1.Text + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saving = false;
        }
    }

}