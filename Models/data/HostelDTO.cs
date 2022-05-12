using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.data
{
    [Table("hosteltbl")]
    public class HostelDTO
    {
        [Key]
        public int Hostelid { get; set; }
        public string HostelName { get; set; }
        public string Warden { get; set; }
        public string Phone { get; set; }
    }
}