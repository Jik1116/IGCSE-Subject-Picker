namespace Computer_Sceince_IA
{
    partial class EditSubjectList
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
            this.ListBox_SubjectList = new System.Windows.Forms.CheckedListBox();
            this.Button_Confrim = new System.Windows.Forms.Button();
            this.Button_Close = new System.Windows.Forms.Button();
            this.Button_AddSubject = new System.Windows.Forms.Button();
            this.TextBox_AddSubject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ListBox_SubjectList
            // 
            this.ListBox_SubjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox_SubjectList.FormattingEnabled = true;
            this.ListBox_SubjectList.Location = new System.Drawing.Point(12, 14);
            this.ListBox_SubjectList.Name = "ListBox_SubjectList";
            this.ListBox_SubjectList.Size = new System.Drawing.Size(374, 404);
            this.ListBox_SubjectList.TabIndex = 0;
            // 
            // Button_Confrim
            // 
            this.Button_Confrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button_Confrim.Location = new System.Drawing.Point(12, 434);
            this.Button_Confrim.Name = "Button_Confrim";
            this.Button_Confrim.Size = new System.Drawing.Size(184, 44);
            this.Button_Confrim.TabIndex = 1;
            this.Button_Confrim.Text = "Confirm";
            this.Button_Confrim.UseVisualStyleBackColor = true;
            this.Button_Confrim.Click += new System.EventHandler(this.Button_Confrim_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button_Close.Location = new System.Drawing.Point(202, 434);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(184, 44);
            this.Button_Close.TabIndex = 2;
            this.Button_Close.Text = "Close";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_AddSubject
            // 
            this.Button_AddSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button_AddSubject.Location = new System.Drawing.Point(38, 492);
            this.Button_AddSubject.Name = "Button_AddSubject";
            this.Button_AddSubject.Size = new System.Drawing.Size(158, 44);
            this.Button_AddSubject.TabIndex = 3;
            this.Button_AddSubject.Text = "Add Subject";
            this.Button_AddSubject.UseVisualStyleBackColor = true;
            this.Button_AddSubject.Click += new System.EventHandler(this.Button_AddSubject_Click);
            // 
            // TextBox_AddSubject
            // 
            this.TextBox_AddSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.TextBox_AddSubject.Location = new System.Drawing.Point(202, 495);
            this.TextBox_AddSubject.Name = "TextBox_AddSubject";
            this.TextBox_AddSubject.Size = new System.Drawing.Size(157, 38);
            this.TextBox_AddSubject.TabIndex = 4;
            // 
            // EditSubjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 545);
            this.Controls.Add(this.TextBox_AddSubject);
            this.Controls.Add(this.Button_AddSubject);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Button_Confrim);
            this.Controls.Add(this.ListBox_SubjectList);
            this.Name = "EditSubjectList";
            this.Text = "Edit Subject List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ListBox_SubjectList;
        private System.Windows.Forms.Button Button_Confrim;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.Button Button_AddSubject;
        private System.Windows.Forms.TextBox TextBox_AddSubject;
    }
}