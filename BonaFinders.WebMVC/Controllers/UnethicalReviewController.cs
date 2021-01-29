using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.UnethicalReviewModels;
using BonaFinders.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonaFinders.WebMVC.Controllers
{
    public class UnethicalReviewController : Controller
    {
        // Adding a link to the database
        private ApplicationDbContext _db = new ApplicationDbContext();

        // Index
        // GET: Index
        // GET: Post
        public ActionResult Index()
        {
            var service = CreateNoUserService();
            var model = service.GetUnethicalReviews();

            return View(model);
        }

        // Create
        // GET: Create Viewpage
        public ActionResult Create()
        {
            var service = CreateUnethicalReviewService();
            ViewBag.Organizations = service.GetUnethicalOrganizationsList();
            
            return View();
        }
        // POST: 
        // [Route(/Post/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(URCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUnethicalReviewService();

            if (service.CreateUnethicalReview(model))
            {
                TempData["SaveResult"] = "Your review was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Review could not be created.");

            return View(model);
        }
               

        // Helper Methods
        private UnethicalReviewService CreateUnethicalReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UnethicalReviewService(userId);
            return service;
        }
        private UnethicalReviewService CreateNoUserService()
        {
            var service = new UnethicalReviewService();
            return service;
        }


    }
}