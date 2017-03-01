using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DA = AMS.DataAccess;




namespace AMS
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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

        public class Database
        {
            public static string ConnectionString
            {
                get
                {
                    return WebConfigurationManager.ConnectionStrings["AttendanceConnectionString"].ConnectionString;
                }
            }
        }
        

        
    }
}