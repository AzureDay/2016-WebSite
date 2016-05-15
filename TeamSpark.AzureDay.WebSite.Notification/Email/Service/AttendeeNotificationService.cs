using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.Notification.Email.Template;

namespace TeamSpark.AzureDay.WebSite.Notification.Email.Service
{
	public sealed class AttendeeNotificationService
	{
		public async Task SendConfirmationEmailAsync(string email, string code)
		{
			var template = new ConfirmRegistration();
			template.ConfirmationCode = code;

			var text = template.TransformText();
		}
	}
}
