using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class Review
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ReviewName { get; set; }

        public string ReviewYear { get; set; }

        [StringLength(50)]
        public string ReviewCategory { get; set; }

        [Required]
        [StringLength(100)]
        public string review_Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime ? CreateDate { get; set; }

        public string ? CreatedBy { get; set; }

       




    }
}
