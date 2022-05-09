using CloudBasedFingerIdentificationSystem.Models.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.ViewModels
{
    public class PolicyVM
    {
        public PolicyVM()
        {
                
        }
        public PolicyVM(PolicyDTO dto)
        {
            Policyid = dto.Policyid;
            PolicyName = dto.PolicyName;
        }
        [Display(Name ="Policy Id")]
        public int Policyid { get; set; }
        [Display(Name = "Policy Name")]
        [Required]
        public string PolicyName { get; set; }
    }
}