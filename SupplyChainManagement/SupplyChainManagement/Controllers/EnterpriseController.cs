﻿using loowootech.SCM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplyChainManagement.Controllers
{
    public class EnterpriseController : ControllerBase
    {
        //
        // GET: /Enterprise/

        public ActionResult Index(Business business)
        {
            var list = Core.EnterpriseManager.Get(business);
            ViewBag.Dictionary = Core.ContactManager.Get();
            ViewBag.Business = business;
            return View(list);
        }

        [HttpPost]
        public ActionResult Add(Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                var index = Core.EnterpriseManager.Add(enterprise);
            }
            return RedirectToAction("Index", new { business = enterprise.Business });
        }

    }
}
