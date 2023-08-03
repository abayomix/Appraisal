using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class AssesmentResponse
    {
        [Key]
        public int ARID { get;set; }
        public int AssementID { get; set; }

        public int QID { get; set; }
        public int AnswerResponse { get;set;}

        public bool iscorrect { get; set; }
        public string Empid { get; set; }

        public DateTime createddate { get; set; }




    }
}
