using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Release_1.Controllers
{
    public class ServiceController : Controller
    {
        masmix_dbEntities db = new masmix_dbEntities();
        // GET: Service


        public ActionResult Get()
        {
         return View(db.service_bd.ToList());
        }

        [HttpGet]
        public ActionResult Create() { return View(); }

        [HttpPost]
        public ActionResult Create(service_bd service)
        {
            if (ModelState.IsValid)
            {
                db.service_bd.Add(service);
                db.SaveChanges();
                return RedirectToAction("Get");
            }
            return Json(service);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = db.service_bd.Single(c => c.service_id == id);
            return View(service);
        }

        [HttpPost]
        public ActionResult Edit(service_bd service)
        {
            var service1 = db.service_bd.Single(c => c.service_id == service.service_id);
            service1.service_id = service.service_id;
            service1.service_name = service.service_name;
            service1.service_state = service.service_state;
            db.SaveChanges();
            return RedirectToAction("Get");
        }
        public ActionResult Delete(int id)
        {
            var service = db.service_bd.Single(c => c.service_id == id);
            db.service_bd.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Get");
        }
    }
}