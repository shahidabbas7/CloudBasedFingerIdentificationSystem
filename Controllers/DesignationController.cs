using CloudBasedFingerIdentificationSystem.Models.data;
using CloudBasedFingerIdentificationSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudBasedFingerIdentificationSystem.Controllers
{
    public class DesignationController : Controller
    {
        // GET: Designation
        public ActionResult Designation()
        {
            //declare designation vm list
            List<DesignationVM> designationList;
            using(contextdb db=new contextdb())
            {
                //init designation vm list
                designationList = db.designations.ToArray().Select(x => new DesignationVM(x)).ToList();
            }
            //return view with model
            return View(designationList);
        }
        // GET: Designation//adddesignation
        public ActionResult adddesignation()
        {
            //declare designation vm
            DesignationVM model = new DesignationVM();
            return View(model);
        }
        // post: Designation//adddesignation
        [HttpPost]
        public ActionResult adddesignation(DesignationVM model)
        {
            //check if model is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using(contextdb db=new contextdb())
            {
                //declare designation dto
                DesignationDTO dto = new DesignationDTO();
                //check if designation name exist
                if (db.designations.Any(x => x.designame == model.designame))
                {
                    ModelState.AddModelError("desigerror", "Designation name "+model.designame+ " already exist");
                    return View(model);
                }
                //check if id exist
                //check if designation name exist
                if (db.designations.Any(x => x.desigcode == model.desigcode))
                {
                    ModelState.AddModelError("desigerrorc ", "Designation code "+model.desigcode+ " already exist");
                    return View(model);
                }
                //save dto
                dto.desigcode = model.desigcode;
                dto.designame = model.designame;
                dto.rank = model.rank;
                dto.Reports_to = model.Reports_to;
                db.designations.Add(dto);
                db.SaveChanges();
            }
            //set tempdata message
            TempData["SM"] = "Designation Added";
            //redirect to  page
            return RedirectToAction("Designation");

        }
        // get: Designation//editdesignation
        public ActionResult editDeignation(int id)
        {
            //delcare designationvm
            DesignationVM model;
            //init designationvm
            using(contextdb db=new contextdb())
            {
                //init designationdto
                DesignationDTO dto = db.designations.Find(id);
                model = new DesignationVM(dto);

            }
            return View(model);
        }
        // get: Designation//editdesignation
        [HttpPost]
        public ActionResult editDeignation(DesignationVM model)
        {
            //check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //init designationvm
            using (contextdb db = new contextdb())
            {
                
                //check if the designation Already exist
                if (db.designations.Where(x => x.desigcode != model.desigcode).Any(x => x.designame == model.designame))
                {
                    ModelState.AddModelError("desigError", "Designation " +  model.designame + " Already exist");
                    return View(model);
                }
                // init deptcode
                int desgcode = model.desigcode;
                //init designationdto
                DesignationDTO dto = db.designations.Find(desgcode);
                //set to dto
                dto.designame = model.designame;
                dto.rank = model.rank;
                dto.Reports_to = model.Reports_to;
                //save changes to database
                db.SaveChanges();
            }
            //set success message
            TempData["SM"] = "Designation Successfully Updated";
            return RedirectToAction("Designation");
        }
        // get: Designation//DeleteDesignation
        public ActionResult DeleteDesignation(int id)
        {
            //delete designation
            using(contextdb db=new contextdb())
            {
                DesignationDTO dto = db.designations.Find(id);
                db.designations.Remove(dto);
                db.SaveChanges();
            }
            return RedirectToAction("Designation");
        }
    }
}