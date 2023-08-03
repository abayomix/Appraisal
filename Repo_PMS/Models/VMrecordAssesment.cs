using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class VMrecordAssesment
    {
        public Question Question { get; set; }
        public string EMPID { get; set; }
        public string EMPNAme { get; set; }

        public int ASID { get; set; }
        public int  NumberOfQuestion { get; set; }
        public int QuestionNo { get; set; }

        public string AssesmentName { get; set; }
        public AssesmentResponse AR { get; set; }

        public List<assesment> assesments { get; set; }








    }
}
