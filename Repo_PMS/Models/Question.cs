using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class Question
    {
        [Key]
        public int Qid { get; set; }
        [Required]
        public string Question_Text { get; set; }

        [Required]
        public string option_1 { get; set; }

        [Required]
        public string option_2 { get; set; }
        
        [Required]
        public string option_3 { get; set; }
        [Required] 
        public string option_4 { get; set; }

        [Required]
        public int Correct { get; set; }

        [Required] 
        public int DeptID { get; set; }

        [Required] 
        public int DegID { get; set; }

        public DateTime createdDate { get; set; }

        public string ? ModifiedBY { get; set; }

        public DateTime ? ModifiedDate { get; set; }

        public string ? CreatedBy { get; set; }

        [NotMapped]
        public bool selected { get; set; }







    }
}
