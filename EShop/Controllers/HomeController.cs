using System.Diagnostics;
using System.Security.Claims;
using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly DataContext _dataContext;
		private readonly ILogger<HomeController> _logger;
		private UserManager<AppUserModel> _userManager;
		public HomeController(ILogger<HomeController> logger, DataContext context, UserManager<AppUserModel> userManager)
		{
			_logger = logger;
			_dataContext = context;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var products = _dataContext.Products.Include("Category").Include("Brand").ToList();

			// Thêm Slider hiển thị cần gọi partial slider
			var sliders = _dataContext.Sliders.Where(s => s.Status == 1).ToList();

			ViewBag.Sliders = sliders;
			// End Slider

			return View(products);
		}

		[Authorize]
		public async Task<IActionResult> Compare()
		{
			// Lấy UserId của người dùng hiện tại
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			// Truy vấn chỉ lấy Compare của người dùng đang đăng nhập
			var compare_product = await (from c in _dataContext.Compares
										 join p in _dataContext.Products on c.ProductId equals p.Id
										 where c.UserId == userId
										 select new {
											 User = userId,
											 Product = p, 
											 Compares = c
										 })
										 .ToListAsync();

			return View(compare_product);
		}

		[Authorize]
		public async Task<IActionResult> Wishlist()
		{
			// Lấy UserId của người dùng hiện tại
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			// Truy vấn chỉ lấy wishlist của người dùng đang đăng nhập
			var wishlist_product = await (from w in _dataContext.Wishlists
										  join p in _dataContext.Products on w.ProductId equals p.Id
										  where w.UserId == userId
										  select new 
										  {
											  User = userId,
											  Product = p,
											  Wishlists = w 
										  })
										 .ToListAsync();

			return View(wishlist_product);
		}
		
		//[Authorize]
		//public async Task<IActionResult> Wishlist()
		//{
		//	var wishlist_product = await (from w in _dataContext.Wishlists
		//								  join p in _dataContext.Products on w.ProductId equals p.Id
		//								  join u in _dataContext.Users on w.UserId equals u.Id
		//								  select new { User = u, Product = p, Wishlists = w })
		//								 .ToListAsync();

		//	return View(wishlist_product);
		//}

		[Authorize]
		public async Task<IActionResult> DeleteCompare(int Id)
		{
			CompareModel compare = await _dataContext.Compares.FindAsync(Id);

			_dataContext.Compares.Remove(compare);
			await _dataContext.SaveChangesAsync();
			TempData["success"] = "So sánh đã được xoá thành công";
			return RedirectToAction("Compare", "Home");
		}

		[Authorize]
		public async Task<IActionResult> DeleteWishlist(int Id)
		{
			WishlistModel wishlist = await _dataContext.Wishlists.FindAsync(Id);

			_dataContext.Wishlists.Remove(wishlist);
			await _dataContext.SaveChangesAsync();
			TempData["success"] = "Yêu thích đã được xoá thành công";
			return RedirectToAction("Wishlist", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> AddWishlist(long Id)
		{
			var user = await _userManager.GetUserAsync(User);

			// Kiểm tra nếu sản phẩm đã tồn tại trong danh sách yêu thích của người dùng hiện tại
			var existingWishlistItem = await _dataContext.Wishlists
				.FirstOrDefaultAsync(w => w.ProductId == Id && w.UserId == user.Id);

			if (existingWishlistItem != null)
			{
				// Nếu sản phẩm đã có trong wishlist, trả về thông báo và điều hướng về trang Home
				return Ok(new { success = false, message = "Product already exists in your wishlist" });
			}

			// Nếu chưa tồn tại, thêm sản phẩm vào danh sách yêu thích
			var wishlistProduct = new WishlistModel
			{
				ProductId = Id,
				UserId = user.Id
			};

			_dataContext.Wishlists.Add(wishlistProduct);

			try
			{
				await _dataContext.SaveChangesAsync();
				return Ok(new { success = true, message = "Add to wishlist successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while adding to wishlist.");
			}
		}


		[HttpPost]
		public async Task<IActionResult> AddCompare(long Id)
		{
			var user = await _userManager.GetUserAsync(User);

			// Kiểm tra nếu sản phẩm đã tồn tại trong danh sách yêu thích của người dùng hiện tại
			var existingCompareItem = await _dataContext.Compares
				.FirstOrDefaultAsync(w => w.ProductId == Id && w.UserId == user.Id);

			if (existingCompareItem != null)
			{
				// Nếu sản phẩm đã có trong compare, trả về thông báo và điều hướng về trang Home
				return Ok(new { success = false, message = "Product already exists in your wishlist" });
			}

			// Nếu chưa tồn tại, thêm sản phẩm vào danh sách yêu thích
			var compareProduct = new CompareModel
			{
				ProductId = Id,
				UserId = user.Id
			};

			_dataContext.Compares.Add(compareProduct);

			try
			{
				await _dataContext.SaveChangesAsync();
				return Ok(new { success = true, message = "Add to compare Successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, "An error occurred while adding to compare table.");
			}

			return View();
		}

		//[HttpPost]
		//public async Task<IActionResult> AddWishlist(long Id)
		//{
		//	var user = await _userManager.GetUserAsync(User);

		//	var wishlistProduct = new WishlistModel {
		//		ProductId = Id,
		//		UserId = user.Id
		//	};

		//	_dataContext.Wishlists.Add(wishlistProduct);

		//	try
		//	{
		//		await _dataContext.SaveChangesAsync();
		//		return Ok(new { success = true, message = "Add to wishlist Successfully" });
		//	}
		//	catch (Exception ex) {
		//		return StatusCode(500, "An error occurred while adding to wishlist table.");
		//	}

		//	return View();
		//}

		//[HttpPost]
		//public async Task<IActionResult> AddCompare(long Id)
		//{
		//	var user = await _userManager.GetUserAsync(User);

		//	var compareProduct = new CompareModel
		//	{
		//		ProductId = Id,
		//		UserId = user.Id
		//	};

		//	_dataContext.Compares.Add(compareProduct);

		//	try
		//	{
		//		await _dataContext.SaveChangesAsync();
		//		return Ok(new { success = true, message = "Add to compare Successfully" });
		//	}
		//	catch (Exception ex)
		//	{
		//		return StatusCode(500, "An error occurred while adding to compare table.");
		//	}

		//	return View();
		//}

		public IActionResult Privacy()
		{
			return View();
		}

		public async Task<IActionResult> Contact()
		{
			var contact = await _dataContext.Contact.FirstOrDefaultAsync();
			return View(contact);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statuscode)
		{
			if (statuscode == 404)
			{
				return View("NotFound");
			}
			else
			{
				return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
			}
		}


	}
}
