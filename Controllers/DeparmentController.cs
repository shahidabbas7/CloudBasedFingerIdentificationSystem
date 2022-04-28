using CloudBasedFingerIdentificationSystem.Models.data;
using CloudBasedFingerIdentificationSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudBasedFingerIdentificationSystem.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Deparment//departments
        public ActionResult Departments()
        {
            //declare dept vm list
            List<DepartmentVM> departmentslist;
            //init deptvmlist 
            using(contextdb db=new contextdb())
            {
                departmentslist = db.departments.ToArray().Select(x => new DepartmentVM(x)).ToList();
            }
            return View(departmentslist);
        }
        // GET: Deparment//departments
        public ActionResult adddepartments()
        {
            DepartmentVM model = new DepartmentVM();
            return View(model);
        }
        [HttpPost]
        // POST: Deparment//departments
        public ActionResult adddepartments(DepartmentVM model)
        {
            //check model validity
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //init dto 
            using(contextdb db=new contextdb())
            {
                //declare department dto
                DepartmentDTO dto=new DepartmentDTO();
                //check if the department name already exist
                if (db.departments.Any(x => x.deptname == model.deptname))
                {
                    ModelState.AddModelError("depterrorn", "Department Name " + model.deptname + " Already exist");
                    return View(model);
                }
                //check if deptcode exist
                if (db.departments.Any(x => x.deptcode == model.deptcode))
                {
                    ModelState.AddModelError("depterrorc", "Department code " + model.deptcode + " Already exist");
                    return View(model);
                }
                //add to dto
                dto.deptcode = model.deptcode;
                dto.deptname = model.deptname;
                dto.parentdeptcode = model.parentdeptcode;
                dto.depthead = model.depthead;
                dto.shortdescription = model.shortdescription;
                dto.approvedsalary = model.approvedsalary;
                dto.email = model.email;
                dto.division = model.division;
                dto.leaveapprovedlevel = model.leaveapprovedlevel;
                dto.salarygroup = model.salarygroup;
                dto.primaryreportsto = model.primaryreportsto;
                dto.secondaryreportsto = model.secondaryreportsto;
                db.departments.Add(dto);
                //save changes to database
                db.SaveChanges();
            }
            //set temp message
            TempData["SM"] = "Department Successfully Added";
            return RedirectToAction("Departments");
        }
        // GET: Deparment//DeleteDeparments
        public ActionResult DeleteDeparments(int id)
        {
            //delete department
            using(contextdb db=new contextdb())
            {
                //get dto
                DepartmentDTO dto = db.departments.Find(id);
                db.departments.Remove(dto);
                db.SaveChanges();
            }
            return RedirectToAction("Departments");
        }
    }
}