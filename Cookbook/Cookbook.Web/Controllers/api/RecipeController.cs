using Cookbook.Entities.Entities;
using Cookbook.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cookbook.Web.Controllers
{
    [RoutePrefix("api/Recipe")]
    public class RecipeController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public RecipeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RecipeController()
        {
            _unitOfWork = (IUnitOfWork)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUnitOfWork));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            try
            {
                var result = _unitOfWork.RecipeRepository
                                        .Get()
                                        .OrderBy(x => x.DateCreated);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var result = _unitOfWork.RecipeRepository
                                        .GetById(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Insert(Recipe recipe)
        {
            try
            {
                recipe.DateCreated = DateTime.Now;

                _unitOfWork.RecipeRepository
                           .Insert(recipe);
                _unitOfWork.Save();

                return Ok(recipe);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Edit([FromBody] Recipe recipe)
        {
            try
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (ingredient.Id == 0)
                    {
                        ingredient.RecipeId = recipe.Id;
                        _unitOfWork.IngredientRepository.Insert(ingredient);
                    }
                }

                _unitOfWork.RecipeRepository
                           .Update(recipe);
                _unitOfWork.Save();

                return Ok(recipe);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.RecipeRepository
                           .Delete(id);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }           
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _unitOfWork.Dispose();
        }
    }
}
