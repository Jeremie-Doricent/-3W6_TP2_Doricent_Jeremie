using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var categories = _Bd.Categorie
                .Include(c => c.Recettes.OrderBy(r => r.Nom))
                .OrderByDescending(c => c.Nom)
                .ToList();

            return View(categories);
        }
    }
}
