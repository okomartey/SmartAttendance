using System;
using System.Web.UI;

namespace AttandanceProject
{
    public partial class searchstudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GridView1.Visible = false;
            else
                GridView1.Visible = true;
        }
    }
}