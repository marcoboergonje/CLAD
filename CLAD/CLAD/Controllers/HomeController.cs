using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLAD.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Diagnostics;

namespace CLAD.Controllers
{
    public class HomeController : Controller
    {
        private readonly CLADContext _context;

        public HomeController(CLADContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lastFiveProducts = (from p in _context.Article
                                    orderby p.Content descending
                                    select p).Take(3);

            // return View(await _context.Article.ToListAsync());
            return View(lastFiveProducts);

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
