using Microsoft.AspNetCore.Mvc;
using NutriVie.Models.data;

namespace NutriVie.Controllers
{
    public class Recette : Controller
    {
        private NutriVieDbContext _BD { get; set; }

        public Recette(NutriVieDbContext baseDonnees)
        {
            _BD = baseDonnees;
        }
        public IActionResult Index()
        {

            return View(_BD.Recettes);
        }
        public IActionResult Detail()
        {
            return View();
        }
    }
}
