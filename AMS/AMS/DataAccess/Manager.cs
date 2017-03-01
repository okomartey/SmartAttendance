using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.DataAccess
{
    public class Manager
    {
        public static List<subject> GetAllSubjects()
        {
            List<subject> subjects = new List<subject>();
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                subjects = context.subjects.ToList();
            }

            return subjects;
        }

        public static faculty GetLogin(string username, string password)
        {
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                var currentLogin = context.faculties.SingleOrDefault(x => x.fcode == username && x.pwd == password);

                return currentLogin;
            }
        }

        public static void UpdateStaff(faculty staff)
        {
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                var dbStaff = context.faculties.SingleOrDefault(x => x.fname == staff.fname);
                if (dbStaff != null)
                {
                    dbStaff.fname = staff.fname;
                    dbStaff.Surname = staff.Surname;
                    dbStaff.dept = staff.dept;

                    context.SubmitChanges();
                }
            }
        }

        public static void UpdateStudent(student student)
        {
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                var dbStudent = context.students.SingleOrDefault(x => x.fname == student.fname);
                if (dbStudent != null)
                {
                    dbStudent.fname = student.fname;
                    dbStudent.Surname = student.Surname;
                    dbStudent.bcode = student.bcode;

                    context.SubmitChanges();
                }
            }
        }

        public static void InsertStaff(faculty staff)
        {
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                context.faculties.InsertOnSubmit(staff);
                context.SubmitChanges();
            }
        }

        public static void InsertStudent(student student)
        {
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                context.students.InsertOnSubmit(student);
                context.SubmitChanges();
            }
        }

        public static faculty GetStaffById(int id)
        {
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                var currentStaff = context.faculties.SingleOrDefault(x => x.admno == id);
                return currentStaff;
            }
        }

        public static student GetStudentById(int id)
        {
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                var currentStudent = context.students.SingleOrDefault(x => x.admno == id);
                return currentStudent;
            }
        }

        public static List<faculty> GetStaffByStaffId(int id)
        {
            List<faculty> staffList = new List<faculty>();
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                staffList = context.faculties.Where(x => x.admno == id).ToList();
            }

            return staffList;
        }

        public static List<student> GetStaffByStudentId(int id)
        {
            List<student> studentList = new List<student>();
            using (AttandanceContextDataContext context = new AttandanceContextDataContext())
            {
                studentList = context.students.Where(x => x.admno == id).ToList();
            }

            return studentList;
        }
    }
}