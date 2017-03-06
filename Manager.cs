using System.Collections.Generic;
using System.Linq;

namespace AttandanceProject.DataAccess
{
    public class Manager
    {
        public static List<subject> GetAllSubjects()
        {
            List<subject> subjects = new List<subject>();
            using (ASMDataContext context = new ASMDataContext())
            {
                subjects = context.subjects.ToList();
            }

            return subjects;
        }

    

        public static List<faculty> GetAllStaff()
        {
            List<faculty> staff = new List<faculty>();
            using (ASMDataContext context = new ASMDataContext())
            {
                staff = context.faculties.ToList();
            }

            return staff;
        }

        public static faculty GetLogin(string username, string password)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                var currentLogin = context.faculties.SingleOrDefault(x => x.fcode == username && x.pwd == password);

                return currentLogin;
            }
        }


        public static void UpdateLogin(faculty obj)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                var login = context.faculties.SingleOrDefault(x => x.admno == obj.admno);
                if (login != null)
                {
                    login.fcode = obj.fcode;
                    login.pwd = obj.pwd;
                    context.SubmitChanges();
                }
            }
        }

        public static void UpdateStaff(faculty staff)
        {
            using (ASMDataContext context = new ASMDataContext())
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
            using (ASMDataContext context = new ASMDataContext())
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

        public static void UpdateAttendance(attendance attendId)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                var dbStudent = context.attendances.SingleOrDefault(x => x.admno == attendId.admno);
                if (dbStudent != null)
                {
                    dbStudent.admno = attendId.admno;
                    dbStudent.period = attendId.period;
                    dbStudent.weekno = attendId.weekno;

                    context.SubmitChanges();
                }
            }
        }

        public static void InsertStaff(faculty staff)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                context.faculties.InsertOnSubmit(staff);
                context.SubmitChanges();
            }
        }

        public static void InsertSubjects(subject subj)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                context.subjects.InsertOnSubmit(subj);
                context.SubmitChanges();
            }
        }

        public static void AssignTimeTable(schedule sch)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                context.schedules.InsertOnSubmit(sch);
                context.SubmitChanges();
            }
        }

        public static void InsertStudent(student student)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                context.students.InsertOnSubmit(student);
                context.SubmitChanges();
            }
        }

        public static void InsertAttendance(attendance attendId)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                context.attendances.InsertOnSubmit(attendId);
                context.SubmitChanges();
            }
        }

        public static faculty GetStaffById(int id)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                var currentStaff = context.faculties.SingleOrDefault(x => x.admno == id);
                return currentStaff;
            }
        }

        public static student GetStudentById(int id)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                var currentStudent = context.students.SingleOrDefault(x => x.admno == id);
                return currentStudent;
            }
        }

        public static subject GetSubjectById(int id)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                var currentSubect = context.subjects.SingleOrDefault(x => x.Id == id);
                return currentSubect;
            }
        }



        public static attendance GetAttendanceById(int id)
        {
            using (ASMDataContext context = new ASMDataContext())
            {
                var currentAttendId = context.attendances.SingleOrDefault(x => x.Id == id);
                return currentAttendId;
            }
        }

        public static List<faculty> GetStaffByStaffId(int id)
        {
            List<faculty> staffList = new List<faculty>();
            using (ASMDataContext context = new ASMDataContext())
            {
                staffList = context.faculties.Where(x => x.admno == id).ToList();
            }

            return staffList;
        }

        public static List<student> GetStaffByStudentId(int id)
        {
            List<student> studentList = new List<student>();
            using (ASMDataContext context = new ASMDataContext())
            {
                studentList = context.students.Where(x => x.admno == id).ToList();
            }

            return studentList;
        }
    }
}