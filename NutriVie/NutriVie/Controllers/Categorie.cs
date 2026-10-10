using Microsoft.AspNetCore.Mvc;
using NutriVie.Models.data;

namespace NutriVie.Controllers
{
    public class Categorie : Controller
    {
        private NutriVieDbContext _Bd { get; set; }

        public Categorie(NutriVieDbContext baseDonnees)
        {
            _Bd = baseDonnees;
        }
        public IActionResult Index()
        {
            return View(_Bd.Categorie);
        }
    }
}
