using System.Security.Cryptography;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.App.Enum;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;

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

			return AppFactory.Mapper.Value.Map<Attendee>(entity);
		}

		public bool IsPasswordValid(Attendee attendee, string plainPassword)
		{
			var hashedPassword = Hash(plainPassword, attendee.Salt);
			return SlowEquals(attendee.PasswordHash, hashedPassword);
		}

		public byte[] GenerateSalt()
		{
			var rng = new RNGCryptoServiceProvider();
			var salt = new byte[256];
			rng.GetBytes(salt);
			return salt;
		}

		public byte[] Hash(string plainText, byte[] salt)
		{
			var hashFunc = new SHA512Cng();
			var plainBytes = System.Text.Encoding.ASCII.GetBytes(plainText);
			var toHash = new byte[plainBytes.Length + salt.Length];
			plainBytes.CopyTo(toHash, 0);
			salt.CopyTo(toHash, plainBytes.Length);
			return hashFunc.ComputeHash(toHash);
		}

		public bool SlowEquals(byte[] a, byte[] b)
		{
			var diff = a.Length ^ b.Length;
			for (var i = 0; i < a.Length && i < b.Length; i++)
			{
				diff |= a[i] ^ b[i];
			}
			return diff == 0;
		}

		public async Task RegisterAsync(Attendee attendee)
		{
			var data = AppFactory.Mapper.Value.Map<Data.Entity.Table.Attendee>(attendee);

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
