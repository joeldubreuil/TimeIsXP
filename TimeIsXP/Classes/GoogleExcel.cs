using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Data;
using System.Threading;
//

namespace TimeIsXP.Classes
{
    static public class GoogleExcel
    {

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";


        /// <summary>
        /// Fill DataTable from Google Excel
        /// </summary>
        /// <param name="sDataTableName"></param>
        /// <param name="sSpreadsheetId">"1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms"</param>
        /// <param name="sRange">"Class Data!A2:F"</param>
        /// <returns></returns>
        static public DataTable LoadGoogleSheet(string sDataTableName, string sSpreadsheetId, string sRange)
        {
            #region Set Credential File + New Service
            //Use a Specifi Google account with API enable to Access Files (credential in client_secret.json)
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

            #endregion Set Credential File + New Service

            #region Google spreadsheet samples

            // Define request parameters.
            //sample spreadsheet:
            //String spreadsheetId = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms";
            //String range = "Class Data!A2:F";
            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit

            #endregion Google spreadsheet samples

            #region Connect to Google API & GetValues
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(sSpreadsheetId, sRange);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values; //GetValues
            #endregion Connect to Google API & GetValues

            DataTable dt = new DataTable(sDataTableName);
            #region Load DataTable (Create Column & Rows) from Google Excel
            if (values != null && values.Count > 0)
            {
                bool bFirstRow = true;

                foreach (var row in values)
                {
                    if (row != null)
                    {

                        if (bFirstRow)
                        {
                            //Create All Columns
                            foreach (var cell in row)
                            {
                                string sColumnName = (string)cell;
                                dt.Columns.Add(new DataColumn(sColumnName, typeof(string)));
                            }

                            //Change Mode
                            bFirstRow = false;
                        }
                        else
                        {
                            //Create all Rows
                            DataRow dr = dt.NewRow();
                            for(int i = 0; i < row.Count; i++)
                            {
                                dr[i] = (string)row[i];
                            }
                            dt.Rows.Add(dr);
                        }
                    }

                }

            }
            else
            {
                Console.WriteLine("No data found.");
            }
            #endregion Load DataTable (Create Column & Rows) from Google Excel

            return dt;
        }

    }
}