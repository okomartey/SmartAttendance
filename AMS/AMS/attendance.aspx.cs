using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DA = AMS.DataAccess;


namespace AMS
{
    public partial class attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string AttendId = Request.QueryString["AttendId"];
                lblToday.Text = DateTime.Now.ToShortDateString();
                lblWeekno.Text = Request.QueryString["weekno"];
                lblPeriod.Text = Request.QueryString["period"];
                lblSemister.Text = Request.QueryString["semister"];

                //int weekno = Int32.Parse(Request.QueryString["weekno"]);
                //if (((int)DateTime.Now.DayOfWeek) != weekno)
                //{
                //    Response.Write("<h4>Sorry! Today is NOT the week you selected. Please use Back button of browser and try again!</h4>");
                //    Response.End();
                //}
                //else
                //{
                    int id = 0;
                    int.TryParse(AttendId, out id);
                    if (id > 0)
                    {
                        AttendIdHiddenField.Value = AttendId;

                        LoadAttendanceById(id);
                        lblMsg.Text = "Attendance stored successfully!";
                        //LoadDateGrid(id);
                    }
              //  }
             
            }
       
        }
   

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            int attendId = 0;
            int.TryParse(AttendIdHiddenField.Value, out attendId);
            DA.attendance obj = new DataAccess.attendance();

            string status, remarks;
            obj.adate = Convert.ToDateTime(lblToday.Text);
            obj.weekno = Int32.Parse(lblWeekno.Text);
            obj.period = Int32.Parse(lblPeriod.Text);
            obj.fcode = Session["fcode"].ToString();
           

          

            RadioButton rb;
            foreach (GridViewRow r in GridView1.Rows)
            {
                remarks = "";
                status = "l";
                rb = (RadioButton)r.FindControl("rbPresent");
                if (rb.Checked)
                    status = "p";
                else
                {
                    rb = (RadioButton)r.FindControl("rbAbsent");
                    if (rb.Checked)
                        status = "a";
                    else
                    {
                        TextBox t = (TextBox)r.FindControl("txtRemarks");
                        remarks = t.Text;
                    }
                }
                obj.admno = Int32.Parse(r.Cells[0].Text);
                obj.status = Convert.ToChar(status);
                obj.remarks = remarks;


                DA.Manager.InsertAttendance(obj);
                       
            }
            Response.Redirect(String.Format("attendance.aspx?AttendId={0}", obj.admno));
        }

             private void LoadAttendanceById(int id)
        {
            var attendid = DA.Manager.GetAttendanceById(id);
            lblToday.Text =  Convert.ToString(attendid.adate);
            lblWeekno.Text = Convert.ToString(attendid.weekno);
            lblPeriod.Text = Convert.ToString(attendid.period);
           
        }

     
        
    }
}