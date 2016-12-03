using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovusConceptum.Data;
using Microsoft.EntityFrameworkCore;
using NovusConceptum.Models;
using System.Diagnostics;

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
            var serveurs = _context.Serveurs;
            foreach (var serveur in serveurs)
            {
                liste_serveurvm.Add(new ServeurViewModel(serveur));
            }

            return View(liste_serveurvm);
        }

        // GET: Serveur/Details/5
        public ActionResult Details(int id)
        {
            ServeurViewModel serveur = new ServeurViewModel(_context.Serveurs.FirstOrDefault(se => se.ID == id));
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
            ServeurViewModel serveur = new ServeurViewModel(_context.Serveurs.FirstOrDefault(se => se.ID == id));
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
                Serveur serveur = _context.Serveurs.FirstOrDefault(se => se.ID == id);
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
            ServeurViewModel serveur = new ServeurViewModel(_context.Serveurs.FirstOrDefault(se => se.ID == id));
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
                Serveur serveur = _context.Serveurs.FirstOrDefault(se => se.ID == id);
                _context.Remove(serveur);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public IActionResult StartVM(int id)
        {
            string batchFileLocation = @"Batch\\startvm.bat";
            Process p = new Process();
            string NomVm = _context.Serveurs.SingleOrDefault(se => se.ID == id).Nom;
            var startinfo = new ProcessStartInfo(batchFileLocation, NomVm);
            p.StartInfo = startinfo;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.UserName = "William";
            p.StartInfo.PasswordInClearText = "allo";
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            p.Start();
            string sOutput = p.StandardOutput.ReadToEnd();
            ViewData["output"] = sOutput;
            return View("Output");
        }
        public IActionResult SaveVm(int id)
        {
            string batchFileLocation = @"Batch\\controlvm.bat";
            Process p = new Process();
            string NomVm = _context.Serveurs.SingleOrDefault(se => se.ID == id).Nom;
            var startinfo = new ProcessStartInfo(batchFileLocation,NomVm + " " + "savestate");
            p.StartInfo = startinfo;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.UserName = "William";
            p.StartInfo.PasswordInClearText = "allo";
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            p.Start();
            string sOutput = p.StandardOutput.ReadToEnd();
            ViewData["output"] = sOutput;
            return View("Output");
        }
        public ActionResult StopVM(int id)
        {
            string batchFileLocation = @"Batch\\controlvm.bat";
            Process p = new Process();
            string NomVm = _context.Serveurs.SingleOrDefault(se => se.ID == id).Nom;
            var startinfo = new ProcessStartInfo(batchFileLocation, NomVm + " " + "poweroff");
            p.StartInfo = startinfo;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.UserName = "William";
            p.StartInfo.PasswordInClearText = "allo";
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            p.Start();
            string sOutput = p.StandardOutput.ReadToEnd();
            ViewData["output"] = sOutput;
            return View("Output");
        }

        public ActionResult ResetVM(int id)
        {
            string batchFileLocation = @"Batch\\controlvm.bat";
            Process p = new Process();
            string NomVm = _context.Serveurs.SingleOrDefault(se => se.ID == id).Nom;
            var startinfo = new ProcessStartInfo(batchFileLocation, NomVm + " " + "reset");
            p.StartInfo = startinfo;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.UserName = "William";
            p.StartInfo.PasswordInClearText = "allo";
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            p.Start();
            string sOutput = p.StandardOutput.ReadToEnd();
            ViewData["output"] = sOutput;
            return View("Output");
        }

        public ActionResult ResumeVM(int id)
        {
            string batchFileLocation = @"Batch\\controlvm.bat";
            Process p = new Process();
            string NomVm = _context.Serveurs.SingleOrDefault(se => se.ID == id).Nom;
            var startinfo = new ProcessStartInfo(batchFileLocation, NomVm + " " + "resume");
            p.StartInfo = startinfo;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.UserName = "William";
            p.StartInfo.PasswordInClearText = "allo";
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            p.Start();
            string sOutput = p.StandardOutput.ReadToEnd();
            ViewData["output"] = sOutput;
            return View("Output");
        }

        public ActionResult ACPIOffVM(int id)
        {
            string batchFileLocation = @"Batch\\test.bat";
          //  string batchFileLocation = @"Batch\\controlvm.bat";
            Process p = new Process();
            string NomVm = _context.Serveurs.SingleOrDefault(se => se.ID == id).Nom;
            var startinfo = new ProcessStartInfo(batchFileLocation);
           // var startinfo = new ProcessStartInfo(batchFileLocation, NomVm + " " + "acpipowerbutton");
            p.StartInfo = startinfo;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.UserName = "William";
            p.StartInfo.PasswordInClearText = "allo";
            startinfo.RedirectStandardOutput = true;
            startinfo.UseShellExecute = false;
            p.Start();
            string sOutput = p.StandardOutput.ReadToEnd();
            ViewData["output"] = sOutput;
            return View("Output");
        }
    }
}