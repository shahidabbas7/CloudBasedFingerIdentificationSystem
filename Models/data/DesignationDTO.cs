using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.data
{
    [Table("Designationtbl")]
    public class DesignationDTO
    {
        [Key]
        public int desigcode { get; set; }
        public string designame { get; set; }
        public string rank { get; set; }
        public string Reports_to { get; set; }
        public int? employeeid { get; set; }

    }
}