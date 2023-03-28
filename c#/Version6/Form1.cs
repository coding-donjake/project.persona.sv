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


namespace Version6
{

    public partial class Form1 : Form
    {

        // camera capture
        public VideoCapture videoCapture = null;
        public Mat frame = new Mat();
        public Image<Bgr, Byte> currentFrame = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new VideoCapture();
            Application.Idle += processFrame;
        }

        private void processFrame(object sender, EventArgs e)
        {
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCamera.Width, picCamera.Height, Inter.Cubic);

                
            }
        }

    }

}
