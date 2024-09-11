using EShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers
{
	public class ProductController : Controller
	{
		private readonly DataContext _dataContext;
		public ProductController(DataContext context)
		{
			_dataContext = context;
		}
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> Details(long Id)
		{
			if (Id == null)
			{
				return RedirectToAction("Index");
			}
			var productById = _dataContext.Products.Where(p => p.Id == Id).FirstOrDefault();
			return View(productById);
		}

	}
}
