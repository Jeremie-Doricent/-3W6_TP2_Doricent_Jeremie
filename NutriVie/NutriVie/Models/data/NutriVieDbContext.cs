using Microsoft.EntityFrameworkCore;

namespace NutriVie.Models.data
{
    public class NutriVieDbContext:DbContext

    {
        public NutriVieDbContext(DbContextOptions<NutriVieDbContext> options) : base(options)
        {

        }
    }
}
