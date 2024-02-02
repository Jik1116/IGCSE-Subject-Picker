namespace Computer_Sceince_IA
{
    partial class Login_Form
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
            this.Button_Register = new System.Windows.Forms.Button();
            this.Button_Close = new System.Windows.Forms.Button();
            this.TEXTBOX_USERNAME = new System.Windows.Forms.TextBox();
            this.TEXTBOX_PASSWORD = new System.Windows.Forms.TextBox();
            this.LABEL_USERNAME = new System.Windows.Forms.Label();
            this.LABEL_PASSWORD = new System.Windows.Forms.Label();
            this.BUTTON_LOGIN = new System.Windows.Forms.Button();
            this.Lable_UsertType = new System.Windows.Forms.Label();
            this.comboBox_UserType = new System.Windows.Forms.ComboBox();
            this.pictureBox_AscotLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AscotLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Register
            // 
            this.Button_Register.Location = new System.Drawing.Point(454, 170);
            this.Button_Register.Name = "Button_Register";
            this.Button_Register.Size = new System.Drawing.Size(75, 23);
            this.Button_Register.TabIndex = 0;
            this.Button_Register.Text = "Register";
            this.Button_Register.UseVisualStyleBackColor = true;
            this.Button_Register.Click += new System.EventHandler(this.Button_Register_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.Location = new System.Drawing.Point(358, 208);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(171, 23);
            this.Button_Close.TabIndex = 4;
            this.Button_Close.Text = "Close";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // TEXTBOX_USERNAME
            // 
            this.TEXTBOX_USERNAME.Location = new System.Drawing.Point(358, 44);
            this.TEXTBOX_USERNAME.Name = "TEXTBOX_USERNAME";
            this.TEXTBOX_USERNAME.Size = new System.Drawing.Size(171, 20);
            this.TEXTBOX_USERNAME.TabIndex = 5;
            // 
            // TEXTBOX_PASSWORD
            // 
            this.TEXTBOX_PASSWORD.Location = new System.Drawing.Point(358, 84);
            this.TEXTBOX_PASSWORD.Name = "TEXTBOX_PASSWORD";
            this.TEXTBOX_PASSWORD.PasswordChar = '●';
            this.TEXTBOX_PASSWORD.Size = new System.Drawing.Size(171, 20);
            this.TEXTBOX_PASSWORD.TabIndex = 6;
            // 
            // LABEL_USERNAME
            // 
            this.LABEL_USERNAME.AutoSize = true;
            this.LABEL_USERNAME.Location = new System.Drawing.Point(292, 44);
            this.LABEL_USERNAME.Name = "LABEL_USERNAME";
            this.LABEL_USERNAME.Size = new System.Drawing.Size(55, 13);
            this.LABEL_USERNAME.TabIndex = 7;
            this.LABEL_USERNAME.Text = "Username";
            // 
            // LABEL_PASSWORD
            // 
            this.LABEL_PASSWORD.AutoSize = true;
            this.LABEL_PASSWORD.Location = new System.Drawing.Point(292, 91);
            this.LABEL_PASSWORD.Name = "LABEL_PASSWORD";
            this.LABEL_PASSWORD.Size = new System.Drawing.Size(53, 13);
            this.LABEL_PASSWORD.TabIndex = 8;
            this.LABEL_PASSWORD.Text = "Password";
            // 
            // BUTTON_LOGIN
            // 
            this.BUTTON_LOGIN.Location = new System.Drawing.Point(358, 170);
            this.BUTTON_LOGIN.Name = "BUTTON_LOGIN";
            this.BUTTON_LOGIN.Size = new System.Drawing.Size(75, 23);
            this.BUTTON_LOGIN.TabIndex = 9;
            this.BUTTON_LOGIN.Text = "Login";
            this.BUTTON_LOGIN.UseVisualStyleBackColor = true;
            this.BUTTON_LOGIN.Click += new System.EventHandler(this.BUTTON_LOGIN_Click);
            // 
            // Lable_UsertType
            // 
            this.Lable_UsertType.AutoSize = true;
            this.Lable_UsertType.Location = new System.Drawing.Point(289, 136);
            this.Lable_UsertType.Name = "Lable_UsertType";
            this.Lable_UsertType.Size = new System.Drawing.Size(56, 13);
            this.Lable_UsertType.TabIndex = 10;
            this.Lable_UsertType.Text = "User Type";
            // 
            // comboBox_UserType
            // 
            this.comboBox_UserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UserType.FormattingEnabled = true;
            this.comboBox_UserType.Items.AddRange(new object[] {
            "Student",
            "Teacher"});
            this.comboBox_UserType.Location = new System.Drawing.Point(358, 127);
            this.comboBox_UserType.Name = "comboBox_UserType";
            this.comboBox_UserType.Size = new System.Drawing.Size(171, 21);
            this.comboBox_UserType.TabIndex = 11;
            // 
            // pictureBox_AscotLogo
            // 
            this.pictureBox_AscotLogo.Image = global::Computer_Sceince_IA.Properties.Resources.Ascot_Logo;
            this.pictureBox_AscotLogo.Location = new System.Drawing.Point(12, -3);
            this.pictureBox_AscotLogo.Name = "pictureBox_AscotLogo";
            this.pictureBox_AscotLogo.Size = new System.Drawing.Size(260, 267);
            this.pictureBox_AscotLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_AscotLogo.TabIndex = 12;
            this.pictureBox_AscotLogo.TabStop = false;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 274);
            this.Controls.Add(this.pictureBox_AscotLogo);
            this.Controls.Add(this.comboBox_UserType);
            this.Controls.Add(this.Lable_UsertType);
            this.Controls.Add(this.BUTTON_LOGIN);
            this.Controls.Add(this.LABEL_PASSWORD);
            this.Controls.Add(this.LABEL_USERNAME);
            this.Controls.Add(this.TEXTBOX_PASSWORD);
            this.Controls.Add(this.TEXTBOX_USERNAME);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Button_Register);
            this.Name = "Login_Form";
            this.Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AscotLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Register;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.TextBox TEXTBOX_USERNAME;
        private System.Windows.Forms.TextBox TEXTBOX_PASSWORD;
        private System.Windows.Forms.Label LABEL_USERNAME;
        private System.Windows.Forms.Label LABEL_PASSWORD;
        private System.Windows.Forms.Button BUTTON_LOGIN;
        private System.Windows.Forms.Label Lable_UsertType;
        private System.Windows.Forms.ComboBox comboBox_UserType;
        private System.Windows.Forms.PictureBox pictureBox_AscotLogo;
    }
}

