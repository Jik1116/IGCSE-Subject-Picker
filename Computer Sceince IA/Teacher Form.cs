using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Sceince_IA
{
    public partial class Teacher_Form : Form
    {
        Database database = new Database();
        Spreadsheet spreadsheet = new Spreadsheet();
        Mail mail = new Mail();
        Teacher teacher;
        string SubjectName;
        Admin_Form AdminForm;

        /// <summary>
        /// Constructor
        /// </summary>
        public Teacher_Form(string username)
        {
            InitializeComponent();
            this.teacher = database.CreateTeacher(username);
            SubjectName = teacher.GetSubjectName();
            Label_TeacherName.Text = "Teacher: " + teacher.GetName();
            Label_SubjectName.Text = "Subject: " + SubjectName;
            SetDataViewGrades();
            SetDataGridViewFlag();
        }

        /// <summary>
        /// Overload contrustor
        /// </summary>
        public Teacher_Form(string username, Admin_Form AdminForm)
        {
            InitializeComponent();
            this.teacher = database.CreateTeacher(username);
            SubjectName = teacher.GetSubjectName();
            Button_Back.Show();
            Label_TeacherName.Text = "Teacher: " + teacher.GetName();
            Label_SubjectName.Text = "Subject: " + SubjectName;
            SetDataViewGrades();
            this.AdminForm = AdminForm;
            SetDataGridViewFlag();

        }

        //==============Start of View Student Section==============//

        /// <summary>
        /// Adds colums for the grades
        /// </summary>
        public void SetDataViewGrades()
        {
            DataGridView_TeacherView.Columns.Add("0", "Student Name");
            DataGridView_TeacherView.Columns[0].Frozen = true;
            DataGridView_TeacherView.Columns.Add("1", "Term 1.1 (Grade)");
            DataGridView_TeacherView.Columns.Add("2", "Term 1.1 (Effort)");
            DataGridView_TeacherView.Columns.Add("3", "Term 1.2 (Grade)");
            DataGridView_TeacherView.Columns.Add("4", "Term 1.2 (Effort)");
            DataGridView_TeacherView.Columns.Add("5", "Term 2.1 (Grade)");
            DataGridView_TeacherView.Columns.Add("6", "Term 2.1 (Effort)");
            DataGridView_TeacherView.Columns.Add("5", "Term 2.2 (Grade)");
            DataGridView_TeacherView.Columns.Add("8", "Term 2.2 (Effort)");
            DataGridView_TeacherView.Columns.Add("9", "Term 3 (Grade)");
            DataGridView_TeacherView.Columns.Add("10", "Term 3 (Effort)");

            UpdateRows();
        }

        /// <summary>
        /// Adds all the rows for the grades
        /// </summary>
        public void UpdateRows()
        {
            int student = 0;
            string[] Row = new string[11];

            while (teacher.GetStudent(student) != null)
            {
                //Console.WriteLine("in a loop");

                string name = teacher.GetStudent(student).GetName();

                Row[0] = name;
                Row[1] = spreadsheet.GetTermStudentGrades("1.1", SubjectName, name);
                Row[2] = spreadsheet.GetTermStudentEffort("1.1", SubjectName, name);
                Row[3] = spreadsheet.GetTermStudentGrades("1.2", SubjectName, name);
                Row[4] = spreadsheet.GetTermStudentEffort("1.2", SubjectName, name);
                Row[5] = spreadsheet.GetTermStudentGrades("2.1", SubjectName, name);
                Row[6] = spreadsheet.GetTermStudentEffort("2.1", SubjectName, name);
                Row[7] = spreadsheet.GetTermStudentGrades("2.2", SubjectName, name);
                Row[8] = spreadsheet.GetTermStudentEffort("2.2", SubjectName, name);
                Row[9] = spreadsheet.GetTermStudentGrades("3", SubjectName, name);
                Row[10] = spreadsheet.GetTermStudentEffort("3", SubjectName, name);

                DataGridView_TeacherView.Rows.Add(Row);

                student++;
            }
            SetFlag();
        }

        /// <summary>
        /// Loops through the the grid to check which students are flagged and change the colour of the cell
        /// pre: Student exists
        /// post: Colour change
        /// </summary>
        private void SetFlag()
        {
            foreach (DataGridViewRow row in DataGridView_TeacherView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    for (int x = 1; x < row.Cells.Count; x++)
                    {
                        Student TempStudent = teacher.GetStudent(row.Cells[0].Value.ToString());

                        Subject subject = TempStudent.GetSubject(teacher.GetSubjectName());

                        if (subject != null)
                        {
                            bool flag = subject.GetFlag();

                            if (flag == true)
                            {
                                row.Cells[0].Style.BackColor = Color.Red;
                            }
                        }

                    }
                }
            }
        }

        //Event driven//

        /// <summary>
        /// Gets the email address of selected cell
        /// pre: Cell Selected
        /// post: Textbox updated
        /// </summary>
        private void DataGridView_Flag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView_Flag.SelectedCells.Count == 1)
            {
                LABEL_EMAIL.Text = "Email: " + DataGridView_Flag.CurrentCell.Value.ToString();
            }
        }

        /// <summary>
        /// For admin only (back and forth between admin page)
        /// post: Admin shown
        /// </summary>
        private void Button_Back_Click(object sender, EventArgs e)
        {
            AdminForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Re-fetches all the data from the database
        /// post: All student data is upto date
        /// </summary>
        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            DataGridView_TeacherView.Rows.Clear();
            UpdateRows();
        }

        /// <summary>
        /// Filter through the array to meet set criterion 
        /// pre: Valid inputed text and field 
        /// post: Datagridview is updated with what is required
        /// </summary>
        private void Button_Search_Click_1(object sender, EventArgs e)
        {
            List<DataGridViewRow> DeleteRows = new List<DataGridViewRow>();
            string Field = ComboBox_SetField.GetItemText(ComboBox_SetField.SelectedItem).ToString();

            //Validation
            if (TextBox_Search.Text != "" || Field == "")
            {
                //Loops through every row
                foreach (DataGridViewRow row in DataGridView_TeacherView.Rows)
                {
                    //Validation
                    if (row.Cells[0].Value != null)
                    {
                        //Update to switch statement
                        //Compare all the names to the input
                        if (Field == "Name" && row.Cells[0].Value.ToString().Contains(TextBox_Search.Text) == false)
                        {
                            DeleteRows.Add(row);
                        }
                        else if (Field == "Interest")
                        {
                            bool found = false;

                            //Loops through interets and compres what does and does not fit
                            for (int interest = 1; interest < row.Cells.Count; interest++)
                            {
                                //Comparing
                                if (row.Cells[interest].Value.ToString().Contains(TextBox_Search.Text) == true)
                                {
                                    found = true;
                                }
                            }

                            //Adds to delete
                            if (found == false)
                            {
                                DeleteRows.Add(row);
                            }
                        }
                        else if (Field == "Flag")
                        {
                            bool found = false;

                            //Loops through all the rows
                            for (int flag = 1; flag < row.Cells.Count; flag++)
                            {
                                //Chekcs colour for flagged
                                if (row.Cells[flag].Style.BackColor != Color.Red)
                                {
                                    found = true;
                                }
                            }

                            //Adds to delete
                            if (found == false)
                            {
                                DeleteRows.Add(row);
                            }
                        }
                    }
                }

                //Deletes all the rows that do not the criteion
                while (DeleteRows.Count != 0)
                {
                    //Compares data gird to deleted
                    if (DataGridView_TeacherView.Rows.Contains(DeleteRows.ElementAt(0)))
                    {
                        DataGridView_TeacherView.Rows.Remove(DeleteRows.ElementAt(0));
                    }

                    //Delete first element to move to the next
                    DeleteRows.RemoveAt(0);
                }
            }
            else
            {
                MessageBox.Show("Please fill in search requirments");
            }
        }

        //==============Start of View Flag Section==============//

        /// <summary>
        /// Summary of the students who have been flagged
        /// pre: student array is not null
        /// post: Flag girdview updated
        /// </summary>
        public void SetDataGridViewFlag()
        {
            DataGridView_Flag.Columns.Add("0", "Student Name");
            string[] Row = new string[1];
            int student = 0;

            while (teacher.GetStudent(student) != null)
            {
                if (teacher.GetStudent(student).GetSubject(SubjectName).GetFlag() == true)
                {
                    Row[0] = teacher.GetStudent(student).GetName();
                    DataGridView_Flag.Rows.Add(Row);
                }

                student++;
            }
        }

        //Event Driven//

        /// <summary>
        /// Sends email to selected studnet
        /// pre: Valid student selected
        /// post: Email sent to student
        /// </summary>
        private void BUTTON_EMAIL_Click(object sender, EventArgs e)
        {
            if (DataGridView_Flag.SelectedCells.Count == 1)
            {
                string TempStudentName = DataGridView_Flag.CurrentCell.Value.ToString();

                string email = teacher.GetStudent(TempStudentName).GetEmail();

                mail.SendEmail(email, teacher.GetName(), TextBox_EmailBody.Text);

            }
            else
            {
                MessageBox.Show("Please select a student");
            }
        }
    }
}