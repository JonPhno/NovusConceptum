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
        public ActionResult Details(int id)
        {
            SondageViewModel s = new SondageViewModel(_context.Sondages.Include(u => u.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(s);
        }

        // GET: Sondage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sondage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Sondage sondage = new Sondage();
                TryUpdateModelAsync(sondage);
                sondage.Date = DateTime.Now;
                int iNombreOptions = sondage.Options.Count();
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

        // GET: Sondage/Edit/5
        public ActionResult Edit(int id)
        {
            SondageViewModel s = new SondageViewModel(_context.Sondages.Include(u => u.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(s);
        }

        // POST: Sondage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Sondage sondage = _context.Sondages.Include(s => s.Utilisateurs).SingleOrDefault(so => so.ID == id);
                TryUpdateModelAsync(sondage);
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
        public ActionResult Delete(int id)
        {
            SondageViewModel sondagevm = new SondageViewModel(_context.Sondages.Include(s => s.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(sondagevm);
        }

        // POST: Sondage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _context.Sondages.Remove(_context.Sondages.SingleOrDefault(s => s.ID == id));
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Vote(int id)
        {
            SondageViewModel s = new SondageViewModel(_context.Sondages.Include(u => u.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int id, string selectedOption)
        {
            try
            {
                Sondage sondage = _context.Sondages.Include(s => s.Utilisateurs).SingleOrDefault(so => so.ID == id);
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
                _context.Entry(sondage).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Results",new { });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Results(int id)
        {
            SondageViewModel s = new SondageViewModel(_context.Sondages.Include(u => u.Utilisateurs).SingleOrDefault(so => so.ID == id));
            return View(s);
        }
    }
}