using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace TeamSpark.AzureDay.WebSite.Data.Service
{
	public abstract class StorageServiceBase
	{
		protected CloudStorageAccount Account { get; private set; }

		protected StorageServiceBase(string accountName, string accountKey)
		{
			var credentials = new StorageCredentials(accountName, accountKey);

			Account = new CloudStorageAccount(credentials, true);
		}
	}
}
