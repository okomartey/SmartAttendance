using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
              
        
        protected void AddNewStudent_click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewStudent.aspx");
        }
    }
}