using CloudBasedFingerIdentificationSystem.Models.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.ViewModels
{
    public class DivisionVM
    {
        public DivisionVM()
        {
                
        }
        public DivisionVM(DivisionDTO dto)
        {
            DivisionCode = dto.DivisionCode;
            DivisionName = dto.DivisionName;
        }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
    }
}