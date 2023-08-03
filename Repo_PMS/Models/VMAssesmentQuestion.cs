using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class VMAssesmentQuestion
    {
        public Question Question{ get; set; }

        public List<Department> ? DepartmentList{ get; set; } 

        public List<Degination> ? DeginationsList{ get; set; }

        public List<Question>? questions { get; set; }



    }
}
