using AMS.DataAccess;
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
            if (!IsPostBack)
            {
                string SubjectId = Request.QueryString["SubjectId"];

                if (string.IsNullOrEmpty(SubjectId))
                {
                    //Add new subject

                    //LoadStaffGrid(0);
                }
                else
                {
                    //Load existing subject details
                    int id = 0;
                    int.TryParse(SubjectId, out id);
                    if (id > 0)
                    {
                        StudentIdHiddenField.Value = SubjectId;

                        SubjectGrid.DataSource = Manager.GetAllSubjects();
                        SubjectGrid.DataBind();
                        SlblMsg.Text = " New Subject was created successfully";
                   
                      
                    }
                    else
                    {
                        throw new InvalidOperationException("Staff Id couldn't recognize.");
                    }
                }
            }
        }

        protected void AddNewDate_Click(object sender, EventArgs e)
        {


            int SubjectId = 0;
            int.TryParse(StudentIdHiddenField.Value, out SubjectId);

            subject obj = new DataAccess.subject();
            obj.sname = SubNameTextBox.Text;
            obj.scode = SubCodeTextBox.Text;
            obj.Id = SubjectId;

            Manager.InsertSubjects(obj);

            Response.Redirect(String.Format("AddSubjects.aspx?SubjectId={0}", obj.Id));
            AddNewRowToGrid();


        }


        private void AddNewRowToGrid()
        {
            DataTable dt = new DataTable();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("sname");
            }

            DataRow newrow = dt.NewRow();

            dt.Rows.Add(newrow);
            SubjectGrid.DataSource = dt;
            SubjectGrid.DataBind();
        }
    }
}