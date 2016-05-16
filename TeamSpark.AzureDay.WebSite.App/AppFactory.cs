using System;
using AutoMapper;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.App.Service;

namespace TeamSpark.AzureDay.WebSite.App
{
	public static class AppFactory
	{
		public static readonly Lazy<IMapper> Mapper = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Attendee, Data.Entity.Table.Attendee>();
				cfg.CreateMap<Data.Entity.Table.Attendee, Attendee>();

				cfg.CreateMap<Speaker, Data.Entity.Table.Speaker>();
				cfg.CreateMap<Data.Entity.Table.Speaker, Speaker>();

				cfg.CreateMap<Country, Data.Entity.Table.Country>();
				cfg.CreateMap<Data.Entity.Table.Country, Country>();

				cfg.CreateMap<QuickAuthToken, Data.Entity.Table.QuickAuthToken>();
				cfg.CreateMap<Data.Entity.Table.QuickAuthToken, QuickAuthToken>();

				cfg.CreateMap<Room, Data.Entity.Table.Room>();
				cfg.CreateMap<Data.Entity.Table.Room, Room>();

				cfg.CreateMap<Timetable, Data.Entity.Table.Timetable>();
				cfg.CreateMap<Data.Entity.Table.Timetable, Timetable>();

				cfg.CreateMap<Topic, Data.Entity.Table.Topic>();
				cfg.CreateMap<Data.Entity.Table.Topic, Topic>();

				cfg.CreateMap<Language, Data.Entity.Table.Language>();
				cfg.CreateMap<Data.Entity.Table.Language, Language>();
			});

			var mapper = config.CreateMapper();

			return mapper;
		});

		public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService());
		public static readonly Lazy<SpeakerService> SpeakerService = new Lazy<SpeakerService>(() => new SpeakerService());
		public static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() => new QuickAuthTokenService());
		public static readonly Lazy<RoomService> RoomService = new Lazy<RoomService>(() => new RoomService());
		public static readonly Lazy<TimetableService> TimetableService = new Lazy<TimetableService>(() => new TimetableService());
	}
}
