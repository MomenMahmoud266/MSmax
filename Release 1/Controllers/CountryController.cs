using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Release_1.Controllers
{
    public class CountryController : Controller
    {
        masmix_dbEntities db = new masmix_dbEntities();

        // GET: Country
        public ActionResult Get()
        {

            return View(db.country_bd.ToList());
        }
        [HttpGet]
        public ActionResult Create() { return View(); }

        [HttpPost]
        public ActionResult Create(country_bd country)
        {
            if (ModelState.IsValid)
            {
                db.country_bd.Add(country);
                db.SaveChanges();
                return RedirectToAction("Get");
            }
            return Json(country);
        }


        [HttpGet]
        public ActionResult Edit(int id) {
            var country = db.country_bd.Single(c => c.country_id == id);
            return View(country);
        }

        [HttpPost]
        public ActionResult Edit(country_bd country)
        {
            var country1 = db.country_bd.Single(c => c.country_id == country.country_id);
            country1.country_code = country.country_code;
            country1.country_Name = country.country_Name;
            country1.country_state = country.country_state;
            country1.country_general_coditions = country.country_general_coditions;
            country1.country_desc = country.country_desc;
            db.SaveChanges();
            return RedirectToAction("Get");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var country = db.country_bd.Single(c => c.country_id == id);
            db.country_bd.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Get");
        }
    }
}