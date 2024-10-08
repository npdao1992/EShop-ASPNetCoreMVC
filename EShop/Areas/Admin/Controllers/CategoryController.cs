﻿using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Category")]
    [Authorize(Roles = "Admin,Staff")]
    public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;
		public CategoryController(DataContext context)
		{
			_dataContext = context;
		}

		// Phân trang bằng DataTable JS
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Categories.OrderByDescending(p => p.Id).ToListAsync());
		}

		// Phân trang bằng code thuần
		//[Route("Index")]
		//public async Task<IActionResult> Index(int pg = 1)
		//{
		//	// Lấy tất cả danh mục từ cơ sở dữ liệu
		//	List<CategoryModel> category = _dataContext.Categories.OrderBy(p => p.Name).ToList(); //33 datas


		//	const int pageSize = 10; //10 items/trang

		//	if (pg < 1) //page < 1;
		//	{
		//		pg = 1; //page ==1
		//	}
		//	// Tổng số danh mục
		//	int recsCount = category.Count(); //33 items;

		//	var pager = new Paginate(recsCount, pg, pageSize);

		//	// Tính số lượng danh mục cần bỏ qua
		//	int recSkip = (pg - 1) * pageSize; //(3 - 1) * 10; 

		//	// Lấy dữ liệu cho trang hiện tại
		//	var data = category.Skip(recSkip).Take(pager.PageSize).ToList(); //category.Skip(20).Take(10).ToList()

		//	// Truyền dữ liệu vào view dưới dạng Tuple ( Xử lý việc truyền tổng số được truy vấn)
		//	var model = new Tuple<IEnumerable<CategoryModel>, int>(data, recsCount);

		//	ViewBag.Pager = pager;

		//	return View(model);
		//}

		[Route("Edit")]
		public async Task<IActionResult> Edit(int Id)
		{
			CategoryModel category = await _dataContext.Categories.FindAsync(Id);
			return View(category);
		}

		[Route("Create")]
		public IActionResult Create()
		{
			return View();
		}

		[Route("Create")]
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


		[Route("Edit")]
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


		[Route("Delete")]
		public async Task<IActionResult> Delete(int Id)
		{
			CategoryModel category = await _dataContext.Categories.FindAsync(Id);

			_dataContext.Categories.Remove(category);
			await _dataContext.SaveChangesAsync();
			TempData["success"] = "Danh mục đã xoá thành công";
			return RedirectToAction("Index");
		}



	}
}
