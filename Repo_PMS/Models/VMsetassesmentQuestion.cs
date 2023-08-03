using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class VMsetassesmentQuestion
    {
       
        
        public QuestionSet Questionset { get; set; }
        public List<Question> ? questions { get; set; }
        public List<Department> ? departments { get; set; }

        public List<Degination> ? deginations { get; set; }

        public List<assesment>?lstAssements { get; set; }


    }
}
