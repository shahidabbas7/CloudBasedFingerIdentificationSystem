using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.data
{
    public class contextdb:DbContext
    {
        public DbSet<DesignationDTO> designations { get; set; }
        public DbSet<DepartmentDTO> departments { get; set; }
        public DbSet<PolicyDTO> policy { get; set; }
        public DbSet<DivisionDTO> division { get; set; }
        public DbSet<HostelDTO> Hostels { get; set; }
    }
}