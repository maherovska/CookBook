﻿namespace Cookbook.Entities.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
