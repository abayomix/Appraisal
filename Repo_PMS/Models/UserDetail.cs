using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class UserDetail
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "User Id ")]
        public string UserID { get; set; }
        
        [Display(Name = "Password")]
        public string ? Password { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Employee ID")]
        public string EmpID { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Role")]
        public int RoleID { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DeptID { get; set; }

        [Required]
        [Display(Name = "Degination")]
        public int DeginationID { get; set; }


        [Required]
        [Display(Name = "Manager")]
        public string ManagerID { get; set; }


        public string ? CreatedBy { get; set; }
        
        public DateTime ?CreatedDate { get; set; }
        public string ? ModifiedBy { get; set; }
        public DateTime ? ModifiedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public DateTime ? PasswordChangeDate { get; set; }



    }
}
