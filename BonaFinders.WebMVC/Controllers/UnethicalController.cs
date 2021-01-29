using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.UnethicalModels;
using BonaFinders.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonaFinders.WebMVC.Controllers
{
    public class UnethicalController : Controller
    {
        // Adding a link to the database
        private ApplicationDbContext _db = new ApplicationDbContext();

        // Index
        // GET: Unethical/Index
        public ActionResult Index()
        {
            var service = CreateNoUserService();
            var model = service.GetUnethicalOrganizations();

            return View(model);
        }

        // Create
        // GET: Unethical/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUnethicalService();

            if (service.CreateUnethicalOrganization(model))
            {
                TempData["SaveResult"] = "Your organization was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Organization could not be created.");

            return View(model);
        }

        // Delete
        // GET: Delete
        // Unethical/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            UnethicalOrganization unethicalOrganization = _db.UnethicalOrganizations.Find(id);
            if (unethicalOrganization == null)
            {
                return HttpNotFound();
            }
            return View(unethicalOrganization);
        }
        // POST: Delete
        // Unethical/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            UnethicalOrganization unethicalOrganization = _db.UnethicalOrganizations.Find(id);
            _db.UnethicalOrganizations.Remove(unethicalOrganization);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Update
        // GET: Edit (Update)
        // Unethical/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateUnethicalService();
            var detail = service.GetUnethicalOrganizationById(id);
            var model =
                new UEdit
                {
                    UnethicalOrganizationName = detail.UnethicalOrganizationName,
                    FastFashion = detail.FastFashion,
                    Exploitation = detail.Exploitation,
                    Sweatshop = detail.Sweatshop,
                    Copyright = detail.Copyright,
                    UCountry = detail.UCountry,
                    UImprove = detail.UImprove
                };
            return View(model);
        }
        // POST: Edit
        // Unethical/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UEdit model)
        {
            var svc = CreateUnethicalService();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                else if (svc.UpdateUnethicalOrganization(model, id))
                {
                    TempData["SaveResult"] = " Your organization was updated.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                if (model.UnethicalOrganizationId != id)
                {
                    ModelState.AddModelError("", "Unethical Organization ID Missmatch");
                    return View(model);
                }
            }
            return View(model);
        }

        // Details
        // GET: Details
        // Unethical/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateUnethicalService();
            var model = svc.GetUnethicalOrganizationById(id);

            return View(model);
        }

        // Helper Methods 
        private UnethicalService CreateUnethicalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UnethicalService(userId);
            return service;
        }
        private UnethicalService CreateNoUserService()
        {
            var service = new UnethicalService();
            return service;
        }


    }
}