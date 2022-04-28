using CloudBasedFingerIdentificationSystem.Models.data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CloudBasedFingerIdentificationSystem.Models.ViewModels
{
    public class DepartmentVM
    {
        public DepartmentVM()
        {
                
        }
        public DepartmentVM(DepartmentDTO dept)
        {
            deptcode = dept.deptcode;
            parentdeptcode = dept.parentdeptcode;
            deptname = dept.deptname;
            shortdescription = dept.shortdescription;
            depthead = dept.depthead;
            approvedsalary = dept.approvedsalary;
            division = dept.division;
            salarygroup = dept.salarygroup;
            email = dept.email;
            leaveapprovedlevel = dept.leaveapprovedlevel;
            primaryreportsto = dept.primaryreportsto;
            secondaryreportsto = dept.secondaryreportsto;
            employeeid = dept.employeeid;
        }
        [Display(Name ="Department Code")]
        public int deptcode { get; set; }
        [Display(Name ="Parent Department Code")]
        public string parentdeptcode { get; set; }
        [Display(Name = "Department Name")]
        [Required]
        public string deptname { get; set; }
        [Display(Name = "Short Description")]
        [Required]
        public string shortdescription { get; set; }
        [Display(Name = "Department Head")]
        public string depthead { get; set; }
        [Display(Name = "Approved Salary")]
        [Required]
        public int approvedsalary { get; set; }
        [Display(Name = "Division")]
        public string division { get; set; }
        [Display(Name = "Salary Group")]
        public string salarygroup { get; set; }
        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Display(Name = "LeaveApprovedLevel")]
        public string leaveapprovedlevel { get; set; }
        [Display(Name = "Primary Reports To")]
        public string primaryreportsto { get; set; }
        [Display(Name = "Secondary Reports To")]
        public string secondaryreportsto { get; set; }
        public int? employeeid { get; set; }
    }
}