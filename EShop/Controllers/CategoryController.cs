using EShop.Models;
using EShop.Models.ViewModels;
using EShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Controllers
{
	public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;

		public CategoryController(DataContext context)
		{
			_dataContext = context;
		}



		public async Task<IActionResult> Index(string Slug = "", string sort_by = "", string startprice = "", string endprice = "")
		{
			CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
			if (category == null)
			{
				return RedirectToAction("Index");
			}
			// Lấy tất cả sản phẩm
			IQueryable<ProductModel> productByCategory = _dataContext.Products.Where(p => p.CategoryId == category.Id);
			var count = await productByCategory.CountAsync();

			if (count > 0)
			{
				if (sort_by == "price_increase")
				{
					productByCategory = productByCategory.OrderBy(p => p.Price);
				}
				else if (sort_by == "price_decrease")
				{
					productByCategory = productByCategory.OrderByDescending(p => p.Price);
				}
				else if (sort_by == "price_newest")
				{
					productByCategory = productByCategory.OrderByDescending(p => p.Id);
				}
				else if (sort_by == "price_oldest")
				{
					productByCategory = productByCategory.OrderBy(p => p.Id);
				}
				// Lọc giá sản phẩm
				else if (startprice != "" && endprice != "")
				{
					decimal startPriceValue;
					decimal endPriceValue;

					if (decimal.TryParse(startprice, out startPriceValue) && decimal.TryParse(endprice, out endPriceValue))
					{
						productByCategory = productByCategory.Where(p => p.Price >= startPriceValue && p.Price <= endPriceValue);
					}
					else
					{
						productByCategory = productByCategory.OrderByDescending(p => p.Id);
					}
				}
				else
				{
					productByCategory = productByCategory.OrderByDescending(p => p.Id);
				}

			}


			return View(await productByCategory.ToListAsync());
		}

		//public async Task<IActionResult> Index(string Slug = "")
		//{
		//    // Lấy thông tin danh mục theo Slug
		//    var category = _dataContext.Categories
		//        .Where(c => c.Slug == Slug)
		//        .FirstOrDefault();

		//    if (category == null)
		//    {
		//        return RedirectToAction("Index");
		//    }

		//    // Lấy sản phẩm theo danh mục
		//    var products = _dataContext.Products
		//        .Where(p => p.CategoryId == category.Id)
		//        .OrderByDescending(p => p.Id)
		//        .ToList();

		//    // Tạo đối tượng CategoryViewModel
		//    var categoryViewModel = new CategoryViewModel
		//    {
		//        Category = category,
		//        Products = products,
		//        ProductCount = products.Count
		//    };

		//    // Trả về View với CategoryViewModel
		//    return View(categoryViewModel);
		//}


	}
}
