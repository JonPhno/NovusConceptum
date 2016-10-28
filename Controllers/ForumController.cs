using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovusConceptum.Data;
using NovusConceptum.Models;
using NovusConceptum.Models.ForumViewModels;
using Microsoft.EntityFrameworkCore;

namespace NovusConceptum.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext _context = null;
        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Forum
        public ActionResult Index()
        {
            // ViewData["Message"] = "Notre forum de discussion";
            List<ForumViewModel> liste_fm = new List<ForumViewModel>();

            var sujets = _context.Sujets.Include(p => p.Posts);

           foreach (Sujet s in sujets)
            {
                liste_fm.Add(new ForumViewModel(s));
            }

            return View(liste_fm);
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            ForumViewModel forumVM = new ForumViewModel(_context.Sujets
                .Include(s => s.Posts)
                .SingleOrDefault(f => f.ID ==id));

            return View(forumVM);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Forum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}