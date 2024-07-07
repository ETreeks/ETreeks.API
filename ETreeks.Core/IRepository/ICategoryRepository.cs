using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
	public interface ICategoryRepository
	{
		Task<List<Category>> GetAllCategories();

		Task<Category> GetCategoryById(int id);

		Task CreateCategory(Category category);

		Task UpdateCategory(Category category);

		Task DeleteCategory(int id);

	}
}
