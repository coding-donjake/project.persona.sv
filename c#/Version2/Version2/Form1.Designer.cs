
namespace Version2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.picFaceDetection = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnStartCameraCapture = new System.Windows.Forms.Button();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnSaveFace = new System.Windows.Forms.Button();
            this.labelFacesCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFaceDetection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(10, 10);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(300, 300);
            this.picCamera.TabIndex = 0;
            this.picCamera.TabStop = false;
            // 
            // picFaceDetection
            // 
            this.picFaceDetection.Location = new System.Drawing.Point(320, 10);
            this.picFaceDetection.Name = "picFaceDetection";
            this.picFaceDetection.Size = new System.Drawing.Size(300, 300);
            this.picFaceDetection.TabIndex = 1;
            this.picFaceDetection.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 320);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 145);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(165, 320);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(145, 145);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(320, 320);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(145, 145);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(475, 320);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(145, 145);
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // btnStartCameraCapture
            // 
            this.btnStartCameraCapture.Location = new System.Drawing.Point(630, 10);
            this.btnStartCameraCapture.Name = "btnStartCameraCapture";
            this.btnStartCameraCapture.Size = new System.Drawing.Size(243, 40);
            this.btnStartCameraCapture.TabIndex = 6;
            this.btnStartCameraCapture.Text = "Open Camera";
            this.btnStartCameraCapture.UseVisualStyleBackColor = true;
            this.btnStartCameraCapture.Click += new System.EventHandler(this.startCameraCapture);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(630, 320);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(243, 20);
            this.txtPersonName.TabIndex = 7;
            // 
            // btnSaveFace
            // 
            this.btnSaveFace.Location = new System.Drawing.Point(630, 346);
            this.btnSaveFace.Name = "btnSaveFace";
            this.btnSaveFace.Size = new System.Drawing.Size(243, 40);
            this.btnSaveFace.TabIndex = 8;
            this.btnSaveFace.Text = "Save Person";
            this.btnSaveFace.UseVisualStyleBackColor = true;
            this.btnSaveFace.Click += new System.EventHandler(this.saveFace);
            // 
            // labelFacesCount
            // 
            this.labelFacesCount.AutoSize = true;
            this.labelFacesCount.Location = new System.Drawing.Point(630, 408);
            this.labelFacesCount.Name = "labelFacesCount";
            this.labelFacesCount.Size = new System.Drawing.Size(48, 13);
            this.labelFacesCount.TabIndex = 9;
            this.labelFacesCount.Text = "Faces: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "No data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Saving: False";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 476);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFacesCount);
            this.Controls.Add(this.btnSaveFace);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.btnStartCameraCapture);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picFaceDetection);
            this.Controls.Add(this.picCamera);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFaceDetection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.PictureBox picFaceDetection;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnStartCameraCapture;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnSaveFace;
        private System.Windows.Forms.Label labelFacesCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

