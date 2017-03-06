using System;
using System.Web.Security;
using DA = AttandanceProject.DataAccess;

namespace AttandanceProject
{
    public partial class login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {



            string fname = FacultyDAL.Login(txtFcode.Text, txtPwd.Text);
            if (fname == null)
                lblMsg.Text = "Sorry! Invalid Login! Try Again.";
            else
            {
                Session.Add("fcode", txtFcode.Text);
                Session.Add("fname", fname);
                FormsAuthentication.RedirectFromLoginPage
                    (txtFcode.Text, false);
            }

        }


        public class FacultyDAL
        {
            public static string Login(string fcode, string pwd)
            {

                var Isvalid = DA.Manager.GetLogin(fcode, pwd);

                if (Isvalid == null)
                { return null; }

                else { return Isvalid.fname; }

            }


        }
    }
}