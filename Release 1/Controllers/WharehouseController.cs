using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Release_1.Models;
namespace Release_1.Controllers
{
    public class WharehouseController : Controller
    {
        masmix_dbEntities db = new masmix_dbEntities();
        // GET: Wharehouse


        public ActionResult Get()
        {

            return View(db.wharehouse_bd.ToList());
        }

        [HttpGet]
        public ActionResult Create() {

 
            var active_countries = db.country_bd.Where(c => c.country_state == 1).ToList<country_bd>();
            WharehouseViewModel wh = new WharehouseViewModel
            {
                active_countries = active_countries,
                wharehouse = null
            };
            return View(wh); 
        }

        [HttpPost]
        public ActionResult Create(WharehouseViewModel wh, string selectedvalue)
        {

            var selectedvalue1 = selectedvalue;
            var uservaluewidth = wh.wharehouse.wharehouse_width_ft;
            var uservaluelength = wh.wharehouse.wharehouse_length_ft;
            var uservaluehieght = wh.wharehouse.wharehouse_hieght_ft;

            if (selectedvalue == "1")
            {
                wh.wharehouse.wharehouse_width_ft = uservaluewidth;
                wh.wharehouse.wharehouse_width_cm = uservaluewidth / 30.48m;

                wh.wharehouse.wharehouse_length_ft = uservaluelength;
                wh.wharehouse.wharehouse_length_cm = uservaluelength / 30.48m;

                wh.wharehouse.wharehouse_hieght_ft = uservaluehieght;
                wh.wharehouse.wharehouse_hieght_cm = uservaluehieght / 30.48m;
            }
            else if (selectedvalue == "0")
            {
                wh.wharehouse.wharehouse_width_cm = uservaluewidth;
                wh.wharehouse.wharehouse_width_ft = uservaluewidth * 30.48m;

                wh.wharehouse.wharehouse_length_cm = uservaluelength;
                wh.wharehouse.wharehouse_length_ft = uservaluelength * 30.48m;

                wh.wharehouse.wharehouse_hieght_cm = uservaluehieght;
                wh.wharehouse.wharehouse_hieght_ft = uservaluehieght * 30.48m;
            }
            //var test = wh.wharehouse.wharehouse_name;
            //var test1 = wh.wharehouse.wharehouse_length_cm;

            //return Content("ft:" + test + "       cm:" + test1 + "   lezgo       " + selectedvalue1);


            if (ModelState.IsValid)
            {

                db.wharehouse_bd.Add(wh.wharehouse);
                db.SaveChanges();
                return RedirectToAction("Get");
            }
            return Json(wh.wharehouse);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = db.wharehouse_bd.Single(c => c.wharehouse_id == id);
            return View(service);
        }

        [HttpPost]
        public ActionResult Edit(wharehouse_bd service)
        {
            var service1 = db.wharehouse_bd.Single(c => c.wharehouse_id == service.wharehouse_id);
            service1.wharehouse_id = service.wharehouse_id;
            service1.wharehouse_name = service.wharehouse_name;
            service1.wharehouse_state = service.wharehouse_state;
            db.SaveChanges();
            return RedirectToAction("Get");
        }
        public ActionResult Delete(int id)
        {
            var wharehouse = db.wharehouse_bd.Single(c => c.wharehouse_id == id);
            db.wharehouse_bd.Remove(wharehouse);
            db.SaveChanges();
            return RedirectToAction("Get");
        }
    }
}