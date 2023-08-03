using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class QuestionSet
    {
        [Key]
        public int id { get;set;}
        public int AssesmentID { get; set; }
        public string AssesmentYear { get; set; }
        public string AssesmentCategory { get; set; }
        public string ? QuestionID { get; set; }
        public int Dept { get; set; }
        public int Deg { get; set; }
        public DateTime createdDate { get; set; }

        public string? ModifiedBY { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? CreatedBy { get; set; }





    }
}
