using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models;
using NutriVie.Models.data;

namespace NutriVie.Controllers
{
    public class HomeController : Controller
    {

        private NutriVieDbContext _Bd { get; set; }

        public HomeController(NutriVieDbContext baseDonnees)
        {
            _Bd = baseDonnees;
        }
        public IActionResult Index()
        {

            
            return View(_Bd.Services);
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
