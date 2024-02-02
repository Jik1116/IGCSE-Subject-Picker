using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Sceince_IA
{
    class Student
    {
        private Subject[] Subjects;
        string[] SubjectsWant;
        string[] SubjectsPicked;
        string email;
        string name;
        int ID;

        /// <summary>
        /// Consructors
        /// </summary>
        public Student(string email, string name, string subjects, string grades, string effort, int ID)
        {
            this.email = email;
            this.name = name;
            this.ID = ID;
            SetSubjects(subjects, grades, effort);

        }

        /// <summary>
        /// Overload constructor
        /// </summary>
        public Student(string email, string name, string subjects, int ID)
        {
            this.email = email;
            this.name = name;
            this.ID = ID;
            SetSubjects(subjects);
        }

        //Accesors//

        /// <summary>
        /// Returns the length of final pick array
        /// post: returns length as an int
        /// </summary>
        public int GetFinalPickLength()
        {
            if(SubjectsPicked != null)
            {
                return SubjectsPicked.Length;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns student email
        /// </summary>
        public string GetEmail()
        {
            return email;
        }

        /// <summary>
        /// Returns student names
        /// </summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Expansion code
        /// </summary>
        public int GetID()
        {
            return ID;
        }

        /// <summary>
        /// Returns lenghth
        /// post: int for elements in subject
        /// </summary>
        public int GetSubjectsLength()
        {
            return Subjects.Length;
        }

        /// <summary>
        /// Searches through subject array using index
        /// pre: Valid input
        /// post: Return subject object
        /// </summary>
        public Subject GetSubject(int x)
        {
            return Subjects[x];
        }

        /// <summary>
        /// Returns subject according to string name
        /// pre: Valid input
        /// post: Return subject object 
        /// </summary>
        public Subject GetSubject(string name)
        {
            for (int x = 0; x < Subjects.Length; x++)
            {
                if (Subjects[x].GetName() == name)
                {
                    return Subjects[x];
                }
            }

            return null;
        }

        /// <summary>
        /// Return values from what students have picked as their interest (want)
        /// pre: Valid input
        /// post: returns subject name
        /// </summary>
        public string GetWant(int x)
        {
            if (SubjectsWant != null)
            {
                return SubjectsWant[x];
            }

            return "";
        }

        /// <summary>
        /// Return values from what students have picked as their final 
        /// pre: Valid input
        /// post: returns subject name
        /// </summary>
        public string GetFinalPick(int x)
        {
            if (SubjectsPicked != null)
            {
                return SubjectsPicked[x];
            }

            return "";
        }

        /// <summary>
        /// Returns int for length of an array
        /// </summary>
        public int GetWantLength()
        {
            if (SubjectsWant != null)
            {
                return SubjectsWant.Length;
            }
            else
            {
                return 0;
            }
        }

        //Mutator//

        /// <summary>
        /// Formatting the subjects into a single string
        /// pre: Valid input
        /// post: Database updated
        /// </summary>
        public void SetSubjects(string subjects)
        {
            string[] SubjectName = subjects.Split(',');

            Subjects = new Subject[SubjectName.Length];

            for (int x = 0; x < SubjectName.Length; x++)
            {
                Subjects[x] = new Subject(SubjectName[x]);
            }
        }

        /// <summary>
        /// Formatting the subjects into a single string
        /// pre: Valid input
        /// post: Database updated
        /// </summary>
        public void SetGrade(string grades, string effort)
        {
            string[] grade = grades.Split(',');

            string[] efforts = effort.Split(',');

            for (int x = 0; x < Subjects.Length; x++)
            {
                Subjects[x].SetGarde(grade[x]);
                Subjects[x].SetEffort(efforts[x]);
            }
        }

        /// <summary>
        /// Sets subject list for students
        /// pre: Valid input
        /// post: Database updated
        /// </summary>
        public void SetSubjects(string subjects, string grades, string effort)
        {
            SetSubjects(subjects);
            SetGrade(grades, effort);
        }

        /// <summary>
        /// Popultes the want array (interest)
        /// pre: Valid input
        /// post: Database updated
        /// </summary>
        public void SetWant(string want)
        {
            SubjectsWant = want.Split(',');

            for (int x = 0; x < Subjects.Length; x++)
            {
                for(int y = 0; y < SubjectsWant.Length; y++)
                {
                    if(SubjectsWant[y].Equals(Subjects[x].GetName()))
                    {
                        Subjects[x].SetWant(true);
                    }
                }
            }
        }

        /// <summary>
        /// Populates the final array (subjects picked)
        /// pre: Valid input
        /// post: Database updated
        /// </summary>
        public void SetFinalPick(string finalpick)
        {
            SubjectsPicked = finalpick.Split(',');

            if(SubjectsPicked != null)
            {
                for (int x = 0; x < Subjects.Length; x++)
                {
                    for (int y = 0; y < SubjectsPicked.Length; y++)
                    {
                        if (SubjectsPicked[y].Equals(Subjects[x]))
                        {
                            Subjects[x].Setpickedfinal(true);
                        }
                    }
                }
            }
        }
    }
}
