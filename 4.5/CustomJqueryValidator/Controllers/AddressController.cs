﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomJqueryValidator.Data;

namespace CustomJqueryValidator.Controllers
{
    public class AddressController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Address/

        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.Country);
            return View(addresses.ToList());
        }

        //
        // GET: /Address/Details/5

        public ActionResult Details(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // GET: /Address/Create

        public ActionResult Create()
        {
            ViewBag.CountryId = db.Countries.ToList<Country>(); //new SelectList(db.Countries, "Id", "Name");
            return View();
        }

        //
        // POST: /Address/Create

        [HttpPost]
        public ActionResult Create(CustomJqueryValidator.Models.Address address)
        {
            if (ModelState.IsValid)
            {
                Address addr = new Address
                {
                    Area = address.Area,
                    Code = address.Code,
                    CountryId = address.CountryId,
                    State = address.State,
                    Street = address.Street
                };
                db.Addresses.Add(addr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = db.Countries.ToList<Country>();//  new SelectList(db.Countries, "Id", "Name", address.CountryId);
            return View(address);
        }

        //
        // GET: /Address/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", address.CountryId);
            return View(address);
        }

        //
        // POST: /Address/Edit/5

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", address.CountryId);
            return View(address);
        }

        //
        // GET: /Address/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        //
        // POST: /Address/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}