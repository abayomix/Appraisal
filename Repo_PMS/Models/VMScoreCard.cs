using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class VMScoreCard
    {

        public string UserID { get; set; }
        public string EmpID { get; set; }
        public string Name { get; set; }
        public decimal F_Score { get; set; }

        public decimal A_Score { get; set; }
        public decimal AggrScore { get; set; }



    }
}
