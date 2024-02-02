using System;
using System.Windows.Forms;

namespace Computer_Sceince_IA
{
    public partial class EditSubjectList : Form
    {
        Database database = new Database();
        string[] LisItems;

        //Constructer//

        public EditSubjectList()
        {
            InitializeComponent();

            if (database.GetSubjectList() != null)
            {
                //Can not be binded to a datasource as items can be added while list it open
                LisItems = database.GetSubjectList();

                for(int x =0; x < LisItems.Length; x++)
                {
                    ListBox_SubjectList.Items.Add(LisItems[x]);
                }
            }
            else
            {
                LisItems = database.GetSpreadSheetSubjectList();

                for (int x = 0; x < LisItems.Length; x++)
                {
                    ListBox_SubjectList.Items.Add(LisItems[x]);
                }
            }

        }

        /// <summary>
        /// Hides the form
        /// </summary>
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Event driven//

        /// <summary>
        /// Gets the subject list from the database
        /// pre: Item list is not null
        /// post: Outputs list of the subjects into a list box 
        /// </summary>
        private void Button_Confrim_Click(object sender, EventArgs e)
        {
            if(ListBox_SubjectList.CheckedItems.Count > 7 && ListBox_SubjectList.CheckedItems.Count < 10)
            {
                string SubjectList = "";

                foreach (var Subject in ListBox_SubjectList.CheckedItems)
                {
                    SubjectList += Subject.ToString() + ",";
                }
                SubjectList = SubjectList.TrimEnd(',');
                database.SetSubjectList(SubjectList);
                MessageBox.Show("The subject list has been updated");
            }
            else
            {
                MessageBox.Show("Please select only 8 or 9 items");
            }

        }

        /// <summary>
        /// Adds a subject onto the list 
        /// pre: List of items is inisaltised
        /// post: New list of items for studends to pick from
        /// </summary>
        private void Button_AddSubject_Click(object sender, EventArgs e)
        {
            string NewSubject = TextBox_AddSubject.Text;
            bool found = false;

            if (NewSubject != "" && LisItems != null)
            {
                for(int subject = 0; subject < LisItems.Length; subject++)
                {
                    if(LisItems[subject] == NewSubject)
                    {
                        found = true;
                        MessageBox.Show("The input was invalid");
                    }
                }

                if (found != true)
                {
                    ListBox_SubjectList.Items.Add(NewSubject, CheckState.Unchecked);
                }

            }
            else
            {
                MessageBox.Show("The input was invalid");
            }

        }
    }
}
