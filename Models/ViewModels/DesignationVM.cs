using CloudBasedFingerIdentificationSystem.Models.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.ViewModels
{
    public class DesignationVM
    {
        public DesignationVM()
        {
                
        }
        public DesignationVM(DesignationDTO dto)
        {
            desigcode = dto.desigcode;
            designame = dto.designame;
            rank = dto.rank;
            Reports_to = dto.Reports_to;
            employeeid = dto.employeeid;
        }
        [Display(Name ="Designation Code")]
        [Required]
        public int desigcode { get; set; }
        [Display(Name = "Designation Name")]
        [Required]
        public string designame { get; set; }
        [Display(Name = "Rank")]
        public string rank { get; set; }
        [Display(Name = "Reports To")]
        public string Reports_to { get; set; }
        public int? employeeid { get; set; }


    }
}