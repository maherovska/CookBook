using Cookbook.Repositories.Abstract;
using System;
using Cookbook.Entities.Entities;
using Cookbook.Entities.Context;

namespace Cookbook.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private CookBookDbContext _context;
        private IRepository<Recipe> _recipeRepository;
        private IRepository<Ingredient> _ingredientRepository;

        public UnitOfWork()
        {
            _context = new CookBookDbContext();
        }

        public IRepository<Recipe> RecipeRepository
        {
            get
            {
                if (_recipeRepository == null)
                {
                    _recipeRepository = new GenericRepository<Recipe>(_context);
                }

                return _recipeRepository;
            }
        }

        public IRepository<Ingredient> IngredientRepository
        {
            get
            {
                if (_ingredientRepository == null)
                {
                    _ingredientRepository = new GenericRepository<Ingredient>(_context);
                }

                return _ingredientRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
