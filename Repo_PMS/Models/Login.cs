using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class Login
    {

        [Display(Name ="User ID")]
        public string UserID { get; set; }
        
        public string Password { get; set; }


    }
}
