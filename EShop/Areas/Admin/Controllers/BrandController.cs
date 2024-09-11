using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class BrandController : Controller
	{
		private readonly DataContext _dataContext;
		public BrandController(DataContext context)
		{
			_dataContext = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Brands.OrderByDescending(p => p.Id).ToListAsync());
		}

		public async Task<IActionResult> Edit(int Id)
		{
			BrandModel brand = await _dataContext.Brands.FindAsync(Id);
			return View(brand);
		}
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BrandModel brand)
		{

			if (ModelState.IsValid)
			{
				// code them du lieu
				brand.Slug = brand.Name.Replace(" ", "-");
				var slug = await _dataContext.Brands.FirstOrDefaultAsync(p => p.Slug == brand.Slug);

				if (slug != null)
				{
					ModelState.AddModelError("", "Danh mục đã có trong database");
					return View(brand);
				}

				_dataContext.Add(brand);
				await _dataContext.SaveChangesAsync();
				TempData["success"] = "Thêm thương hiệu thành công";
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


			return View(brand);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(BrandModel brand)
		{
			var existed_brand = _dataContext.Brands.Find(brand.Id); // tìm sản phẩm theo id brand

			if (ModelState.IsValid)
			{
				// code them du lieu
				brand.Slug = brand.Name.Replace(" ", "-");

				//var slug = await _dataContext.Brands.FirstOrDefaultAsync(p => p.Slug == brand.Slug);

				//if (slug != null)
				//{
				//	ModelState.AddModelError("", "Thương hiệu đã có trong database");
				//	return View(brand);
				//}

				// Update ohter category properties
				existed_brand.Name = brand.Name;
				existed_brand.Description = brand.Description;
				existed_brand.Slug = brand.Slug;
				existed_brand.Status = brand.Status;
				// End Update ohter category properties

				_dataContext.Update(existed_brand); // Update the existing category object

				await _dataContext.SaveChangesAsync();
				TempData["success"] = "Cập nhật thương hiệu thành công";
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


			return View(brand);
		}

		public async Task<IActionResult> Delete(int Id)
		{
			BrandModel brand = await _dataContext.Brands.FindAsync(Id);

			_dataContext.Brands.Remove(brand);
			await _dataContext.SaveChangesAsync();
			TempData["successs"] = "Thương hiệu đã xoá";
			return RedirectToAction("Index");
		}

	}
}
