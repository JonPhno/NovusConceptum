using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace NovusConceptum.Controllers
{
    public class HomeController : Controller
    {
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
            string batchFileLocation = @"A:\\William\\Desktop\\test.bat";
            Process p = new Process();
            p.StartInfo.FileName = /*@"C:\Windows\System32\cmd.exe";*/batchFileLocation;
           // p.StartInfo.WorkingDirectory = Path.GetDirectoryName(batchFileLocation);
            p.StartInfo.UseShellExecute = false;
            //p.StartInfo.Arguments = batchFileLocation;
            // Run the process and wait for it to complete
            p.StartInfo.UserName = "William";
            p.StartInfo.PasswordInClearText = "allo";
            p.Start();
  //          p.WaitForExit();
            return View("Index");
        }
        public IActionResult Online()
        {

            //Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //var ip = IPAddress.Parse("192.168.0.117");
            //var point = new IPEndPoint(ip, 25565);
            //sock.Bind(point);
            //sock.Listen(10);
        //   TcpClient c = new TcpClient();
         //   UdpClient u = new UdpClient();
            //bool b;
            //try
            //{
       //         u.
        //      c.ConnectAsync("192.168.0.117", 25565);
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
    }
}
