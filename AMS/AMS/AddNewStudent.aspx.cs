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
using DA = AMS.DataAccess;

namespace AMS
{
    public partial class AddNewStudent : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                string StudentId = Request.QueryString["StudentId"];

                if (string.IsNullOrEmpty(StudentId))
                {
                    //Add new subject
                    
                    //LoadStaffGrid(0);
                }
                else
                {
                    //Load existing subject details
                    int id = 0;
                    int.TryParse(StudentId, out id);
                    if (id > 0)
                    {
                        StudentIdHiddenField.Value = StudentId;

                        LoadStudentById(id);
                        SlblMsg.Text = " New Student wasnt created successfully";
                        //LoadDateGrid(id);
                    }
                    else
                    {
                        throw new InvalidOperationException("Staff Id couldn't recognize.");
                    }
                }
           }
        }

        protected void AddStudent_Click(object sender, EventArgs e)

        {
             int studentId = 0;
            int.TryParse(StudentIdHiddenField.Value, out studentId);

            DA.student student = new DataAccess.student();
            student.fname = FnameBox.Text;
            student.Surname = SnameBox.Text;
            student.bcode =Int32.Parse(SemBox.Text);
          

            if (studentId > 0)
            {
                student.admno = studentId;

                DA.Manager.UpdateStudent(student);
            }
            else
            {
                DA.Manager.InsertStudent(student);
            }

            //After insert, redirect to update page
            Response.Redirect(String.Format("AddNewStudent.aspx?StudentId={0}", student.admno));

        }



        private void LoadStudentById(int id)
        {
            var student = DA.Manager.GetStudentById(id);
            FnameBox.Text = student.fname;
            SnameBox.Text = student.Surname;
            SemBox.Text = Convert.ToString(student.bcode);
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
