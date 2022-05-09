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
        // GET: Deparment//EditDepartments
        public ActionResult EditDepartments(int id)
        {
            //declare departmentvm
            DepartmentVM model;
            using(contextdb db=new contextdb())
            {
                //init department dto
                DepartmentDTO dto = db.departments.Find(id);
                //init departmentvm
                model = new DepartmentVM(dto);
            }
            return View(model);
        }
        [HttpPost]
        // POST: Deparment//EditDepartments
        public ActionResult EditDepartments(DepartmentVM model)
        {
            //check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //init department dto
            using (contextdb db=new contextdb())
            { 
                //declare department dto
                DepartmentDTO dto = db.departments.Find(model.deptcode);
                //check if the department name already exist
                if (db.departments.Where(x=>x.deptcode!=model.deptcode).Any(x => x.deptname == model.deptname))
                {
                    ModelState.AddModelError("depterrorn", "Department Name " + model.deptname + " Already exist");
                    return View(model);
                }
                //check if deptcode exist
                if (db.departments.Where(x=>x.deptcode!=model.deptcode).Any(x => x.deptcode == model.deptcode))
                {
                    ModelState.AddModelError("depterrorc", "Department code " + model.deptcode + " Already exist");
                    return View(model);
                }
                //set dto
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
                //save changes to database
                db.SaveChanges();
            }
            //set temp message
            TempData["SM"] = "Department Successfully Updated";
            return RedirectToAction("Departments");

        }
        // get: Deparment//policy
        public ActionResult policy()
        {
            //declare policy vmlist
            List<PolicyVM> policylist;
            //init policy vmlist
            using(contextdb db=new contextdb())
            {
                policylist = db.policy.ToArray().Select(x => new PolicyVM(x)).ToList();
            }
            //return view with list
            return View(policylist);
        }
        // get: Deparment//addpolicy
        public ActionResult addpolicy()
        {
            PolicyVM model = new PolicyVM();
            return View(model);
        }
        // POST: Deparment//addpolicy
        [HttpPost]
        public ActionResult addpolicy(PolicyVM model)
        {
            //check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //init dto
            using(contextdb db=new contextdb())
            {
                //declare policy dto
                PolicyDTO dto = new PolicyDTO();
                //check if the policy name already exist
                if (db.policy.Any(x => x.PolicyName == model.PolicyName))
                {
                    ModelState.AddModelError("policyerrorn", "Policy Name " + model.PolicyName + " Already exist");
                    return View(model);
                }
                //add to dto
                dto.Policyid = model.Policyid;
                dto.PolicyName = model.PolicyName;
                db.policy.Add(dto);
                //save changes to database
                db.SaveChanges();

            }
            //set success message
            TempData["SM"] = "Policy Successfully Added";
            return RedirectToAction("policy");
        }
        // get: Deparment//editpolicy
        public ActionResult editpolicy(int id)
        {
            //declare policy model
            PolicyVM model;
            using(contextdb db=new contextdb())
            {
                //init policydto
                PolicyDTO dto = db.policy.Find(id);
                //init policy model
                model = new PolicyVM(dto);
            }
            //return view with model
            return View(model);
        }
        // POST: Deparment//editpolicy
        [HttpPost]
        public ActionResult editpolicy(PolicyVM model)
        {
            //check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using(contextdb db=new contextdb())
            {
                //init policydto
                PolicyDTO dto = db.policy.Find(model.Policyid);
                //check if the policy name exist
                if (db.policy.Where(x => x.Policyid != model.Policyid).Any(x => x.PolicyName == model.PolicyName))
                {
                    ModelState.AddModelError("policyerrorn", "Policy Name " + model.PolicyName + " Already exist");
                    return View(model);
                }
                //set dto
                dto.Policyid = model.Policyid;
                dto.PolicyName = model.PolicyName;
                db.SaveChanges();
            }
            //set temp message
            TempData["SM"] = "Policy Successfully Updated";
            return RedirectToAction("policy");
        }
        // POST: Deparment//deletepolicy
        public ActionResult deletepolicy(int id)
        {
            //delete the selected policy
            using(contextdb db=new contextdb())
            {
                //init policydto
                PolicyDTO dto = db.policy.Find(id);
                //remove policy
                db.policy.Remove(dto);
                //save changes to db
                db.SaveChanges();
            }
            //redirect to view
            return RedirectToAction("policy");
        }

    }
}