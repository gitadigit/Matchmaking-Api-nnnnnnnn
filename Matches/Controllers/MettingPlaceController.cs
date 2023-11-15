using Matches.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MettingPlaceController : ControllerBase
    {
        private DataContext _dataContext;
        public MettingPlaceController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/<MettingPlaceController>
        [HttpGet]
        public IEnumerable<MeetingPlace> Get()
        {
            return _dataContext.meetingPlace;
        }

        // GET api/<MettingPlaceController>/5
        [HttpGet("{id}")]
        public ActionResult<MeetingPlace> Get(string namePlace)
        {
            //for (int i = 0; i < meetingPlace.Count; i++)
            //{
            //    if (_dataContext.meetingPlace[i].NamePlace == namePlace)
            //        return _dataContext.meetingPlace[i];
            //}
            ////return new HttpException(404,"page is not found!");
            //Response.StatusCode = 404;
            ////return new HttpNotFoundResult(); // 404
            //return new MeetingPlace();
            var place = _dataContext.meetingPlace.Find(p => p.NamePlace == namePlace);
            if (place == null)
                return NotFound();
            return place;   
        }

        // POST api/<MettingPlaceController>
        [HttpPost]
        public void Post([FromBody] MeetingPlace value)
        {
            _dataContext.meetingPlace.Add(new MeetingPlace { NamePlace = value.NamePlace,Descriptuon=value.Descriptuon,IsActive =value.IsActive,IsSatisfied=value.IsSatisfied});
        }

        // PUT api/<MettingPlaceController>/5
        [HttpPut("{id}")]
        public void Put(string namePlace, [FromBody] MeetingPlace value)
        {
            var meetingPlaceName = _dataContext.meetingPlace.Find(meetingPlaceName => meetingPlaceName.NamePlace == namePlace);
            meetingPlaceName.Descriptuon = value.Descriptuon;
            meetingPlaceName.IsActive = value.IsActive;
            meetingPlaceName.NamePlace = value.NamePlace;
        }

        // DELETE api/<MettingPlaceController>/5
        [HttpDelete("{id}")]
        public void Delete(string namePlace)
        {
            var meetingPlaceName = _dataContext.meetingPlace.Find(meetingPlaceName => meetingPlaceName.NamePlace == namePlace);
            _dataContext.meetingPlace.Remove(meetingPlaceName);
        }
    }
}
