using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovusConceptum.Data;
using NovusConceptum.Models.MembresViewModels;
using Microsoft.EntityFrameworkCore;
using NovusConceptum.Models;

namespace NovusConceptum.Controllers
{
    public class MembresController : Controller
    {
        private ApplicationDbContext _context = null;
        public MembresController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Membres
        public ActionResult Index()
        {
            List<MembresViewModel> list_mvm = new List<MembresViewModel>();
            var membres = _context.Users.Include(isu => isu.InfoSup).ThenInclude(i => i.Image);

            foreach (ApplicationUser user in membres)
            {
                list_mvm.Add(new MembresViewModel(user));
            }

            return View(list_mvm);
        }

        // GET: Membres/Details/5
        public ActionResult Details(string id)
        {
            MembresViewModel membreVM = new MembresViewModel(_context.Users
                .Include(i => i.InfoSup).ThenInclude(r => r.User.Roles).SingleOrDefault(f => f.Id == id));
            foreach (var role in membreVM.User.Roles)
            {
                membreVM.Roles.Add(_context.Roles.Where(i => i.Id == role.RoleId).FirstOrDefault());
            }

            return View(membreVM);
        }

        // GET: Membres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Membres/Create
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

        // GET: Membres/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Membres/Edit/5
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

        // GET: Membres/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Membres/Delete/5
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