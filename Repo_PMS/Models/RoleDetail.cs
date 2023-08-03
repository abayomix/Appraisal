using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class RoleDetail
    {
        [Key]
        [Display(Name = "Roll ID")]
        public int RoleId { get; set; }

        [StringLength(50)]
        [RegularExpression(@"[A-Z a-z 0-9_-]+")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [StringLength(50)]
        [RegularExpression(@"[A-Z a-z]+")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Created Date")]
        public DateTime ? CreatedDate { get; set; }   







    }
}
