using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class TicketService
	{
		public decimal GetTicketPrice(TicketType ticketType)
		{
			decimal ticketPrice = 600;
			switch (ticketType)
			{
				case TicketType.EarlyBird:
					ticketPrice = 500;
					break;
				case TicketType.Educational:
					ticketPrice = 300;
					break;
			}

			return ticketPrice;
		}

		public async Task AddTicketAsync(Ticket ticket)
		{
			var data = AppFactory.Mapper.Value.Map<Data.Entity.Table.Ticket>(ticket);

			await DataFactory.TicketService.Value.InsertAsync(data);
		}

		public async Task<Ticket> GetTicketByEmailAsync(string email)
		{
			var data = await DataFactory.TicketService.Value.GetByKeysAsync(Configuration.Year, email);

			if (data == null)
			{
				return null;
			}

			var ticket = AppFactory.Mapper.Value.Map<Ticket>(data);
			//ticket.Attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);

			return ticket;
		}
	}
}
