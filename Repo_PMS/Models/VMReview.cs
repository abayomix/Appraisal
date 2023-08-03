using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class VMReview
    {

        public Review review { get; set; }  
        public List<Review>? lstReviews { get; set; }




    }
}
