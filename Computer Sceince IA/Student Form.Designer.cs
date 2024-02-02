namespace Computer_Sceince_IA
{
    partial class Student_Form
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TAB_OPTIONS = new System.Windows.Forms.TabPage();
            this.Button_Lock = new System.Windows.Forms.Button();
            this.Label_Heading = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBox_Option2 = new System.Windows.Forms.ComboBox();
            this.ComboBox_Option4 = new System.Windows.Forms.ComboBox();
            this.ComboBox_Option3 = new System.Windows.Forms.ComboBox();
            this.ComboBox_Option1 = new System.Windows.Forms.ComboBox();
            this.TAB_GRADES = new System.Windows.Forms.TabPage();
            this.DataGirdView_Suggested = new System.Windows.Forms.DataGridView();
            this.Label_Suggested = new System.Windows.Forms.Label();
            this.DataGirdView_StudentGrades = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.TAB_OPTIONS.SuspendLayout();
            this.TAB_GRADES.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdView_Suggested)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdView_StudentGrades)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TAB_OPTIONS);
            this.tabControl1.Controls.Add(this.TAB_GRADES);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // TAB_OPTIONS
            // 
            this.TAB_OPTIONS.Controls.Add(this.Button_Lock);
            this.TAB_OPTIONS.Controls.Add(this.Label_Heading);
            this.TAB_OPTIONS.Controls.Add(this.label4);
            this.TAB_OPTIONS.Controls.Add(this.label3);
            this.TAB_OPTIONS.Controls.Add(this.label2);
            this.TAB_OPTIONS.Controls.Add(this.label1);
            this.TAB_OPTIONS.Controls.Add(this.ComboBox_Option2);
            this.TAB_OPTIONS.Controls.Add(this.ComboBox_Option4);
            this.TAB_OPTIONS.Controls.Add(this.ComboBox_Option3);
            this.TAB_OPTIONS.Controls.Add(this.ComboBox_Option1);
            this.TAB_OPTIONS.Location = new System.Drawing.Point(4, 22);
            this.TAB_OPTIONS.Name = "TAB_OPTIONS";
            this.TAB_OPTIONS.Padding = new System.Windows.Forms.Padding(3);
            this.TAB_OPTIONS.Size = new System.Drawing.Size(768, 400);
            this.TAB_OPTIONS.TabIndex = 0;
            this.TAB_OPTIONS.Text = "Options";
            this.TAB_OPTIONS.UseVisualStyleBackColor = true;
            // 
            // Button_Lock
            // 
            this.Button_Lock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Button_Lock.Location = new System.Drawing.Point(297, 298);
            this.Button_Lock.Name = "Button_Lock";
            this.Button_Lock.Size = new System.Drawing.Size(174, 53);
            this.Button_Lock.TabIndex = 10;
            this.Button_Lock.Text = "Lock";
            this.Button_Lock.UseVisualStyleBackColor = true;
            this.Button_Lock.Click += new System.EventHandler(this.BUTTON_LOCK_Click);
            // 
            // Label_Heading
            // 
            this.Label_Heading.AutoSize = true;
            this.Label_Heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Label_Heading.Location = new System.Drawing.Point(262, 34);
            this.Label_Heading.Name = "Label_Heading";
            this.Label_Heading.Size = new System.Drawing.Size(261, 46);
            this.Label_Heading.TabIndex = 9;
            this.Label_Heading.Text = "Initial Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(603, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Option 4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(430, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Option 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(257, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Option 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(78, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Option 1";
            // 
            // ComboBox_Option2
            // 
            this.ComboBox_Option2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Option2.FormattingEnabled = true;
            this.ComboBox_Option2.Location = new System.Drawing.Point(222, 151);
            this.ComboBox_Option2.Name = "ComboBox_Option2";
            this.ComboBox_Option2.Size = new System.Drawing.Size(156, 21);
            this.ComboBox_Option2.TabIndex = 4;
            // 
            // ComboBox_Option4
            // 
            this.ComboBox_Option4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Option4.FormattingEnabled = true;
            this.ComboBox_Option4.Location = new System.Drawing.Point(568, 151);
            this.ComboBox_Option4.Name = "ComboBox_Option4";
            this.ComboBox_Option4.Size = new System.Drawing.Size(156, 21);
            this.ComboBox_Option4.TabIndex = 3;
            // 
            // ComboBox_Option3
            // 
            this.ComboBox_Option3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Option3.FormattingEnabled = true;
            this.ComboBox_Option3.Location = new System.Drawing.Point(395, 151);
            this.ComboBox_Option3.Name = "ComboBox_Option3";
            this.ComboBox_Option3.Size = new System.Drawing.Size(156, 21);
            this.ComboBox_Option3.TabIndex = 2;
            // 
            // ComboBox_Option1
            // 
            this.ComboBox_Option1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Option1.FormattingEnabled = true;
            this.ComboBox_Option1.Location = new System.Drawing.Point(45, 151);
            this.ComboBox_Option1.Name = "ComboBox_Option1";
            this.ComboBox_Option1.Size = new System.Drawing.Size(156, 21);
            this.ComboBox_Option1.TabIndex = 0;
            // 
            // TAB_GRADES
            // 
            this.TAB_GRADES.Controls.Add(this.DataGirdView_Suggested);
            this.TAB_GRADES.Controls.Add(this.Label_Suggested);
            this.TAB_GRADES.Controls.Add(this.DataGirdView_StudentGrades);
            this.TAB_GRADES.Location = new System.Drawing.Point(4, 22);
            this.TAB_GRADES.Name = "TAB_GRADES";
            this.TAB_GRADES.Padding = new System.Windows.Forms.Padding(3);
            this.TAB_GRADES.Size = new System.Drawing.Size(768, 400);
            this.TAB_GRADES.TabIndex = 1;
            this.TAB_GRADES.Text = "View Grades";
            this.TAB_GRADES.UseVisualStyleBackColor = true;
            // 
            // DataGirdView_Suggested
            // 
            this.DataGirdView_Suggested.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGirdView_Suggested.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGirdView_Suggested.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGirdView_Suggested.Location = new System.Drawing.Point(446, 65);
            this.DataGirdView_Suggested.Name = "DataGirdView_Suggested";
            this.DataGirdView_Suggested.Size = new System.Drawing.Size(284, 303);
            this.DataGirdView_Suggested.TabIndex = 2;
            // 
            // Label_Suggested
            // 
            this.Label_Suggested.AutoSize = true;
            this.Label_Suggested.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Label_Suggested.Location = new System.Drawing.Point(244, 21);
            this.Label_Suggested.Name = "Label_Suggested";
            this.Label_Suggested.Size = new System.Drawing.Size(312, 31);
            this.Label_Suggested.TabIndex = 1;
            this.Label_Suggested.Text = "Grades and Suggestions";
            // 
            // DataGirdView_StudentGrades
            // 
            this.DataGirdView_StudentGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGirdView_StudentGrades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGirdView_StudentGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGirdView_StudentGrades.Location = new System.Drawing.Point(44, 65);
            this.DataGirdView_StudentGrades.Name = "DataGirdView_StudentGrades";
            this.DataGirdView_StudentGrades.Size = new System.Drawing.Size(284, 303);
            this.DataGirdView_StudentGrades.TabIndex = 0;
            // 
            // Student_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Student_Form";
            this.Text = "Student_Form";
            this.tabControl1.ResumeLayout(false);
            this.TAB_OPTIONS.ResumeLayout(false);
            this.TAB_OPTIONS.PerformLayout();
            this.TAB_GRADES.ResumeLayout(false);
            this.TAB_GRADES.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdView_Suggested)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdView_StudentGrades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TAB_OPTIONS;
        private System.Windows.Forms.TabPage TAB_GRADES;
        private System.Windows.Forms.Button Button_Lock;
        private System.Windows.Forms.Label Label_Heading;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBox_Option2;
        private System.Windows.Forms.ComboBox ComboBox_Option4;
        private System.Windows.Forms.ComboBox ComboBox_Option3;
        private System.Windows.Forms.ComboBox ComboBox_Option1;
        private System.Windows.Forms.DataGridView DataGirdView_StudentGrades;
        private System.Windows.Forms.Label Label_Suggested;
        private System.Windows.Forms.DataGridView DataGirdView_Suggested;
    }
}