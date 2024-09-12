using System.Net.Mail;
using System.Net;

namespace EShop.Areas.Admin.Repository
{
	public class EmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string message)
		{
			var client = new SmtpClient("smtp.gmail.com", 587)
			{
				EnableSsl = true, //bật bảo mật
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential("dnp.relax@gmail.com", "jnppovloipwotglw")
			};

			return client.SendMailAsync(
				new MailMessage(from: "dnp.relax@gmail.com",
								to: email,
								subject,
								message
								));
		}
	}
}
