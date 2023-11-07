using Matches.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MettingPlaceController : ControllerBase
    {
        private static List<MeetingPlace> meetingPlace = new List<MeetingPlace> { new MeetingPlace {NamePlace= "NamePlace" ,IsActive=true, Descriptuon= "Descriptuon", IsSatisfied=true } };

        // GET: api/<MettingPlaceController>
        [HttpGet]
        public IEnumerable<MeetingPlace> Get()
        {
            return meetingPlace;
        }

        // GET api/<MettingPlaceController>/5
        [HttpGet("{id}")]
        public MeetingPlace Get(string namePlace)
        {
            for (int i = 0; i < meetingPlace.Count; i++)
            {
                if (meetingPlace[i].NamePlace == namePlace)
                    return meetingPlace[i];
            }
            //return new HttpException(404,"page is not found!");
            Response.StatusCode = 404;
            //return new HttpNotFoundResult(); // 404
            return new MeetingPlace();
        }

        // POST api/<MettingPlaceController>
        [HttpPost]
        public void Post([FromBody] MeetingPlace value)
        {
            meetingPlace.Add(new MeetingPlace { NamePlace = value.NamePlace,Descriptuon=value.Descriptuon,IsActive =value.IsActive,IsSatisfied=value.IsSatisfied});
        }

        // PUT api/<MettingPlaceController>/5
        [HttpPut("{id}")]
        public void Put(string namePlace, [FromBody] MeetingPlace value)
        {
            var meetingPlaceName = meetingPlace.Find(meetingPlaceName => meetingPlaceName.NamePlace == namePlace);
            meetingPlaceName.Descriptuon = value.Descriptuon;
            meetingPlaceName.IsActive = value.IsActive;
            meetingPlaceName.NamePlace = value.NamePlace;
        }

        // DELETE api/<MettingPlaceController>/5
        [HttpDelete("{id}")]
        public void Delete(string namePlace)
        {
            var meetingPlaceName = meetingPlace.Find(meetingPlaceName => meetingPlaceName.NamePlace == namePlace);
            meetingPlace.Remove(meetingPlaceName);
        }
    }
}
