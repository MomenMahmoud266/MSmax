using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Release_1.Models;
namespace Release_1.Controllers
{
    public class RouteController : Controller
    {
        masmix_dbEntities db = new masmix_dbEntities();

        // GET: Route
        [HttpGet]
        public ActionResult Get()
        {
            
            return View(db.route_bd.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            var active_countries = db.country_bd.Where(c => c.country_state == 1).ToList<country_bd>();
            var active_cities = db.city_bd.Where(c => c.city_state == 1).ToList<city_bd>();
            RoutesViewModel route = new RoutesViewModel
            {
                cities = active_cities,
                countries = active_countries,
                route = null
            };
            return View(route);
        }

        [HttpPost]
        public ActionResult Create(route_bd route)
        {
            if (ModelState.IsValid)
            {
                db.route_bd.Add(route);
                db.SaveChanges();
                return RedirectToAction("Get");
            }
            return HttpNotFound();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var active_countries = db.country_bd.Where(c => c.country_state == 1).ToList<country_bd>();
            var active_cities = db.city_bd.Where(c => c.city_state == 1).ToList<city_bd>();
            var route1 = db.route_bd.Single(r => r.route_id == id);
            RoutesViewModel route = new RoutesViewModel
            {
                cities = active_cities,
                countries = active_countries,
                route = route1
            };
            return View(route);
        }

        [HttpPost]
        public ActionResult Edit (RoutesViewModel r)
        {
            var route1 = db.route_bd.Single(a => a.route_id == r.route.route_id);
            route1.route_name = r.route.route_name;
            route1.route_from_country = r.route.route_from_country;
            route1.route_from_city = r.route.route_from_city;
            route1.route_to_country = r.route.route_to_country;
            route1.route_to_city = r.route.route_to_city;
            route1.route_state = r.route.route_state;
            db.SaveChanges();
            return RedirectToAction("Get");
        }
        public ActionResult Delete(int id)
        {
            var route = db.route_bd.Single(c => c.route_id == id);
            db.route_bd.Remove(route);
            db.SaveChanges();
            return RedirectToAction("Get");
        }

        [WebMethod]
        public ActionResult getcities(int countryid)
        {
            var cities = db.city_bd.Where(c => c.city_country_id == countryid).ToList<city_bd>();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
 }
