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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NovusConceptum.Controllers
{
    public class MembresController : Controller
    {
        private ApplicationDbContext _context = null;
        private IdentityUserRole<string>[] user_roles;

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
        public ActionResult Edit(string id)
        {
            MembresViewModel membreVM = new MembresViewModel(_context.Users
                .Include(i => i.InfoSup).ThenInclude(r => r.User.Roles).SingleOrDefault(f => f.Id == id));

            membreVM.Roles = _context.Roles.ToList();

            return View(membreVM);
        }

        // POST: Membres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(string id, IFormCollection collection)
        public ActionResult Edit(MembresViewModel modelMembre, string[] selectedRoles)
        {
            try
            {
                // TODO: Add update logic here
                modelMembre.User = _context.Users.Include(i => i.InfoSup).ThenInclude(r => r.User.Roles).SingleOrDefault(u => u.Id == modelMembre.ID);
                user_roles = new IdentityUserRole<string>[selectedRoles.Length];

                
                _context.UserRoles.RemoveRange(modelMembre.User.Roles);
                _context.SaveChanges();

                foreach (var role in selectedRoles)
                    {
                        IdentityUserRole<string> ur = new IdentityUserRole<string>()
                        {
                            UserId = _context.Users.Single(u => u.UserName == modelMembre.User.UserName).Id,
                            RoleId = _context.Roles.Single(r => r.Name == role).Id
                        };
                    _context.UserRoles.Add(ur);
                    }

                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Membres/Delete/5
        public ActionResult Delete(string id)
        {
            MembresViewModel membreVM = new MembresViewModel(_context.Users
                .Include(i => i.InfoSup).ThenInclude(r => r.User.Roles).SingleOrDefault(f => f.Id == id));

            foreach (var role in membreVM.User.Roles)
            {
                membreVM.Roles.Add(_context.Roles.Where(i => i.Id == role.RoleId).FirstOrDefault());
            }

            return View(membreVM);
        }

        // POST: Membres/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
                try
                {
                //Models.Terrains.Liste.Remove(Models.Terrains.Liste.Find(t => t.ID == id));
                    _context.Users.Remove(_context.Users.Include(r => r.Roles).Include(i => i.InfoSup).ThenInclude(im => im.Image).FirstOrDefault(t => t.Id == id));
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                string s = ex.Message;
                    return View();
                }
        }
    }
}