namespace Cookbook.Entities.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Cookbook.Entities.Context.CookBookDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cookbook.Entities.Context.CookBookDbContext context)
        {
            context.Recipes.AddOrUpdate(
                x => x.Id,
                new Recipe()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Title = "Honey-Garlic Slow Cooker Chicken Thighs",
                    Description = "This is an easy slow cooker recipe for chicken thighs in a sauce made with soy sauce, ketchup, and honey.",
                    Instructions = "Lay chicken thighs into the bottom of a 4-quart slow cooker. Whisk soy sauce, ketchup, honey, garlic, and basil together in a bowl; pour over the chicken. Cook on Low for 6 hours.",
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "skinless, boneless chicken thighs",
                            Units = "4",
                        },
                        new Ingredient()
                        {
                            Name = "soy sauce",
                            Units = "1/2 cup",
                        },
                        new Ingredient()
                        {
                            Name = "ketchup",
                            Units = "1/2 cup",
                        },
                        new Ingredient()
                        {
                            Name = "honey",
                            Units = "1/3 cup",
                        },
                        new Ingredient()
                        {
                            Name = "dried basil",
                            Units = "1 teaspoon",
                        }
                    }
                },
                new Recipe()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Title = "Oatmeal Blueberry Yogurt Pancakes",
                    Description = "Healthy Pancakes made in the blender with oatmeal, yogurt, banana and an egg! Easy to make, filling and high in protein!",
                    Instructions = "Place all ingredients except fresh blueberries into a blender; blend until smooth. Add a few blueberries on top. Flip cakes and cook until golden brown on underside.",
                    Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "gluten free rolled oats",
                            Units = "1/2 cup",
                            RecipeId = 2
                        },
                        new Ingredient()
                        {
                            Name = "baking powder",
                            Units = "1/2 teaspoon",
                            RecipeId = 2
                        },
                        new Ingredient()
                        {
                            Name = "ripe banana",
                            Units = "1/2",
                            RecipeId = 2
                        },
                        new Ingredient()
                        {
                            Name = "egg",
                            Units = "1",
                            RecipeId = 2
                        },
                        new Ingredient()
                        {
                            Name = "blueberries",
                            Units = "1/3 cup",
                            RecipeId = 2
                        }
                    }
                });
        }
    }
}
