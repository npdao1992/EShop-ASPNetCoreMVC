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
    [Route("Admin/Contact")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
		private readonly DataContext _dataContext;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ContactController(DataContext context, IWebHostEnvironment webHostEnvironment)
		{
			_dataContext = context;
			_webHostEnvironment = webHostEnvironment;
		}

		[Route("Index")]
		public IActionResult Index()
        {
            var contact = _dataContext.Contact.ToList();
            return View(contact);
        }

        [Route("Edit")]
		public async Task<IActionResult> Edit()
		{
			ContactModel contact = await _dataContext.Contact.FirstOrDefaultAsync();
			return View(contact);
		}

		[Route("Edit")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ContactModel contact)
		{

			var existed_contact = _dataContext.Contact.FirstOrDefault();

			// Nếu không tồn tại
			if (existed_contact == null)
			{
				TempData["error"] = "Contact không tồn tại.";
				return RedirectToAction("Index");
			}

			if (ModelState.IsValid)
			{

				// Kiểm tra và upload hình ảnh mới
				if (contact.ImageUpload != null)
				{
					string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/logo");
					string imageName = Guid.NewGuid().ToString() + "_" + contact.ImageUpload.FileName;
					string filePath = Path.Combine(uploadsDir, imageName);

					// Xóa hình ảnh cũ
					string oldfilePath = Path.Combine(uploadsDir, existed_contact.LogoImg);
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
						await contact.ImageUpload.CopyToAsync(fs);
					}

					existed_contact.LogoImg = imageName;
				}

				// Cập nhật các thuộc tính khác của sản phẩm
				existed_contact.Name = contact.Name;
				existed_contact.Email = contact.Email;
				existed_contact.Description = contact.Description;
				existed_contact.Phone = contact.Phone;
				existed_contact.Map = contact.Map;

				// Lưu thay đổi vào cơ sở dữ liệu
				_dataContext.Update(existed_contact);
				await _dataContext.SaveChangesAsync();

				TempData["success"] = "Cập nhật liên hệ thành công";
				return RedirectToAction("Index");
			}
			else
			{
				// Xử lý lỗi ModelState
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

			return View(contact);
		}
	}
}
