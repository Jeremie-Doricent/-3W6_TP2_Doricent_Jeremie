using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace NutriVie.Models
    
{
    public class Service
    {
        [Key]
        public int Id { get; set; } 

        [Range(5, 20)]
        public string Nom { get; set; }
        [Range(5, 250)]
        public string Description  { get; set; }

      

    }
}
