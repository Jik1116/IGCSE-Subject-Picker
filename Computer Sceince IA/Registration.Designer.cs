namespace Computer_Sceince_IA
{
    partial class Registration
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
            this.label2 = new System.Windows.Forms.Label();
            this.RB_Student = new System.Windows.Forms.RadioButton();
            this.RB_Teacher = new System.Windows.Forms.RadioButton();
            this.ComboBox_Subject = new System.Windows.Forms.ComboBox();
            this.Label_Subject = new System.Windows.Forms.Label();
            this.Lable_At = new System.Windows.Forms.Label();
            this.Button_Back = new System.Windows.Forms.Button();
            this.TextBox_Email = new System.Windows.Forms.TextBox();
            this.Button_Register = new System.Windows.Forms.Button();
            this.TextBox_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Lable_Password = new System.Windows.Forms.Label();
            this.Lable_Email = new System.Windows.Forms.Label();
            this.Lable_Name = new System.Windows.Forms.Label();
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.TextBox_TeacherName = new System.Windows.Forms.TextBox();
            this.ComboBox_StudentName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Role:";
            // 
            // RB_Student
            // 
            this.RB_Student.AutoSize = true;
            this.RB_Student.Location = new System.Drawing.Point(230, 201);
            this.RB_Student.Name = "RB_Student";
            this.RB_Student.Size = new System.Drawing.Size(62, 17);
            this.RB_Student.TabIndex = 54;
            this.RB_Student.TabStop = true;
            this.RB_Student.Text = "Student";
            this.RB_Student.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RB_Student.UseVisualStyleBackColor = true;
            this.RB_Student.CheckedChanged += new System.EventHandler(this.RB_Student_CheckedChanged);
            // 
            // RB_Teacher
            // 
            this.RB_Teacher.AutoSize = true;
            this.RB_Teacher.Location = new System.Drawing.Point(145, 201);
            this.RB_Teacher.Name = "RB_Teacher";
            this.RB_Teacher.Size = new System.Drawing.Size(65, 17);
            this.RB_Teacher.TabIndex = 53;
            this.RB_Teacher.TabStop = true;
            this.RB_Teacher.Text = "Teacher";
            this.RB_Teacher.UseVisualStyleBackColor = true;
            this.RB_Teacher.CheckedChanged += new System.EventHandler(this.RB_Teacher_CheckedChanged);
            // 
            // ComboBox_Subject
            // 
            this.ComboBox_Subject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Subject.FormattingEnabled = true;
            this.ComboBox_Subject.Location = new System.Drawing.Point(147, 250);
            this.ComboBox_Subject.Name = "ComboBox_Subject";
            this.ComboBox_Subject.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_Subject.TabIndex = 52;
            // 
            // Label_Subject
            // 
            this.Label_Subject.AutoSize = true;
            this.Label_Subject.Location = new System.Drawing.Point(59, 258);
            this.Label_Subject.Name = "Label_Subject";
            this.Label_Subject.Size = new System.Drawing.Size(46, 13);
            this.Label_Subject.TabIndex = 51;
            this.Label_Subject.Text = "Subject:";
            // 
            // Lable_At
            // 
            this.Lable_At.AutoSize = true;
            this.Lable_At.Location = new System.Drawing.Point(197, 61);
            this.Lable_At.Name = "Lable_At";
            this.Lable_At.Size = new System.Drawing.Size(0, 13);
            this.Lable_At.TabIndex = 50;
            // 
            // Button_Back
            // 
            this.Button_Back.Location = new System.Drawing.Point(254, 348);
            this.Button_Back.Name = "Button_Back";
            this.Button_Back.Size = new System.Drawing.Size(58, 22);
            this.Button_Back.TabIndex = 49;
            this.Button_Back.Text = "Back";
            this.Button_Back.UseVisualStyleBackColor = true;
            this.Button_Back.Click += new System.EventHandler(this.Button_Back_Click);
            // 
            // TextBox_Email
            // 
            this.TextBox_Email.Location = new System.Drawing.Point(147, 57);
            this.TextBox_Email.Name = "TextBox_Email";
            this.TextBox_Email.Size = new System.Drawing.Size(121, 20);
            this.TextBox_Email.TabIndex = 48;
            // 
            // Button_Register
            // 
            this.Button_Register.Location = new System.Drawing.Point(30, 297);
            this.Button_Register.Name = "Button_Register";
            this.Button_Register.Size = new System.Drawing.Size(262, 29);
            this.Button_Register.TabIndex = 47;
            this.Button_Register.Text = "Regsiter";
            this.Button_Register.UseVisualStyleBackColor = true;
            this.Button_Register.Click += new System.EventHandler(this.Button_Register_Click_1);
            // 
            // TextBox_ConfirmPassword
            // 
            this.TextBox_ConfirmPassword.Location = new System.Drawing.Point(147, 148);
            this.TextBox_ConfirmPassword.Name = "TextBox_ConfirmPassword";
            this.TextBox_ConfirmPassword.Size = new System.Drawing.Size(121, 20);
            this.TextBox_ConfirmPassword.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Confirm Password:";
            // 
            // Lable_Password
            // 
            this.Lable_Password.AutoSize = true;
            this.Lable_Password.Location = new System.Drawing.Point(49, 104);
            this.Lable_Password.Name = "Lable_Password";
            this.Lable_Password.Size = new System.Drawing.Size(56, 13);
            this.Lable_Password.TabIndex = 43;
            this.Lable_Password.Text = "Password:";
            // 
            // Lable_Email
            // 
            this.Lable_Email.AutoSize = true;
            this.Lable_Email.Location = new System.Drawing.Point(70, 60);
            this.Lable_Email.Name = "Lable_Email";
            this.Lable_Email.Size = new System.Drawing.Size(35, 13);
            this.Lable_Email.TabIndex = 42;
            this.Lable_Email.Text = "Email:";
            // 
            // Lable_Name
            // 
            this.Lable_Name.AutoSize = true;
            this.Lable_Name.Location = new System.Drawing.Point(67, 19);
            this.Lable_Name.Name = "Lable_Name";
            this.Lable_Name.Size = new System.Drawing.Size(38, 13);
            this.Lable_Name.TabIndex = 41;
            this.Lable_Name.Text = "Name:";
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.Location = new System.Drawing.Point(147, 104);
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.Size = new System.Drawing.Size(121, 20);
            this.TextBox_Password.TabIndex = 40;
            // 
            // TextBox_TeacherName
            // 
            this.TextBox_TeacherName.Location = new System.Drawing.Point(147, 15);
            this.TextBox_TeacherName.Name = "TextBox_TeacherName";
            this.TextBox_TeacherName.Size = new System.Drawing.Size(121, 20);
            this.TextBox_TeacherName.TabIndex = 39;
            // 
            // ComboBox_StudentName
            // 
            this.ComboBox_StudentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_StudentName.FormattingEnabled = true;
            this.ComboBox_StudentName.Location = new System.Drawing.Point(147, 15);
            this.ComboBox_StudentName.Name = "ComboBox_StudentName";
            this.ComboBox_StudentName.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_StudentName.TabIndex = 38;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 384);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RB_Student);
            this.Controls.Add(this.RB_Teacher);
            this.Controls.Add(this.ComboBox_Subject);
            this.Controls.Add(this.Label_Subject);
            this.Controls.Add(this.Lable_At);
            this.Controls.Add(this.Button_Back);
            this.Controls.Add(this.TextBox_Email);
            this.Controls.Add(this.Button_Register);
            this.Controls.Add(this.TextBox_ConfirmPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lable_Password);
            this.Controls.Add(this.Lable_Email);
            this.Controls.Add(this.Lable_Name);
            this.Controls.Add(this.TextBox_Password);
            this.Controls.Add(this.TextBox_TeacherName);
            this.Controls.Add(this.ComboBox_StudentName);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RB_Student;
        private System.Windows.Forms.RadioButton RB_Teacher;
        private System.Windows.Forms.ComboBox ComboBox_Subject;
        private System.Windows.Forms.Label Label_Subject;
        private System.Windows.Forms.Label Lable_At;
        private System.Windows.Forms.Button Button_Back;
        private System.Windows.Forms.TextBox TextBox_Email;
        private System.Windows.Forms.Button Button_Register;
        private System.Windows.Forms.TextBox TextBox_ConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Lable_Password;
        private System.Windows.Forms.Label Lable_Email;
        private System.Windows.Forms.Label Lable_Name;
        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.TextBox TextBox_TeacherName;
        private System.Windows.Forms.ComboBox ComboBox_StudentName;
    }
}