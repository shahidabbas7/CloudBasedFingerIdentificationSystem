using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.data
{
    [Table("policytbl")]
    public class PolicyDTO
    {
        [Key]
        public int Policyid { get; set; }
        public string PolicyName { get; set; }
    }
}