using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public sealed class Ticket : TableEntity
	{
		[IgnoreProperty]
		public string AttendeeEMail
		{
			get { return RowKey; }
			set { RowKey = value; }
		}

		public bool IsPayed { get; set; }

		public string CouponCode { get; set; }

		[IgnoreProperty]
		public TicketType TicketType
		{
			get { return (TicketType)TicketTypeId; }
			set { TicketTypeId = (int)value; }
		}

		public int TicketTypeId { get; set; }

		public double Price { get; set; }

		public Ticket()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
