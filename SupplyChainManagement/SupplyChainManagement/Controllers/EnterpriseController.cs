﻿using loowootech.SCM.Model;
using LoowooTech.SCM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoowooTech.SCM.Web.Controllers
{
    public class EnterpriseController : ControllerBase
    {
        public ActionResult Index(Business business, string name, int page = 1, int rows = 20)
        {
            var filter = new EnterpriseFilter
            {
                Business = business,
                Name = name,
                Page = new PageFilter(page, rows)
            };
            ViewBag.Page = filter.Page;
            ViewBag.List = Core.EnterpriseManager.GetList(filter);
            ViewBag.Business = business;
            return View();
        }

        public ActionResult Edit(int id = 0, Business business = Business.Supplier)
        {
            ViewBag.Model = Core.EnterpriseManager.GetModel(id) ?? new Enterprise { Business = business };
            return View();
        }

        [HttpPost]
        public ActionResult Save(Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                var index = Core.EnterpriseManager.Save(enterprise);
            }
            return RedirectToAction("Index", new { business = enterprise.Business });
        }

        public ActionResult Details(int id)
        {
            ViewBag.Model = Core.EnterpriseManager.GetModel(id);
            ViewBag.Contacts = Core.ContactManager.GetList(id);
            return View();
        }
    }
}
