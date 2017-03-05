using System;
using AttandanceProject.DataAccess;

namespace AttandanceProject
{
    public partial class Subjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SubjectGrid.DataSource = Manager.GetAllSubjects();
            SubjectGrid.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSubjects.aspx");
        }
    }
}