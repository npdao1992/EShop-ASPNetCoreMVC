using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Brand")]
    [Authorize(Roles = "Admin,Staff")]
    public class BrandController : Controller
	{
		private readonly DataContext _dataContext;
		public BrandController(DataContext context)
		{
			_dataContext = context;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Brands.OrderByDescending(p => p.Id).ToListAsync());
		}

		//[Route("Index")]
		//public async Task<IActionResult> Index(int pg = 1)
		//{
		//	List<BrandModel> brand = _dataContext.Brands.OrderBy(p => p.Name).ToList();

		//	const int pageSize = 10;

		//	if (pg < 1)
		//	{
		//		pg = 1;
		//	}
		//	int recsCount = brand.Count();

		//	var pager = new Paginate(recsCount, pg, pageSize);

		//	int recSkip = (pg - 1) * pageSize; 

		//	var data = brand.Skip(recSkip).Take(pager.PageSize).ToList();

		//	// Truyền dữ liệu vào view dưới dạng Tuple ( Xử lý việc truyền tổng số được truy vấn)
		//	var model = new Tuple<IEnumerable<BrandModel>, int>(data, recsCount);

		//	ViewBag.Pager = pager;

		//	return View(model);
		//}

		[Route("Edit")]
		public async Task<IActionResult> Edit(int Id)
		{
			BrandModel brand = await _dataContext.Brands.FindAsync(Id);
			return View(brand);
		}

		[Route("Create")]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[Route("Create")]
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

		[Route("Edit")]
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

		[Route("Delete")]
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
