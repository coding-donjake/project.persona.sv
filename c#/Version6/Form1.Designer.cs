namespace Version6
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
            this.components = new System.ComponentModel.Container();
            this.picDetected = new Emgu.CV.UI.ImageBox();
            this.picCompare1 = new Emgu.CV.UI.ImageBox();
            this.picCompare2 = new Emgu.CV.UI.ImageBox();
            this.picFace = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.picCamera = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // picDetected
            // 
            this.picDetected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDetected.Location = new System.Drawing.Point(318, 12);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(300, 200);
            this.picDetected.TabIndex = 3;
            this.picDetected.TabStop = false;
            // 
            // picCompare1
            // 
            this.picCompare1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCompare1.Location = new System.Drawing.Point(12, 218);
            this.picCompare1.Name = "picCompare1";
            this.picCompare1.Size = new System.Drawing.Size(100, 100);
            this.picCompare1.TabIndex = 4;
            this.picCompare1.TabStop = false;
            // 
            // picCompare2
            // 
            this.picCompare2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCompare2.Location = new System.Drawing.Point(118, 218);
            this.picCompare2.Name = "picCompare2";
            this.picCompare2.Size = new System.Drawing.Size(100, 100);
            this.picCompare2.TabIndex = 5;
            this.picCompare2.TabStop = false;
            // 
            // picFace
            // 
            this.picFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFace.Location = new System.Drawing.Point(318, 218);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(100, 100);
            this.picFace.TabIndex = 6;
            this.picFace.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(624, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start Camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(624, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 20);
            this.textBox1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(624, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Save Face";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // picCamera
            // 
            this.picCamera.Location = new System.Drawing.Point(12, 12);
            this.picCamera.Name = "picCamera";
            this.picCamera.Size = new System.Drawing.Size(100, 50);
            this.picCamera.TabIndex = 10;
            this.picCamera.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picCamera);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picFace);
            this.Controls.Add(this.picCompare2);
            this.Controls.Add(this.picCompare1);
            this.Controls.Add(this.picDetected);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCompare2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox picDetected;
        private Emgu.CV.UI.ImageBox picCompare1;
        private Emgu.CV.UI.ImageBox picCompare2;
        private Emgu.CV.UI.ImageBox picFace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox picCamera;
    }
}

