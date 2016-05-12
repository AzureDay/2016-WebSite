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
			});

			var mapper = config.CreateMapper();

			return mapper;
		});

		public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService());
	}
}
