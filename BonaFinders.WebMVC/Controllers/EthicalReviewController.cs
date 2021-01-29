using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.EthicalReviewModels;
using BonaFinders.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonaFinders.WebMVC.Controllers
{
    public class EthicalReviewController : Controller
    {
        // Adding a link to the database
        private ApplicationDbContext _db = new ApplicationDbContext();

        // Index
        // GET: Index
        public ActionResult Index()
        {
            var service = CreateNoUserService();
            var model = service.GetEthicalReviews();

            return View(model);
        }

        // Create
        // GET: Create
        public ActionResult Create()
        {
            var service = CreateEthicalReviewService();
            ViewBag.Organizations = service.GetEthicalOrganizationsList();

            return View();
        }
        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ERCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEthicalReviewService();

            if (service.CreateEthicalReview(model))
            {
                TempData["SaveResult"] = "Your review was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Review could not be created.");

            return View(model);
        }
        
        // Helper Methods
        private EthicalReviewService CreateEthicalReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EthicalReviewService(userId);
            return service;
        }
        private EthicalReviewService CreateNoUserService()
        {
            var service = new EthicalReviewService();
            return service;
        }

    }
}