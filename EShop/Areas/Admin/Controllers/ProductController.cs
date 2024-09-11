using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Route("Admin/Product")]
	[Authorize]
	public class ProductController : Controller
	{
		private readonly DataContext _dataContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ProductController(DataContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dataContext = context;
			_webHostEnvironment = webHostEnvironment;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Products.OrderByDescending(p => p.Id).Include(p => p.Category).Include(p => p.Brand).ToListAsync());
		}
		//[Route("Create")]
		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name");
			ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name");
			return View();
		}

		//[Route("Create")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductModel product)
		{
			ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
			ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);

			if (ModelState.IsValid)
			{
				// code them du lieu
				product.Slug = product.Name.Replace(" ", "-");
				var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);

				if (slug != null)
				{
					ModelState.AddModelError("", "Sản phẩm đã có trong database");
					return View(product);
				}

				if (product.ImageUpload != null)
				{
					string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
					string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
					string filePath = Path.Combine(uploadsDir, imageName);

					FileStream fs = new FileStream(filePath, FileMode.Create);
					await product.ImageUpload.CopyToAsync(fs);
					fs.Close();

					product.Image = imageName;
				}

				_dataContext.Add(product);
				await _dataContext.SaveChangesAsync();
				TempData["success"] = "Thêm sản phẩm thành công";
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


			return View(product);
		}

		//[Route("Edit")]
		public async Task<IActionResult> Edit(long Id)
		{
			ProductModel product = await _dataContext.Products.FindAsync(Id);

			ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
			ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);

			return View(product);
		}

		//[Route("Edit")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ProductModel product)
		{
			ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryId);
			ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandId);

			var existed_product = _dataContext.Products.Find(product.Id); // tìm sản phẩm theo id product

			if (ModelState.IsValid)
			{
				// code them du lieu
				product.Slug = product.Name.Replace(" ", "-");

				if (product.ImageUpload != null)
				{
					// upload new image

					string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
					string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
					string filePath = Path.Combine(uploadsDir, imageName);

					// delete old picture
					string oldfilePath = Path.Combine(uploadsDir, existed_product.Image);
					try
					{
						if (System.IO.File.Exists(oldfilePath))
						{
							System.IO.File.Delete(oldfilePath);
						}
					}
					catch (Exception ex)
					{
						ModelState.AddModelError("", "An error occurred while deleting the product image.");
					}

					FileStream fs = new FileStream(filePath, FileMode.Create);
					await product.ImageUpload.CopyToAsync(fs);
					fs.Close();

					existed_product.Image = imageName;
				}

				// Update ohter product properties
				existed_product.Name = product.Name;
				existed_product.Description = product.Description;
				existed_product.Price = product.Price;
				existed_product.CategoryId = product.CategoryId;
				existed_product.BrandId = product.BrandId;
				existed_product.Slug = product.Slug;
				// End Update ohter product properties


				_dataContext.Update(existed_product); // Update the existing product object

				await _dataContext.SaveChangesAsync();
				TempData["success"] = "Cập nhật sản phẩm thành công";
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


			return View(product);
		}

		public async Task<IActionResult> Delete(long Id)
		{
			ProductModel product = await _dataContext.Products.FindAsync(Id);

			if (product == null)
			{
				return NotFound();
			}

				string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/products");
				string oldfilePath = Path.Combine(uploadsDir, product.Image);
			try
			{
				if (System.IO.File.Exists(oldfilePath))
				{
					System.IO.File.Delete(oldfilePath);
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "An error occurred while deleting the product image.");
			}

			_dataContext.Products.Remove(product);
			await _dataContext.SaveChangesAsync();
			TempData["error"] = "Sản phẩm đã xoá";
			return RedirectToAction("Index");
		}
	}
}
