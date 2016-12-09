using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using NovusConceptum.Data;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace NovusConceptum.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Qui sommes nous?";

            return View();
        }
        
        public IActionResult Contact()
        {
            ViewData["Message"] = "Comment nous contacter?";
            ViewData["will"] = _context.Users.SingleOrDefault(u => u.UserName == "willp3").Id;
            ViewData["sam"] = _context.Users.SingleOrDefault(u => u.UserName == "Angela").Id;
            return View();
        }

       

        public IActionResult Membres()
        {
            ViewData["Message"] = "La liste de nos membres";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }

        [Authorize(Roles ="Administrateurs")]
        public IActionResult Game()
        {
            return View();
        }


    }
}
