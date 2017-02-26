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


namespace AMS
{
    public partial class attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int weekno = Int32.Parse(Request.QueryString["weekno"]);
            if (((int)DateTime.Now.DayOfWeek) != weekno)
            {
                Response.Write("<h4>Sorry! Today is NOT the week you selected. Please use Back button of browser and try again!</h4>");
                Response.End();
            }
            lblToday.Text = DateTime.Now.ToShortDateString();
            lblWeekno.Text = Request.QueryString["weekno"];
            lblPeriod.Text = Request.QueryString["period"];
            lblSemister.Text = Request.QueryString["semister"];
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // get details from Gridview
            string status, remarks;
            SqlConnection con = new SqlConnection(Database.ConnectionString);
            SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand("insert into attendance values(@adate,@weekno,@period,@fcode,@admno,@status,@remarks)", con);
                cmd.Transaction = trans;

                cmd.Parameters.Add("@adate", SqlDbType.DateTime).Value = lblToday.Text;
                cmd.Parameters.Add("@weekno", SqlDbType.Int).Value = Int32.Parse(lblWeekno.Text);
                cmd.Parameters.Add("@period", SqlDbType.Int).Value = Int32.Parse(lblPeriod.Text);
                cmd.Parameters.Add("@fcode", SqlDbType.VarChar, 10).Value = Session["fcode"].ToString();

                cmd.Parameters.Add("@admno", SqlDbType.Int);
                cmd.Parameters.Add("@status", SqlDbType.Char, 1);
                cmd.Parameters.Add("@remarks", SqlDbType.VarChar, 50);

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
                    cmd.Parameters["@admno"].Value = r.Cells[0].Text;
                    cmd.Parameters["@status"].Value = status;
                    cmd.Parameters["@remarks"].Value = remarks;
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                lblMsg.Text = "Attendance stored successfully!";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                lblMsg.Text = "Error ->" + ex.Message;
            }
            finally
            {
                con.Close();
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