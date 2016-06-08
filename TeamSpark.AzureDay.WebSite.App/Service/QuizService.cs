using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class QuizService
    {
		public async Task<List<QuizScore>> GetAllScoresAsync()
		{
			var scores = await DataFactory.QuizService.Value.GetByPartitionKeyAsync(Configuration.Year);

			return AppFactory.Mapper.Value.Map<IEnumerable<QuizScore>>(scores)
                .OrderBy(s => s.Score)
				.ThenBy(s => s.Date)				
				.ToList();
		}
        public async Task<QuizScore> GetUserScore(string identifier)
        {
            var scores = await DataFactory.QuizService.Value.GetByPartitionKeyAsync(Configuration.Year);

            return AppFactory.Mapper.Value.Map<IEnumerable<QuizScore>>(scores)
                  .Where(s => s.Email == identifier)
                  .Single();
        }
        public async Task InsertAsync(QuizScore scoreData)
        {
            var data = AppFactory.Mapper.Value.Map<Data.Entity.Table.QuizScore>(scoreData);

            await  DataFactory.QuizService.Value.InsertAsync(data);
        }
    }
}
