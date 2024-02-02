namespace Computer_Sceince_IA
{
    partial class Teacher_Form
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
            this.TABCONTROL_TEACHER = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.Button_SetField = new System.Windows.Forms.Button();
            this.ComboBox_SetField = new System.Windows.Forms.ComboBox();
            this.TextBox_Search = new System.Windows.Forms.TextBox();
            this.Button_Search = new System.Windows.Forms.Button();
            this.Label_Filters = new System.Windows.Forms.Label();
            this.Button_Back = new System.Windows.Forms.Button();
            this.Label_SubjectName = new System.Windows.Forms.Label();
            this.Label_TeacherName = new System.Windows.Forms.Label();
            this.DataGridView_TeacherView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LABEL_EMAIL = new System.Windows.Forms.Label();
            this.BUTTON_EMAIL = new System.Windows.Forms.Button();
            this.TextBox_EmailBody = new System.Windows.Forms.TextBox();
            this.DataGridView_Flag = new System.Windows.Forms.DataGridView();
            this.TABCONTROL_TEACHER.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_TeacherView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Flag)).BeginInit();
            this.SuspendLayout();
            // 
            // TABCONTROL_TEACHER
            // 
            this.TABCONTROL_TEACHER.Controls.Add(this.tabPage1);
            this.TABCONTROL_TEACHER.Controls.Add(this.tabPage2);
            this.TABCONTROL_TEACHER.Location = new System.Drawing.Point(12, 12);
            this.TABCONTROL_TEACHER.Name = "TABCONTROL_TEACHER";
            this.TABCONTROL_TEACHER.SelectedIndex = 0;
            this.TABCONTROL_TEACHER.Size = new System.Drawing.Size(776, 426);
            this.TABCONTROL_TEACHER.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Button_Refresh);
            this.tabPage1.Controls.Add(this.Button_SetField);
            this.tabPage1.Controls.Add(this.ComboBox_SetField);
            this.tabPage1.Controls.Add(this.TextBox_Search);
            this.tabPage1.Controls.Add(this.Button_Search);
            this.tabPage1.Controls.Add(this.Label_Filters);
            this.tabPage1.Controls.Add(this.Button_Back);
            this.tabPage1.Controls.Add(this.Label_SubjectName);
            this.tabPage1.Controls.Add(this.Label_TeacherName);
            this.tabPage1.Controls.Add(this.DataGridView_TeacherView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View Students";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button_Refresh.Location = new System.Drawing.Point(521, 260);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(150, 56);
            this.Button_Refresh.TabIndex = 37;
            this.Button_Refresh.Text = "Refersh Table";
            this.Button_Refresh.UseVisualStyleBackColor = true;
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // Button_SetField
            // 
            this.Button_SetField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button_SetField.Location = new System.Drawing.Point(457, 226);
            this.Button_SetField.Name = "Button_SetField";
            this.Button_SetField.Size = new System.Drawing.Size(126, 28);
            this.Button_SetField.TabIndex = 36;
            this.Button_SetField.Text = "Set Field";
            this.Button_SetField.UseVisualStyleBackColor = true;
            // 
            // ComboBox_SetField
            // 
            this.ComboBox_SetField.AutoCompleteCustomSource.AddRange(new string[] {
            "Interest",
            "Name",
            "Flag"});
            this.ComboBox_SetField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_SetField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ComboBox_SetField.FormattingEnabled = true;
            this.ComboBox_SetField.Items.AddRange(new object[] {
            "Name",
            "Interest",
            "Flag"});
            this.ComboBox_SetField.Location = new System.Drawing.Point(589, 226);
            this.ComboBox_SetField.Name = "ComboBox_SetField";
            this.ComboBox_SetField.Size = new System.Drawing.Size(129, 28);
            this.ComboBox_SetField.TabIndex = 35;
            // 
            // TextBox_Search
            // 
            this.TextBox_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TextBox_Search.Location = new System.Drawing.Point(587, 194);
            this.TextBox_Search.Name = "TextBox_Search";
            this.TextBox_Search.Size = new System.Drawing.Size(130, 26);
            this.TextBox_Search.TabIndex = 34;
            // 
            // Button_Search
            // 
            this.Button_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button_Search.Location = new System.Drawing.Point(457, 194);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(125, 26);
            this.Button_Search.TabIndex = 33;
            this.Button_Search.Text = "Search";
            this.Button_Search.UseVisualStyleBackColor = true;
            this.Button_Search.Click += new System.EventHandler(this.Button_Search_Click_1);
            // 
            // Label_Filters
            // 
            this.Label_Filters.AutoSize = true;
            this.Label_Filters.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.Label_Filters.Location = new System.Drawing.Point(349, 152);
            this.Label_Filters.Name = "Label_Filters";
            this.Label_Filters.Size = new System.Drawing.Size(86, 29);
            this.Label_Filters.TabIndex = 7;
            this.Label_Filters.Text = "Filters:";
            // 
            // Button_Back
            // 
            this.Button_Back.Location = new System.Drawing.Point(683, 370);
            this.Button_Back.Name = "Button_Back";
            this.Button_Back.Size = new System.Drawing.Size(79, 24);
            this.Button_Back.TabIndex = 4;
            this.Button_Back.Text = "Back";
            this.Button_Back.UseVisualStyleBackColor = true;
            this.Button_Back.Click += new System.EventHandler(this.Button_Back_Click);
            // 
            // Label_SubjectName
            // 
            this.Label_SubjectName.AutoSize = true;
            this.Label_SubjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.Label_SubjectName.Location = new System.Drawing.Point(349, 87);
            this.Label_SubjectName.Name = "Label_SubjectName";
            this.Label_SubjectName.Size = new System.Drawing.Size(100, 29);
            this.Label_SubjectName.TabIndex = 3;
            this.Label_SubjectName.Text = "Subject:";
            // 
            // Label_TeacherName
            // 
            this.Label_TeacherName.AutoSize = true;
            this.Label_TeacherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.Label_TeacherName.Location = new System.Drawing.Point(349, 19);
            this.Label_TeacherName.Name = "Label_TeacherName";
            this.Label_TeacherName.Size = new System.Drawing.Size(109, 29);
            this.Label_TeacherName.TabIndex = 2;
            this.Label_TeacherName.Text = "Teacher:";
            // 
            // DataGridView_TeacherView
            // 
            this.DataGridView_TeacherView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView_TeacherView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridView_TeacherView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_TeacherView.Location = new System.Drawing.Point(5, 7);
            this.DataGridView_TeacherView.Name = "DataGridView_TeacherView";
            this.DataGridView_TeacherView.Size = new System.Drawing.Size(331, 388);
            this.DataGridView_TeacherView.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LABEL_EMAIL);
            this.tabPage2.Controls.Add(this.BUTTON_EMAIL);
            this.tabPage2.Controls.Add(this.TextBox_EmailBody);
            this.tabPage2.Controls.Add(this.DataGridView_Flag);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View Flags";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LABEL_EMAIL
            // 
            this.LABEL_EMAIL.AutoSize = true;
            this.LABEL_EMAIL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.LABEL_EMAIL.Location = new System.Drawing.Point(374, 75);
            this.LABEL_EMAIL.Name = "LABEL_EMAIL";
            this.LABEL_EMAIL.Size = new System.Drawing.Size(55, 18);
            this.LABEL_EMAIL.TabIndex = 3;
            this.LABEL_EMAIL.Text = "Email:";
            // 
            // BUTTON_EMAIL
            // 
            this.BUTTON_EMAIL.Location = new System.Drawing.Point(477, 316);
            this.BUTTON_EMAIL.Name = "BUTTON_EMAIL";
            this.BUTTON_EMAIL.Size = new System.Drawing.Size(144, 45);
            this.BUTTON_EMAIL.TabIndex = 2;
            this.BUTTON_EMAIL.Text = "Send";
            this.BUTTON_EMAIL.UseVisualStyleBackColor = true;
            this.BUTTON_EMAIL.Click += new System.EventHandler(this.BUTTON_EMAIL_Click);
            // 
            // TextBox_EmailBody
            // 
            this.TextBox_EmailBody.Location = new System.Drawing.Point(377, 96);
            this.TextBox_EmailBody.Multiline = true;
            this.TextBox_EmailBody.Name = "TextBox_EmailBody";
            this.TextBox_EmailBody.Size = new System.Drawing.Size(348, 214);
            this.TextBox_EmailBody.TabIndex = 1;
            // 
            // DataGridView_Flag
            // 
            this.DataGridView_Flag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridView_Flag.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridView_Flag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Flag.Location = new System.Drawing.Point(6, 6);
            this.DataGridView_Flag.Name = "DataGridView_Flag";
            this.DataGridView_Flag.Size = new System.Drawing.Size(329, 388);
            this.DataGridView_Flag.TabIndex = 0;
            this.DataGridView_Flag.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Flag_CellContentClick);
            // 
            // Teacher_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TABCONTROL_TEACHER);
            this.Name = "Teacher_Form";
            this.Text = "Teacher_Form";
            this.TABCONTROL_TEACHER.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_TeacherView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Flag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TABCONTROL_TEACHER;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label Label_SubjectName;
        private System.Windows.Forms.Label Label_TeacherName;
        private System.Windows.Forms.DataGridView DataGridView_TeacherView;
        private System.Windows.Forms.Label LABEL_EMAIL;
        private System.Windows.Forms.Button BUTTON_EMAIL;
        private System.Windows.Forms.TextBox TextBox_EmailBody;
        private System.Windows.Forms.DataGridView DataGridView_Flag;
        private System.Windows.Forms.Button Button_Back;
        private System.Windows.Forms.Label Label_Filters;
        private System.Windows.Forms.Button Button_Refresh;
        private System.Windows.Forms.Button Button_SetField;
        private System.Windows.Forms.ComboBox ComboBox_SetField;
        private System.Windows.Forms.TextBox TextBox_Search;
        private System.Windows.Forms.Button Button_Search;
    }
}