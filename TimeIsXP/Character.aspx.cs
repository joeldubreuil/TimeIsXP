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
using TimeIsXP.Classes;

namespace TimeIsXP
{
    public partial class Character : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GenerateTableASP();
            GenerateTableASP_V2();
        }

        public void GenerateTableASP_V2()
        {

            DataTable dt = GoogleExcel.LoadGoogleSheet("Class", "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms", "Class Data!A:F");

            GridView gv = new GridView();
            gv.DataSource = dt;
            gv.DataBind();

            // Add the the Table in the Form
            form1.Controls.Add(gv);
        }


        public void GenerateTableASP()
        {
            DataSet ds = new DataSet();
            DataTable dt = GoogleExcel.LoadGoogleSheet("Class", "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms", "Class Data!A:F");
            ds.Tables.Add(dt);

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

    }

}