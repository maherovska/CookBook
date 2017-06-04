using System;
using System.Collections.Generic;

namespace Cookbook.Entities.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
