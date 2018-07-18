using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Data;

namespace TimeIsXP
{
    public partial class Character : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateTableASP();
        }

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";


        public void GenerateTableASP()
        {
            DataTable dt = LoadGoogleSheet();
            Table table = new Table();
            TableRow row = null;


            //Add the Headers
            row = new TableRow();
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                TableHeaderCell headerCell = new TableHeaderCell();
                headerCell.Text = dt.Columns[j].ColumnName;
                row.Cells.Add(headerCell);
            }
            table.Rows.Add(row);



            //Add the Column values
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = new TableRow();

                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    TableCell cell = new TableCell();
                    cell.Text = dt.Rows[i][j].ToString();
                    row.Cells.Add(cell);

                }

                // Add the TableRow to the Table
                table.Rows.Add(row);

            }

            // Add the the Table in the Form
            form1.Controls.Add(table);

        }

        //static void Main(string[] args)
        public DataTable LoadGoogleSheet()
        {
            DataTable dt = new DataTable("Character");

            dt.Columns.Add(new DataColumn("Student Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Gender", typeof(string)));
            dt.Columns.Add(new DataColumn("Class Level", typeof(string)));
            dt.Columns.Add(new DataColumn("Home State", typeof(string)));
            dt.Columns.Add(new DataColumn("Major", typeof(string)));
            dt.Columns.Add(new DataColumn("Extracurricular Activity", typeof(string)));





            UserCredential credential;

            string sPathCredential = HttpRuntime.BinDirectory + "client_secret.json";


            using (var stream =
                new FileStream(sPathCredential, FileMode.Open, FileAccess.Read))
            {
                //string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string credPath = HttpRuntime.BinDirectory;
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms";
            String range = "Class Data!A2:F";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                ////Console.WriteLine("Name, Major");
                //string sData = "Name, Major" + Environment.NewLine;
                //foreach (var row in values)
                //{
                //    // Print columns A and E, which correspond to indices 0 and 4.
                //    //Console.WriteLine("{0}, {1}", row[0], row[4]);

                //    sData += row[0] + ", " + row[4] + Environment.NewLine; ;
                //}

                foreach (var row in values)
                {
                    if (row != null)
                    {

                        DataRow dr = dt.NewRow();

                        dr["Student Name"] = (string)row[0];
                        dr["Gender"] = (string)row[1];
                        dr["Class Level"] = (string)row[2];
                        dr["Home State"] = (string)row[3];
                        dr["Major"] = (string)row[4];
                        dr["Extracurricular Activity"] = (string)row[5];

                        dt.Rows.Add(dr);
                    }

                }

            }
            else
            {
                Console.WriteLine("No data found.");
            }
            //Console.Read();

            return dt;
        }
    }

}