using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            var recettes = _BD.Recettes
        .Include(r => r.categorie)
        .OrderBy(r => r.categorie.Nom)
        .ThenBy(r => r.Nom).Include(r => r.categorie)
        .ToList();
            return View(recettes);
        }
        public IActionResult Details(int id)
        {
            var recette = _BD.Recettes
                .Include(r => r.categorie)
                .FirstOrDefault(r => r.Id == id);

            if (recette == null)
                return NotFound();

            return View(recette);
        }
    }
}
