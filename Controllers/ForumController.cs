using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovusConceptum.Data;
using NovusConceptum.Models;
using NovusConceptum.Models.ForumViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace NovusConceptum.Controllers
{
    public class ForumController : Controller
    {
        private ApplicationDbContext _context = null;
        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        // GET: Forum
        public ActionResult Index()
        {
            // ViewData["Message"] = "Notre forum de discussion";
            List<ForumViewModel> liste_fm = new List<ForumViewModel>();

            var sujets = _context.Sujets.Include(p => p.Posts).Include(i=> i.Auteur.InfoSup).ThenInclude(a=>a.Image);

           foreach (Sujet s in sujets)
            {
                liste_fm.Add(new ForumViewModel(s));
            }

            return View(liste_fm);
        }

        // GET: Forum/Details/5
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult Details(int id)
        {
            ForumViewModel forumVM = new ForumViewModel(_context.Sujets
                .Include(a=>a.Auteur).Include(i=>i.Auteur.InfoSup).ThenInclude(m=> m.Image)
                .Include(s => s.Posts).ThenInclude(p=>p.Auteur).ThenInclude(au=>au.InfoSup).ThenInclude(inf=>inf.Image)
                .SingleOrDefault(f => f.ID ==id));

            return View(forumVM);
        }
        [Authorize(Roles = "Administrateur,Modérateur")]
        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Sujet sujet = new Sujet();
                TryUpdateModelAsync(sujet);
              sujet.DateCreation = DateTime.Now;
                sujet.DateModifier = DateTime.Now;
                sujet.NombreMessages = 1;
                sujet.Auteur = _context.Users.SingleOrDefault(u => User.Identity.Name == u.UserName);
                sujet.Dernier = _context.Users.SingleOrDefault(u => User.Identity.Name == u.UserName);
                Post post = new Post()
                {
                    Auteur = _context.Users.SingleOrDefault(u => User.Identity.Name == u.UserName),
                    Date = DateTime.Now,
                    Message = sujet.PremierMessage,
                    SujetID = sujet.ID,
                    Suj = sujet
                };
                _context.Sujets.Add(sujet);
                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("/Details/" + _context.Sujets.SingleOrDefault(s => s.Titre == sujet.Titre).ID);
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Edit/5
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Edit(int id)
        {
            ForumViewModel ForumVM = new ForumViewModel(_context.Sujets.SingleOrDefault(s => s.ID == id));
            return View(ForumVM);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Edit(ForumViewModel forumModel)
        {
            try
            {
                // TODO: Add update logic here
                Sujet sujet = _context.Sujets.SingleOrDefault(s => s.ID == forumModel.ID);
                TryUpdateModelAsync(sujet);
                if (sujet.Posts != null)
                {
                    sujet.NombreMessages = sujet.Posts.Count;
                }
                else
                {
                    sujet.NombreMessages = 0;
                }
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Delete/5
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Delete(int id)
        {
            ForumViewModel ForumVM = new ForumViewModel(_context.Sujets.SingleOrDefault(s => s.ID == id));
            return View(ForumVM);
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur")]
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
        [Authorize(Roles = "Administrateur,Modérateur,Ange")]
        public ActionResult EditPost(int id)
        {
            PostViewModel PostVM = new PostViewModel(_context.Posts.SingleOrDefault(s => s.ID == id));
            return View(PostVM);
        }

        // POST: Forum/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur,Ange")]
        public ActionResult EditPost(PostViewModel postModel)
        {
            try
            {
                // TODO: Add update logic here
                Post post = _context.Posts.SingleOrDefault(s => s.ID == postModel.ID);
                TryUpdateModelAsync(post);
                _context.SaveChanges();

                return RedirectToAction("/Details/" + post.SujetID);
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Delete/5
        [Authorize(Roles = "Administrateur,Modérateur,Ange")]

        public ActionResult DeletePost(int id)
        {
            PostViewModel PostVM = new PostViewModel(_context.Posts.SingleOrDefault(s => s.ID == id));
            return View(PostVM);
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur,Ange")]

        public ActionResult DeletePost(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                int sujetId = _context.Posts.SingleOrDefault(p => p.ID == id).SujetID;
                _context.Posts.Remove(_context.Posts.SingleOrDefault(p => p.ID == id));
                _context.SaveChanges();
                return RedirectToAction("/Details/" + sujetId);
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult CreatePost(int id)
        {
            PostViewModel PostVM = new PostViewModel();
            PostVM.SujetID = id;

            return View(PostVM);
        }

        // POST: Forum/Create
        [HttpPost]
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(IFormCollection collection)
        {
            try
           {
                // TODO: Add insert logic here
                Post post = new Post();
                TryUpdateModelAsync(post);
                post.Date = DateTime.Now;
                Sujet sujet = _context.Sujets.SingleOrDefault(s=> s.ID == post.SujetID);
                sujet.DateModifier = DateTime.Now;
                //post.SujetID = sujet.ID;
                post.Auteur =_context.Users.SingleOrDefault(u=> User.Identity.Name== u.UserName);
                sujet.NombreMessages++;
                post.Date = DateTime.Now;
                sujet.Dernier = _context.Users.SingleOrDefault(u => User.Identity.Name == u.UserName);
                post.ID = 0;

                _context.Posts.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = _context.Sujets.SingleOrDefault(s => s.Titre == sujet.Titre).ID });
            }
            catch
            {
                return View();
                //asdklnjasdnjasdnjasdlnasklnjdaklnsdaklnsdalnsdklns
            }
        }
    }
}