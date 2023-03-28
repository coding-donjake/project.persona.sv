using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version4
{
    public partial class Form1 : Form
    {
        public Capture camera;
        public Image<Bgr, Byte> currentFrame;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            camera = new Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(FrameProcedure);
        }

        private void FrameProcedure(object sender, EventArgs e)
        {
            currentFrame = camera.QueryFrame().Resize(picCamera.Width, picCamera.Height, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
            picCamera.Image = currentFrame;
        }
    }
}
