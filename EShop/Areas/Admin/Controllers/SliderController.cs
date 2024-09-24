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
	[Route("Admin/Slider")]
    [Authorize(Roles = "Admin,Staff")]
    public class SliderController : Controller
	{

		private readonly DataContext _dataContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public SliderController(DataContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dataContext = context;
			_webHostEnvironment = webHostEnvironment;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Sliders.OrderByDescending(p => p.Id).ToListAsync());
		}

		[Route("Create")]
		public IActionResult Create()
		{
			return View();
		}

		[Route("Create")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(SliderModel slider)
		{

			if (ModelState.IsValid)
			{
				// code them du lieu

				if (slider.ImageUpload != null)
				{
					string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/sliders");
					string imageName = Guid.NewGuid().ToString() + "_" + slider.ImageUpload.FileName;
					string filePath = Path.Combine(uploadsDir, imageName);

					FileStream fs = new FileStream(filePath, FileMode.Create);
					await slider.ImageUpload.CopyToAsync(fs);
					fs.Close();

					slider.Image = imageName;
				}

				_dataContext.Add(slider);
				await _dataContext.SaveChangesAsync();
				TempData["success"] = "Thêm slider thành công";
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


			return View(slider);
		}


		[Route("Edit")]
		public async Task<IActionResult> Edit(int Id)
		{
			SliderModel slider = await _dataContext.Sliders.FindAsync(Id);

			return View(slider);

		}


		[Route("Edit")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(SliderModel slider)
		{

			if (ModelState.IsValid)
			{
				var slider_existed = _dataContext.Sliders.Find(slider.Id);
				// code them du lieu

				if (slider.ImageUpload != null)
				{
					string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/sliders");
					string imageName = Guid.NewGuid().ToString() + "_" + slider.ImageUpload.FileName;
					string filePath = Path.Combine(uploadsDir, imageName);

					// Xóa hình ảnh cũ
					string oldfilePath = Path.Combine(uploadsDir, slider_existed.Image);
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

					// Lưu hình ảnh mới
					using (FileStream fs = new FileStream(filePath, FileMode.Create))
					{
						await slider.ImageUpload.CopyToAsync(fs);
					}
					slider_existed.Image = imageName;
				}

				slider_existed.Name = slider.Name;
				slider_existed.Description = slider.Description;
				slider_existed.Status = slider.Status;

				_dataContext.Update(slider_existed);
				await _dataContext.SaveChangesAsync();
				TempData["success"] = "Cập nhật slider thành công";
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


			return View(slider);
		}


		[Route("Delete")]
		public async Task<IActionResult> Delete(int Id)
		{
			SliderModel slider = await _dataContext.Sliders.FindAsync(Id);

			if (slider == null)
			{
				return NotFound();
			}

			if (!string.Equals(slider.Image, "noname.jpg"))
			{
				string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/sliders");
				string oldfilePath = Path.Combine(uploadsDir, slider.Image);
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
			}

			_dataContext.Sliders.Remove(slider);
			await _dataContext.SaveChangesAsync();
			TempData["error"] = "Slider đã xoá thành công";
			return RedirectToAction("Index");
		}

	}
}
