namespace Version7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picCamera = new Emgu.CV.UI.ImageBox();
            picDetection = new Emgu.CV.UI.ImageBox();
            picCompare1 = new Emgu.CV.UI.ImageBox();
            picCompare2 = new Emgu.CV.UI.ImageBox();
            picFocused = new Emgu.CV.UI.ImageBox();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)picCamera).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDetection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCompare1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCompare2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFocused).BeginInit();
            SuspendLayout();
            // 
            // picCamera
            // 
            picCamera.BorderStyle = BorderStyle.FixedSingle;
            picCamera.Location = new Point(12, 12);
            picCamera.Name = "picCamera";
            picCamera.Size = new Size(300, 300);
            picCamera.TabIndex = 2;
            picCamera.TabStop = false;
            // 
            // picDetection
            // 
            picDetection.BorderStyle = BorderStyle.FixedSingle;
            picDetection.Location = new Point(318, 12);
            picDetection.Name = "picDetection";
            picDetection.Size = new Size(300, 300);
            picDetection.TabIndex = 3;
            picDetection.TabStop = false;
            // 
            // picCompare1
            // 
            picCompare1.BorderStyle = BorderStyle.FixedSingle;
            picCompare1.Location = new Point(12, 318);
            picCompare1.Name = "picCompare1";
            picCompare1.Size = new Size(100, 100);
            picCompare1.TabIndex = 4;
            picCompare1.TabStop = false;
            // 
            // picCompare2
            // 
            picCompare2.BorderStyle = BorderStyle.FixedSingle;
            picCompare2.Location = new Point(118, 318);
            picCompare2.Name = "picCompare2";
            picCompare2.Size = new Size(100, 100);
            picCompare2.TabIndex = 5;
            picCompare2.TabStop = false;
            // 
            // picFocused
            // 
            picFocused.BorderStyle = BorderStyle.FixedSingle;
            picFocused.Location = new Point(318, 318);
            picFocused.Name = "picFocused";
            picFocused.Size = new Size(100, 100);
            picFocused.TabIndex = 6;
            picFocused.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(624, 12);
            button1.Name = "button1";
            button1.Size = new Size(164, 23);
            button1.TabIndex = 7;
            button1.Text = "Start Camera";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(624, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(164, 23);
            textBox1.TabIndex = 8;
            // 
            // button2
            // 
            button2.Location = new Point(624, 100);
            button2.Name = "button2";
            button2.Size = new Size(164, 23);
            button2.TabIndex = 9;
            button2.Text = "Start Saving Face";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(624, 129);
            button3.Name = "button3";
            button3.Size = new Size(164, 23);
            button3.TabIndex = 10;
            button3.Text = "Stop Saving Face";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(picFocused);
            Controls.Add(picCompare2);
            Controls.Add(picCompare1);
            Controls.Add(picDetection);
            Controls.Add(picCamera);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picCamera).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDetection).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCompare1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCompare2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFocused).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Emgu.CV.UI.ImageBox picCamera;
        private Emgu.CV.UI.ImageBox picDetection;
        private Emgu.CV.UI.ImageBox picCompare1;
        private Emgu.CV.UI.ImageBox picCompare2;
        private Emgu.CV.UI.ImageBox picFocused;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
    }
}