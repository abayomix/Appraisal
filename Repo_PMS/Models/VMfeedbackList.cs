using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class VMfeedbackList
    {
        public string? mgrEmpID { get; set; }
        public string ? reviewname { get; set; }

        public string? EmpID { get; set; }

        public string ?EmpName { get; set; }

        public List<FeedBack_Question> ?lstfbQuestion { get; set; }

        public List<Feedback> ? lstfeedback { get; set; }
        public List<UsersDLVM>?  lstreporties {get; set;}



    }
}
