using MailKit;
using MailKit.Net.Imap;
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
    public partial class Registration : Form
    {
        Login_Form Login_Form;
        Database databse = new Database();
        Mail mail = new Mail();

        /// <summary>
        /// Constructor
        /// </summary>
        public Registration(Login_Form Form)
        {
            InitializeComponent();
            TextBox_TeacherName.Hide();
            ComboBox_StudentName.Hide();
            ComboBox_Subject.Hide();
            Label_Subject.Hide();

            this.Login_Form = Form;

            ComboBox_StudentName.DataSource = databse.GetAllStudentNames().ToArray();
            ComboBox_Subject.DataSource = databse.GetSpreadSheetSubjectList();
        }

        /// <summary>
        ///Registration for teacher
        ///pre: Teacher radio button clicked
        ///post: Subject option appears
        /// </summary>
        private void TeacherView()
        {
            TextBox_TeacherName.Show();
            ComboBox_StudentName.Hide();
            ComboBox_Subject.Show();
            Label_Subject.Show();
        }

        /// <summary>
        /// Registartion for student 
        /// pre: Student radio button clicked 
        /// post: Sets name drop down list to unregistered students
        /// </summary>
        private void StudentView()
        {
            ComboBox_StudentName.Show();
            TextBox_TeacherName.Hide();
            ComboBox_Subject.Hide();
            Label_Subject.Hide();
        }

        /// <summary>
        /// Back to login page 
        /// pre: Resgistration form is shown 
        /// post: Login form is shown while regstration is hiden
        /// </summary>
        private void Back()
        {
            this.Hide();
            Login_Form.Show();
        }


        /// <summary>
        /// Sends email to address to confirm the email extists 
        /// pre: Valid emial 
        /// post: Email registered
        /// </summary>
        private void SendAuthentication()
        {
            mail.SendAuthenication(string.Format(TextBox_Email.Text));
            CheckAuthentication();
        }

        /// <summary>
        /// Presents a dialog box to re send the email or confrim registration
        /// pre: Valid email address
        /// post: Updates the database
        /// </summary>
        private void CheckAuthentication()
        {
            DialogResult DR_Replied = MessageBox.Show("Have you replied to the email?", "Authentication", MessageBoxButtons.YesNoCancel);
            if (DR_Replied == DialogResult.No)
            {
                DialogResult DR_Resend = MessageBox.Show("Would Like the mail re-sent?", "Authentication", MessageBoxButtons.RetryCancel);
                if (DR_Resend == DialogResult.Retry)
                {
                    //Send email
                    SendAuthentication();
                }
                else if (DR_Resend == DialogResult.Cancel)
                {
                    MessageBox.Show("Registration failed, please re-try");
                }
            }
            else if (DR_Replied == DialogResult.Yes)
            {
                MessageBox.Show("Please wait 20 seconds");

                //Estimated time it takes for an email to be sent
                //Need delay to recieve and send email
                Task.Delay(30000);

                //Checks to see if an email was sent to the authenticater
                if (mail.CheckInbox(TextBox_Email.Text) == true)
                {
                    if (RB_Teacher.Checked == true)
                    {
                        //Teacher registration
                        if (databse.GetTeacherStatus(TextBox_Email.Text) == false)
                        {
                            //Confirm registartion
                            MessageBox.Show("You have been registered!");
                            databse.SetTeacher(TextBox_TeacherName.Text, TextBox_Email.Text, 
                                               TextBox_Password.Text, ComboBox_Subject.SelectedItem.ToString());
                            Back();
                        }
                    }
                    else
                    {
                        //Student registartion
                        if (databse.GetStudentStatus(ComboBox_StudentName.SelectedText) == false)
                        {
                            MessageBox.Show("You have been registered!");
                            databse.SetStudent(ComboBox_StudentName.SelectedItem.ToString(), 
                                               TextBox_Email.Text, TextBox_Password.Text);
                            Back();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Registration failed, please try again");
                }
            }
        }

        //Evenet driven//

        /// <summary>
        /// Goes back to login page
        /// </summary>
        private void Button_Back_Click(object sender, EventArgs e)
        {
            Back();
        }


        /// <summary>
        /// Validating fuction make sure everything is as it should be
        /// </summary>
        private void Button_Register_Click_1(object sender, EventArgs e)
        {
            //Nested if's for specific error messages
            if (TextBox_Password.Text != "")
            {
                if (TextBox_Password.Text == TextBox_ConfirmPassword.Text)
                {
                    if (TextBox_Email.Text != "")
                    {
                        if (RB_Teacher.Checked == true )
                        {
                            if (TextBox_TeacherName.Text != "")
                            {
                                SendAuthentication();
                            }
                            else
                            {
                                MessageBox.Show("Name is invalid");
                            }
                        }
                        else if (RB_Student.Checked == true)
                        {

                            SendAuthentication();
                        }
                        else
                        {
                            MessageBox.Show("Selected role is invalid");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Email is invalid");
                    }
                }
                else
                {
                    MessageBox.Show("Passwords do not match");
                }
                    
            }
            else
            {
                MessageBox.Show("Password is invalid");
            }
        }

        //Sets type of registartion//
        private void RB_Teacher_CheckedChanged(object sender, EventArgs e)
        {
            TeacherView();
        }

        private void RB_Student_CheckedChanged(object sender, EventArgs e)
        {
            StudentView();
        }
    }
}
