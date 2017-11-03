using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarageWeb.DataAccess;
using GarageWeb.Models;

namespace GarageWeb.Controllers
{
    //stuff
    public class GarageController : Controller
    {
        //private Repository Rep = new Repository();

        // GET: Garage
        public ActionResult Index(string regnr = null, int filtering = 0, int option = 0)
        {
            ViewBag.FreeSlots = Common.FreeLots(Repository.GetStock(filtering).Count());
            //CHECK if there is a search term
            if (regnr == null || regnr.Trim() == "")
            {
                return View(Repository.GetStock(filtering));
            }


            Common.SearchResult tempVehicles = Repository.RegHandler(regnr, filtering, option);

            if (tempVehicles.vehicles == null || tempVehicles.vehicles.Count() == 0) //If no results check in vehicle
            {

                if (option == 0) //IF handling reg number
                {
                    Common.VehicleInfo vh = Common.GatherInfo(regnr);

                    ViewBag.Valid = vh.isvalid;
                    ViewBag.Persnr = vh.persnr;
                    ViewBag.Vtype = vh.vehicletype;
                    ViewBag.Regnr = regnr;
                    ViewBag.Date = vh.parkdate;

                    return View("Add");
                }

                return View();
                
            }
            else
            {
                if (tempVehicles.exactMatch && option == 0)
                {
                    return View("Remove", tempVehicles.vehicles); //If regnr is not null return whole stock, else only the regnr
                }

                return View(tempVehicles.vehicles);
            }
            
        }

        public ActionResult Remove(string[] id)
        {

            return View(Repository.GetFromRegnr(id));
        }

        public ActionResult ConfirmAdd(Common.vType vtype, string regnr, string persnr, DateTime date)
        {

           Repository.AddVehicle(vtype, regnr, persnr, date);
           return RedirectToAction("Index", "Garage");
        }

        public ActionResult ConfirmDelete(string[] id)
        {


            if (Repository.CheckOut(id))
            {
                 
            }


            return RedirectToAction("Index", "Garage");

        }

        // GET: Garage/Details/5
        public ActionResult Details(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Vehicle vehicle = Rep.GetStock().Find(id);
            //if (vehicle == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: Garage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Regnr,Persnr,ParkDate,VehicleType")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                Repository.AddVehicle(vehicle);
                Repository.Updatedb();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Garage/Edit/5
        public ActionResult Edit(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Vehicle vehicle = db.Vehicles.Find(id);
            //if (vehicle == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Garage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Regnr,Persnr,ParkDate,VehicleType")] Vehicle vehicle)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(vehicle).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View();
        }

        // GET: Garage/Delete/5
        public ActionResult Checkout(string id)
        {



            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Rep.CheckOut(id);

            //if (vehicle == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Garage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    db.Vehicles.Remove(vehicle);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
            //base.Dispose();
            return RedirectToAction("Index");
        }
    }
}
