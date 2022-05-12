using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.data
{
    [Table("Divisiontbl")]
    public class DivisionDTO
    {
        [Key]
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
    }
}