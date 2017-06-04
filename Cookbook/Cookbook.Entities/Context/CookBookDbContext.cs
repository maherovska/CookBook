using Cookbook.Entities.Entities;
using System.Data.Entity;

namespace Cookbook.Entities.Context
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext() : base("name=CookbookDBConnectionString")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
