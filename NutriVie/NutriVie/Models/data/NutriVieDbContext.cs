using Microsoft.EntityFrameworkCore;

namespace NutriVie.Models.data
{
    public class NutriVieDbContext:DbContext

    {
        public NutriVieDbContext(DbContextOptions<NutriVieDbContext> options) : base(options)
        {

        }
        public DbSet<Service> Services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(
               new Service() {id =1, Nom = "Recettes Saines", Description = "Des recettes équilibrées et faciles à préparer pour toute la famille." },
               new Service() {id=2, Nom = "Plans Nutritionnels", Description = "Des plans alimentaires personnalisés par nos nutritionnistes." },
               new Service() {id =3, Nom = "Conseils d'Experts", Description = "Des articles et guides sur la nutrition et le bien-être." }


                );
        }
    }
}
