using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class Feedback
    {
        [Key]
        public int ID { get; set; }

        public string FQID { get; set; }

        public int score { get; set; }
        
        public string empid { get; set; }


        [Required]
        public DateTime createdDate { get; set; }

        public string? ModifiedBY { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? CreatedBY { get; set; }




    }
}
