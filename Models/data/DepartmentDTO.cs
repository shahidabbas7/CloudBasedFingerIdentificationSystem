using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.data
{
    [Table("Departmenttbl")]
    public class DepartmentDTO
    {
        [Key]
        public int deptcode { get; set; }
        public string parentdeptcode { get; set; }
        public string deptname { get; set; }
        public string shortdescription { get; set; }
        public string depthead { get; set; }
        public int approvedsalary { get; set; }
        public string division { get; set; }
        public string salarygroup { get; set; }
        public string email { get; set; }
        public string leaveapprovedlevel { get; set; }
        public string primaryreportsto { get; set; }
        public string secondaryreportsto { get; set; }
        public int? employeeid { get; set; }
        public string DivisionCode { get; set; }
        [ForeignKey("DivisionCode")]
        public virtual DivisionDTO divisions { get; set; }


    }
    }