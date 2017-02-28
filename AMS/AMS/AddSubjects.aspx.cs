using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class AddSubjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void AddNewRowToGrid()
        {
            DataTable dt = new DataTable();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Date", typeof(DateTime));
            }

            DataRow newrow = dt.NewRow();
            
            dt.Rows.Add(newrow);
            SubjectDateGrid.DataSource = dt;
            SubjectDateGrid.DataBind();
        }

        protected void AddNewDate_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
    }
}