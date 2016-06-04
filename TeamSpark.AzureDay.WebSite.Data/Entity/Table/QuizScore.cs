using Microsoft.WindowsAzure.Storage.Table;
using System;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
    public sealed class QuizScore : TableEntity
    {
        [IgnoreProperty]
        public string Email { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

        public QuizScore()
        {
            PartitionKey = Configuration.Year;
        }
    }
}