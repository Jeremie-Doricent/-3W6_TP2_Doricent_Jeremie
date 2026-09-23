using Microsoft.AspNetCore.Mvc;

namespace NutriVie.Controllers
{
    public class Recette : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
