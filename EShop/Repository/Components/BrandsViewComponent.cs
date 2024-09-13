using EShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Repository.Components
{
	public class BrandsViewComponent : ViewComponent
	{
		private readonly DataContext _dataContext;
		public BrandsViewComponent(DataContext context)
		{
			_dataContext = context;
		}

        //public async Task<IViewComponentResult> InvokeAsync()=> View(await _dataContext.Brands.ToListAsync());

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Lấy tất cả danh mục
            var brands = await _dataContext.Brands.ToListAsync();

            // Lấy số lượng sản phẩm theo từng danh mục
            var brandProductCounts = await _dataContext.Brands
                .Select(b => new
                {
                    Brand = b,
                    ProductCount = _dataContext.Products.Count(p => p.BrandId == b.Id)
                })
                .ToListAsync();

            // Tạo view model
            var viewModel = brands.Select(b => new BrandViewModel
            {
                Brand = b,
                Products = _dataContext.Products.Where(p => p.BrandId == b.Id).ToList(),
                ProductCount = brandProductCounts.FirstOrDefault(x => x.Brand.Id == b.Id)?.ProductCount ?? 0
            }).ToList();

            return View(viewModel);
        }


    }
}
