using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CorpersMVC.Models;

namespace CorpersMVC.Controllers
{
    public class CorpersController : Controller
    {
        private CorpersDBEntities Corpersdb = new CorpersDBEntities();
        // GET: Corpers
        public ActionResult Read()
        {
            return View(Corpersdb.CorpersTables.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new CorpersTable();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Corpers corpers)
        {

            var model = new CorpersTable
            {
                FirstName = corpers.FirstName,
                LastName = corpers.LastName,
                Email = corpers.Email,
                PhoneNumber = corpers.PhoneNumber,
                School = corpers.School,
                Gender = corpers.Gender,
                Discipline = corpers.Discipline,
                StateCode = corpers.StateCode,
            };
            if (ModelState.IsValid)
            {
                Corpersdb.CorpersTables.Add(model);
                Corpersdb.SaveChanges();
                return RedirectToAction("Read");
            }
            return View("Create", model);
        }

        //Get
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            CorpersTable corpers = Corpersdb.CorpersTables.Find(id);
            if (corpers == null)
            {
                return HttpNotFound();
            }
            return View(corpers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Corpers corpers)
        {
            var model = Corpersdb.CorpersTables.Where(s => s.Id.Equals(corpers.Id)).FirstOrDefault();
            {
                model.FirstName = corpers.FirstName;
                model.LastName = corpers.LastName;
                model.Email = corpers.Email;
                model.PhoneNumber = corpers.PhoneNumber;
                model.School = corpers.School;
                model.Gender = corpers.Gender;
                model.Discipline = corpers.Discipline;
                model.StateCode = corpers.StateCode;
            };
            if (ModelState.IsValid)
            {
                Corpersdb.SaveChanges();
                return RedirectToAction("Read");
            }
            return View(model);

        }

        //Get Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            CorpersTable corpers = Corpersdb.CorpersTables.Find(id);
            if (corpers == null)
            {
                return HttpNotFound();
            }
            return View(corpers);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            CorpersTable corpers = Corpersdb.CorpersTables.Find(id);

            Corpersdb.CorpersTables.Remove(corpers);
                Corpersdb.SaveChanges();
                return RedirectToAction("Read");

            
        }
    }
}
