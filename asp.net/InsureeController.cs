using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private CarInsuranceEntities db = new CarInsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,SpeedingTickets,Dui,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                decimal quote = 50; // base monthly price

                // Calculate age
                int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
                if (insuree.DateOfBirth > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                // Age pricing
                if (age <= 18)
                {
                    quote += 100;
                }
                else if (age >= 19 && age <= 25)
                {
                    quote += 50;
                }
                else
                {
                    quote += 25;
                }

                // Car year pricing
                if (insuree.CarYear < 2000)
                {
                    quote += 25;
                }
                if (insuree.CarYear > 2015)
                {
                    quote += 25;
                }

                // Porsche pricing
                if (insuree.CarMake.ToLower() == "porsche")
                {
                    quote += 25;

                    if (insuree.CarModel.ToLower() == "911 carrera")
                    {
                        quote += 25;
                    }
                }

                // Speeding tickets
                quote += insuree.SpeedingTickets * 10;

                // DUI
                if (insuree.Dui)
                {
                    quote += quote * 0.25m;
                }

                // Full coverage
                if (insuree.CoverageType.ToLower() == "full")
                {
                    quote += quote * 0.50m;
                }

                // Save quote to database
                insuree.Quote = quote;

                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Admin
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}