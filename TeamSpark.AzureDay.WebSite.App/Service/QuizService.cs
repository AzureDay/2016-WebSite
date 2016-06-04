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
		public async Task<List<QuizScore>> GetAllQuizAsync()
		{
			var scores = await DataFactory.QuizService.Value.GetByPartitionKeyAsync(Configuration.Year);

			return AppFactory.Mapper.Value.Map<IEnumerable<QuizScore>>(scores)
                .OrderBy(s => s.Score)
				.ThenBy(s => s.Date)				
				.ToList();
		}
        public async Task InsertAsync(QuizScore attendee)
        {
            var data = AppFactory.Mapper.Value.Map<Data.Entity.Table.QuizScore>(attendee);

            await  DataFactory.QuizService.Value.InsertAsync(data);
        }
    }
}
