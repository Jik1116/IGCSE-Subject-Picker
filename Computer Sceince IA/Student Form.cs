using System;
using System.Windows.Forms;

namespace Computer_Sceince_IA
{
    public partial class Student_Form : Form
    {
        Database database = new Database();
        Student student;
        ComboBox[] ComboBox_Options = new ComboBox[4];

        /// <summary>
        /// Constructor
        /// </summary>
        public Student_Form(string username)
        {
            InitializeComponent();
            student = database.CreateStudent(username);
            SetDataGirdView_StudentGrades();
            //Fetches state from database
            Label_Heading.Text = database.GetOption();
            SetComboBox();
            SetDataGirdView_Suggested();
        }

        //==============Start of Options Section==============//

        /// <summary>
        /// Sets combobox according to option set 
        /// pre: Fetch option from database
        /// prost: Ouput correct number of option and sets
        /// </summary>
        private void SetComboBox()
        {
            ComboBox_Options[0] = ComboBox_Option1;
            ComboBox_Options[1] = ComboBox_Option2;
            ComboBox_Options[2] = ComboBox_Option3;
            ComboBox_Options[3] = ComboBox_Option4;

            //Checking condition if student has picked and what state to set
            if (student.GetWant(0) == "" && Label_Heading.Text == "Initial Options")
            {
                SetInitialOptions();
            }
            else if (student.GetFinalPick(0) == "" && Label_Heading.Text == "Final Options")
            {
                ComboBox_Option4.Items.Add("No choice");
                SetFinalOptions();
            }
            else
            {
                Button_Lock.Hide();
                MessageBox.Show("You've already selected options");
            }

        }

        /// <summary>
        /// Fetches information from tha database from inital column
        /// pre: Valid list of subjects
        /// post: Set ComboBox
        /// </summary>
        private void SetInitialOptions()
        {
            string[] subjects = database.GetSubjectList();

            if (subjects != null)
            {
                for (int subject = 0; subject < subjects.Length; subject++)
                {
                    for (int CB = 0; CB < ComboBox_Options.Length; CB++)
                    {
                        if (subjects[subject] != "")
                        {
                            ComboBox_Options[CB].Items.Add(subjects[subject]);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Initial has not been set yet");
            }
        }

        /// <summary>
        /// Fetches information from tha database from best combination column
        /// pre: Valid Best Combination
        /// post: Set ComboBox
        /// </summary>
        private void SetFinalOptions()
        {
            ArrayList<string> subjects = database.GetBestCombination();

            //Validation
            if (subjects.GetFirst() != "")
            {
                int CB = 0;

                while(subjects.isEmpty() != true)
                {
                    for(int block = 0; block < 3; block++)
                    {
                        if(subjects.Get(block) != "")
                        {
                            ComboBox_Options[CB].Items.Add(subjects.Get(block));
                        }
                    }

                    for (int block = 0; block < 3; block++)
                    {
                        subjects.RemoveFirst();
                    }

                    CB++;
                }
            }
            else
            {
                MessageBox.Show("Final has not been set yet");
            }
        }

        /// <summary>
        /// Prevents accidental locks if student misclicks (Confrims)
        /// pre: Locked was clicked
        /// post: Options are set in database
        /// </summary>
        private void WarningMessage()
        {
            DialogResult DR_Replied = MessageBox.Show("Are you sure you want to lock?", "Warning", MessageBoxButtons.YesNo);
            {
                if (DR_Replied == DialogResult.Yes)
                {
                    Lock();
                }
            }
        }

        /// <summary>
        /// Validation and sets it in database
        /// pre: Warning message was clicked yes
        /// post: Options sent and set in database
        /// </summary>
        private void Lock()
        {
            //Prevents edits and errors
            for (int x = 0; x < ComboBox_Options.Length; x++)
            {
                ComboBox_Options[x].IsAccessible = false;
            }

            //Which option to set to 
            if (Label_Heading.Text.Equals("Initial Options"))
            {
                string InterestList = "";

                for (int x = 0; x < ComboBox_Options.Length; x++)
                {
                    InterestList += ComboBox_Options[x].GetItemText(ComboBox_Options[x].SelectedItem.ToString()) + ",";
                }
                InterestList = InterestList.TrimEnd(',');
                database.Setinterest(InterestList, student.GetEmail());

                MessageBox.Show("Interests has been locked");
            }
            else
            {
                string FinalList = "";

                for (int x = 0; x < ComboBox_Options.Length - 1; x++)
                {
                    FinalList += ComboBox_Options[x].GetItemText(ComboBox_Options[x].SelectedItem.ToString()) + ",";
                }
                FinalList = FinalList.TrimEnd(',');

                database.Setfinalpick(FinalList, student.GetEmail());

                MessageBox.Show("Final has been locked");
            }
        }


        /// <summary>
        /// Doesn't allow for blanks or multiple picks 
        /// pre: All combobox's are picked 
        /// post: Outputs error message if there is any
        /// </summary>
        private bool CheckError()
        {
            //Nested loop to compre the options
            for (int x = 0; x < ComboBox_Options.Length; x++)
            {
                for (int y = x + 1; y < ComboBox_Options.Length; y++)
                {
                    string COx = ComboBox_Options[x].GetItemText(ComboBox_Options[x].SelectedItem).ToString();
                    string COy = ComboBox_Options[y].GetItemText(ComboBox_Options[y].SelectedItem).ToString();

                    if (COx == "" || COy == "")
                    {
                        MessageBox.Show("A subject has not been picked");
                        return true;
                    }
                    else
                    {
                        if (COx == COy)
                        {
                            MessageBox.Show("A subject has been picked multiple times");
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        //Event driven//

        /// <summary>
        /// Calls all the error methods
        /// </summary>
        private void BUTTON_LOCK_Click(object sender, EventArgs e)
        {
            bool error = CheckError();

            if (error == false)
            {
                WarningMessage();
            }
        }

        //==============Start of View Grades Section==============//

        /// <summary>
        /// Add column headings
        /// pre: Form has loaded
        /// post: Outputs headers
        /// </summary>
        private void SetDataGirdView_StudentGrades()
        {
            DataGirdView_StudentGrades.Columns.Add("0", "Subject Name");
            DataGirdView_StudentGrades.Columns.Add("1", "Gardes");
            DataGirdView_StudentGrades.Columns.Add("2", "Effort");
            UpdateRowsGrade(3);
        }

        /// <summary>
        /// Adds all the rows of grades
        /// pre: Headings set
        /// post: Set all rows to appropriate gardes
        /// </summary>
        private void UpdateRowsGrade(int rowsNo)
        {
            string[] rows = new string[rowsNo];

            for (int subject = 0; subject < student.GetSubjectsLength(); subject++)
            {
                int row = 0;
                rows[0] = student.GetSubject(subject).GetName();
                row++;
                rows[row] = student.GetSubject(subject).GetGrade();
                row++;
                rows[row] = student.GetSubject(subject).GetEffort();

               DataGirdView_StudentGrades.Rows.Add(rows);
            }

        }

        /// <summary>
        /// Add colum for what suggested
        /// pre: Set headings
        /// post: Output headings
        /// </summary>
        private void SetDataGirdView_Suggested()
        {
            DataGirdView_Suggested.Columns.Add("0", "Subject Name");
            DataGirdView_Suggested.Columns.Add("1", "Suggested");
            UpdateRowsSuggested(2);
        }

        /// <summary>
        /// Add all rows to suggested or not depending if its flagged
        /// pre: Valid list of students
        /// post: Studnets in red
        /// </summary>
        private void UpdateRowsSuggested(int rowsNo)
        {
            string[] tempSubject;

            //Set according to database
            if (Label_Heading.Text == "Initial Options")
            {
                tempSubject = database.GetSubjectList();
            }
            else if (Label_Heading.Text == "Final Options")
            {
                tempSubject = database.GetBestCombination().ToArray();
            }
            else
            {
                tempSubject = new string[0];
            }

            string[] rows = new string[rowsNo];
            
            //Loop through subject list
            for (int subject = 0; subject < tempSubject.Length; subject++)
            {
                int row = 0;

                //Database reads it as ""
                if (tempSubject[subject] != "")
                {
                    rows[0] = tempSubject[subject];
                    row++;


                    //Validation
                    if(student.GetSubject(tempSubject[subject]) != null)
                    {
                        if (student.GetSubject(tempSubject[subject]).GetFlag() == false)
                        {
                            rows[row] = "Suggested";
                        }
                        else if (student.GetSubject(tempSubject[subject]).GetFlag() == true)
                        {
                            rows[row] = "Not Suggested";
                        }
                    }
                    else
                    {
                        rows[row] = "Not enough data";
                    }

                    DataGirdView_Suggested.Rows.Add(rows);

                }
            }

        }

    }
}
