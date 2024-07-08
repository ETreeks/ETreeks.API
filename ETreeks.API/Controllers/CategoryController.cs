using ETreeks.Core.Data;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETreeks.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		// Get all categories
		[HttpGet("GetAllCategories")]
		public async Task<ActionResult<List<Category>>> GetAllCategories()
		{
			var categories = await _categoryService.GetAllCategories();
			return Ok(categories);
		}

		// Get category by id
		[HttpGet("GetCategoryById/{id}")]
		public async Task<ActionResult<Category>> GetCategoryById(int id)
		{
			var category = await _categoryService.GetCategoryById(id);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		// Create a new category
		[HttpPost("CreateCategory")]
		public async Task<ActionResult> CreateCategory([FromBody] Category category)
		{
			if (category == null)
			{
				return BadRequest();
			}

			await _categoryService.CreateCategory(category);
			return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
		}

		// Update an existing category
		[HttpPut("UpdateCategory")]
		public async Task<ActionResult> UpdateCategory([FromBody] Category category)
		{
			if (category == null)
			{
				return BadRequest();
			}

			await _categoryService.UpdateCategory(category);
			return NoContent();
		}

		// Delete a category
		[HttpDelete("DeleteCategory/{id}")]
		public async Task<ActionResult> DeleteCategory(int id)
		{
			var category = await _categoryService.GetCategoryById(id);
			if (category == null)
			{
				return NotFound();
			}

			await _categoryService.DeleteCategory(id);
			return NoContent();
		}
	}
}
