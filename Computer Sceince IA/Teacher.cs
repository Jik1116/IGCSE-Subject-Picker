using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Sceince_IA
{
    class Teacher
    {
        ArrayList<Student> students = new ArrayList<Student>();
        private string SubjectName;
        private Admin Myadmin;
        string email;
        string name;
        int ID;

        /// <summary>
        /// Creates a teacher object using data from the database
        /// pre: Valid data 
        /// post: teacher object containing a list of students
        /// </summary>
        public Teacher(int ID, string email, string name, string SubjectName, bool admin, ArrayList<Student> students)
        {
            this.ID = ID;
            this.email = email;
            this.name = name;
            this.SubjectName = SubjectName;
            Myadmin = new Admin(admin);
            this.students = students;
        }

        /// <summary>
        /// Gets a student in the list using an index
        /// pre: x > 0  
        /// post: returns a student object
        /// </summary>
        public Student GetStudent(int x)
        {
            //Loop to search for a student
            if(x > -1 && x < students.Size())
            {
                return students.Get(x);
            }

            return null;
        }

        /// <summary>
        /// Gets a student in the list using an index
        /// pre: name != null  
        /// post: returns a student object
        /// </summary>
        public Student GetStudent(string name)
        {
            //Loop to search for a student 
            if (name != null)
            {
                for (int x = 0; x < students.Size(); x++)
                {
                    if (students.Get(x).GetName().Equals(name))
                    {
                        return students.Get(x);
                    }
                }

            }

            return null;
        }


        //Accessors//

        public string GetName()
        {
            return name;
        }
        
        public string GetSubjectName()
        {
            return SubjectName;
        }

        public string GetEmail()
        {
            return email;
        }

        public bool GetPermission()
        {
            bool permissions = Myadmin.GetPermissions();
            return permissions;
        }

        //Mutators//

        /// <summary>
        /// Sets Admin permissions
        /// pre: Valid input
        /// post: Changes admin permissions for teacher
        /// </summary>
        public void SetAdmin(bool admin)
        {
            Myadmin.SetPermissions(admin);
        }

        /// <summary>
        /// Sets the student array by looping through an array of students
        /// pre: Valid student object list
        /// post: Set student
        /// </summary>
        public void SetStudents(ArrayList<Student> student)
        {
            for(int x = 0; x < student.Size(); x++)
            {
                students.AddLast(student.Get(x));
            }
        }
    }
}
