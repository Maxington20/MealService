using Microsoft.EntityFrameworkCore;

namespace MealService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Models.Meal> Meals { get; set; }
    }
}
