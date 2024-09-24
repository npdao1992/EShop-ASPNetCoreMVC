using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    [Authorize(Roles = "Admin,Staff")]
    public class ProductImageController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

		[Route("Index/{productId}")]
		public async Task<IActionResult> Index(long productId)
		{
			// Lấy danh sách hình ảnh của sản phẩm
			var images = await _dataContext.ProductImages
				.Include(pi => pi.Product) // Bao gồm sản phẩm trong truy vấn
				.Where(img => img.ProductId == productId)
				.ToListAsync();

			// Lấy thông tin sản phẩm từ productId
			var product = await _dataContext.Products
				.Where(p => p.Id == productId)
				.Select(p => new { p.Name, p.Image }) // Chỉ lấy Name và Image
				.FirstOrDefaultAsync();

			// Kiểm tra nếu không tìm thấy sản phẩm
			if (product == null)
			{
				return NotFound(); // Hoặc xử lý tùy theo yêu cầu của bạn
			}

			// Gán tên và hình ảnh của sản phẩm vào ViewBag
			ViewBag.ProductId = productId;
			ViewBag.ProductName = product.Name;
			ViewBag.ProductImage = product.Image;

			return View(images);
		}


		//[Route("Index/{productId}")]
		//public async Task<IActionResult> Index(long productId)
		//{
		//    var images = await _dataContext.ProductImages
		//        .Include(pi => pi.Product)
		//        .Where(img => img.ProductId == productId)
		//        .ToListAsync();

		//    ViewBag.ProductId = productId;
		//    return View(images);
		//}

		[Route("Create")]
        public IActionResult Create(long productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ProductImageModel productImage, long productId)
        {
            // Gán giá trị ProductId từ route nếu model không nhận được
            productImage.ProductId = productId;

            if (ModelState.IsValid)
            {
                // Kiểm tra và lưu hình ảnh nếu được tải lên
                if (productImage.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/product-details");
                    string imageName = Guid.NewGuid().ToString() + "_" + productImage.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await productImage.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    productImage.ImageUrl = imageName;
                }
                else
                {
                    // Nếu không có hình ảnh được tải lên, hiển thị lỗi
                    TempData["error"] = "Hình ảnh không được để trống";
                    return RedirectToAction("Create", "ProductImage", new { productId = productImage.ProductId });
                }

                // Lưu hình ảnh vào cơ sở dữ liệu
                _dataContext.Add(productImage);
                await _dataContext.SaveChangesAsync();

                TempData["success"] = "Thêm hình ảnh thành công";
                return RedirectToAction("Index", new { productId = productImage.ProductId });
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


            return View(productImage);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(long Id)
        {
            ProductImageModel productImage = await _dataContext.ProductImages.FindAsync(Id);

            if (productImage == null)
            {
                return NotFound();
            }

            string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "media/product-details");
            string oldfilePath = Path.Combine(uploadsDir, productImage.ImageUrl);
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

            _dataContext.ProductImages.Remove(productImage);
            await _dataContext.SaveChangesAsync();

            TempData["success"] = "Hình ảnh đã xoá thành công.";
            return RedirectToAction("Index", "ProductImage", new { productId = productImage.ProductId });
        }


    }
}
