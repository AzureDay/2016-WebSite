using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public abstract class TableServiceBase<T> : StorageServiceBase where T : TableEntity, new()
	{
		protected abstract string TableName { get; }

		protected CloudTableClient Client { get; private set; }
		protected CloudTable Table { get; private set; }

		protected TableServiceBase(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
			if (string.IsNullOrWhiteSpace(TableName))
			{
				throw new ArgumentNullException();
			}

			Client = Account.CreateCloudTableClient();
			Table = Client.GetTableReference(TableName);
		}

		public async Task InitializeAsync()
		{
			await Table.CreateIfNotExistsAsync();
		}

		public async Task<T> GetByKeysAsync(string partitionKey, string rowKey)
		{
			var operation = TableOperation.Retrieve<T>(partitionKey, rowKey);

			var result = await Table.ExecuteAsync(operation);

			return (T)result.Result;
		}

		public async Task<List<T>> GetByPartitionKeyAsync(string partitionKey)
		{
			var filter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey);

			var query = new TableQuery<T>().Where(filter);

			return (await Table.ExecuteQuerySegmentedAsync(query, null)).Results;
		}

		public async Task InsertAsync(T entity)
		{
			var operation = TableOperation.Insert(entity);

			await Table.ExecuteAsync(operation);
		}

		public async Task ReplaceAsync(T entity)
		{
			var operation = TableOperation.Replace(entity);

			await Table.ExecuteAsync(operation);
		}

		public TableBatchOperation CreateBatch()
		{
			var batch = new TableBatchOperation();

			return batch;
		}

		public void AddBatchInsert(TableBatchOperation batch, T entity)
		{
			var operation = TableOperation.Insert(entity);

			batch.Add(operation);
		}

		public void AddBatchReplace(TableBatchOperation batch, T entity)
		{
			var operation = TableOperation.Replace(entity);

			batch.Add(operation);
		}

		public void AddBatchDelete(TableBatchOperation batch, T entity)
		{
			var operation = TableOperation.Delete(entity);

			batch.Add(operation);
		}

		public async Task AddBatchDeleteAsync(TableBatchOperation batch, string partitionKey, string rowKey)
		{
			var entity = await GetByKeysAsync(partitionKey, rowKey);

			var operation = TableOperation.Delete(entity);

			batch.Add(operation);
		}

		public async Task ExecuteBatchAsync(TableBatchOperation batch)
		{
			await Table.ExecuteBatchAsync(batch);
		}
	}
}
