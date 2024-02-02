using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace Computer_Sceince_IA
{
    class Spreadsheet
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Ascot IGCSE Option Blocks";
        String spreadsheetId = "1lnFcL4DPHSrFxfag5iX5Fkmyf_9q4nqRS9qrH64bipM";
        SheetsService service;

        //Set by API
        IList<IList<Object>> NameValues;
        IList<IList<Object>> values;


        Database database = new Database();
        string[,] GradesA;
        string[,] EffortA;
        bool creds = false;
        string[] SubjectNameList;


        /// <summary>
        /// Constructor 
        /// post: Creates a spreadsheet object with connection to the sheet
        /// </summary>
        public Spreadsheet()
        {
            //Gets the token from the user to gain access to the spreadsheet
            this.service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetCredential(),
                ApplicationName = ApplicationName,
            });

            //Only gets the credentials once (compensates for expired tokens)
            if (creds != true)
            {
                ExecuteDataFetch();
            }

            //Gets the list of subjects from the database
            SubjectNameList = database.GetSpreadSheetSubjectList();
        }

        /// <summary>
        /// Gets the list of students on the spreadsheet
        /// pre: Valid term and student
        /// post:Retruns data of all subjects for said student at sepcificed term
        /// </summary>
        public string[] GetStudentNameList()
        {
            //Sets the list of students according to length
            string[] StudentNameList = new string[NameValues.Count()];
            int x = 0;

            //Adds the students into an array
            foreach (var value in NameValues)
            {
                StudentNameList[x] = value[0].ToString();
                x++;
            }

            return StudentNameList;
        }


        /// <summary>
        /// Gets the data of a specific studnet for a subject and a term
        /// pre: Valid term and student
        /// post:Retruns data of all subjects for said student at sepcificed term
        /// </summary>
        public string GetTermStudentGrades(string term, string SubjectName, string StudentName)
        {
            //Gets for specificed term
            GetSpreadSheetData(term);
            int x = 0;

            //Get index of the subjects (x axis)(serach)
            for (int subject = 0; subject < SubjectNameList.Length; subject++)
            {
                if (SubjectNameList[subject] == SubjectName)
                {
                    x = subject + 1;
                }
            }
            //Get index of the studet (y axis)
            if (GradesA != null)
            {
                for (int y = 0; y < GradesA.GetLength(1); y++)
                {
                    if (GradesA[0, y] == StudentName)
                    {
                        return GradesA[x, y];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the data of a specific studnet for a subject and a term
        /// pre: Valid term and student
        /// post:Retruns data of all subjects for said student at sepcificed term
        /// </summary>
        public string GetTermStudentEffort(string term, string SubjectName, string StudentName)
        {
            //Gets for specificed term
            GetSpreadSheetData(term);

            //Get index of the subjects (x axis)(serach)
            int x = 0;
            for (int subject = 0; subject < SubjectNameList.Length; subject++)
            {
                if (SubjectNameList[subject] == SubjectName)
                {
                    x = subject + 1;
                }
            }

            //Get index of the studet (y axis)
            if (EffortA != null)
            {
                for (int y = 0; y < EffortA.GetLength(1); y++)
                {
                    if (EffortA[0, y] == StudentName)
                    {
                        return EffortA[x, y];
                    }
                }
            }

            return null;

        }

        /// <summary>
        /// Gets the data from the spreadsheet to add to the database (formatting)
        /// pre: Term is valid
        /// post:Retruns a single line of all the data from the term
        /// </summary>
        public void SetTermStudentData(string term)
        {
            //Set term data
            GetSpreadSheetData(term);

            //Validation
            if (GradesA != null)
            {
                //Loops to through the array to get the grades for each student
                for (int y = 0; y < GradesA.GetLength(1); y++)
                {
                    string GradesS = "";

                    for (int x = 1; x < GradesA.GetLength(0); x++)
                    {
                        //Added to a single string
                        GradesS += GradesA[x, y].ToString() + ",";
                    }
                    //Compensate for the loop
                    GradesS = GradesS.TrimEnd(',');

                    //Sets the string in the database for a single student
                    database.SetGrades(GradesA[0, y], GradesS);
                }
            }

            if (EffortA != null)
            {
                //Loops to through the array to get the grades for each student
                for (int y = 0; y < EffortA.GetLength(1); y++)
                {
                    string EffortS = "";

                    for (int x = 1; x < EffortA.GetLength(0); x++)
                    {
                        //Added to a single string
                        EffortS += EffortA[x, y].ToString() + ",";
                    }
                    //Compensate for the loop
                    EffortS = EffortS.TrimEnd(',');

                    //Sets the string in the database for a single student
                    database.SetEffort(EffortA[0, y], EffortS);
                }
            }
        }

        /// <summary>
        /// Returns all the grades from the spreadsheet of a specific term
        /// pre: Term is picked and passed
        /// post: Term gardes
        /// </summary>        
        public void GetSpreadSheetData(string term)
        {
            //Sets the array dynamically according the the subjects and number of students
            GradesA = new string[SubjectNameList.Length + 1, NameValues.Count];
            EffortA = new string[SubjectNameList.Length + 1, NameValues.Count];

            //indexed by terms, stores the min value that the loop should go
            Dictionary<string, Int32> terms = new Dictionary<string, Int32>();
            terms.Add("1.1", 0);
            terms.Add("1.2", SubjectNameList.Length * 2);
            terms.Add("2.1", SubjectNameList.Length * 4);
            terms.Add("2.2", SubjectNameList.Length * 6);
            terms.Add("3", SubjectNameList.Length * 8);

            //Checks to make sure there are names on the sheet
            if (NameValues != null && NameValues.Count > 0)
            {
                //Set the first column to names
                int n = 0;
                foreach (var row in NameValues)
                {
                    GradesA[0, n] = row[0].ToString();
                    EffortA[0, n] = row[0].ToString();
                    n++;
                }

                //Sets the values for the loop
                int x = 1;
                int min = terms[term];
                int max = min + (SubjectNameList.Length * 2);

                //Loops through the rows
                for (int row = min; row < max; row++)
                {
                    int y = 0;

                    //Loops through the values in each row
                    foreach (var rows in values)
                    {
                        if (rows.Count <= row)
                        {
                            EffortA[x, y] = "";
                            GradesA[x, y] = "";
                        }
                        else
                        {
                            string value = rows[row].ToString();

                            //Each even number row is a grade  
                            //Each odd number rows are the effort grade
                            if ((row % 2) == 0)
                            {
                                GradesA[x, y] = value;
                            }
                            else
                            {
                                EffortA[x, y] = value;
                            }
                        }
                        y++;
                    }
                    //Only incerements after the efforts are added
                    if ((row % 2) != 0)
                    {
                        x++;
                    }
                }
            }
        }

        /// <summary>
        /// Reads in the spreadhsheet from a specificed range
        /// post: Strores the validated token 
        ///       Returns all the studnet grades in a list of lists
        /// </summary>        
        public void ExecuteDataFetch()
        {
            //Range is set according to where the names start in the spreadsheet
            String Names = "YEAR 9!A4:A";

            //Error Handelling
            try
            {
                //Reads in names from spreadsheet
                SpreadsheetsResource.ValuesResource.GetRequest requestNames =
                service.Spreadsheets.Values.Get(spreadsheetId, Names);
                ValueRange responseNames = requestNames.Execute();
                //Stores locally
                NameValues = responseNames.Values;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //You don't initally know how many students there are 
            //Sets range according to number of students
            String range = string.Format("YEAR 9!B4:{0}", NameValues.Count + 4);

            //Error Handelling
            try
            {
                //Reads in all the grades
                SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(spreadsheetId, range);
                ValueRange response = request.Execute();
                //Stores locally
                values = response.Values;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //Spreadsheet has been read
            creds = true;
        }

        /// <summary>
        /// Gets the token and consent of the user to use google account
        /// pre: Valid school email address
        /// post: Returns token
        /// </summary>
        public UserCredential GetCredential()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, 
                    Scopes, 
                    "user", 
                    CancellationToken.None, 
                    new FileDataStore(credPath, true)).Result;
            }

            return credential;
        }
    }
}