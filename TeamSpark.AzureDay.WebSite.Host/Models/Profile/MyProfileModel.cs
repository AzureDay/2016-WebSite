using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Profile
{
	public sealed class MyProfileModel
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }

		private string _emailHash;
		public string EmailHash
		{
			get
			{
				if (string.IsNullOrEmpty(_emailHash))
				{
					var md5 = MD5.Create();

					var inputBytes = Encoding.ASCII.GetBytes(Email);

					var hash = md5.ComputeHash(inputBytes);

					var sb = new StringBuilder();
					foreach (byte b in hash)
					{
						sb.Append(b.ToString("X2"));
					}

					_emailHash = sb.ToString();
				}

				return _emailHash;
			}
		}

		public List<TicketModel> Tickets { get; set; }

		public Ticket PayedTicket { get; set; }
	}
}