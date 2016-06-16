using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.App.Entity.Api;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
    public class AppUserService
    {
        public async Task<Attendee> GetAttendeeByEmailAsync(string email) =>
         AppFactory.Mapper.Value.Map<Attendee>(await DataFactory.AttendeeService.Value.GetByKeysAsync(Configuration.Year, email));                 
    }
}
