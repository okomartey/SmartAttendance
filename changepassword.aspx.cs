﻿using System;
using AttandanceProject.DataAccess;

namespace AttandanceProject
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {

            int obj = 0;
            int.TryParse(ChangePwdIdHiddenField.Value, out obj);
            // txtNewpwd.Text
            string fname = FacultyDAL.ChangePassword(Session["fcode"].ToString(), txtOldpwd.Text);
            if (fname == null)
            {
                lblMsg.Text = "Sorry! Invalid OldPassword! Try Again.";
            }
            else
            {
                faculty staff = new DataAccess.faculty();
                staff.fcode = Session["fcode"].ToString();
                staff.pwd = txtNewpwd.Text;


                staff.admno = obj;

                Manager.UpdateLogin(staff);

                lblMsg.Text = "Password Changed Sucessfully!";


            }


        }


        public class FacultyDAL
        {
            public static string ChangePassword(string fcode, string pwd)
            {


                var Isvalid = Manager.GetLogin(fcode, pwd);

                if (Isvalid == null)
                { return null; }

                else { return Isvalid.fname; }

            }


        }
    }
}