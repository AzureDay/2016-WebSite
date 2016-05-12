using System;
using System.Threading.Tasks;
using AutoMapper;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.App.Enum;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class AttendeeService
	{
		public async Task<bool> IsEmailRegisteredAsync(string email)
		{
			var entity = await DataFactory.AttendeeService.Value.GetByKeysAsync(Configuration.Year, email);

			return entity != null;
		}

		public async Task<Attendee> GetAttendeeByEmailAsync(string email)
		{
			var entity = await DataFactory.AttendeeService.Value.GetByKeysAsync(Configuration.Year, email);

			return Mapper.Map<Attendee>(entity);
		}

		public bool IsPasswordValid(Attendee attendee, string plainPassword)
		{
			throw new NotImplementedException();
		}

		public async Task RegisterAsync(Attendee attendee)
		{
			var data = Mapper.Map<Data.Entity.Table.Attendee>(attendee);

			await DataFactory.AttendeeService.Value.InsertAsync(data);
		}

		public async Task<RegistrationConfirmationResult> ConfirmRegistrationByTokenAsync(string token)
		{
			var authToken = await DataFactory.QuickAuthTokenService.Value.GetByKeysAsync(Configuration.Year, token);

			if (authToken == null)
			{
				return RegistrationConfirmationResult.TokenIsInvalid;
			}

			if (authToken.IsUsed)
			{
				return RegistrationConfirmationResult.TokenIsUsed;
			}

			authToken.IsUsed = true;

			var attendee = await DataFactory.AttendeeService.Value.GetByKeysAsync(Configuration.Year, authToken.Email);

			attendee.IsConfirmed = true;

			await Task.WhenAll(
				DataFactory.QuickAuthTokenService.Value.ReplaceAsync(authToken),
				DataFactory.AttendeeService.Value.ReplaceAsync(attendee));

			return RegistrationConfirmationResult.Confirmed;
		}
	}
}
