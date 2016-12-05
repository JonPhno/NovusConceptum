using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovusConceptum.Data;
using NovusConceptum.Models.SondageViewModel;
using Microsoft.EntityFrameworkCore;
using NovusConceptum.Models;
using Microsoft.AspNetCore.Authorization;

namespace NovusConceptum.Controllers
{
    public class SondageController : Controller
    {
        private ApplicationDbContext _context = null;
        public SondageController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Sondage
        public ActionResult Index()
        {
            List<SondageViewModel> sondagesVm = new List<SondageViewModel>();
            var sondages = _context.Sondages.Include(s => s.Utilisateurs);

            foreach (Sondage s in sondages)
            {
                sondagesVm.Add(new SondageViewModel(s));
            }

            return View(sondagesVm);
        }

        // GET: Sondage/Details/5
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult Details(int id)
        {
            SondageViewModel s = new SondageViewModel(_context.Sondages.Include(u => u.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(s);
        }

        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        // GET: Sondage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sondage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult Create(SondageViewModel svm)
        {
            try
            {
                // TODO: Add insert logic here
                Sondage sondage = new Sondage();
                TryUpdateModelAsync(sondage);
                sondage.Options = svm.Options[1];
                string[] optionsSplit = svm.Options[1].Split(',');
                sondage.Date = DateTime.Now;
                int iNombreOptions = optionsSplit.Count();
                string choix = "0";
                for (int i = 0; i < iNombreOptions; i++)
                {
                    choix += ",0";
                }
                sondage.Choix = choix;
                _context.Sondages.Add(sondage);
                _context.SaveChanges();
                return RedirectToAction("/Details/" ,new { _context.Sondages.Include(so=> so.Utilisateurs).SingleOrDefault(s => s.Nom == sondage.Nom).ID });
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrateur,Modérateur")]
        // GET: Sondage/Edit/5
        public ActionResult Edit(int id)
        {
            SondageViewModel s = new SondageViewModel(_context.Sondages.Include(u => u.Utilisateurs).SingleOrDefault(so => so.ID == id));
            s.OptionsString = s.Options[0];
            for (int i =1; i < s.Options.Count; i++)
            {
                s.OptionsString += "," + s.Options[i];
;            }
            return View(s);
        }

        // POST: Sondage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Edit(int id, SondageViewModel svm)
        {
            try
            {
                // TODO: Add insert logic here
                Sondage sondage = _context.Sondages.Include(s => s.Utilisateurs).SingleOrDefault(so => so.ID == id);
                TryUpdateModelAsync(sondage);
                sondage.Options = svm.OptionsString;
                sondage.Date = DateTime.Now;
                _context.Entry(sondage).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("/Details/", new { _context.Sondages.Include(so => so.Utilisateurs).SingleOrDefault(s => s.Nom == sondage.Nom).ID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Sondage/Delete/5
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Delete(int id)
        {
            SondageViewModel sondagevm = new SondageViewModel(_context.Sondages.Include(s => s.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(sondagevm);
        }

        // POST: Sondage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
               Sondage sondage = _context.Sondages.FirstOrDefault(s => s.ID == id);
                sondage.Utilisateurs = null;
                _context.Sondages.Remove(sondage);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult Vote(int id)
        {
            SondageViewModel s = new SondageViewModel(_context.Sondages.Include(u => u.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult Vote(int id, string selectedOption)
        {
            try
            {
                Sondage sondage = _context.Sondages.Include(s => s.Utilisateurs).SingleOrDefault(so => so.ID == id);

                if (!sondage.Utilisateurs.Any(u => u.UserName == User.Identity.Name) && sondage.DateFin > DateTime.Now)
                {

                    string[] options = sondage.Options.Split(',');
                    string[] choix = sondage.Choix.Split(',');
            
                for (int i = 0; i < options.Length; i++)
                {
                    if (options[i] == selectedOption)
                    {
                        choix[i] = (int.Parse(choix[i]) + 1).ToString(); ;
                    }
                }
                string choixVote = choix[0];
                for (int i = 1; i < choix.Length; i++)
                {
                    choixVote += "," + choix[i];
                }
                sondage.Choix = choixVote;
                sondage.Utilisateurs.Add(_context.Users.SingleOrDefault(u => u.UserName == User.Identity.Name));
                _context.Entry(sondage).State = EntityState.Modified;
                _context.SaveChanges();
                }
                return RedirectToAction("Results", new { sondage.ID });
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrateur,Modérateur,Utilisateur,Ange")]
        public ActionResult Results(int id)
        {
            SondageViewModel s = new SondageViewModel(_context.Sondages.Include(u => u.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(s);
        }
    }
}