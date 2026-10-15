using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models.data;
using NutriVie.ViewModel;

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
        public IActionResult Delete(int id)
        {
            var recette = _BD.Recettes
                .Include(r => r.categorie)
                .FirstOrDefault(r => r.Id == id);

            if (recette == null)
                return NotFound();

            return View(recette);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var recette = _BD.Recettes.Find(id);
            if (recette != null)
            {
                _BD.Recettes.Remove(recette);
                
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Models.Recette? recette = _BD.Recettes.Find(id);

            if (recette == null)
                return NotFound();

            RecetteCate recetteCate = new RecetteCate();
            recetteCate.Recette = recette;
            recetteCate.Cate = new SelectList(_BD.Categorie.ToList(), "Id", "Nom", recette.CategorieId);

            return View(recetteCate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RecetteCate recetteCate)
        {
            if (ModelState.IsValid)
            {
                _BD.Recettes.Update(recetteCate.Recette);
               
                TempData["Success"] = $"Recette {recetteCate.Recette.Nom} modifiée";
                return this.RedirectToAction("Index");
            }

            recetteCate.Cate = new SelectList(_BD.Categorie.ToList(), "Id", "Nom", recetteCate.Recette.CategorieId);

            return View(recetteCate);
        }
        public IActionResult Create()
        {
            RecetteCate recetteCate = new RecetteCate();

            recetteCate.Cate = new SelectList(_BD.Categorie.ToList(), "Id", "Nom");

            return View(recetteCate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecetteCate recetteCate)
        {
            // Si le modèle est valide, la recette est ajoutée et nous sommes redirigés vers Index.
            if (ModelState.IsValid)
            {
                _BD.Recettes.Add(recetteCate.Recette);
                _BD.SaveChanges();
                TempData["Success"] = $"Recette {recetteCate.Recette.Nom} ajoutée";
                return this.RedirectToAction("Index");
            }

            recetteCate.Cate = new SelectList(_BD.Categorie.ToList(), "Id", "Nom");

            return View(recetteCate);
        }

    }
}
