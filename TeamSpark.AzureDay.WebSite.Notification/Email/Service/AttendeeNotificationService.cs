using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Notification.Email.Model;
using TeamSpark.AzureDay.WebSite.Notification.Email.Template;

namespace TeamSpark.AzureDay.WebSite.Notification.Email.Service
{
	public sealed class AttendeeNotificationService
	{
		private async Task SendEmail(SendGridMessage message)
		{
			var transportWeb = new Web(Configuration.SendGridApiKey);

			await transportWeb.DeliverAsync(message);
		}

		public async Task SendConfirmationEmailAsync(ConfirmRegistrationMessage model)
		{
			var template = new ConfirmRegistration();
			template.ConfirmationCode = model.Token;

			var text = template.TransformText();

			var message = new SendGridMessage();
			message.To = new[] { new MailAddress(model.Email, model.FullName) };
			message.Subject = string.Format("Подтверждение регистрации на AZUREday {0}", Configuration.Year);
			message.Html = text;
			message.From = new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName);
			message.ReplyTo = new[] { new MailAddress(Configuration.SendGridFromEmail, Configuration.SendGridFromName) };

			await SendEmail(message);
		}
	}
}
