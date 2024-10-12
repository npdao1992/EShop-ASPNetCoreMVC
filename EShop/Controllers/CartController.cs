using EShop.Models;
using EShop.Models.ViewModels;
using EShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EShop.Controllers
{
	public class CartController : Controller
	{
		private readonly DataContext _dataContext;
		public CartController(DataContext _context)
		{
			_dataContext = _context;
		}
		public IActionResult Index()
		{
			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

			// Start Lấy shipping giá từ cookie
			var shippingPriceCookie = Request.Cookies["ShippingPrice"];
			decimal shippingPrice = 0;

			if (shippingPriceCookie != null)
			{
				var shippingPriceJson = shippingPriceCookie;
				shippingPrice = JsonConvert.DeserializeObject<decimal>(shippingPriceJson);
			}
			// End Lấy shipping giá từ cookie

			CartItemViewModel cartVM = new()
			{
				CartItems = cartItems,
				GrandTotal = cartItems.Sum(x => x.Quantity * x.Price),
				ShippingCost = shippingPrice
			};
			return View(cartVM);
		}
		public IActionResult Checkout()
		{
			return View("~/Views/Checkout/Index.cshtml");
		}

		public async Task<IActionResult> Add(long Id)
		{
			ProductModel product = await _dataContext.Products.FindAsync(Id);
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
			CartItemModel cartItems = cart.Where(c => c.ProductId == Id).FirstOrDefault();

			if (cartItems == null)
			{
				cart.Add(new CartItemModel(product));
			}
			else
			{
				cartItems.Quantity += 1;
			}

			HttpContext.Session.SetJson("Cart", cart);

			TempData["success"] = "Add item to cart Successfully.";

			return Redirect(Request.Headers["Referer"].ToString());
		}

		public async Task<IActionResult> Decrease(long Id)
		{
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

			CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

			if (cartItem.Quantity > 1)
			{
				--cartItem.Quantity;
			}
			else
			{
				cart.RemoveAll(p => p.ProductId == Id);
			}

			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

			TempData["success"] = "Decrease Item Quantity to cart Successfully.";

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Increase(long Id)
		{
			ProductModel product = await _dataContext.Products.Where(p => p.Id == Id).FirstOrDefaultAsync();

			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
			CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

			if (cartItem.Quantity >= 1 && product.Quantity > cartItem.Quantity)
			{
				++cartItem.Quantity;
				TempData["success"] = "Increase Product to cart Successfully.";
			}
			else
			{
				cartItem.Quantity = product.Quantity;
				//cart.RemoveAll(p => p.ProductId == Id);
				TempData["success"] = "Maximum Increase Product to cart Successfully.";
			}

			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

			TempData["success"] = "Increase Product to cart Successfully.";

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Remove(long Id)
		{
			List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

			cart.RemoveAll(p => p.ProductId == Id);
			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

			TempData["success"] = "Remove Item of cart Successfully.";

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Clear(long Id)
		{
			HttpContext.Session.Remove("Cart");

			TempData["success"] = "Clear all Item of cart Successfully.";

			return RedirectToAction("Index");
		}

		// Tính phí shipping
		[HttpPost]
		[Route("Cart/GetShipping")]
		public async Task<IActionResult> GetShipping(ShippingModel shippingModel, string phuong, string quan, string tinh)
		{
			var existingShipping = await _dataContext.Shippings
					.FirstOrDefaultAsync(x => x.City == tinh && x.District == quan && x.Ward == phuong);

			decimal shippingPrice = 0; //Set mặc định giá tiền

			if (existingShipping != null)
			{
				shippingPrice = existingShipping.Price;
			}
			else
			{
				shippingPrice = 50000; // Set mặc định giá tiền nếu không tìm thấy
			}

			var shippingPriceJson = JsonConvert.SerializeObject(shippingPrice);
			try
			{
				var cookieOptions = new CookieOptions
				{
					HttpOnly = true,
					Expires = DateTimeOffset.UtcNow.AddMinutes(30),
					Secure = true, // using HTTPS
				};

				Response.Cookies.Append("ShippingPrice", shippingPriceJson, cookieOptions);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error adding shipping price cookie: {ex.Message}");
			}

			return Json(new { shippingPrice });
		}

		[HttpGet]
		[Route("Cart/DeleteShipping")]
		public async Task<IActionResult> DeleteShipping()
		{
			Response.Cookies.Delete("ShippingPrice");
			return RedirectToAction("Index", "Cart");
		}
	}
}
