using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Sceince_IA
{
    class Subject
    {
        private string name;
        private string grade;
        private string effort;
        private bool want;
        private bool flag;
        private bool pickedfinal;

        /// <summary>
        /// Expansion code
        /// </summary>
        public Subject(string name, string grade, string effort)
        {
            this.name = name;
            this.grade = grade;
            this.effort = effort;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Subject(string name)
        {
            this.name = name;
            SetFlag();        
        }

        //Mutators//

        /// <summary>
        /// Updates subject object with new grades
        /// pre: Valid input 
        /// </summary>
        public void SetGarde(string grade)
        {
            this.grade = grade;
        }

        /// <summary>
        /// Updates subject object with new effort
        /// pre: Valid input 
        /// </summary>
        public void SetEffort(string effort)
        {
            this.effort = effort;
        }

        /// <summary>
        /// Updates subject object with new want
        /// pre: Valid input 
        /// </summary>
        public void SetWant(bool want)
        {
            this.want = want;
            SetFlag();
        }

        /// <summary>
        /// Sets an issue with the subject if the students grade aren't on par
        /// pre: Have grades
        /// post: Sets a bool
        /// </summary>
        public void SetFlag()
        {
            if(grade == "D" || grade == "F" && want == true)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }

        /// <summary>
        /// Updates picked final 
        /// pre: Valid input 
        /// </summary>
        public void Setpickedfinal(bool picked)
        {
            pickedfinal = picked;
        }

        //Accessors//

        public string GetName()
        {
            return this.name;
        }

        public string GetGrade()
        {
            return grade;
        }

        public string GetEffort()
        {
         
            return effort;
        }

        public bool GetWant()
        {
            return want;
        }

        public bool GetFlag()
        {
            return flag;
        }

    }
}
