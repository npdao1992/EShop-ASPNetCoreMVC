using EShop.Models;
using EShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{

	[Area("Admin")]
	[Route("Admin/User")]
	[Authorize(Roles = "Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUserModel> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly DataContext _dataContext;
		public UserController(DataContext context, UserManager<AppUserModel> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_dataContext = context;
		}

		//[HttpGet]
		//[Route("Index")]
		//public async Task<IActionResult> Index()
		//{
		//	var usersWithRoles = await (from u in _dataContext.Users
		//								join ur in _dataContext.UserRoles on u.Id equals ur.UserId
		//								join r in _dataContext.Roles on ur.RoleId equals r.Id
		//								select new { User = u, RoleName = r.Name })
		//								.ToListAsync();
		//	//return View(await _userManager.Users.OrderByDescending(p => p.Id).ToListAsync());
		//	return View(usersWithRoles);
		//}	
		
		[HttpGet]
		[Route("Index")]
		public async Task<IActionResult> Index(int pg = 1)
		{
			List<UserWithRoleModel> usersWithRoles = (from u in _dataContext.Users
													  join ur in _dataContext.UserRoles on u.Id equals ur.UserId
													  join r in _dataContext.Roles on ur.RoleId equals r.Id
													  select new UserWithRoleModel
													  {
														  User = u,
														  RoleName = r.Name
													  })
										  .ToList();

			const int pageSize = 10;

			if (pg < 1)
			{
				pg = 1;
			}
			int recsCount = usersWithRoles.Count();

			var pager = new Paginate(recsCount, pg, pageSize);

			int recSkip = (pg - 1) * pageSize;

			var data = usersWithRoles.Skip(recSkip).Take(pager.PageSize).ToList();

			ViewBag.Pager = pager;

			return View(data);
		}

		[HttpGet]
		[Route("Create")]
		public async Task<IActionResult> Create()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			ViewBag.Roles = new SelectList(roles, "Id", "Name");

			return View(new AppUserModel());
		}


		[HttpGet]
		[Route("Edit")]
		public async Task<IActionResult> Edit(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			var roles = await _roleManager.Roles.ToListAsync();
			ViewBag.Roles = new SelectList(roles, "Id", "Name");



			return View(user);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("Create")]
		public async Task<IActionResult> Create(AppUserModel user)
		{
			if (ModelState.IsValid)
			{
				var createUserResult = await _userManager.CreateAsync(user, user.PasswordHash); // Tạo user dựa vào email
				if (createUserResult.Succeeded)
				{
					var createUser = await _userManager.FindByEmailAsync(user.Email);
					var userId = createUser.Id; // Lấy user
					var role = _roleManager.FindByIdAsync(user.RoleId); // Lấy RoleId

					// Gán quyền
					var addToRoleRsult = await _userManager.AddToRoleAsync(createUser, role.Result.Name);
					if (!addToRoleRsult.Succeeded)
					{
						foreach (var error in createUserResult.Errors)
						{
							ModelState.AddModelError(string.Empty, error.Description);
						}
					}

					return RedirectToAction("Index", "User");
				}
				else
				{
					//AddIdentityErrors(createUserResult);

					foreach (var error in createUserResult.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}

					return View(user);
				}
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

			var roles = await _roleManager.Roles.ToListAsync();
			ViewBag.Roles = new SelectList(roles, "Id", "Name");

			return View(user);


		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("Edit")]
		public async Task<IActionResult> Edit(string id, AppUserModel user)
		{
			if (id != user.Id)
			{
				TempData["error"] = "ID không khớp.";
				return RedirectToAction("Index", "User");
			}

			var existingUser = await _userManager.FindByIdAsync(id); // Lấy user dựa vào id
			if (existingUser == null)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				// Update ohter user properties (excluding password)
				existingUser.UserName = user.UserName;
				existingUser.Email = user.Email;
				existingUser.PhoneNumber = user.PhoneNumber;
				existingUser.RoleId = user.RoleId;
				// End Update ohter user properties

				// Update Rolein UserRoles
				var currentRoles = await _userManager.GetRolesAsync(existingUser);
				var selectedRole = await _roleManager.FindByIdAsync(user.RoleId);

				// Delete Role Old
				if (currentRoles.Any())
				{
					await _userManager.RemoveFromRolesAsync(existingUser, currentRoles);
				}

				// Add Role New
				if (selectedRole != null)
				{
					await _userManager.AddToRoleAsync(existingUser, selectedRole.Name);
				}
				// End Update Role in UserRoles

				var updateUserResult = await _userManager.UpdateAsync(existingUser);
				if (updateUserResult.Succeeded)
				{
					TempData["success"] = "Cập nhật User thành công";
					return RedirectToAction("Index", "User");
				}
				else
				{
					AddIdentityErrors(updateUserResult);
					return View(existingUser);
				}
			}

			var role = await _roleManager.Roles.ToListAsync();
			ViewBag.Role = new SelectList(role, "Id", "Name");

			// Model validation failed
			TempData["error"] = "Model validation failed";
			var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
			string errorMessage = string.Join("\n", errors);

			return View(existingUser);

		}

		private void AddIdentityErrors(IdentityResult identityResult)
		{
			foreach (var error in identityResult.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}

		[HttpGet]
		[Route("Delete")]
		public async Task<IActionResult> Delete(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}
			var deleteResult = await _userManager.DeleteAsync(user);
			if (!deleteResult.Succeeded)
			{
				return View("Error");
			}

			TempData["success"] = "User đã được xoá thành công";
			return RedirectToAction("Index");

		}
	}
}
