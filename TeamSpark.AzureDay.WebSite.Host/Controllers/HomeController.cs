using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Data.Enum;
using TeamSpark.AzureDay.WebSite.Host.Filter;
using TeamSpark.AzureDay.WebSite.Host.Models.Home;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			var speakersTask = AppFactory.SpeakerService.Value.GetSpeakersAsync();
			var partnersTask = AppFactory.PartnerService.Value.GetPartnersAsync();

			var model = new IndexModel
			{
				Speakers = new SpeakersModel
				{
					SpeakersCollections = new List<List<Speaker>>()
				},
				Partners = new PartnersModel
				{
					PartnersCollection = new Dictionary<PartnerType, List<Partner>>()
				}
			};

			await Task.WhenAll(
				speakersTask,
				partnersTask
			);

			var speakers = speakersTask.Result;
			var i = 0;
			foreach (var speaker in speakers)
			{
				List<Speaker> list;
				if (i == 0)
				{
					list = new List<Speaker>();
					model.Speakers.SpeakersCollections.Add(list);
				}
				else
				{
					list = model.Speakers.SpeakersCollections.Last();
				}

				list.Add(speaker);

				if (i == 3)
				{
					i = 0;
				}
				else
				{
					i++;
				}
			}

			var partners = partnersTask.Result;
			model.Partners.PartnersCollection = partners
				.GroupBy(p => p.PartnerType)
				.ToDictionary(p => p.Key, group => group.OrderBy(p => p.OrderN).ToList());

			return View(model);
		}

		public async Task<ActionResult> Schedule()
		{
			var roomsTask = AppFactory.RoomService.Value.GetAllRoomsAsync();
			var timetableTask = AppFactory.TimetableService.Value.GetTimetableAsync();

			await Task.WhenAll(
				roomsTask,
				timetableTask
			);

			var model = new ScheduleModel();

			model.Rooms = roomsTask.Result
				.Where(r => r.RoomType != RoomType.CoffeeRoom)
				.ToList();

			model.Timetables = timetableTask.Result
				.GroupBy(t => t.TimeStartHours * 100 + t.TimeStartMinutes, (key, timetables) => timetables.ToList())
				.ToList();

			return View(model);
		}

		public async Task<ActionResult> Partners()
		{
			var model = new PartnersModel();

			model.PartnersCollection = (await AppFactory.PartnerService.Value.GetPartnersAsync())
				.GroupBy(p => p.PartnerType)
				.ToDictionary(p => p.Key, group => group.OrderBy(p => p.OrderN).ToList());

			return View(model);
		}

		[NonAuthorize]
		public async Task<ActionResult> Redirect([FromUri] string quickAuthToken, [FromUri] string redirectUrl)
		{
			var authToken = await AppFactory.QuickAuthTokenService.Value.GetQuickAuthTokenByValueAsync(quickAuthToken, false);

			if (authToken != null)
			{
				var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(authToken.Email);
				if (attendee != null && attendee.IsConfirmed)
				{
					FormsAuthentication.SetAuthCookie(attendee.EMail, true);
					await AppFactory.QuickAuthTokenService.Value.ExpireTokenByValueAsync(quickAuthToken);
				}
			}

			return Redirect(redirectUrl);
		}
	}
}