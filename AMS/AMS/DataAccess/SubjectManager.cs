using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.DataAccess
{
    public class SubjectManager
    {
        public static List<subject> GetAllSubjects()
        {
            List<subject> subjects = new List<subject>();
            using (AttandanceContextDataContext coxtext = new AttandanceContextDataContext())
            {
                subjects = coxtext.subjects.ToList();
            }

            return subjects;
        }
    }
}