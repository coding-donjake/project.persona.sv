
namespace Version3
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
            this.picFocused = new System.Windows.Forms.PictureBox();
            this.picCompare1 = new System.Windows.Forms.PictureBox();
            this.picCompare2 = new System.Windows.Forms.PictureBox();
            this.picCamera = new System.Windows.Forms.PictureBox();
            this.picFaceDetection = new System.Windows.Forms.PictureBox();
            this.picFace3 = new System.Windows.Forms.PictureBox();
            this.picFace2 = new System.Windows.Forms.PictureBox();
            this.picFace1 = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnToggleSaveFace = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFaces = new System.Windows.Forms.TextBox();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImages = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStatistic1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFocused)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFaceDetection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace1)).BeginInit();
            this.SuspendLayout();
            // 
            // picFocused
            // 
            this.picFocused.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFocused.Location = new System.Drawing.Point(12, 330);
            this.picFocused.Name = "picFocused";
            this.picFocused.Size = new System.Drawing.Size(100, 100);
            this.picFocused.TabIndex = 0;
            this.picFocused.TabStop = false;
            // 
            // picCompare1
            // 
            this.picCompare1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCompare1.Location = new System.Drawing.Point(118, 330);
            this.picCompare1.Name = "picCompare1";
            this.picCompare1.Size = new System.Drawing.Size(100, 100);
            this.picCompare1.TabIndex = 1;
            this.picCompare1.TabStop = false;
            // 
            // picCompare2
            // 
            this.picCompare2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCompare2.Location = new System.Drawing.Point(224, 330);
            this.picCompare2.Name = "picCompare2";
            this.picCompare2.Size = new System.Drawing.Size(100, 100);
            this.picCompare2.TabIndex = 2;
            this.picCompare2.TabStop = false;
            // 
            // picCamera
            // 
            this.picCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCamera.Location = new System.Drawing.Point(12, 12);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(312, 312);
            this.picCamera.TabIndex = 3;
            this.picCamera.TabStop = false;
            // 
            // picFaceDetection
            // 
            this.picFaceDetection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFaceDetection.Location = new System.Drawing.Point(330, 12);
            this.picFaceDetection.Name = "picFaceDetection";
            this.picFaceDetection.Size = new System.Drawing.Size(312, 312);
            this.picFaceDetection.TabIndex = 7;
            this.picFaceDetection.TabStop = false;
            // 
            // picFace3
            // 
            this.picFace3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFace3.Location = new System.Drawing.Point(542, 330);
            this.picFace3.Name = "picFace3";
            this.picFace3.Size = new System.Drawing.Size(100, 100);
            this.picFace3.TabIndex = 6;
            this.picFace3.TabStop = false;
            // 
            // picFace2
            // 
            this.picFace2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFace2.Location = new System.Drawing.Point(436, 330);
            this.picFace2.Name = "picFace2";
            this.picFace2.Size = new System.Drawing.Size(100, 100);
            this.picFace2.TabIndex = 5;
            this.picFace2.TabStop = false;
            // 
            // picFace1
            // 
            this.picFace1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFace1.Location = new System.Drawing.Point(330, 330);
            this.picFace1.Name = "picFace1";
            this.picFace1.Size = new System.Drawing.Size(100, 100);
            this.picFace1.TabIndex = 4;
            this.picFace1.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(648, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(174, 23);
            this.btnCapture.TabIndex = 8;
            this.btnCapture.Text = "Open Camera";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(648, 330);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(174, 20);
            this.txtPersonName.TabIndex = 9;
            // 
            // btnToggleSaveFace
            // 
            this.btnToggleSaveFace.Location = new System.Drawing.Point(648, 356);
            this.btnToggleSaveFace.Name = "btnToggleSaveFace";
            this.btnToggleSaveFace.Size = new System.Drawing.Size(174, 23);
            this.btnToggleSaveFace.TabIndex = 10;
            this.btnToggleSaveFace.Text = "Start Saving Face";
            this.btnToggleSaveFace.UseVisualStyleBackColor = true;
            this.btnToggleSaveFace.Click += new System.EventHandler(this.toggleSaveFace);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(649, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "# of faces";
            // 
            // txtFaces
            // 
            this.txtFaces.Location = new System.Drawing.Point(652, 66);
            this.txtFaces.Name = "txtFaces";
            this.txtFaces.Size = new System.Drawing.Size(77, 20);
            this.txtFaces.TabIndex = 12;
            // 
            // txtPerson
            // 
            this.txtPerson.Location = new System.Drawing.Point(741, 66);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(77, 20);
            this.txtPerson.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(738, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "person";
            // 
            // txtImages
            // 
            this.txtImages.Location = new System.Drawing.Point(652, 105);
            this.txtImages.Name = "txtImages";
            this.txtImages.Size = new System.Drawing.Size(77, 20);
            this.txtImages.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(649, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "# of images";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(741, 105);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(77, 20);
            this.txtDistance.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(738, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "distance";
            // 
            // txtStatistic1
            // 
            this.txtStatistic1.Location = new System.Drawing.Point(652, 144);
            this.txtStatistic1.Name = "txtStatistic1";
            this.txtStatistic1.Size = new System.Drawing.Size(166, 20);
            this.txtStatistic1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(649, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "distance / # of images";
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Location = new System.Drawing.Point(648, 417);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(43, 13);
            this.labStatus.TabIndex = 21;
            this.labStatus.Text = "Status: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 443);
            this.Controls.Add(this.labStatus);
            this.Controls.Add(this.txtStatistic1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtImages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFaces);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnToggleSaveFace);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picFaceDetection);
            this.Controls.Add(this.picFace3);
            this.Controls.Add(this.picFace2);
            this.Controls.Add(this.picFace1);
            this.Controls.Add(this.picCamera);
            this.Controls.Add(this.picCompare2);
            this.Controls.Add(this.picCompare1);
            this.Controls.Add(this.picFocused);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picFocused)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFaceDetection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFocused;
        private System.Windows.Forms.PictureBox picCompare1;
        private System.Windows.Forms.PictureBox picCompare2;
        private System.Windows.Forms.PictureBox picCamera;
        private System.Windows.Forms.PictureBox picFaceDetection;
        private System.Windows.Forms.PictureBox picFace3;
        private System.Windows.Forms.PictureBox picFace2;
        private System.Windows.Forms.PictureBox picFace1;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnToggleSaveFace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFaces;
        private System.Windows.Forms.TextBox txtPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStatistic1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labStatus;
    }
}

