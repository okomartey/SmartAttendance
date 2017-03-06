using System;
using System.Data;
using AttandanceProject.DataAccess;

namespace AttandanceProject
{
    public partial class AssignTimeTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AssignId = Request.QueryString["AssignId"];

                if (string.IsNullOrEmpty(AssignId))
                {
                    //Add new subject

                    //LoadStaffGrid(0);
                }
                else
                {
                  
                    int id = 0;
                    int.TryParse(AssignId, out id);
                    if (id > 0)
                    {
                        TimeTableIdHiddenField.Value = AssignId;
                                           
                        SlblMsg.Text = " Assigned successfully";


                    }
                    else
                    {
                        throw new InvalidOperationException("Error Assgining!!");
                    }
                }
            }
        }

        protected void Assign_Click(object sender, EventArgs e)
        {


            int AssignId = 0;
            int.TryParse(TimeTableIdHiddenField.Value, out AssignId);

            schedule sch = new schedule();
                     

            sch.fcode = DropDownList7.Text;
            sch.weekno = int.Parse(DropDownList5.Text);
            sch.period = int.Parse(DropDownList3.Text);
            sch.bcode = int.Parse(DropDownList1.Text);
            sch.scode = int.Parse(DropDownList6.Text);




            sch.Id = AssignId;

            Manager.AssignTimeTable(sch);

            Response.Redirect(String.Format("AssignTimeTable.aspx?AssignId={0}", sch.Id));
          
        }


       
    }

}