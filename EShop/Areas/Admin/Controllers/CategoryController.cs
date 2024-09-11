using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;
		public CategoryController(DataContext context)
		{
			_dataContext = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Categories.OrderByDescending(p => p.Id).ToListAsync());
		}
		public async Task<IActionResult> Edit(int Id)
		{
			CategoryModel category = await _dataContext.Categories.FindAsync(Id);
			return View(category);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CategoryModel category)
		{

			if (ModelState.IsValid)
			{
				// code them du lieu
				category.Slug = category.Name.Replace(" ", "-");
				var slug = await _dataContext.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);

				if (slug != null)
				{
					ModelState.AddModelError("", "Danh mục đã có trong database");
					return View(category);
				}

				_dataContext.Add(category);
				await _dataContext.SaveChangesAsync();
				TempData["success"] = "Thêm danh mục thành công";
				return RedirectToAction("Index");
			}
			else
			{
				TempData["error"] = "Model có một vài thứ đang bị lỗi";
				List<string> errors = new List<string>();
				foreach (var value in ModelState.Values)
				{
					foreach (var error in value.Errors)
					{
						errors.Add(error.ErrorMessage);
					}
				}
				string errorMessage = string.Join("\n", errors);
				return BadRequest(errorMessage);
			}


			return View(category);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(CategoryModel category)
		{
			var existed_category = _dataContext.Categories.Find(category.Id); // tìm sản phẩm theo id category

			if (ModelState.IsValid)
			{
				// code them du lieu
				category.Slug = category.Name.Replace(" ", "-");
				//var slug = await _dataContext.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);

				//if (slug != null)
				//{
				//	ModelState.AddModelError("", "Danh mục đã có trong database");
				//	return View(category);
				//}

				// Update ohter category properties
				existed_category.Name = category.Name;
				existed_category.Description = category.Description;
				existed_category.Slug = category.Slug;
				existed_category.Status = category.Status;
				// End Update ohter category properties

				_dataContext.Update(existed_category); // Update the existing category object

				await _dataContext.SaveChangesAsync();
				TempData["success"] = "Cập nhật danh mục thành công";
				return RedirectToAction("Index");
			}
			else
			{
				TempData["error"] = "Model có một vài thứ đang bị lỗi";
				List<string> errors = new List<string>();
				foreach (var value in ModelState.Values)
				{
					foreach (var error in value.Errors)
					{
						errors.Add(error.ErrorMessage);
					}
				}
				string errorMessage = string.Join("\n", errors);
				return BadRequest(errorMessage);
			}


			return View(category);
		}

		public async Task<IActionResult> Delete(int Id)
		{
			CategoryModel category = await _dataContext.Categories.FindAsync(Id);

			_dataContext.Categories.Remove(category);
			await _dataContext.SaveChangesAsync();
			TempData["successs"] = "Danh mục đã xoá";
			return RedirectToAction("Index");
		}



	}
}
