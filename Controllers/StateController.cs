using NoOperation_MVC.Interface;
using NoOperation_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoOperation_MVC.Controllers
{
    public class StateController : Controller
    {
        private IEmployeeManager _empMgr;
        private ApplicationDbContext context = new ApplicationDbContext();
        public StateController(IEmployeeManager empMgr)
        {
            _empMgr = empMgr;
        }
        // GET: Employee

        public ActionResult Index()
        {
            //add this directly but was not used.
            ViewBag.profile = context.Employees.ToList();

            var model = _empMgr.GetStates();
            return View(model.ToList());

            return View();
        }

        public ActionResult Create()
        {
            //ViewBag.lgas = new SelectList(_empMgr.GetLGAs(), "LGAId", "LGAName");
            //ViewBag.states = new SelectList(_empMgr.GetStates(), "StateId", "StateName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(State state)
        {
            //ViewBag.lgas = new SelectList(_empMgr.GetLGAs(), "LGAId", "LGAName");
            //ViewBag.states = new SelectList(_empMgr.GetStates(), "StateId", "StateName");

            var result = _empMgr.CreateState(state);
            if (result)
            {
                TempData["message"] = $" was successfully added!";
                return RedirectToAction("Index");
            }
            return View(result);
        }
    }
}