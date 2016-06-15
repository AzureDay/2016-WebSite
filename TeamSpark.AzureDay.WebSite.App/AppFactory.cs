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

                cfg.CreateMap<QuizScore, Data.Entity.Table.QuizScore>();
                cfg.CreateMap<Data.Entity.Table.QuizScore, QuizScore>();

                cfg.CreateMap<Timetable, Data.Entity.Table.Timetable>();
				cfg.CreateMap<Data.Entity.Table.Timetable, Timetable>();

				cfg.CreateMap<Topic, Data.Entity.Table.Topic>();
				cfg.CreateMap<Data.Entity.Table.Topic, Topic>();

				cfg.CreateMap<Language, Data.Entity.Table.Language>();
				cfg.CreateMap<Data.Entity.Table.Language, Language>();

				cfg.CreateMap<Partner, Data.Entity.Table.Partner>();
				cfg.CreateMap<Data.Entity.Table.Partner, Partner>();

				cfg.CreateMap<Coupon, Data.Entity.Table.Coupon>();
				cfg.CreateMap<Data.Entity.Table.Coupon, Coupon>();

				cfg.CreateMap<Ticket, Data.Entity.Table.Ticket>();
				cfg.CreateMap<Data.Entity.Table.Ticket, Ticket>();

                //API

                cfg.CreateMap<Entity.Api.Room, Data.Entity.Table.Room>();
                cfg.CreateMap<Data.Entity.Table.Room, Entity.Api.Room>();

                cfg.CreateMap<Entity.Api.Language, Data.Entity.Table.Language>();
                cfg.CreateMap<Data.Entity.Table.Language, Entity.Api.Language>();

                cfg.CreateMap<Entity.Api.Speaker, Data.Entity.Table.Speaker>();
                cfg.CreateMap<Data.Entity.Table.Speaker, Entity.Api.Speaker>();

                cfg.CreateMap<Entity.Api.SpeakerTopic, Data.Entity.Table.SpeakerTopic>();
                cfg.CreateMap<Data.Entity.Table.SpeakerTopic, Entity.Api.SpeakerTopic>();

                cfg.CreateMap<Entity.Api.Country, Data.Entity.Table.Country>();
                cfg.CreateMap<Data.Entity.Table.Country, Entity.Api.Country>();

                cfg.CreateMap<Entity.Api.Topic, Data.Entity.Table.Topic>();
                cfg.CreateMap<Data.Entity.Table.Topic, Entity.Api.Topic>();


            });

			var mapper = config.CreateMapper();

			return mapper;
		});

		public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService());
		public static readonly Lazy<SpeakerService> SpeakerService = new Lazy<SpeakerService>(() => new SpeakerService());
		public static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() => new QuickAuthTokenService());
		public static readonly Lazy<RoomService> RoomService = new Lazy<RoomService>(() => new RoomService());
		public static readonly Lazy<QuizService> QuizScoreService = new Lazy<QuizService>(() => new QuizService());
        public static readonly Lazy<TimetableService> TimetableService = new Lazy<TimetableService>(() => new TimetableService());
		public static readonly Lazy<PartnerService> PartnerService = new Lazy<PartnerService>(() => new PartnerService());
		public static readonly Lazy<CouponService> CouponService = new Lazy<CouponService>(() => new CouponService());
		public static readonly Lazy<TicketService> TicketService = new Lazy<TicketService>(() => new TicketService());
        public static readonly Lazy<EventService> EventService = new Lazy<EventService>(() => new EventService());

    }
}
