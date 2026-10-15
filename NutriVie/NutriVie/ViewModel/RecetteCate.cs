using Microsoft.AspNetCore.Mvc.Rendering;
using NutriVie.Controllers;

namespace NutriVie.ViewModel
{
    public class RecetteCate
    {
        public NutriVie.Models.Recette Recette { get; set; }

        public SelectList? Cate { get; set; }
    }
}
