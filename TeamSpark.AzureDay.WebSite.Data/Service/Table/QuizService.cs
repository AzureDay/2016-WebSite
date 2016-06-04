using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
    public sealed class QuizService : TableServiceBase<QuizScore>
    {
        protected override string TableName
        {
            get { return "QuizScore"; }
        }

        public QuizService(string accountName, string accountKey)
            : base(accountName, accountKey)
        {
        }
    }
}
