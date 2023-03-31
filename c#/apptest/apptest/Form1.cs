using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Npgsql.PostgresTypes.PostgresCompositeType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace apptest
{
    public partial class Form1 : Form
    {
        Capture capture;
        public Form1()
        {
            InitializeComponent();
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            NpgsqlDataReader dr = sql.getRecords();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                recordsList.DataSource = dt;
            }
            else
            {
                dr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Queries sql = new Queries("localhost", "5432", "postgres", "postgres", "donjake");
            Console.WriteLine(sql.createRecord(lastname.Text, firstname.Text, middlename.Text, email.Text, phone.Text, department.Text, face.Text, image_profile.Text, status.Text));
            NpgsqlDataReader dr = sql.getRecords();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                recordsList.DataSource = dt;
            }
            else
            {
                dr.Close();
            }
        }
    }
}
