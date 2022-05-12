using CloudBasedFingerIdentificationSystem.Models.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.ViewModels
{
    public class HostelVM
    {
        public HostelVM()
        {
                
        }
        public HostelVM(HostelDTO dto)
        {
            Hostelid = dto.Hostelid;
            HostelName = dto.HostelName;
            Warden = dto.Warden;
            Phone = dto.Phone;
        }
        public int Hostelid { get; set; }
        public string HostelName { get; set; }
        public string Warden { get; set; }
        public string Phone { get; set; }
    }
}