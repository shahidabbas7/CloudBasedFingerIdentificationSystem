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
            //get the lists from db
            using(contextdb db=new contextdb())
            {
                model.Divisions = new SelectList(db.division.ToList(), "DivisionCode", "DivisionName");
                model.Departments= new SelectList(db.departments.ToList(), "deptcode", "deptcode");
            }
            return View(model);
        }
        [HttpPost]
        // POST: Deparment//departments
        public ActionResult adddepartments(DepartmentVM model)
        {
            //check model validity
            if (!ModelState.IsValid)
            {
                using (contextdb db = new contextdb())
                {
                    model.Divisions = new SelectList(db.division.ToList(), "DivisionCode", "DivisionName");
                    model.Departments = new SelectList(db.departments.ToList(), "deptcode", "deptcode");
                }
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
                dto.DivisionCode = model.DivisionCode;
                DivisionDTO div = db.division.Find(model.DivisionCode);
                dto.division = div.DivisionName;
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
                //geting list of division
                model.Divisions = new SelectList(db.division.ToList(), "DivisionCode", "DivisionName");
                //getting list of dept
                model.Departments = new SelectList(db.departments.ToList(), "deptcode", "deptcode");
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
                using (contextdb db = new contextdb())
                {
                    //geting list of division
                    model.Divisions = new SelectList(db.division.ToList(), "DivisionCode", "DivisionName");
                    model.Departments = new SelectList(db.departments.ToList(), "deptcode", "deptcode");
                }
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
                dto.DivisionCode = model.DivisionCode;
                DivisionDTO div = db.division.Find( model.DivisionCode);
                dto.division = div.DivisionName;
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
        // get: Deparment//deletepolicy
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
        // get: Deparment//division
        public ActionResult division()
        {
            //declare division vmlist
            List<DivisionVM> divisionlist;
            //init policy vmlist
            using(contextdb db=new contextdb())
            {
                divisionlist = db.division.ToArray().Select(x => new DivisionVM(x)).ToList();
            }
            //return view with list
            return View(divisionlist);
        }
        // get: Deparment//adddivision
        public ActionResult adddivision()
        {
            DivisionVM model = new DivisionVM();
            return View(model);
        }
        // POST: Deparment//adddivision
        [HttpPost]
        public ActionResult adddivision(DivisionVM model)
        {
            //check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //init dto
            using(contextdb db=new contextdb())
            {
                //declare division dto
                DivisionDTO dto = new DivisionDTO();
                //check if the division name already exist
                if (db.division.Any(x => x.DivisionName == model.DivisionName))
                {
                    ModelState.AddModelError("divisionerrorn", "Division Name " + model.DivisionName + " Already exist");
                    return View(model);
                }
                //check if the division code already exist
                if (db.division.Any(x => x.DivisionCode == model.DivisionCode))
                {
                    ModelState.AddModelError("divisionerrorc", "Division Code " + model.DivisionCode + " Already exist");
                    return View(model);
                }
                //add to dto
                dto.DivisionCode = model.DivisionCode;
                dto.DivisionName = model.DivisionName;
                db.division.Add(dto);
                //save changes to database
                db.SaveChanges();

            }
            //set success message
            TempData["SM"] = "Division Successfully Added";
            return RedirectToAction("division");
        }
        // get: Deparment//editdivision
        public ActionResult editdivision(string id)
        {
            //declare division model
            DivisionVM model;
            using(contextdb db=new contextdb())
            {
                //init divisiondto
                DivisionDTO dto = db.division.Find(id);
                //init division model
                model = new DivisionVM(dto);
            }
            //return view with model
            return View(model);
        }
        // POST: Deparment//editpolicy
        [HttpPost]
        public ActionResult editdivision(DivisionVM model)
        {
            //check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using(contextdb db=new contextdb())
            {
                //init Divisiondto
                DivisionDTO dto = db.division.Find(model.DivisionCode);
                //check if the Division name exist
                if (db.division.Where(x => x.DivisionCode != model.DivisionCode).Any(x => x.DivisionName == model.DivisionName))
                {
                    ModelState.AddModelError("divisionerrorn", "Division Name " + model.DivisionName + " Already exist");
                    return View(model);
                }
                //set dto
                dto.DivisionCode = model.DivisionCode;
                dto.DivisionName = model.DivisionName;
                db.SaveChanges();
            }
            //set temp message
            TempData["SM"] = "division Successfully Updated";
            return RedirectToAction("division");
        }
        // POST: Deparment//deletepolicy
        public ActionResult deletedivision(string id)
        {
            //delete the selected policy
            using(contextdb db=new contextdb())
            {
                //init Divisiondto
                DivisionDTO dto = db.division.Find(id);
                //remove Division
                db.division.Remove(dto);
                //save changes to db
                db.SaveChanges();
            }
            //redirect to view
            return RedirectToAction("division");
        }
        // GET: Deparment//hostels
        public ActionResult hostels()
        {
            //declare hostel vm list
            List<HostelVM> hostelvmlist;
            //init hostelvmlist 
            using (contextdb db = new contextdb())
            {
                hostelvmlist = db.Hostels.ToArray().Select(x => new HostelVM(x)).ToList();
            }
            return View(hostelvmlist);
        }
        // GET: Deparment//addhostel
        public ActionResult addhostel()
        {
            HostelVM model = new HostelVM();
            return View(model);
        }
        // POST: Deparment//addhostel
        [HttpPost]
        public ActionResult addhostel(HostelVM model)
        {
            //check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //init dto
            using (contextdb db = new contextdb())
            {
                //declare hostel dto
                HostelDTO dto = new HostelDTO();
                //check if the hostel name already exist
                if (db.Hostels.Any(x => x.HostelName == model.HostelName))
                {
                    ModelState.AddModelError("hostelerrorn", "Hostel Name " + model.HostelName + " Already exist");
                    return View(model);
                }
                //add to dto
                dto.Hostelid = model.Hostelid;
                dto.HostelName = model.HostelName;
                dto.Warden = model.Warden;
                dto.Phone = model.Phone;
                db.Hostels.Add(dto);
                //save changes to database
                db.SaveChanges();

            }
            //set success message
            TempData["SM"] = "Hostel Successfully Added";
            return RedirectToAction("hostels");
        }
        // get: Deparment//edithostel
        public ActionResult edithostel(int id)
        {
            //declare hostel model
            HostelVM model;
            using (contextdb db = new contextdb())
            {
                //init hosteldto
                HostelDTO dto = db.Hostels.Find(id);
                //init hostel model
                model = new HostelVM(dto);
            }
            //return view with model
            return View(model);
        }
        // POST: Deparment//edithostel
        [HttpPost]
        public ActionResult edithostel(HostelVM model)
        {
            //check model state
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (contextdb db = new contextdb())
            {
                //init hosteldto
                HostelDTO dto = db.Hostels.Find(model.Hostelid);
                //check if the policy name exist
                if (db.Hostels.Where(x => x.Hostelid != model.Hostelid).Any(x => x.HostelName == model.HostelName))
                {
                    ModelState.AddModelError("hostelerrorn", "Hostel Name " + model.HostelName + " Already exist");
                    return View(model);
                }
                //set dto
                dto.Hostelid = model.Hostelid;
                dto.HostelName = model.HostelName;
                dto.Warden = model.Warden;
                dto.Phone = model.Phone;
                db.SaveChanges();
            }
            //set temp message
            TempData["SM"] = "Hostel Successfully Updated";
            return RedirectToAction("hostels");
        }
        // get: Deparment//edithostel
        public ActionResult deletehostel(int id)
        {
            //delete the selected policy
            using (contextdb db = new contextdb())
            {
                //init hosteldto
                HostelDTO dto = db.Hostels.Find(id);
                //remove hostel
                db.Hostels.Remove(dto);
                //save changes to db
                db.SaveChanges();
            }
            //redirect to view
            return RedirectToAction("hostels");
        }



    }
}