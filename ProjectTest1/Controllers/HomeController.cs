using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectTest1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("MainUser"))
            {
                return RedirectToAction("Index", "MainUser");
            }
            else if (User.IsInRole("ProjectManager"))
            {
                return RedirectToAction("ShowProjets", "ProjectManager");
            }
            else if (User.IsInRole("TeamLeader"))
            {
                return RedirectToAction("ShowProject", "TeamLeader");
            }
            else if (User.IsInRole("Developer"))
            {
                return RedirectToAction("ShowProjects", "Developer");
            }
            else
            {
                return LocalRedirect("/Identity/Account/Login");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
