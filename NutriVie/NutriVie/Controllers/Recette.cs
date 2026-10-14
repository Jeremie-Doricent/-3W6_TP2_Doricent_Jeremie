using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
               _BD.Recettes.Find(id);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Recette recette)
        {
            if (ModelState.IsValid)
            {
                _BD.Recettes.Update(recette);

                TempData["Success"] = $"{recette.Nom} zombie type added";
                return this.RedirectToAction("Index");
            }

            return View(recette);
        }
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Recette recette)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                _BD.Recettes.Add(recette);
                
                TempData["Success"] = $"{recette.Nom} zombie type added";
                return this.RedirectToAction("Index");
               
            }
            ViewBag.Categories = new SelectList(_BD.Categorie, "Id", "Nom", recette.CategorieId);
            return this.View(recette);
        }

    }
}
