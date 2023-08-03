using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class VMScoreboard
    {
        public string year { get; set; }
        public int DeptID { get; set; }

        public int Degination {get; set; }

        public List<Department> ? lstdepartment { get; set; }
        public List<Degination> ? LstDegination { get; set; }

        public List<VMScoreCard> ? LstScoreCards { get; set; }



    }
}
