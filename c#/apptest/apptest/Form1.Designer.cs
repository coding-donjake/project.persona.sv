namespace apptest
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
            this.createRecord = new System.Windows.Forms.Button();
            this.lastname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.firstname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.middlename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.face = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.image_profile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ComboBox();
            this.recordsList = new System.Windows.Forms.DataGridView();
            this.department = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.recordsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // createRecord
            // 
            this.createRecord.Location = new System.Drawing.Point(15, 152);
            this.createRecord.Name = "createRecord";
            this.createRecord.Size = new System.Drawing.Size(318, 23);
            this.createRecord.TabIndex = 0;
            this.createRecord.Text = "create";
            this.createRecord.UseVisualStyleBackColor = true;
            this.createRecord.Click += new System.EventHandler(this.button1_Click);
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(15, 25);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(100, 20);
            this.lastname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "lastname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "firstname";
            // 
            // firstname
            // 
            this.firstname.Location = new System.Drawing.Point(124, 25);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(100, 20);
            this.firstname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "middlename";
            // 
            // middlename
            // 
            this.middlename.Location = new System.Drawing.Point(233, 25);
            this.middlename.Name = "middlename";
            this.middlename.Size = new System.Drawing.Size(100, 20);
            this.middlename.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "email";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(15, 64);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(100, 20);
            this.email.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "phone";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(124, 64);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(100, 20);
            this.phone.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "department";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "face";
            // 
            // face
            // 
            this.face.Location = new System.Drawing.Point(233, 64);
            this.face.Name = "face";
            this.face.Size = new System.Drawing.Size(100, 20);
            this.face.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "image profile";
            // 
            // image_profile
            // 
            this.image_profile.Location = new System.Drawing.Point(15, 103);
            this.image_profile.Name = "image_profile";
            this.image_profile.Size = new System.Drawing.Size(100, 20);
            this.image_profile.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "status";
            // 
            // status
            // 
            this.status.FormattingEnabled = true;
            this.status.Items.AddRange(new object[] {
            "active",
            "suspended",
            "removed"});
            this.status.Location = new System.Drawing.Point(233, 103);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(100, 21);
            this.status.TabIndex = 19;
            // 
            // recordsList
            // 
            this.recordsList.AllowDrop = true;
            this.recordsList.AllowUserToAddRows = false;
            this.recordsList.AllowUserToDeleteRows = false;
            this.recordsList.AllowUserToResizeColumns = false;
            this.recordsList.AllowUserToResizeRows = false;
            this.recordsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordsList.Location = new System.Drawing.Point(15, 253);
            this.recordsList.Name = "recordsList";
            this.recordsList.Size = new System.Drawing.Size(773, 185);
            this.recordsList.TabIndex = 21;
            // 
            // department
            // 
            this.department.FormattingEnabled = true;
            this.department.Items.AddRange(new object[] {
            "department 1",
            "department 2",
            "department 3"});
            this.department.Location = new System.Drawing.Point(124, 103);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(100, 21);
            this.department.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(339, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(545, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.department);
            this.Controls.Add(this.recordsList);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.image_profile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.face);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.middlename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.createRecord);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.recordsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createRecord;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox middlename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox face;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox image_profile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.DataGridView recordsList;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

