using Cookbook.Entities.Entities;
using System;

namespace Cookbook.Repositories.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Recipe> RecipeRepository { get; }
        IRepository<Ingredient> IngredientRepository { get; }

        void Save();
    }
}
