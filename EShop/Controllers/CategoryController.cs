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



        public async Task<IActionResult> Index(string Slug = "")
        {
            CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            var productByCategory = _dataContext.Products.Where(p => p.CategoryId == category.Id);

            return View(await productByCategory.OrderByDescending(p => p.Id).ToListAsync());
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
