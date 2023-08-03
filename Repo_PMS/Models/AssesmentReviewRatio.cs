using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class AssesmentReviewRatio
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int AssesmentRatio { get; set; }
        [Required]
        public int ReviewRatio { get; set; }

        [Required]
        [StringLength(4)]
        [RegularExpression(@"[0-9]+")]
        public string Year { get; set; }

        public DateTime createdDate { get; set; }








    }
}
