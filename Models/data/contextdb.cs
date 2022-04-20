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
    }
}