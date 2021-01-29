using BonaFinders.Data.Contexts;
using BonaFinders.Data.Entities;
using BonaFinders.Models.TipModels;
using BonaFinders.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BonaFinders.WebMVC.Controllers
{
    public class TipController : Controller
    {
        // Adding a link to the database
        private ApplicationDbContext _db = new ApplicationDbContext();

        // Index
        // GET: Tip/Index
        public ActionResult Index()
        {
            var service = CreateNoUserService();
            var model = service.GetTips();

            return View(model);
        }

        // Create
        // GET: Tip/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Tip
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTipService();

            if (service.CreateTip(model))
            {
                TempData["SaveResult"] = "Your tip was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Tip could not be created.");

            return View(model);
        }

        // Delete
        // GET: Delete
        // Tip/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Tip tip = _db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            return View(tip);
        }
        // POST: Delete
        // Tip/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            Tip tip = _db.Tips.Find(id);
            _db.Tips.Remove(tip);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Update
        // GET: Edit (Update)
        // Tip/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateTipService();
            var detail = service.GetTipById(id);
            var model =
                new TEdit
                {
                    Title = detail.Title,
                    Text = detail.Text
                };
            return View(model);
        }
        // POST: Edit
        // Tip/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TEdit model)
        {
            var svc = CreateTipService();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                else if (svc.UpdateTip(model, id))
                {
                    TempData["SaveResult"] = " Your tip was updated.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                if (model.TipId != id)
                {
                    ModelState.AddModelError("", "Tip ID Missmatch");
                    return View(model);
                }
            }
            return View(model);
        }

        // Details
        // GET: Details
        // Tip/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateTipService();
            var model = svc.GetTipById(id);

            return View(model);
        }

        // Helper Methods 
        private TipService CreateTipService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TipService(userId);
            return service;
        }
        private TipService CreateNoUserService()
        {
            var service = new TipService();
            return service;
        }


    }
}