using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Computer_Sceince_IA
{
    class Database
    {

        //Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
        //static string MySQLConnectionString = "datasource=NS201_18;database=igcse database";
        
        /// <summary>
        /// Source = Location of database
        /// Database = Name of database
        /// pre: Running XAMPP
        /// post: Connection to database
        /// </summary>
        static string MySQLConnectionString = "datasource=localhost;" +
                                              "database=igcse database";
        //Login Validation/Check//

        /// <summary>
        /// Check if student is registered in the database
        /// pre: Valid input
        /// post: bool returned
        /// </summary>
        public bool StudentLogin(string email, string password)
        {
            string MyQuery = string.Format("SELECT * FROM user_student WHERE email = '{0}' AND password = '{1}'", email, password);

            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            //Error Handelling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                myConnection.Close();
            }


        }

        /// <summary>
        /// Creates students from the information stored in the databse
        /// Limits the access to grade inforation which will be controlled and updated by the admin
        /// pre: Valid email
        /// post: Student object
        /// </summary>
        public Student CreateStudent(string email)
        {
            string MyQuery = string.Format("SELECT * FROM user_student WHERE email = '{0}'", email);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);
            Student student;

            //Error Handelling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();


                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        //email, password, name, subject, grade, effort, interest, finalpick, StudentID
                        string email1 = myReader.GetString(0);
                        string name = myReader.GetString(2);
                        string subjects = myReader.GetString(3);
                        string grade = myReader.GetString(4);
                        string effort = myReader.GetString(5);
                        int ID = myReader.GetInt32(8);

                        if (myReader.GetString(4) != "" && myReader.GetString(5) != "")
                        {
                            student = new Student(email1, name, subjects, grade, effort, ID);

                        }
                        else
                        {
                            student = new Student(email1, name, subjects, ID);
                        }

                        if (myReader.GetString(6) != "")
                        {
                            string interest = myReader.GetString(6);

                            student.SetWant(interest);
                        }

                        if (myReader.GetString(7) != "")
                        {
                            string finalpick = myReader.GetString(7);

                            student.SetFinalPick(finalpick);
                        }

                        return student;

                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

            return null;

        }

        /// <summary>
        /// Logs the teacher in and creates a variable called teacher
        /// Access all of the commands a teacher and admin can do
        /// pre: Valid input
        /// post: Returns bool
        /// </summary>
        public bool TeacherLogin(string email, string password)
        {
            //Quries the database
            string MyQuery = string.Format("SELECT * FROM user_teacher WHERE email = '{0}' AND password = '{1}'", email, password);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            //Error-Handelling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                //Allow a teacher to login
                if (myReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Fetches status of teacher to know whether to display teacher or admin 
        /// pre: Valid input 
        /// post: Returns bool of if teacher is an admin
        /// </summary>
        public bool TeacherCheckAdmin(string email)
        {
            string MyQuery = string.Format("SELECT * FROM user_teacher WHERE email = '{0}' AND tempAdmin = '1'", email);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            //Error-Handelling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Create teacher object and fecthes all the data from teh database
        /// pre: Valid input
        /// post: Returns Tecaher object
        /// </summary>
        public Teacher CreateTeacher(string username)
        {
            //Searches for teacher in the database according to unique entry "email"
            string MyQuery = string.Format("SELECT * FROM user_teacher WHERE email = '{0}'", username);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);
            Teacher teacher;

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        //ID, email, name, password, subjectname, tempAdmin
                        int ID = myReader.GetInt32(0);
                        string email = myReader.GetString(1);
                        string name = myReader.GetString(2);
                        string subjectname = myReader.GetString(4);
                        string adminS = myReader.GetString(5);
                        bool adminB;

                        if (adminS.Equals("True"))
                        {
                            adminB = true;
                        }
                        else
                        {
                            adminB = false;
                        }

                        //Creates teacher object
                        teacher = new Teacher(ID, email, name, subjectname, adminB, GetSubjectSpecificStudentInfo(subjectname));
                        return teacher;
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return null;
        }

        //Accessors//

        /// <summary>
        /// The number of students in the database (allows for looping when searching for students)
        /// post: Returns int
        /// </summary>
        public int GetMaxID()
        {
            int MaxID = 0;

            string MyGet = string.Format("SELECT MAX(`studentID`) FROM user_student");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyGet, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        MaxID = Convert.ToInt32(myReader.GetString(0)) + 1;
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return MaxID;

        }

        /// <summary>
        /// Checks to see if a student has registored using their email
        /// pre: Valid input
        /// post: Bool of if student has an email
        /// </summary>
        public bool GetStudentStatus(string name)
        {
            string MyQuery = string.Format("SELECT * FROM user_student WHERE name = '{0}' AND password = '{1}'", name, "");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    //Not registered
                    return true;
                }
                else
                {
                    //Registered
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                myConnection.Close();
            }

        }

        /// <summary>
        /// Checks to see if a teacher is regsitered
        /// pre: Valid input 
        /// post: Returns bool as indication
        /// </summary>
        public bool GetTeacherStatus(string email)
        {
            string MyQuery = string.Format("SELECT * FROM user_teacher WHERE email = '{0}' AND password = '{1}'", email, "");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    //Not registored
                    return true;
                }
                else
                {
                    //Registored
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                myConnection.Close();
            }

        }

        /// <summary>
        /// Subject list which can be edited by teacher (interest list)
        /// post:       
        /// pre:
        /// </summary>
        public string[] GetSubjectList()
        {
            string MyQuery = string.Format("SELECT * FROM user_admin WHERE SubjectList != ''");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        string SubjectListS = myReader.GetString(3);

                        string[] SubjectList = SubjectListS.Split(',');

                        return SubjectList;
                    }

                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                myConnection.Close();
            }


        }

        /// <summary>
        /// Student information for a specific teacher (subject dependent)
        /// pre: Valid input
        /// post: return list of Student objects
        /// </summary>
        public ArrayList<Student> GetSubjectSpecificStudentInfo(string SubjectName)
        {
            ArrayList<Student> students = new ArrayList<Student>();
            int id = 1;
            string MyQuery;
            int MaxID = GetMaxID();

            while (id < MaxID)
            {
                //Decides what array to search
                if (GetOption() == "Initial Options")
                {
                    MyQuery = string.Format("SELECT * FROM user_student WHERE interest LIKE '%{0}%' AND studentID = '{1}' AND email != ''", SubjectName, id);
                }
                else
                {
                    MyQuery = string.Format("SELECT * FROM user_student WHERE finalpick LIKE '%{0}%' AND studentID = '{1}' AND email != ''", SubjectName, id);
                }

                MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
                MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

                //Error-Handeling
                try
                {
                    myConnection.Open();
                    MySqlDataReader myReader = myCommand.ExecuteReader();


                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {

                            Student student = CreateStudent(myReader.GetString(0));
                            students.AddLast(student);
                        }

                    }

                    id++;

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    myConnection.Close();
                }
            }

            return students;
        }

        /// <summary>
        /// Creates all teacher objects for admin to teacher view
        /// pre: Valid teachers in the database
        /// post: Returns Teacher object list
        /// </summary>
        public ArrayList<Teacher> GetAllTeacherInfo()
        {
            ArrayList<Teacher> teachers = new ArrayList<Teacher>();

            int id = 1;

            while (1 == 1)
            {

                string MyQuery = string.Format("SELECT * FROM user_teacher WHERE id='{0}'", id);
                MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
                MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

                //Error-Handling
                try
                {
                    myConnection.Open();
                    MySqlDataReader myReader = myCommand.ExecuteReader();


                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            string email = myReader.GetString(1);

                            Teacher teacher = CreateTeacher(email);

                            teachers.AddLast(teacher);
                        }

                    }
                    else
                    {
                        myConnection.Close();
                        return teachers;
                    }

                    id++;

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    myConnection.Close();
                }


            }


        }

        /// <summary>
        /// Gest the SpreadSheetList from the database
        /// pre: Valid list in database
        /// post: return string array of Subjects
        /// </summary>
        public string[] GetSpreadSheetSubjectList()
        {
            string MyQuery = string.Format("SELECT * FROM user_admin WHERE SpreadSheetSubjectList != ''");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        string SubjectListS = myReader.GetString(4);

                        string[] SubjectList = SubjectListS.Split(',');

                        return SubjectList;
                    }

                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                myConnection.Close();
            }

        }

        /// <summary>
        /// Returns a list of all the students names
        /// pre: Valid list of students
        /// post: String list of student names
        /// </summary>
        public ArrayList<string> GetAllStudentNames()
        {
            ArrayList<string> students = new ArrayList<string>();

            int id = 1;

            int MaxID = GetMaxID();

            while (id < MaxID)
            {

                string MyQuery = string.Format("SELECT * FROM user_student WHERE studentID = '{0}' AND email = ''", id);
                MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
                MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

                //Error Handelling
                try
                {
                    myConnection.Open();
                    MySqlDataReader myReader = myCommand.ExecuteReader();


                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            string name = myReader.GetString(2);
                            students.AddLast(name);
                        }
                    }

                    id++;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    myConnection.Close();
                }
            }

            return students;
        }

        /// <summary>
        /// Creates a List of all the students for the admin and teacher
        /// pre: Valid students in the database
        /// post: Return list of students
        /// </summary>
        public ArrayList<Student> GetAllStudentInfo()
        {
            ArrayList<Student> students = new ArrayList<Student>();

            int id = 1;

            int MaxID = GetMaxID();

            while (id < MaxID)
            {

                string MyQuery = string.Format("SELECT * FROM user_student WHERE studentID = '{0}' AND email != ''", id);
                MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
                MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);
                try
                {
                    myConnection.Open();
                    MySqlDataReader myReader = myCommand.ExecuteReader();


                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            string email = myReader.GetString(0);

                            Student student = CreateStudent(email);

                            students.AddLast(student);
                        }

                    }

                    id++;

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    myConnection.Close();
                }


            }

            return students;

        }

        /// <summary>
        /// fetches the Option state from database
        /// pre: Vaild entry
        /// post: Return string of value
        /// </summary>
        public string GetOption()
        {
            string MyQuery = string.Format("SELECT * FROM user_admin WHERE OptionBlock IS NOT NULL");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            //Error Handelling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        //Console.WriteLine(myReader.GetString(2));
                        return myReader.GetString(2);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return null;
        }

        /// <summary>
        /// Returns value in BestCombination stored in database
        /// </summary>
        public ArrayList<string> GetBestCombination()
        {
            string MyQuery = string.Format("SELECT * FROM user_admin WHERE BestCombinations IS NOT NULL");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);
            string BestCombinationsS = null;

            //Error-Handelling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        BestCombinationsS = myReader.GetString(0);
                    }

                    string[] BestCombinationsA = BestCombinationsS.Split(',');

                    ArrayList<string> BestCombincations = new ArrayList<string>();

                    for (int subject = 0; subject < BestCombinationsA.Length; subject++)
                    {
                        BestCombincations.AddLast(BestCombinationsA[subject]);
                    }

                    return BestCombincations;
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }


            return null;

        }
    
        //Mutators//

        /// <summary>
        /// Updates student to be registered
        /// pre: Valid input
        /// post: Student set
        /// </summary>
        public void SetStudent(string name, string email, string password)
        {
            string[] subjectsA = GetSpreadSheetSubjectList();

            //Console.WriteLine(subjectsA[0]);

            string subjects = string.Join(",", subjectsA);

            //Console.WriteLine(subjects);

            //UPDATE `user_student` SET `email` = 'jaikirat@ascot.ac.th' WHERE `user_student`.`studentID` = 1;


            string MyUpdate = string.Format("UPDATE user_student SET email = '{0}',password = '{1}',subjects = '{2}' WHERE name = '{3}'", email, password, subjects, name);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Adds a teacher into the database 
        /// pre: Valid input 
        /// post: New teacher in database
        /// </summary>
        public void SetTeacher(string name, string email, string password, string SubjectName)
        {

            string MyInsert = string.Format("INSERT INTO user_teacher (email,password,name,SubjectName) VALUES ('{0}','{1}','{2}','{3}')", email, password, name, SubjectName);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyInsert, myConnection);

            //Error-Handeling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

        }
        
        /// <summary>
        /// Extension: Able to edit SpreadSheet SubjectList
        /// </summary>
        public void SetSpreadSheetSubjectList(string SubjectList)
        {
            string MyUpdate = ("UPDATE user_admin SET SpreadSheetSubjectList = '" + SubjectList + "'");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Sets the subject list stored in the database
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void SetSubjectList(string SubjectList)
        {
            string MyUpdate = ("UPDATE user_admin SET SubjectList = '" + SubjectList + "'");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            //Error-Handeling
            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Updates Option in database
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void SetOption(string SetOption)
        {
            //Searches the database for approprate record to update
            string MyQuery = "SELECT * FROM user_admin WHERE OptionBlock IS NOT NULL";
            //Updates the OptionBlock field when it is found and needs to be changed
            string MyUpdate = string.Format("UPDATE user_admin SET OptionBlock = '{0}'", SetOption);
            //Inserts a record into OptionBlock field when it is not found (does not exsist)
            string MyInsert = string.Format("INSERT INTO user_admin (OptionBlock) VALUES ('{0}')", SetOption);

            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);
            MySqlCommand myCommand2 = new MySqlCommand(MyInsert, myConnection);
            MySqlCommand myCommand3 = new MySqlCommand(MyUpdate, myConnection);

            //Error-Handleing
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();
                myConnection.Close();

                if (myReader.HasRows)
                {
                    myConnection.Open();
                    MySqlDataReader myReader2 = myCommand2.ExecuteReader();
                }
                else
                {
                    myConnection.Open();
                    MySqlDataReader myReader3 = myCommand3.ExecuteReader();
                }

                myConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }


        }

        /// <summary>
        /// Updates the BestCombinations in database
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void SetBestCombination(string BestCombination)
        {
            //Console.WriteLine(BestCombination);
            string MyUpdate = string.Format("UPDATE user_admin SET BestCombinations= '" + BestCombination + "'");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();
                MessageBox.Show("The options have been updated sucessfully");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

        }

        /// <summary>
        /// Updates initial interest for the studented inputed in database
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void Setinterest(string intreset, string email)
        {
            string MyUpdate = ("UPDATE user_student SET interest = '" + intreset + "' WHERE email = '"+ email +"'");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            //Error-Handeling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if(myReader.Read())
                {
                    MessageBox.Show("Your Initial options have been set");

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Updates finalpick for a single student on a database
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void Setfinalpick(string intreset, string email)
        {
            string MyUpdate = ("UPDATE user_student SET finalpick = '" + intreset + "' WHERE email = '" + email + "'");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            //Error-Handeling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    MessageBox.Show("Your final options have been set");

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Updates grades for every student depending on inputs
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void SetGrades(string name, string grades)
        {
            string MyQuery = string.Format("UPDATE user_student SET grades ='{0}' WHERE name = '{1}'",grades, name);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

        }

        /// <summary>
        /// Updates efforts for every student depending on input
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void SetEffort(string name, string effort)
        {
            string MyQuery = string.Format("UPDATE user_student SET effort ='{0}' WHERE name = '{1}'", effort, name);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyQuery, myConnection);

            //Error-Handeling
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

        }

        /// <summary>
        /// Sets, in the databse, if a teacher is an admin or not 
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void SetPermission(string email, string permission)
        {
            string MyUpdate = string.Format("UPDATE user_teacher SET tempAdmin = '{0}' WHERE email = '{1}'", permission, email);
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);
            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Resets database with all the students on the spreadsheet (Deletes) 
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void UpdateStudentNames(string[] StudentNames)
        {

            string MyDelete = string.Format("DELETE FROM user_student WHERE email IS NOT NULL");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyDelete, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();

            }

            ResetIA();

            foreach (string name in StudentNames)
            {
                InsertStudentName(name);
            }
        }

        /// <summary>
        /// Resets database with all the students on the spreadsheet (inserts names) 
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void InsertStudentName(string name)
        {
            string MyUpdate = string.Format("INSERT INTO user_student(name) VALUES ('" + name + "')");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();
                Console.WriteLine("Updated");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }

        }

        /// <summary>
        /// Sets all student interest to null 
        /// e.g. Option block/interest change (flexibility)
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void ResetInterest()
        {
            string MyUpdate = string.Format("UPDATE user_student SET interest = '{0}', finalpick = '{0}' WHERE email != ''", "");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            try
            {
                myConnection.Open();
                MySqlDataReader myReader = myCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }


        }

        /// <summary>
        /// Resets Auto incrementer when adding new students 
        /// (start from 1 instead of e.g. 17)(needed for looping)
        /// pre: Valid input 
        /// post: Updates the database
        /// </summary>
        public void ResetIA()
        {
            string MyUpdate = string.Format("ALTER TABLE user_student AUTO_INCREMENT = 1");
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand myCommand = new MySqlCommand(MyUpdate, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                myConnection.Close();
            }
        }

        /// <summary>
        /// Error handeling to make sure that the programe does not crash
        /// </summary>
        public void CheckServer()
        {
            MySqlConnection myConnection = new MySqlConnection(MySQLConnectionString);

            try
            {
                myConnection.Open();

            }
            catch (Exception)
            {
                MessageBox.Show("The server is currently unavaible");

                //Force shutdown the application
                Environment.Exit(0);

            }
            finally
            {
                myConnection.Close();
            }

        }
    }
}
