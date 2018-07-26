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
            //GenerateTableASP_V2();

            //Idea: give people 3-4 events free to start their character, so they can familiarize with the XP system.
            //instead of free 200xp that will require another UI mechanic to startup.

            int iTimeTotal = 390;
            int iVisualUpkeepPourcent = 10;
            int iTimeGained = 90;

            Init_RadSlider_Time();
            Init_RadSlider_Upkeep(iVisualUpkeepPourcent);
            Init_RadSlider_InvestedTime(iVisualUpkeepPourcent);

            Init_RadSlider_Upkeep_100();
            Init_RadSlider_Upkeep_Detail(iTimeTotal);

            Init_RadSlider_InvestedTime_Detail_100();
            Init_RadSlider_InvestedTime_Detail();
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

        public void Init_RadSlider_Time()
        {
            //RadSlider1.Value = 50;
            //RadSlider1.SelectedRegionStartValue = 0;
            RadSlider_Time.MinimumValue = 0;
            RadSlider_Time.MaximumValue = 100;
            RadSlider_Time.LargeChange = 10;
            
            RadSlider_Time.IsSelectionRangeEnabled = true;
            RadSlider_Time.SelectionStart = 0;
            RadSlider_Time.SelectionEnd = 100;
        }

        public void Init_RadSlider_Upkeep(int iVisualUpkeepPourcent)
        {
            RadSlider_Upkeep.MinimumValue = 0;
            RadSlider_Upkeep.MaximumValue = 100;
            RadSlider_Upkeep.LargeChange = 10;

            RadSlider_Upkeep.IsSelectionRangeEnabled = true;
            RadSlider_Upkeep.SelectionStart = 0;
            RadSlider_Upkeep.SelectionEnd = iVisualUpkeepPourcent;
        }

        public void Init_RadSlider_InvestedTime(int iVisualUpkeepPourcent)
        {
            RadSlider_InvestedTime.MinimumValue = 0;
            RadSlider_InvestedTime.MaximumValue = 100;
            //RadSlider_InvestedTime.Value = 50;
            RadSlider_InvestedTime.LargeChange = 10;
            //RadSlider_InvestedTime.SelectedRegionStartValue = 0;

            RadSlider_InvestedTime.IsSelectionRangeEnabled = true;
            RadSlider_InvestedTime.SelectionStart = iVisualUpkeepPourcent;
            RadSlider_InvestedTime.SelectionEnd = 100;
        }

        public void Init_RadSlider_Upkeep_100()
        {
            RadSlider_Upkeep_Detail_100.MinimumValue = 0;
            RadSlider_Upkeep_Detail_100.MaximumValue = 100;
            RadSlider_Upkeep_Detail_100.LargeChange = 10;

            RadSlider_Upkeep_Detail_100.IsSelectionRangeEnabled = true;
            RadSlider_Upkeep_Detail_100.SelectionStart = 0;
            RadSlider_Upkeep_Detail_100.SelectionEnd = 100;
        }

        public void Init_RadSlider_Upkeep_Detail(int iTimeTotal)
        {

            //For each Skill with at least 1 xp, split in % from iTimeUpkeep
            //ex.
            //Skill 1 : 57xp / iTimeTotal
            //Skill 2 : 38xp / iTimeTotal
            //Skill 3 : 21xp / iTimeTotal

            //RadSlider_Upkeep_Detail_Skill_1
            RadSlider_Upkeep_Detail_Skill_1.MinimumValue = 0;
            RadSlider_Upkeep_Detail_Skill_1.MaximumValue = 100;
            RadSlider_Upkeep_Detail_Skill_1.LargeChange = 10;

            RadSlider_Upkeep_Detail_Skill_1.IsSelectionRangeEnabled = true;
            RadSlider_Upkeep_Detail_Skill_1.SelectionStart = 0;
            RadSlider_Upkeep_Detail_Skill_1.SelectionEnd = 33;

            //RadSlider_Upkeep_Detail_Skill_2
            RadSlider_Upkeep_Detail_Skill_2.MinimumValue = 0;
            RadSlider_Upkeep_Detail_Skill_2.MaximumValue = 100;
            RadSlider_Upkeep_Detail_Skill_2.LargeChange = 10;

            RadSlider_Upkeep_Detail_Skill_2.IsSelectionRangeEnabled = true;
            RadSlider_Upkeep_Detail_Skill_2.SelectionStart = 33;
            RadSlider_Upkeep_Detail_Skill_2.SelectionEnd = 66;

            //RadSlider_Upkeep_Detail_Skill_3
            RadSlider_Upkeep_Detail_Skill_3.MinimumValue = 0;
            RadSlider_Upkeep_Detail_Skill_3.MaximumValue = 100;
            RadSlider_Upkeep_Detail_Skill_3.LargeChange = 10;

            RadSlider_Upkeep_Detail_Skill_3.IsSelectionRangeEnabled = true;
            RadSlider_Upkeep_Detail_Skill_3.SelectionStart = 66;
            RadSlider_Upkeep_Detail_Skill_3.SelectionEnd = 100;
        }

        public void Init_RadSlider_InvestedTime_Detail_100()
        {
            RadSlider_InvestedTime_Detail_100.MinimumValue = 0;
            RadSlider_InvestedTime_Detail_100.MaximumValue = 100;
            RadSlider_InvestedTime_Detail_100.LargeChange = 10;

            RadSlider_InvestedTime_Detail_100.IsSelectionRangeEnabled = true;
            RadSlider_InvestedTime_Detail_100.SelectionStart = 0;
            RadSlider_InvestedTime_Detail_100.SelectionEnd = 100;
        }

        public void Init_RadSlider_InvestedTime_Detail()
        {
            //RadSlider_Upkeep_Detail_Skill_1
            RadSlider_InvestedTime_Detail_Skill_1.MinimumValue = 0;
            RadSlider_InvestedTime_Detail_Skill_1.MaximumValue = 100;
            RadSlider_InvestedTime_Detail_Skill_1.LargeChange = 10;

            RadSlider_InvestedTime_Detail_Skill_1.IsSelectionRangeEnabled = true;
            RadSlider_InvestedTime_Detail_Skill_1.SelectionStart = 0;
            RadSlider_InvestedTime_Detail_Skill_1.SelectionEnd = 33;

            //RadSlider_Upkeep_Detail_Skill_2
            RadSlider_InvestedTime_Detail_Skill_2.MinimumValue = 0;
            RadSlider_InvestedTime_Detail_Skill_2.MaximumValue = 100;
            RadSlider_InvestedTime_Detail_Skill_2.LargeChange = 10;

            RadSlider_InvestedTime_Detail_Skill_2.IsSelectionRangeEnabled = true;
            RadSlider_InvestedTime_Detail_Skill_2.SelectionStart = 33;
            RadSlider_InvestedTime_Detail_Skill_2.SelectionEnd = 66;

            //RadSlider_Upkeep_Detail_Skill_3
            RadSlider_InvestedTime_Detail_Skill_3.MinimumValue = 0;
            RadSlider_InvestedTime_Detail_Skill_3.MaximumValue = 100;
            RadSlider_InvestedTime_Detail_Skill_3.LargeChange = 10;

            RadSlider_InvestedTime_Detail_Skill_3.IsSelectionRangeEnabled = true;
            RadSlider_InvestedTime_Detail_Skill_3.SelectionStart = 66;
            RadSlider_InvestedTime_Detail_Skill_3.SelectionEnd = 100;
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