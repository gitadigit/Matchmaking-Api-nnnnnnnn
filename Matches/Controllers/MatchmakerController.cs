using Matches.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchmakerController : ControllerBase
    {
        private DataContext _dataContext;
        public MatchmakerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/<MatchController>
        [HttpGet]
        public IEnumerable<Matchmaker> Get()
        {
            return _dataContext.matchmakers;
        }

        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public ActionResult<Matchmaker> Get(int id)
        {
            //for (int i = 0; i < matchmakers.Count; i++)
            //{
            //    if (matchmakers[i].Id == id)
            //        return matchmakers[i];
            //}
            ////return new HttpException(404,"page is not found!");
            //Response.StatusCode = 404;
            ////return new HttpNotFoundResult(); // 404
            //return new Matchmaker();
                var matcher = _dataContext.matchmakers.Find(p => p.Id == id);
            if (matcher == null)
                return NotFound();
            return matcher;
        }

        // POST api/<MatchController>
        [HttpPost]
        public void Post([FromBody] Matchmaker value)
        {
            _dataContext.matchmakers.Add(new Matchmaker { Id = _dataContext.count++,FirstName = value.FirstName,LastName = value.LastName, Email=value.Email ,Phone=value.Phone});
        }

        // PUT api/<MatchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Matchmaker value)
        {
            var matchmakerId = _dataContext.matchmakers.Find(matchmakerId => matchmakerId.Id == id);
            matchmakerId.FirstName = value.FirstName;
            matchmakerId.LastName = value.LastName;
            matchmakerId.Email = value.Email;
            matchmakerId.Phone = value.Phone;
        }

        // DELETE api/<MatchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // var matchmakerId = matchmakers.Find(matchmakerId => matchmakerId.Id == id);
            _dataContext.matchmakers.Remove(_dataContext.matchmakers.Find(matchmakerId => matchmakerId.Id == id));//matchmakerId
        }
    }
}
