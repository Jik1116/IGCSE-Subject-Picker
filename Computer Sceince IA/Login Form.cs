using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Computer_Sceince_IA
{
    public partial class Login_Form : Form
    {
        Database database = new Database();

        /// <summary>
        /// Constructor
        /// </summary>
        public Login_Form()
        {
            InitializeComponent();
            database.CheckServer();
            database.GetMaxID();
        }

        /// <summary>
        /// Validation for access to interface and data
        /// pre: Filled in textbox
        /// post: Allows for access to correct form
        /// </summary>
        private void BUTTON_LOGIN_Click(object sender, EventArgs e)
        {
            //Validation
            string Type = comboBox_UserType.GetItemText(this.comboBox_UserType.SelectedItem);
            bool LoginSuccess = false;

            //Check using different tables if user exists
            if ( Type == "Student")
            {

                if (TEXTBOX_USERNAME.Text != "" && TEXTBOX_PASSWORD.Text != "")
                {
                   LoginSuccess = database.StudentLogin(TEXTBOX_USERNAME.Text, TEXTBOX_PASSWORD.Text);
                }

                if (LoginSuccess == true)
                {
                    MessageBox.Show("Login Successful");
                    new Student_Form(TEXTBOX_USERNAME.Text).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The user does not exist please try again");
                }
               
            }
            else if(Type == "Teacher")
            {

                if (TEXTBOX_USERNAME.Text != "" && TEXTBOX_PASSWORD.Text != "")
                {
                    LoginSuccess = database.TeacherLogin(TEXTBOX_USERNAME.Text, TEXTBOX_PASSWORD.Text);
                }

                if (LoginSuccess == true)
                {
                    MessageBox.Show("Login Successful");
                    bool admin = database.TeacherCheckAdmin(TEXTBOX_USERNAME.Text);
                    if (admin == true)
                    {
                        new Admin_Form().Show();
                        this.Hide();
                    }
                    else
                    {
                        new Teacher_Form(TEXTBOX_USERNAME.Text).Show();
                        this.Hide();
                    }
                      
                }
                else
                {
                    MessageBox.Show("The user does not exist please try again");
                }
            }
            else
            {
                MessageBox.Show("Please select a user type");
            }
        }

        /// <summary>
        /// Closes the program 
        /// </summary>
        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Calls the registration form
        /// </summary>
        private void Button_Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration(this).Show();
        }
    }
}
