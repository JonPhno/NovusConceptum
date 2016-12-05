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

        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Execute()
        {
            //string batchFileLocation = @"Batch\\test.bat";
            //Process p = new Process();
            //var startinfo = new ProcessStartInfo(batchFileLocation," asd ");
            //p.StartInfo = startinfo;
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.UserName = "William";
            //p.StartInfo.PasswordInClearText = "allo";
            //startinfo.RedirectStandardOutput = true;
            //startinfo.UseShellExecute = false;
            //p.Start();
            //string s = p.StandardOutput.ReadToEnd();
            //ViewData["test"] = s;
            return View("Index");
        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
           // _sOut += e.Data;
        }

        public IActionResult Online()
        {

            //Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //var ip = IPAddress.Parse("192.168.0.117");
            //var point = new IPEndPoint(ip, 25565);
            //sock.Bind(point);
            //sock.Listen(10);
           //TcpClient c = new TcpClient();
           // UdpClient u = new UdpClient();
            //bool b;
            //try
            //{
              //  u.
              //c.ConnectAsync("192.168.0.117", 25565);
            //    b = c.Connected;
            //    c.Dispose();

            //}
            //catch (Exception)
            //{
            //    b = false;
            //}
            //ViewData["Title"] = b.ToString();


            // jvais essayer de faire un petit programme pour interroger la bd qui va update
            // l'état du serveur 

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
    }
}
