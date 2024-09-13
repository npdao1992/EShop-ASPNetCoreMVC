using EShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Repository.Components
{
	public class CategoriesViewComponent : ViewComponent
	{
		private readonly DataContext _dataContext;
		public CategoriesViewComponent(DataContext context)
		{
			_dataContext = context;
		}

        //public async Task<IViewComponentResult> InvokeAsync()=> View(await _dataContext.Categories.ToListAsync());

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Lấy tất cả danh mục
            var categories = await _dataContext.Categories.ToListAsync();

            // Lấy số lượng sản phẩm theo từng danh mục
            var categoryProductCounts = await _dataContext.Categories
                .Select(c => new
                {
                    Category = c,
                    ProductCount = _dataContext.Products.Count(p => p.CategoryId == c.Id)
                })
                .ToListAsync();

            // Tạo view model
            var viewModel = categories.Select(c => new CategoryViewModel
            {
                Category = c,
                Products = _dataContext.Products.Where(p => p.CategoryId == c.Id).ToList(),
                ProductCount = categoryProductCounts.FirstOrDefault(x => x.Category.Id == c.Id)?.ProductCount ?? 0
            }).ToList();

            return View(viewModel);
        }

    }
}
