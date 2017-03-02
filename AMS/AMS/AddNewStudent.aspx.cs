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
            student.bcode = Int32.Parse(SemBox.Text);


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

   
}
