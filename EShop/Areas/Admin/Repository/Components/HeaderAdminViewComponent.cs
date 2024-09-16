﻿using EShop.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Repository.Components
{
	public class HeaderAdminViewComponent : ViewComponent
	{
		private readonly DataContext _dataContext;
		public HeaderAdminViewComponent(DataContext context)
		{
			_dataContext = context;
		}

		public async Task<IViewComponentResult> InvokeAsync() => View(await _dataContext.Contact.FirstOrDefaultAsync());

	}
}
