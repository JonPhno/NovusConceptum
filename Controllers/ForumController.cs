using System;
using System.Collections.Generic;
using System.Linq;
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
                Sujet sujet = new Sujet();
                TryUpdateModelAsync(sujet);
              sujet.DateCreation = DateTime.Now;
                sujet.DateModifier = DateTime.Now;
                sujet.NombreMessages = 0;
                sujet.Auteur = User.Identity.Name;
                _context.Sujets.Add(sujet);
                _context.SaveChanges();
                return RedirectToAction("/CreatePost/" + _context.Sujets.SingleOrDefault(s => s.Titre == sujet.Titre && s.Posts.Count == 0).ID);
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            ForumViewModel ForumVM = new ForumViewModel(_context.Sujets.SingleOrDefault(s => s.ID == id));
            return View(ForumVM);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ForumViewModel forumModel)
        {
            try
            {
                // TODO: Add update logic here
                Sujet sujet = _context.Sujets.SingleOrDefault(s => s.ID == forumModel.ID);
                TryUpdateModelAsync(sujet);
                sujet.NombreMessages = sujet.Posts.Count;
                _context.SaveChanges();

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
            ForumViewModel ForumVM = new ForumViewModel(_context.Sujets.SingleOrDefault(s => s.ID == id));
            return View(ForumVM);
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Sujets.Remove(_context.Sujets.SingleOrDefault(s => s.ID == id));
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // actions reliés aux posts

        // GET: Forum/Edit/5
        public ActionResult EditPost(int id)
        {
            ForumViewModel ForumVM = new ForumViewModel(_context.Sujets.SingleOrDefault(s => s.ID == id));
            return View(ForumVM);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(ForumViewModel forumModel)
        {
            try
            {
                // TODO: Add update logic here
                Sujet sujet = _context.Sujets.SingleOrDefault(s => s.ID == forumModel.ID);
                TryUpdateModelAsync(sujet);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Delete/5
        public ActionResult DeletePost(int id)
        {
            ForumViewModel ForumVM = new ForumViewModel(_context.Sujets.SingleOrDefault(s => s.ID == id));
            return View(ForumVM);
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                int sujetId = _context.Posts.SingleOrDefault(p => p.ID == id).SujetID;
                _context.Posts.Remove(_context.Posts.SingleOrDefault(p => p.ID == id));
                _context.SaveChanges();
                return RedirectToAction(Details(sujetId).ToString());
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(IFormCollection collection)
        {
          //  try
         //   {
                // TODO: Add insert logic here
                Post post = new Post();
                TryUpdateModelAsync(post);
                //sujet.DateCréation = DateTime.Now;
                Sujet sujet = _context.Sujets.LastOrDefault();
                sujet.DateModifier = DateTime.Now;
                post.SujetID = sujet.ID;
                post.Auteur = User.Identity.Name;
                sujet.NombreMessages++;
                post.Date = DateTime.Now;
                sujet.Dernier = User.Identity.Name;
                post.ID = 0;

                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("/Details/" + _context.Sujets.SingleOrDefault(s => s.Titre == sujet.Titre).ID);
            //}
         //   catch
           // {
          //      return View();
          //  }
        }
    }
}