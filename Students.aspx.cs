﻿using System;

namespace AttandanceProject
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddNewStudent_click(object sender, EventArgs e)
        {
            Response.Redirect("NewStudent.aspx");
        }
    }
}