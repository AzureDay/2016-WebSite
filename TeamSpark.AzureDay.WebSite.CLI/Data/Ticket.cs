using System;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Notification;
using TeamSpark.AzureDay.WebSite.Notification.Email.Model;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Ticket
	{
		internal static void ConfirmPayment()
		{
			Console.WriteLine("Confirm payment");

			var ticketsTask = DataFactory.TicketService.Value.GetByPartitionKeyAsync(Configuration.Year);
			ticketsTask.Wait();

			var tickets = ticketsTask.Result.Where(i => !i.IsPayed).ToList();
			for (var i = 0; i < tickets.Count; i++)
			{
				Console.WriteLine("{0}. {1}", i, tickets[i].AttendeeEMail);
			}

			Console.Write("Chose ticket: ");
			var n = int.Parse(Console.ReadLine());

			var ticket = tickets[n];
			ticket.IsPayed = true;

			var attendeeTask = AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(ticket.AttendeeEMail);
			attendeeTask.Wait();

			var attendee = attendeeTask.Result;

			var message = new ConfirmPaymentModel
			{
				Email = attendee.EMail,
				FullName = attendee.FullName
			};

			AppFactory.TicketService.Value.SetTicketPayedAsync(attendee.EMail).Wait();
			NotificationFactory.AttendeeNotificationService.Value.SendPaymentConfirmationEmailAsync(message).Wait();
		}
	}
}
