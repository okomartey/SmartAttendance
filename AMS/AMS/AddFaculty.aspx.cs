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
    public partial class AddFaculty : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                    GridView1.Visible = false;
                else
                    GridView1.Visible = true;
                                             
            }

            protected void btnSearch_Click(object sender, EventArgs e)
            {
                string qry = FacultyCreate.AddFaculty(FcodeBox.Text, PwdBox.Text, FnameBox.Text, FdeptBox.Text);
                if (qry==null)
                FlblMsg.Text = "You have successfully created a new faculty";
                else
                {
                    FlblMsg.Text = "Sorry! New Facility wasnt created";
                }
            }


            public class FacultyCreate
            {
                public static string AddFaculty(string fcode, string pwd,string fname,string dept)
                {
                    SqlConnection con = new SqlConnection(Database.ConnectionString);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Insert into faculty values (@fcode,@pwd,@fname,@dept)", con);
                        cmd.Parameters.Add("@pwd", SqlDbType.VarChar).Value = pwd;
                        cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                        cmd.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept;
                        cmd.Parameters.Add("@fcode", SqlDbType.VarChar, 10).Value = fcode;
                       int rows = cmd.ExecuteNonQuery(); ;
                       if (rows == 1)
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