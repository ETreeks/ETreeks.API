using ETreeks.Core.Data;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
	public class CategoryService : ICategoryService
	{

		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task CreateCategory(Category category)
		{
			await _categoryRepository.CreateCategory(category);
		}

		public async Task DeleteCategory(int id)
		{
			await _categoryRepository.DeleteCategory(id);
		}

        //public async Task<List<Category>> GetAllCategories()
        //{
        //	var result = await _categoryRepository.GetAllCategories();
        //	var finalResult = from r in result
        //					  group r by r.Id into g
        //					  select new Category
        //					  { Id = g.Key,
        //					  Categoryname = g.First().Categoryname,
        //					  Courses = g.SelectMany(x => x.Courses).ToList() };
        //	return finalResult.ToList();
        //}
        public async Task<List<Category>> GetAllCategories()
        {
            var result = await _categoryRepository.GetAllCategories();
            var finalResult = from r in result
                              group r by r.Id into g
                              select new Category
                              {
                                  Id = g.Key,
                                  Categoryname = g.First().Categoryname,
                                  Imagename = g.First().Imagename, // Ensure this line exists
                                  Courses = g.SelectMany(x => x.Courses).ToList()
                              };
            return finalResult.ToList();
        }

        public Task<Category> GetCategoryById(int id)
		{
			return _categoryRepository.GetCategoryById(id);
		}

		public async Task UpdateCategory(Category category)
		{
			await _categoryRepository.UpdateCategory(category);
		}
	}
}
