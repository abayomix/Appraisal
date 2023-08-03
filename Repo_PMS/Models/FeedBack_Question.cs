using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class FeedBack_Question
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public DateTime createdDate { get; set; }

        public string? ModifiedBY { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? CreatedBY { get; set; }


    }
}
