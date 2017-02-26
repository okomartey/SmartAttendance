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
                SqlConnection con = new SqlConnection(Database.ConnectionString);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select fname from faculty where fcode = @fcode and pwd = @pwd", con);
                    cmd.Parameters.Add("@fcode", SqlDbType.VarChar, 10).Value = fcode;
                    cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 10).Value = pwd;
                    Object fname = cmd.ExecuteScalar();
                    if (fname == null)
                        return null;
                    else
                        return fname.ToString();
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            //  returns null on sccess, error message on failure
            public static String ChangePassword(string fcode, string oldpwd, string newpwd)
            {
                SqlConnection con = new SqlConnection(Database.ConnectionString);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update faculty set pwd = @newpwd where fcode = @fcode and pwd = @oldpwd", con);
                    cmd.Parameters.Add("@fcode", SqlDbType.VarChar, 10).Value = fcode;
                    cmd.Parameters.Add("@oldpwd", SqlDbType.VarChar, 10).Value = oldpwd;
                    cmd.Parameters.Add("@newpwd", SqlDbType.VarChar, 10).Value = newpwd;
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        return null; // success
                    else
                        return "Sorry! Invalid Old Password";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
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