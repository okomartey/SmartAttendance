using System;
using DA = AttandanceProject.DataAccess;

namespace AttandanceProject
{
    public partial class AddNewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string staffId = Request.QueryString["StaffId"];

                if (string.IsNullOrEmpty(staffId))
                {
                    //Add new subject

                    //LoadStaffGrid(0);
                }
                else
                {
                    //Load existing subject details
                    int id = 0;
                    int.TryParse(staffId, out id);
                    if (id > 0)
                    {
                        StaffIdHiddenField.Value = staffId;

                         LoadStaffById(id);
                         SlblMsg.Text = " New Staff was created successfully";
                        //LoadDateGrid(id);
                    }
                    else
                    {
                        throw new InvalidOperationException("Staff Id couldn't recognize.");
                    }
                }
            }
        }

        protected void Addstaff_Click(object sender, EventArgs e)
        {
            int staffId = 0;
            int.TryParse(StaffIdHiddenField.Value, out staffId);

            DA.faculty staff = new DataAccess.faculty();
            staff.fname = SFnameBox.Text;
            staff.Surname = SSnameBox.Text;
            staff.dept = DeptTextBox.Text;
            staff.fcode = UnameBox.Text;
            staff.pwd = PwsdTextBox.Text;

            if (staffId > 0)
            {
                staff.admno = staffId;

                DA.Manager.UpdateStaff(staff);
            }
            else
            {
                DA.Manager.InsertStaff(staff);
            }

            //After insert, redirect to update page
            Response.Redirect(String.Format("AddNewStaff.aspx?StaffId={0}", staff.admno));

        }



        private void LoadStaffById(int id)
        {
            var staff = DA.Manager.GetStaffById(id);
            SFnameBox.Text = staff.fname;
            SSnameBox.Text = staff.Surname;
            DeptTextBox.Text = staff.dept;
        }

    


    }


}
