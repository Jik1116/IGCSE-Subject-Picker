using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Computer_Sceince_IA
{
    class Admin 
    {
        Database database = new Database();

        bool permissions;
        private ArrayList<Teacher> teachers;
        ArrayList<Student> students;
        Spreadsheet spreadsheet = new Spreadsheet();
        private string[] Subjects;

        /// <summary>
        /// Constructor
        /// </summary>
        public Admin(bool admin)
        {
            permissions = admin;
            students = database.GetAllStudentInfo();
        }

        //Accessors//

        /// <summary>
        /// Returns student from student array through index
        /// pre: Student is populated
        /// post: Student object reterned
        /// </summary>
        public Student GetStudent(int x)
        {
            return students.Get(x);
        }

        /// <summary>
        /// Returns student from student array based on name
        /// pre: Student name is passed in 
        /// post: Value is returned
        /// </summary>
        public Student GetStudent(string name)
        {
            //Search through the array
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

        /// <summary>
        /// Returns number of student in array
        /// post: int is returned
        /// </summary>
        public int GetStudentArraySize()
        {
            return students.Size();
        }

        /// <summary>
        /// Returns bool to check if object has admin permissions
        /// post: Bool returned
        /// </summary>
        public bool GetPermissions()
        {
            return permissions;
        }

        /// <summary>
        /// Searches teacher array to check if they have admin
        /// pre: Valid list of teachers
        /// post: returns bool
        /// </summary>
        public bool GetPermissions(string email)
        {
            if (teachers != null)
            {
                for (int x = 0; x < teachers.Size(); x++)
                {
                    if (teachers.Get(x).GetEmail().Equals(email))
                    {
                        return teachers.Get(x).GetPermission();
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Returns email
        /// </summary>
        public string GetTeacherEmail(string name)
        {
            if (teachers != null)
            {
                for (int x = 0; x < teachers.Size(); x++)
                {
                    if (teachers.Get(x).GetName().Equals(name))
                    {
                        return teachers.Get(x).GetEmail();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns list of teacher names
        /// </summary>
        public string[] GetAllTeachersName()
        {
            teachers = database.GetAllTeacherInfo();
            if (teachers != null)
            {
                string[] NamesList = new string[teachers.Size()];

                //Console.WriteLine(teachers.Size());

                for (int x = 0; x < teachers.Size(); x++)
                {
                    NamesList[x] = teachers.Get(x).GetName();
                }

                return NamesList;
            }

            return null;
        }

        //Mutators//

        /// <summary>
        /// Sets admin to the reciprocal
        /// </summary>
        public void SetPermissions(bool admin)
        {
            if(admin == true)
            {
                permissions = false;
            }

            if (admin == false)
            {
                permissions = true;
            }
        }

        /// <summary>
        /// Set admin to the reciprocal for a specific teacher 
        /// pre: Valid email passed
        /// post: Admin changed
        /// </summary>
        public void SetPermissions(string email)
        {
            int admin = 0;

            if (teachers != null)
            {
                for (int x = 0; x < teachers.Size(); x++)
                {
                    if (teachers.Get(x).GetEmail().Equals(email))
                    {
                        bool adminB = teachers.Get(x).GetPermission();

                        if (adminB == true)
                        {
                            adminB = false;
                            admin = 0;
                        }
                        else
                        {
                            adminB = true;
                            admin = 1;
                        }

                        teachers.Get(x).SetAdmin(adminB);
                        database.SetPermission(email, admin.ToString());

                        break;
                    }
                }
            }
        }

        //Access database//

        /// <summary>
        /// Re-writes the student array and updates the information
        /// </summary>
        public void RefreshStudents()
        {
            students = database.GetAllStudentInfo();
        }

        /// <summary>
        /// Clears all the interests for students
        /// </summary>
        public void ResetInterest()
        {
            database.ResetInterest();
        }

        /// <summary>
        /// Need to fix so that it gets a list of subjects from students
        /// </summary>
        public void ResetStudents()
        {
            database.UpdateStudentNames(spreadsheet.GetStudentNameList());
        }

        /// <summary>
        /// Checks to see it all the students have locked in their initial options
        /// </summary>
        public bool AllStudentsLocked()
        {
            if(database.GetOption() == "Initial Options")
            {
                for (int x = 0; x < students.Size(); x++)
                {
                    if (students.Get(x).GetWantLength() == 0)
                    {
                        return false;
                    }
                }

            }
           
            return true;
        }

        /// <summary>
        /// Checks if all the student have locked their option
        /// pre: Valid students in the database
        /// post: Returns int 
        public int AllStudentsLockedLength()
        {
            int total = 0;

            //Knows which array to search
            if (database.GetOption() == "Initial Options")
            {
                for (int x = 0; x < students.Size(); x++)
                {
                    if (students.Get(x).GetWantLength() != 0)
                    {
                        total++;
                    }
                }

            }
            else
            {
                for (int x = 0; x < students.Size(); x++)
                {
                    if (students.Get(x).GetFinalPickLength() != 0)
                    {
                        total++;
                    }
                }

            }

            return total;
        }

        //Option block maker//

        /// <summary>
        /// Function Caller
        /// </summary>
        public string[] MakeOptionBlocks(string[] Subjects)
        {
            this.Subjects = Subjects;
            ArrayList<int> popularity = popularityM();
            ArrayList<string> AllCombinations = AllCombinationsM();
            string[] BestCombination = BestCombinations(AllCombinations, popularity);

            return BestCombination;
        }


        /// <summary>
        /// Creates the option block by looping through the most popular
        /// pre: Need to generate all combinations (int)(reflection of an array)
        /// post: Generates a string array using the numebrs
        /// </summary>
        private string[] BestCombinations(ArrayList<string> AllCombinations, ArrayList<int> popularity)
        {

            ArrayList<string> TempCombination = new ArrayList<string>();
            ArrayList<string> Combinations = new ArrayList<string>();
            ArrayList<int> SkipCombination = new ArrayList<int>();

            int[] total = new int[3];
            string[] BestCombination = new string[3];

            for (int n = 0; n < popularity.Size(); n++)
            {
                SkipCombination.AddFirst(popularity.Get(n));
            }


            for (int x = 0; x < popularity.Size(); x++)
            {
                //Stores top 3 popular subject index's
                //Removes the the index so that a combination can be found
                SkipCombination.RemoveFirst();

                //Returns combinations which contain popular subjects as an index
                TempCombination = AllPopularCombinations(AllCombinations, popularity);

                for (int z = 0; z < SkipCombination.Size(); z++)
                {
                    for (int y = 0; y < TempCombination.Size(); y++)
                    {
                        //Checks to see if a combination must be removed
                        if (TempCombination.Get(y).Contains(Convert.ToString(SkipCombination.Get(z))))
                        {   
                            TempCombination.Remove(y);
                            y--;
                        }
                    }
                }

                for (int y = 0; y < TempCombination.Size(); y++)
                {
                    //Finds the total of the remaining combinations
                    int temptotal = FindTotalOfCombination(TempCombination.Get(y));

                    //Compares totals to see which one is greater
                    if (temptotal >= total[x] || BestCombination[x] == null)
                    {
                        total[x] = temptotal;
                        BestCombination[x] = (TempCombination.Get(y));
                    }
                }

                if(BestCombination[x] != null)
                {
                    //Converts it to a string
                    char[] CombinationST = BestCombination[x].ToCharArray();

                    for (int n = 0; n < CombinationST.Length; n++)
                    {
                        //Adds the newly found best combination to skip
                        //Ensure no combinations are repeated
                        SkipCombination.AddLast(Convert.ToInt32(Char.GetNumericValue(CombinationST[n])));
                    }
                }
            }
            return BestCombination;
        }


        /// <summary>
        /// Gets all of the combinations with the most popular subjects in them
        /// pre: List of all the combinations
        /// post: Outputs list of combinations with most popular student picks
        /// </summary>
        private ArrayList<string> AllPopularCombinations(ArrayList<string> AllCombinations, ArrayList<int> popularity)
        {
            ArrayList<string> tempcombinations = new ArrayList<string>();

            //Loops through all combination and compares it to popular picks
            for (int i = 0; i < AllCombinations.Size(); i++)
            {
                for (int x = 0; x < popularity.Size(); x++)
                {
                    if (AllCombinations.Get(i).Contains(Convert.ToString(popularity.Get(x))))
                    {
                        tempcombinations.AddLast(AllCombinations.Get(i));
                    }

                }
            }
            return tempcombinations;
        }

        /// <summary>
        /// Finds the total for each combination depeneidng on how many student the combination will satisfy
        /// pre: List of all the combinations
        /// post: Outputs list of combinations with most popular student picks
        /// </summary>
        private int FindTotalOfCombination(string CombinationS)
        {
            //Splits the array into a char
            char[] CombinationST = CombinationS.ToCharArray();
            int[] CombinationN = new int[CombinationST.Length];

            //Splits the string combination into a array of ints  
            for (int y = 0; y < CombinationST.Length; y++)
            {
                CombinationN[y] = Convert.ToInt32(Char.GetNumericValue((CombinationST[y])));
            }

            int total = 0;

            //Testing method of using - and a true bool for canceling out double adding
            for (int x = 0; x < students.Size(); x++)
            {
                bool found = false;

                //Adds 1 for each student the combination satisfies 
                for (int n = 0; n < students.Get(x).GetWantLength(); n++)
                {
                    for (int i = 0; i < CombinationN.Length; i++)
                    {
                        //Need to add a student Get want
                        if (Subjects[CombinationN[i]] == students.Get(x).GetWant(n))
                        {
                            //Compensate for level of want
                            if (found == true)
                            {
                                total = total - (n + 1);
                            }
                            //Allows for more distribution if student has multiple 
                            //wants in a single option
                            else
                            {
                                total = total + (n + 1);
                                found = true;
                            }
                        }
                    }
                }
            }

            return total;
        }

        /// <summary>
        /// Generates all possible combination of 3 set options
        /// pre: List of subjects
        /// post: String array of 
        /// </summary>
        private ArrayList<string> AllCombinationsM()
        {
            //ArrayList is used as the number of subjects may very
            ArrayList<string> AllCombinations = new ArrayList<string>();
            int Length = Subjects.Length;

            //first
            for (int f = 0; f < Length; f++)
            {
                //second
                for (int s = f + 1; s < Length; s++)
                {
                    //third
                    for (int t = s + 1; t < Length; t++)
                    {
                        //Combines into a single string 
                        AllCombinations.AddLast(string.Format("{0}{1}{2}", f, s, t));
                    }
                }
            }
            return AllCombinations;
        }

        /// <summary>
        /// Generates all possible combination of 3 set options
        /// pre: List of combinations
        /// post: List of top 3 subjects 
        /// </summary>
        private ArrayList<int> popularityM()
        {
            ArrayList<int> popularityPOS = new ArrayList<int>();
            ArrayList<int> popularityTotal = new ArrayList<int>();
            ArrayList<int> popularity1 = new ArrayList<int>();

            popularityPOS.AddFirst(0);
            popularityPOS.AddFirst(0);
            popularityPOS.AddFirst(0);

            popularityTotal.AddFirst(0);
            popularityTotal.AddFirst(0);
            popularityTotal.AddFirst(0);

            for (int i = 0; i < Subjects.Length; i++)
            {
                int total = 0;

                for (int x = 0; x < students.Size(); x++)
                {
                    //Loops through what subject each student wants
                    for (int n = 0; n < students.Get(x).GetWantLength(); n++)
                    {
                        //Want is if the student wants to take the subject
                        //According to the list set by the admin
                        if (Subjects[i] == students.Get(x).GetWant(n))
                        {
                            total = total + 1;
                        }

                    }
                }
                
                //Stores a temporary total for how many students want the subject
                for (int z = 0; z < popularityTotal.Size(); z++)
                {

                    if (total >= popularityTotal.Get(z))
                    {
                        popularityTotal.Add(z, total);
                        popularityPOS.Add(z, i);

                        break;
                    }
                }
            }

            //Stores the integer of the top 3 subjects 
            popularity1.Add(0, popularityPOS.Get(0));
            popularity1.Add(1, popularityPOS.Get(1));
            popularity1.Add(2, popularityPOS.Get(2));

            return popularity1;
        }

    }

}
      
    