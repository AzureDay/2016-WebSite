using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TeamSpark.AzureDay.WebSite.App;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers.Api
{
    public class EventController : ApiController
    {
        
        [HttpGet]
        [Route("api/event/rooms")]
        public async Task<IHttpActionResult> GetAllRooms()
        {
            var rooms = await AppFactory.EventService.Value.GetAllRoomsAsync();

            return Ok(rooms);
        }

        [HttpGet]
        [Route("api/event/topics")]
        public async Task<IHttpActionResult> GetAllTopics()
        {
            var topics = await AppFactory.EventService.Value.GetAllSpeakerTopicsAsync();

            return Ok(topics);
        }

        [HttpGet]
        [Route("api/event/languages")]
        public async Task<IHttpActionResult> GetAllLanguages()
        {
            var languages = await AppFactory.EventService.Value.GetAllLanguagesAsync();

            return Ok(languages);
        }

        [HttpGet]
        [Route("api/event/speaker")]
        public async Task<IHttpActionResult> GetAllSpeaker()
        {
            var speaker = await AppFactory.EventService.Value.GetAllSpeakersAsync();

            return Ok(speaker);
        }

        [HttpGet]
        [Route("api/event/speakerTopics")]
        public async Task<IHttpActionResult> GetAllSpeakerTopics()
        {
            var speakerTopics = await AppFactory.EventService.Value.GetAllSpeakerTopicsAsync();

            return Ok(speakerTopics);
        }

        [HttpGet]
        [Route("api/event/countries")]
        public async Task<IHttpActionResult> GetAllСountries()
        {
            var countries = await AppFactory.EventService.Value.GetAllSpeakerTopicsAsync();

            return Ok(countries);
        }


    }
}
