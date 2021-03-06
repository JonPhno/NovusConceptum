using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovusConceptum.Models.TournoisViewModels;
using NovusConceptum.Data;
using NovusConceptum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace NovusConceptum.Controllers
{
    public class TournoisController : Controller
    {
        private ApplicationDbContext _context = null;
        public TournoisController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        // GET: Tournois
        public ActionResult Index()
        {
            List<TournoisViewModel> liste_tm = new List<TournoisViewModel>();

            var tournois = _context.Tournois.Include(t=>t.Joueurs);

            foreach (Tournois t in tournois)
            {
                liste_tm.Add(new TournoisViewModel(t));
            }

            return View(liste_tm);
        }
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]

        // GET: Tournois/Details/5
        public ActionResult Details(int id)
        {
            TournoisViewModel tournoisvm = new TournoisViewModel(_context.Tournois.Include(t => t.Joueurs).SingleOrDefault(t => t.ID == id));
            foreach (AspNetUsersTournois jou in tournoisvm.Joueurs)
            {
                jou.User = _context.Users.SingleOrDefault(u=> u.Id == jou.UserId);
            }
            return View(tournoisvm);
        }
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]

        // GET: Tournois/Create
        public ActionResult Create()
        {
            TournoisViewModel tournoisvm = new TournoisViewModel();
            tournoisvm.Date = DateTime.Now;
            tournoisvm.FinInscriptions = DateTime.Now;
            return View(tournoisvm);
        }

        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        // POST: Tournois/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TournoisViewModel tvm)
        {
            try
            {
                Tournois tournois = new Tournois();
                TryUpdateModelAsync(tournois);
                tournois.Date = tvm.Date;
                tournois.FinInscriptions = tvm.FinInscriptions;
                _context.Tournois.Add(tournois);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tournois/Edit/5
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Edit(int id)
        {
            TournoisViewModel TournoisVM = new TournoisViewModel(_context.Tournois.Include(t=>t.Joueurs).SingleOrDefault(s => s.ID == id));
            return View(TournoisVM);
        }

        // POST: Tournois/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Edit(int id, TournoisViewModel tournoisModel)
        {
            try
            {
                // TODO: Add update logic here
                Tournois tournois = _context.Tournois.Include(t=>t.Joueurs).SingleOrDefault(s => s.ID == tournoisModel.ID);
                TryUpdateModelAsync(tournois);
                tournois.Date = tournoisModel.Date;
                tournois.FinInscriptions = tournoisModel.FinInscriptions;
                if (tournois.Joueurs != null)
                {
                    tournois.Joueurs = tournois.Joueurs;
                }
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tournois/Delete/5
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Delete(int id)
        {
            TournoisViewModel TournoisVM = new TournoisViewModel(_context.Tournois.SingleOrDefault(s => s.ID == id));
            return View(TournoisVM);
        }

        // POST: Tournois/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Tournois.Remove(_context.Tournois.SingleOrDefault(s => s.ID == id));
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tournois/Register/5
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult Register(int id)
        {
            Tournois tournois = _context.Tournois.Include(t => t.Joueurs).SingleOrDefault(t => t.ID == id);
            ApplicationUser user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);
            if (!tournois.Joueurs.Any(u=>u.UserId == user.Id) && DateTime.Now < tournois.FinInscriptions)
            {
                AspNetUsersTournois UserTournois = new AspNetUsersTournois()
                {
                    User = user,
                    Tournois = tournois
                };
                tournois.Joueurs.Add(UserTournois);
                _context.Entry(tournois).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Details", new { id = tournois.ID });
        }

        // GET: Tournois/Register/5
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult Deregister(int id)
        {
            Tournois tournois = _context.Tournois.Include(t => t.Joueurs).SingleOrDefault(t => t.ID == id);
            ApplicationUser user = _context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (tournois.Joueurs.Any(u => u.UserId == user.Id) && DateTime.Now < tournois.FinInscriptions)
            {
                AspNetUsersTournois UserTournois = tournois.Joueurs.SingleOrDefault(j=> j.UserId == user.Id && tournois.ID == j.TournoisId);
                tournois.Joueurs.Remove(UserTournois);
                _context.Entry(tournois).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Details", new { id = tournois.ID });
        }
    }
}