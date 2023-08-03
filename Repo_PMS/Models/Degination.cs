﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_PMS.Models
{
    public class Degination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DeginationName { get; set; }
        [Required]
        [StringLength(100)]
        public string D_Description { get; set; }

        public DateTime ? CreateDate { get; set; }

        public string ? CreatedBy { get; set; }





    }
}
