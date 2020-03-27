using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCoreSQL.Models;

namespace EFCoreSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly mifernadbContext mifernadbContext;
        public HomeController(ILogger<HomeController> logger, mifernadbContext context)
        {
            _logger = logger;
            mifernadbContext = context;
        }

        public IActionResult Index()
        {
            var name = mifernadbContext.Names.Where(x => x.Id > 0);
            
            return View(name);
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
