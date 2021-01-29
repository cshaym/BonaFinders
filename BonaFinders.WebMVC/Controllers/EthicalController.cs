using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.EthicalModels;
using BonaFinders.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonaFinders.WebMVC.Controllers
{
    public class EthicalController : Controller
    {
        // Adding a link to the database
        private ApplicationDbContext _db = new ApplicationDbContext();

        // Index
        // GET: Ethical/Index
        public ActionResult Index()
        {
            var service = CreateNoUserService();    // var service = CreateEthicalService();
            var model = service.GetEthicalOrganizations();

            return View(model);
        }

        // Create
        // GET: Ethical/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ECreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEthicalService();

            if (service.CreateEthicalOrganization(model))
            {
                TempData["SaveResult"] = "Your organization was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Organization could not be created.");

            return View(model);
        }

        // Delete
        // GET: Delete
        // Ethical/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            EthicalOrganization ethicalOrganization = _db.EthicalOrganizations.Find(id);
            if (ethicalOrganization == null)
            {
                return HttpNotFound();
            }
            return View(ethicalOrganization);
        }
        // POST: Delete
        // Ethical/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            EthicalOrganization ethicalOrganization = _db.EthicalOrganizations.Find(id);
            _db.EthicalOrganizations.Remove(ethicalOrganization);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Update
        // GET: Edit (Update)
        // Ethical/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateEthicalService();
            var detail = service.GetEthicalOrganizationById(id);
            var model =
                new EEdit
                {
                    EthicalOrganizationName = detail.EthicalOrganizationName,
                    Sustainable = detail.Sustainable,
                    Diverse = detail.Diverse,
                    ECountry = detail.ECountry,
                    EImprove = detail.EImprove
                };
            return View(model);
        }
        // POST: Edit
        // Ethical/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EEdit model)
        {
            var svc = CreateEthicalService();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                
                else if (svc.UpdateEthicalOrganization(model, id))
                {
                    TempData["SaveResult"] = " Your organization was updated.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                if (model.EthicalOrganizationId != id)
                {
                    ModelState.AddModelError("", "Ethical Organization ID Missmatch");
                    return View(model);
                }
            }
            return View(model);
        }

        // Details
        // GET: Details
        // Ethical/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateEthicalService();
            var model = svc.GetEthicalOrganizationById(id);

            return View(model);
        }

        // Helper Methods
        private EthicalService CreateEthicalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EthicalService(userId);
            return service;
        }
        private EthicalService CreateNoUserService()
        {
            var service = new EthicalService();
            return service;
        }

    }
}