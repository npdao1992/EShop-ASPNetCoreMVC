using Microsoft.AspNetCore.Identity;

namespace EShop.Models
{
	public class AppUserModel : IdentityUser
	{
		public string Occupation {  get; set; }

		public string RoleId { get; set; }
	}
}
