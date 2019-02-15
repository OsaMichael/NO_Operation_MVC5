using NoOperation_MVC.Interface;
using NoOperation_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NoOperation_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeManager _empMgr;
        private ApplicationDbContext context = new ApplicationDbContext();
        public EmployeeController(IEmployeeManager empMgr)
        {
            _empMgr = empMgr;
        }
        // GET: Employee

        public ActionResult Index()
        {
            //add this directly but was not used.
            ViewBag.profile = context.Employees.ToList();

            var model = _empMgr.GetEmployees();
            return View(model.ToList());

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.lgas = new SelectList(_empMgr.GetLGAs(), "LGAId", "LGAName");
            ViewBag.states = new SelectList(_empMgr.GetStates(), "StateId", "StateName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            //ViewBag.lgas = new SelectList(_empMgr.GetLGAs(), "LGAId", "LGAName");
            ViewBag.states = new SelectList(_empMgr.GetStates(), "StateId", "StateName");

            var result = _empMgr.CreateEmp(employee);
            if (result)
            {
                TempData["message"] = $" was successfully added!";
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {

            var result = _empMgr.GetEmployeeById(id);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
       public ActionResult Edit(Employee employee)
        {
       
            if(ModelState.IsValid)
            {             
                var result = _empMgr.UpdateEmp(employee);
                if (result != null && employee.Id != 0)
                {
                    TempData["message"] = $"was successfully added!";
                    return RedirectToAction("Index");
                } 
            }
            return View(employee);
        }

        public ActionResult Details(int id = 0)
        {

            var result = _empMgr.EmployDetails(id);
            if(result == null)
            {
                return HttpNotFound();
                //TempData["message"] = $"was successfully";
                //return RedirectToAction("Details");

            }
            return View(result);
        }
        [HttpPost]
        public JsonResult Delete(int id, string empName)
        {
            int empId = Convert.ToInt32(id);
            if(empId > 0)
            {
                var result = _empMgr.DeleteEmp(empId);
                if(result == true)
                {
                    return Json(new { status = true, message = $"{empName} has successfully deleted!", JsonRequestBehavior.AllowGet });
                }
                return Json(new { status = false, error = result.ToString() }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { status = false, error = "Invalid Id" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLGAByStateId(int id)
        {
            var result = _empMgr.GetLGAByStateId(id);
            if (result != null)
            {
                var value = result.Select(d => new
                {
                    LGAId = d.LGAId,
                    LGAName = d.LGAName
                });
                return Json(new { ok = true, data = value.ToArray(), message = "ok", JsonRequestBehavior.AllowGet });
            }
            return Json(new { ok = false, message = result }, JsonRequestBehavior.AllowGet);
        }


        //[HttpGet]
        //public ActionResult GetLgas(string iso3)
        //{
        //    if (!string.IsNullOrWhiteSpace(iso3) && iso3.Length == 3)
        //    {
        //        //var repo = new RegionsRepository();

        //        IEnumerable<SelectListItem> regions = repo.GetRegions(iso3);
        //        return Json(regions, JsonRequestBehavior.AllowGet);
        //    }
        //    return null;
        //}
    }
}