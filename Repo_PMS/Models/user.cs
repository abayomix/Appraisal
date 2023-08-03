using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class user
    {

        public string userid { get; set; }
        public string name { get; set; }
        public string empId { get; set; }
        public string role { get; set; }
        public string IsVAliduser { get; set; }
        public string pwdchgstatus { get; set; }
        public string utype { get; set; }

        public string udeg { get; set; }

        public string udept { get; set; }

        public int response { get; set; }

    }
}
