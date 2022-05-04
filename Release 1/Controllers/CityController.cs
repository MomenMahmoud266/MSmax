using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Release_1.Models;
namespace Release_1.Controllers
{
    public class CityController : Controller
    {
        masmix_dbEntities db = new masmix_dbEntities();

        // GET: City
        [HttpGet]
        public ActionResult Get()
        {

            return View(db.city_bd.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var active_countries = db.country_bd.Where(c => c.country_state == 1).ToList<country_bd>();
            CityViewModel city = new CityViewModel
            {
                active_countries = active_countries,
                city = null
            };
            return View(city);
        }

        [HttpPost]
        public ActionResult Create(city_bd city)
        {
            if (ModelState.IsValid)
            {
                db.city_bd.Add(city);
                db.SaveChanges();
                return RedirectToAction("Get");
            }
            return Json(city);
        }
        public ActionResult Edit(int id)
        {
            var active_countries = db.country_bd.Where(c => c.country_state == 1).ToList<country_bd>();
            var city1 = db.city_bd.Single(c => c.city_id == id);
            CityViewModel city = new CityViewModel
            {
                active_countries = active_countries,
                city = city1
            };
            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(CityViewModel c)
        {
            var city1 = db.city_bd.Single(a => a.city_id == c.city.city_id);
            city1.city_name = c.city.city_name;
            city1.city_desc = c.city.city_desc;
            city1.city_country_id = c.city.city_country_id;
            city1.city_general_conditions = c.city.city_general_conditions;
            city1.city_state = c.city.city_state;
            city1.city_code = c.city.city_code;
            city1.is_pickup = c.city.is_pickup;
            city1.is_delivery = c.city.is_delivery;
            db.SaveChanges();
            return RedirectToAction("Get");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var city = db.city_bd.Single(c => c.city_id == id);
            db.city_bd.Remove(city);
            db.SaveChanges();
            return RedirectToAction("Get");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var country = db.city_bd.Single(c => c.city_id == id);
            return View(country);
        }
    }
}