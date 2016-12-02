using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovusConceptum.Data;
using Microsoft.EntityFrameworkCore;
using NovusConceptum.Models;

namespace NovusConceptum.Controllers
{
    public class ServeurController : Controller
    {
        private ApplicationDbContext _context;
        public ServeurController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Serveur
        public ActionResult Index()
        {
            List<ServeurViewModel> liste_serveurvm = new List<ServeurViewModel>();
            var serveurs = _context.Serveurs.Include(s => s.Admin);

            foreach (var serveur in serveurs)
            {
                liste_serveurvm.Add(new ServeurViewModel(serveur));
            }

            return View(liste_serveurvm);
        }

        // GET: Serveur/Details/5
        public ActionResult Details(int id)
        {
            ServeurViewModel serveur = new ServeurViewModel(_context.Serveurs.Include(s => s.Admin).FirstOrDefault(se => se.ID == id));
            return View(serveur);
        }

        // GET: Serveur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serveur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Serveur s = new Serveur();
                TryUpdateModelAsync(s);
                s.Admin = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
                _context.Serveurs.Add(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Serveur/Edit/5
        public ActionResult Edit(int id)
        {
            ServeurViewModel serveur = new ServeurViewModel(_context.Serveurs.Include(s => s.Admin).FirstOrDefault(se => se.ID == id));
            return View(serveur);
        }

        // POST: Serveur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Serveur serveur = _context.Serveurs.Include(s => s.Admin).FirstOrDefault(se => se.ID == id);
                TryUpdateModelAsync(serveur);
                _context.Entry(serveur).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Serveur/Delete/5
        public ActionResult Delete(int id)
        {
            ServeurViewModel serveur = new ServeurViewModel(_context.Serveurs.Include(s => s.Admin).FirstOrDefault(se => se.ID == id));
            return View(serveur);
        }

        // POST: Serveur/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Serveur serveur = _context.Serveurs.Include(s => s.Admin).FirstOrDefault(se => se.ID == id);
                _context.Remove(serveur);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}