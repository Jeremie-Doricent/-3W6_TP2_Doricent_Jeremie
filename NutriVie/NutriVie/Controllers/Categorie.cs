using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models.data;
using NutriVie.ViewModel;

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


        public IActionResult Delete(int id)
        {
            Models.Categorie? categorie = _Bd.Categorie.Find(id);

            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Models.Categorie categorie)
        {
            // Empêche la suppression si la catégorie contient au moins une recette.
            if (_Bd.Recettes.Any(r => r.CategorieId == categorie.Id))
            {
                TempData["Erreur"] = "Vous ne pouvez supprimer cette catégorie parce qu'elle contient des recettes";
                return this.RedirectToAction("Delete", new { id = categorie.Id });
            }

            Models.Categorie? aSupprimer = _Bd.Categorie.Find(categorie.Id);

            if (aSupprimer != null)
            {
                _Bd.Categorie.Remove(aSupprimer);
               
            }
            TempData["Succes"] = "reussi";
            return this.RedirectToAction("Index"); 
            
        }
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Categorie categorie)
        {
            if (_Bd.Categorie.Any(r => r.Nom.ToLower() == categorie.Nom.ToLower()))
            {
                TempData["Erreur"] = "Cette catégorie existe déjà";
                return this.View(categorie);   
            }
            if (ModelState.IsValid)
            {
                
                _Bd.Categorie.Add(categorie);
                
                TempData["Success"] = $"{categorie.Nom}  type added";
                return this.RedirectToAction("Index");
            }

            return this.View(categorie);
        }
        public IActionResult Edit(int id)
        {
            var recette = _Bd.Categorie.Find(id);

            if (recette == null) { return NotFound();}
                

           

            return View(recette);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _Bd.Categorie.Update(categorie);

                TempData["Success"] = $"Recette {categorie.Nom} modifiée";
                return this.RedirectToAction("Index");
            }

           
            return View(categorie);
        }
    }
}
