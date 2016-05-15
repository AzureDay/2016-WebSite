using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class QuickAuthTokenService
	{
		public async Task<QuickAuthToken> GetQuickAuthTokenByValueAsync(string token, bool? isUsed = null)
		{
			var authToken = await DataFactory.QuickAuthTokenService.Value.GetByKeysAsync(Configuration.Year, token);

			if (isUsed.HasValue)
			{
				if (authToken.IsUsed == isUsed.Value)
				{
					return AppFactory.Mapper.Value.Map<QuickAuthToken>(authToken);
				}
				else
				{
					return null;
				}
			}
			else
			{
				return AppFactory.Mapper.Value.Map<QuickAuthToken>(authToken);
			}
		}

		public async Task ExpireTokenByValueAsync(string token)
		{
			var authToken = await DataFactory.QuickAuthTokenService.Value.GetByKeysAsync(Configuration.Year, token);

			if (authToken != null)
			{
				authToken.IsUsed = true;
				await DataFactory.QuickAuthTokenService.Value.ReplaceAsync(authToken);
			}
		}

		public async Task<bool> IsTokenValidForEmailAsync(string token, string email)
		{
			var authToken = await GetQuickAuthTokenByValueAsync(token, false);
			return authToken != null && authToken.Email == email;
		}

		public async Task AddQuickAuthTokenAsync(QuickAuthToken token)
		{
			var authToken = AppFactory.Mapper.Value.Map<Data.Entity.Table.QuickAuthToken>(token);
			await DataFactory.QuickAuthTokenService.Value.InsertAsync(authToken);
		}
	}
}
