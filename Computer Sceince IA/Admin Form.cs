using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Computer_Sceince_IA
{
    public partial class Admin_Form : Form
    {
        //Private variables
        Database database = new Database();
        Spreadsheet spreadsheet = new Spreadsheet();
        Admin admin = new Admin(true);
        string BestCombination;

        /// <summary>
        /// Constructor 
        /// </summary>
        public Admin_Form()
        {
            InitializeComponent();
            AddTeachersNames();
            SetDataViewGrades();
            PPSetUp();
            DataGridViewPicked();
        }

        //==============Start of Control Panel==============//

        /// <summary>
        ///  Binds the list of teacher names to a combobox
        ///  pre: Admin contains list of valid teacher names
        ///  prost: Valid accessiable list of teachers in the database
        /// </summary>
        private void AddTeachersNames()
        {
            ComboBox_SetTeacher.DataSource = admin.GetAllTeachersName();
        }

        /// <summary>
        ///  Adds the headers to the data gird view for all the subjects and grades
        ///  pre:   Data is read in from the spreadsheet
        ///  prost: Valid accessiable list of teachers in the database
        /// </summary>
        private void SetDataViewGrades()
        {
            DataGridView_AllStudentInfo.Columns.Clear();

            //Sets all the students and allow for scroll
            DataGridView_AllStudentInfo.Columns.Add("0", "Student Name");
            DataGridView_AllStudentInfo.Columns[0].Frozen = true;

            string[] tempsubjects = database.GetSpreadSheetSubjectList();

            //Student is 0
            int header = 1;

            //Sets the names for all the column
            for (int subject = 0; subject < tempsubjects.Length; subject++)
            {
                header++;
                DataGridView_AllStudentInfo.Columns.Add(header.ToString(), "Term 1.1 (" + tempsubjects[subject] + ")");
                header++;
                DataGridView_AllStudentInfo.Columns.Add(header.ToString(), "Term 1.2 (" + tempsubjects[subject] + ")");
                header++;
                DataGridView_AllStudentInfo.Columns.Add(header.ToString(), "Term 2.1 (" + tempsubjects[subject] + ")");
                header++;
                DataGridView_AllStudentInfo.Columns.Add(header.ToString(), "Term 2.2 (" + tempsubjects[subject] + ")");
                header++;
                DataGridView_AllStudentInfo.Columns.Add(header.ToString(), "Term 3 (" + tempsubjects[subject] + ")");
            }

            UpdateRowsGrade(header);
        }

        /// <summary>
        ///  Re-fetches all the data if the teacher makes a change
        ///  pre: Set all column
        ///  prost: Fetches data from spreadsheet and loads it into view
        /// </summary>
        private void UpdateRowsGrade(int rowsNo)
        {
            DataGridView_AllStudentInfo.Rows.Clear();

            string[] tempsubjects = database.GetSpreadSheetSubjectList();
            string[] rows = new string[rowsNo];

            for (int student = 0; student < admin.GetStudentArraySize(); student++)
            {
                int row = 0;
                rows[0] = admin.GetStudent(student).GetName();

                //Get specifc subject for each students
                for (int subject = 0; subject < tempsubjects.Length; subject++)
                {
                    row++;
                    rows[row] = spreadsheet.GetTermStudentGrades("1.1", tempsubjects[subject], rows[0]);
                    row++;
                    rows[row] = spreadsheet.GetTermStudentGrades("1.2", tempsubjects[subject], rows[0]);
                    row++;
                    rows[row] = spreadsheet.GetTermStudentGrades("2.1", tempsubjects[subject], rows[0]);
                    row++;
                    rows[row] = spreadsheet.GetTermStudentGrades("2.2", tempsubjects[subject], rows[0]);
                    row++;
                    rows[row] = spreadsheet.GetTermStudentGrades("3", tempsubjects[subject], rows[0]);
                }
                DataGridView_AllStudentInfo.Rows.Add(rows);
            }
        }

        //Event driven//

        /// <summary>
        ///  Allows admin to access what any teacher would see
        ///  pre: Valid list of teachers in a combobox
        ///  prost: Change to teacher form  
        /// </summary>
        private void BUTTON_TEACHERVIEW_Click(object sender, EventArgs e)
        {
            Teacher_Form TeacherForm = new Teacher_Form(admin.GetTeacherEmail(ComboBox_SetTeacher.GetItemText(this.ComboBox_SetTeacher.SelectedItem)), this);
            TeacherForm.Show();
            this.Hide();
        }

        /// <summary>
        ///  Fills and creates the option block based on interest
        ///  pre: All students have to have locked their interests
        ///  prost: Options are outputed  
        /// </summary>
        private void Button_GenerateOptionBlocks_Click(object sender, EventArgs e)
        {
            string[] TempSubjects = database.GetSubjectList();

            string[] Subjects = new string[9];

            for (int x = 0; x < TempSubjects.Length; x++)
            {
                Subjects[x] = TempSubjects[x];
            }

            //Fixed as there needs to be 3 option blocks
            if (TempSubjects.Length > 9)
            {
                Subjects[8] = null;
            }

            //Validation
            if (Subjects != null)
            {
                string[] blocks = admin.MakeOptionBlocks(Subjects);
                Button[] Button = new Button[9];
                Button[0] = Button_Option1;
                Button[1] = Button_Option2;
                Button[2] = Button_Option3;
                Button[3] = Button_Option4;
                Button[4] = Button_Option5;
                Button[5] = Button_Option6;
                Button[6] = Button_Option7;
                Button[7] = Button_Option8;
                Button[8] = Button_Option9;


                int tempint = 0;

                //Turns the option block from a string into array if its fetched from database
                for (int x = 0; x < blocks.Length; x++)
                {
                    char[] CombinationST = blocks[x].ToCharArray();
                    int[] CombinationN = new int[CombinationST.Length];

                    for (int y = 0; y < CombinationST.Length; y++)
                    {
                        CombinationN[y] = Convert.ToInt32(Char.GetNumericValue((CombinationST[y])));
                    }

                    for (int n = 0; n < CombinationN.Length; n++)
                    {
                        Button[tempint].Text = Subjects[CombinationN[n]];
                        BestCombination += Subjects[CombinationN[n]] + ",";
                        tempint++;
                    }
                }
                BestCombination = BestCombination.TrimEnd(',');

            }
            else
            {
                MessageBox.Show("The subject list is empty");
            }

        }

        /// <summary>
        ///  Displays interface to update
        /// </summary>
        private void BUTTON_EDIT_Click(object sender, EventArgs e)
        {
            EditSubjectList SubjectList_Form = new EditSubjectList();
            SubjectList_Form.Show();
        }

        /// <summary>
        ///  Updates grades for students in the database (term can only be showed)
        ///  pre: The spreadsheet must have grades filled in
        ///  prost: The database stores grades
        /// </summary>
        private void BUTTON_LOADGRADES_Click(object sender, EventArgs e)
        {
            string SelectedText = ComboBox_SetTerm.GetItemText(this.ComboBox_SetTerm.SelectedItem);
            if (SelectedText != "")
            {
                spreadsheet.SetTermStudentData(SelectedText);
                admin.RefreshStudents();
                SetDataViewGrades();
                MessageBox.Show("Grades have been updated");
            }
            else
            {
                MessageBox.Show("A term has not been selected");
            }
        }

        /// <summary>
        /// Changes the permissions of a teacher
        /// </summary>
        private void Button_SetAdmin_Click(object sender, EventArgs e)
        {
            admin.SetPermissions(admin.GetTeacherEmail(ComboBox_SetTeacher.GetItemText(this.ComboBox_SetTeacher.SelectedItem)));
            MessageBox.Show("Permissions updated");
        }

        /// <summary>
        /// Fetches status of admin from database
        /// pre: Teacher exists in the database
        /// post: Admin is changed to the reciprocal
        /// </summary>
        private void Button_CheckAdmin_Click(object sender, EventArgs e)
        {
            bool CheckAdmin = admin.GetPermissions(admin.GetTeacherEmail(ComboBox_SetTeacher.GetItemText(this.ComboBox_SetTeacher.SelectedItem)));

            if (CheckAdmin == true)
            {
                MessageBox.Show(string.Format("{0} has admin premissions", ComboBox_SetTeacher.GetItemText(this.ComboBox_SetTeacher.SelectedItem)));
            }
            else
            {
                MessageBox.Show(string.Format("{0} does not have admin premissions", ComboBox_SetTeacher.GetItemText(this.ComboBox_SetTeacher.SelectedItem)));
            }
        }

        /// <summary>
        /// Clears the datagird and gets all the information from the database again
        /// post: Output datagrid
        /// </summary>
        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            DataGridView_Picked.Rows.Clear();
            admin.RefreshStudents();
            UpdateRowsPicked(5);
        }

        /// <summary>
        /// Fetches all the students from the spreadsheet and replaces the ones in the database (new cohort)
        /// post: Database is reset
        /// </summary>
        private void Button_UpdateStudentData_Click(object sender, EventArgs e)
        {
            DialogResult DR_Replied = MessageBox.Show("Are you sure you want to replace all the students in the database? (Updated using names in the spreadsheet)", "Warning", MessageBoxButtons.YesNo);
            {
                if (DR_Replied == DialogResult.Yes)
                {
                    admin.ResetStudents();
                }
            }
        }

        /// <summary>
        ///  Searches through a specificed field in the database to match the input by the teacher
        ///  pre: Filled textbox and field chosen
        ///  prost: Displayed desiered results
        /// </summary>
        private void Button_Search_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> DeleteRows = new List<DataGridViewRow>();
            string Field = ComboBox_SetField.GetItemText(ComboBox_SetField.SelectedItem).ToString();

            //Validation
            if (TextBox_Search.Text != "" || Field == "")
            {
                foreach (DataGridViewRow row in DataGridView_Picked.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        //Checks to see if the results row matches the desiered out come
                        if (Field == "Name" && row.Cells[0].Value.ToString().Contains(TextBox_Search.Text) == false)
                        {
                            DeleteRows.Add(row);
                        }

                        else if (Field == "Interest")
                        {
                            bool found = false;

                            for (int interest = 1; interest < row.Cells.Count; interest++)
                            {
                                if (row.Cells[interest].Value != null)
                                {
                                    if (row.Cells[interest].Value.ToString().Contains(TextBox_Search.Text) == true)
                                    {
                                        found = true;
                                    }
                                }
                            }

                            if (found == false)
                            {
                                DeleteRows.Add(row);
                            }
                        }
                        else if (Field == "Flag")
                        {
                            bool found = false;

                            for (int flag = 1; flag < row.Cells.Count; flag++)
                            {
                                if (row.Cells[flag].Style.BackColor != Color.Red)
                                {
                                    found = true;
                                }
                            }

                            if (found == false)
                            {
                                DeleteRows.Add(row);
                            }
                        }
                    }
                }

                //Deletes all the rows that don't match
                while (DeleteRows.Count != 0)
                {
                    if (DataGridView_Picked.Rows.Contains(DeleteRows.ElementAt(0)))
                    {
                        DataGridView_Picked.Rows.Remove(DeleteRows.ElementAt(0));
                    }

                    DeleteRows.RemoveAt(0);
                }
            }
            else
            {
                MessageBox.Show("Please fill in search requirments");
            }
        }

        /// <summary>
        /// Adds all the students back onto the table (defualt view)
        /// </summary>
        private void Button_RefreshGrades_Click(object sender, EventArgs e)
        {
            DataGridView_AllStudentInfo.Rows.Clear();
            admin.RefreshStudents();
            SetDataViewGrades();
        }

        //==============Start of Best Combination Block==============//

        //Event driven//

        /// <summary>
        ///  Adds the generated options into the database
        ///  pre: Options have ben generated
        ///  prost: Result is stored in the database  
        /// </summary>
        private void Button_ConfrimSetOption_Click(object sender, EventArgs e)
        {
            string SelectedItemtext = ComboBox_SetOption.GetItemText(this.ComboBox_SetOption.SelectedItem);

            //Validation
            if (SelectedItemtext != null)
            {
                if (database.GetOption() != SelectedItemtext)
                {
                    if (SelectedItemtext.Equals("Final Options") && admin.AllStudentsLocked() == true)
                    {
                        database.SetOption(SelectedItemtext);
                        MessageBox.Show("Option state has been updated");
                    }
                    else if (SelectedItemtext.Equals("Initial Options"))
                    {
                        //Need to confirm incase of misclick
                        DialogResult DR_Replied = MessageBox.Show("Are you sure you want to reset all the students interest?", "Warning", MessageBoxButtons.YesNo);
                        {
                            if (DR_Replied == DialogResult.Yes)
                            {
                                //Clears all students interests (allows for re-pick incase of edit) 
                                admin.ResetInterest();
                                database.SetOption(SelectedItemtext);
                                MessageBox.Show("Option state has been updated");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not all students have locked in their initial options");
                    }
                }
                else
                {
                    MessageBox.Show("This option has already been set");
                }
            }
            else
            {
                MessageBox.Show("No option state has been selected");
            }
        }

        /// <summary>
        ///  Fills and creates the option block based on interest
        ///  pre: All students have to have locked their interests
        ///  prost: Options are outputed  
        /// </summary>
        private void Button_ConfirmBestCombination_Click(object sender, EventArgs e)
        {
            if (BestCombination != null)
            {
                //Fix: If all final is locked does it still generate?
                if (admin.AllStudentsLocked() == true)
                {
                    database.SetBestCombination(BestCombination);
                }
                else
                {
                    MessageBox.Show("Not all students have locked in their initial options");
                }
            }
            else
            {
                MessageBox.Show("No options have been generated");
            }

        }

        //==============Start of Best Picked Progress==============//
        /// <summary>
        ///  Calculates the progress of what students have not picked
        ///  pre: Student > 0 
        ///  prost: Displays the progress 
        /// </summary>
        private void PPSetUp()
        {
            PB_Picked.Maximum = admin.GetStudentArraySize();
            PB_Picked.Minimum = 0;
            PB_Picked.Value = admin.AllStudentsLockedLength();
        }

        /// <summary>
        ///  Sets the data grid view depending on option
        ///  pre: Option is set in the database
        ///  prost: Output display 
        /// </summary>
        private void DataGridViewPicked()
        {
            DataGridView_Picked.Columns.Add("0", "Student Name");
            DataGridView_Picked.Columns[0].Frozen = true;


            if (database.GetOption() == "Initial Options")
            {
                DataGridView_Picked.Columns.Add("1", "Interest 1");
                DataGridView_Picked.Columns.Add("2", "Interest 2");
                DataGridView_Picked.Columns.Add("3", "Interest 3");
                DataGridView_Picked.Columns.Add("4", "Interest 4");

                UpdateRowsPicked(5);
            }
            else
            {
                DataGridView_Picked.Columns.Add("1", "Final Choice 1");
                DataGridView_Picked.Columns.Add("2", "Final Choice 2");
                DataGridView_Picked.Columns.Add("3", "Final Choice 3");

                UpdateRowsPicked(4);
            }

        }

        /// <summary>
        ///  Gets students interest 
        ///  pre: Option is set in the database
        ///  prost: Output display 
        /// </summary>
        private void UpdateRowsPicked(int rowsNo)
        {
            string[] rows = new string[rowsNo];

            //Loops through the want/final pick stored in subject
            for (int student = 0; student < admin.GetStudentArraySize(); student++)
            {
                int row = 0;
                rows[0] = admin.GetStudent(student).GetName();

                if (database.GetOption() == "Initial Options")
                {
                    for (int want = 0; want < rowsNo - 1; want++)
                    {
                        row++;
                        rows[row] = admin.GetStudent(student).GetWant(want);
                    }
                }
                else
                {
                    for (int pick = 0; pick < rowsNo - 1; pick++)
                    {
                        row++;
                        rows[row] = admin.GetStudent(student).GetFinalPick(pick);

                    }
                }

                DataGridView_Picked.Rows.Add(rows);
            }

            SetFlags();
        }

        /// <summary>
        ///  Changes the colour of students that are considered to be concerning 
        ///  pre: Filled data gird 
        ///  prost: Concerned students are in red 
        /// </summary>
        private void SetFlags()
        {
            foreach (DataGridViewRow row in DataGridView_Picked.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    //Some students don't have grades for certain subjects
                    for (int x = 1; x < row.Cells.Count; x++)
                    {
                        if (row.Cells[x].Value != null)
                        {
                            Student TempStudent = admin.GetStudent(row.Cells[0].Value.ToString());

                            //Each student contains a list of subjects where the flagged bool is stored
                            Subject subject = TempStudent.GetSubject(row.Cells[x].Value.ToString());

                            if (subject != null)
                            {
                                bool flag = subject.GetFlag();

                                if (flag == true)
                                {
                                    row.Cells[x].Style.BackColor = Color.Red;
                                }
                            }

                        }
                    }
                }
            }
        }

    }
}
