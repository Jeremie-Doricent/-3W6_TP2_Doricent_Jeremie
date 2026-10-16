using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace NutriVie.Models
{
    public class Aliment
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; }

        public double CaloriesPour100g { get; set; }

        [ValidateNever]
        public List<AlimentRecette> AlimentRecettes { get; set; }
    }
}
