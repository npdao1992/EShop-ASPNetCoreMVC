using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Repository.Components
{
	public class HeaderViewComponent : ViewComponent
	{
		private readonly DataContext _dataContext;
		public HeaderViewComponent(DataContext context)
		{
			_dataContext = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()=> View(await _dataContext.Contact.FirstOrDefaultAsync());

	}
}
