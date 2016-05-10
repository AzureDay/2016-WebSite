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
		private readonly Data.Service.Table.AttendeeService _attendeeService;
		private readonly Data.Service.Table.QuickAuthTokenService _quickAuthTokenService;

		public AttendeeService()
		{
			_attendeeService = new Data.Service.Table.AttendeeService(Configuration.AccountName, Configuration.AccountKey);
			_quickAuthTokenService = new Data.Service.Table.QuickAuthTokenService(Configuration.AccountName, Configuration.AccountKey);
		}

		public async Task<bool> IsEmailRegisteredAsync(string email)
		{
			var entity = await _attendeeService.GetByKeysAsync(Configuration.Year, email);

			return entity != null;
		}

		public async Task<Attendee> GetAttendeeByEmailAsync(string email)
		{
			var entity = await _attendeeService.GetByKeysAsync(Configuration.Year, email);

			return Mapper.Map<Attendee>(entity);
		}

		public bool IsPasswordValid(Attendee attendee, string plainPassword)
		{
			throw new NotImplementedException();
		}

		public async Task RegisterAsync(Attendee attendee)
		{
			var data = Mapper.Map<Data.Entity.Table.Attendee>(attendee);

			await _attendeeService.InsertAsync(data);
		}

		public async Task<RegistrationConfirmationResult> ConfirmRegistrationByTokenAsync(string token)
		{
			var authToken = await _quickAuthTokenService.GetByKeysAsync(Configuration.Year, token);

			if (authToken == null)
			{
				return RegistrationConfirmationResult.TokenIsInvalid;
			}

			if (authToken.IsUsed)
			{
				return RegistrationConfirmationResult.TokenIsUsed;
			}

			authToken.IsUsed = true;

			var attendee = await _attendeeService.GetByKeysAsync(Configuration.Year, authToken.Email);

			attendee.IsConfirmed = true;

			await Task.WhenAll(
				_quickAuthTokenService.ReplaceAsync(authToken),
				_attendeeService.ReplaceAsync(attendee));

			return RegistrationConfirmationResult.Confirmed;
		}
	}
}
