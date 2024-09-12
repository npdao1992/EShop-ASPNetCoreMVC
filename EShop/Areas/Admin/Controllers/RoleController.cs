using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Role")]
	[Authorize(Roles = "Admin")]
	public class RoleController : Controller
	{
		private readonly DataContext _dataContext;
		private readonly RoleManager<IdentityRole> _roleManager;
		public RoleController(DataContext context, RoleManager<IdentityRole> roleManager)
		{
			_dataContext = context;
			_roleManager = roleManager;
		}

		//[Route("Index")]
		//public async Task<IActionResult> Index()
		//{
		//	return View(await _dataContext.Roles.OrderByDescending(p => p.Id).ToListAsync());
		//}

		[Route("Index")]
		public async Task<IActionResult> Index(int pg = 1)
		{
			List<IdentityRole> role = _dataContext.Roles.OrderBy(r => r.Name).ToList();

			const int pageSize = 10;

			if (pg < 1)
			{
				pg = 1;
			}
			int recsCount = role.Count();

			var pager = new Paginate(recsCount, pg, pageSize);

			int recSkip = (pg - 1) * pageSize;

			var data = role.Skip(recSkip).Take(pager.PageSize).ToList();

			ViewBag.Pager = pager;

			return View(data);
		}

		[HttpGet]
		[Route("Create")]
		public IActionResult Create()
		{
			return View();
		}

		[HttpGet]
		[Route("Edit")]
		public async Task<IActionResult> Edit(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			var role = await _roleManager.FindByIdAsync(id);

			return View(role);
		}

		[HttpPost]
		[Route("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(IdentityRole model)
		{
			// code them du lieu
			if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
			{

				_roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
				TempData["success"] = "Thêm Role thành công.";
				return Redirect("Index");
			}
			else
			{
				TempData["error"] = "Role đã tồn tại.";
				return Redirect("Create");
			}

		}

		[HttpPost]
		[Route("Edit")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, IdentityRole model)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				var role = await _roleManager.FindByIdAsync(id);
				if (role == null)
				{
					return NotFound();
				}

				role.Name = model.Name;

				try
				{
					await _roleManager.UpdateAsync(role);
					TempData["success"] = "Role đã cập nhật thành công.";
					return RedirectToAction("Index");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", "An error occurred while deleting the role.");
				}

			}
			return View(model ?? new IdentityRole { Id = id });

		}

		[HttpGet]
		[Route("Delete")]
		public async Task<IActionResult> Delete(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			var role = await _roleManager.FindByIdAsync(id);
			if (role == null)
			{
				return NotFound();
			}

			try
			{
				await _roleManager.DeleteAsync(role);
				TempData["success"] = "Role đã xoá thành công.";
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "An error occurred while deleting the role.");
			}
			return Redirect("Index");

		}



	}
}
