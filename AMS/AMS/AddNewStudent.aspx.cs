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
using System.IO;

namespace AMS
{
    public partial class AddNewStudent : System.Web.UI.Page
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
            string qry = StudentCreate.AddNewStudent(FnameBox.Text,SnameBox.Text,SemBox.Text);
            if (qry == null)
                SlblMsg.Text = "You have successfully created a new Student";
            else
            {
                SlblMsg.Text = "Sorry! New Facility wasnt created";
            }
        }

        public class StudentCreate
        {
            public static string AddNewStudent(string fname, string sname,string semester)
            {
                SqlConnection con = new SqlConnection(Database.ConnectionString);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into students(fname,Surname,bcode) values (@fname,@Surname,@bcode)", con);
                    cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                    cmd.Parameters.Add("@Surname", SqlDbType.VarChar).Value = sname;
                    cmd.Parameters.Add("@bcode", SqlDbType.VarChar).Value = semester;
                    int rows = cmd.ExecuteNonQuery(); ;
                    return null;

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

        //protected void InsertImage_Click(object sender, EventArgs e)
        //{
        //    // Read the file and convert it to Byte Array
        //    string filePath = Server.MapPath("~\\App_Data\\US passport pic.jpg");
        //    string filename = Path.GetFileName(filePath);

        //    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fs);
        //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //    br.Close();
        //    fs.Close();

        //    //insert the file into database
        //    string strQuery = "insert into tblFiles(Name, ContentType, Data) values (@Name, @ContentType, @Data)";
        //    SqlCommand cmd = new SqlCommand(strQuery);
        //    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
        //    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = "image/jpeg";
        //    cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
        //    InsertUpdateData(cmd);
        //}

        //protected void Retreive_Image(object sender, EventArgs e)
        //{
        //    string strQuery = "select Name, ContentType, Data from tblFiles where id=@id";
        //    SqlCommand cmd = new SqlCommand(strQuery);
        //    cmd.Parameters.Add("@id", SqlDbType.Int).Value = 3;
        //    DataTable dt = GetData(cmd);
        //    if (dt != null)
        //    {
        //        download(dt);
        //    }
        //}

        //private Boolean InsertUpdateData(SqlCommand cmd)
        //{
        //    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["AttendanceConnectionString"].ConnectionString;
        //    SqlConnection con = new SqlConnection(strConnString);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }
        //}

        //private DataTable GetData(SqlCommand cmd)
        //{
        //    DataTable dt = new DataTable();
        //    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["AttendanceConnectionString"].ConnectionString;
        //    SqlConnection con = new SqlConnection(strConnString);
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con;
        //    try
        //    {
        //        con.Open();
        //        sda.SelectCommand = cmd;
        //        sda.Fill(dt);
        //        return dt;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        sda.Dispose();
        //        con.Dispose();
        //    }
        //}

        //private void download(DataTable dt)
        //{
        //    Byte[] bytes = (Byte[])dt.Rows[0]["Data"];
        //    Response.Buffer = true;
        //    Response.Charset = "";
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = dt.Rows[0]["ContentType"].ToString();
        //    Response.AddHeader("content-disposition", "attachment;filename="
        //    + dt.Rows[0]["Name"].ToString());
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.End();
        //}
    }
}