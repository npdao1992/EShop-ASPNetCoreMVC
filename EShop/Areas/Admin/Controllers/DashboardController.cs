using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Dashboard")]
	[Authorize(Roles = "Admin,Publisher,Author")]
	public class DashboardController : Controller
	{
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
