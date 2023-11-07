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
        static int count = 100;
        private static List<Matchmaker> matchmakers = new List<Matchmaker> { new Matchmaker { Id = count++, FirstName = " FirstName", LastName = "LastName", Email = "Email@gmail.com", Phone = "0554455445" } };

        // GET: api/<MatchController>
        [HttpGet]
        public IEnumerable<Matchmaker> Get()
        {
            return matchmakers;
        }

        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public Matchmaker Get(int id)
        {
            for (int i = 0; i < matchmakers.Count; i++)
            {
                if (matchmakers[i].Id == id)
                    return matchmakers[i];
            }
            //return new HttpException(404,"page is not found!");
            Response.StatusCode = 404;
            //return new HttpNotFoundResult(); // 404
            return new Matchmaker();
        }

        // POST api/<MatchController>
        [HttpPost]
        public void Post([FromBody] Matchmaker value)
        {
            matchmakers.Add(new Matchmaker { Id = count++,FirstName = value.FirstName,LastName = value.LastName, Email=value.Email ,Phone=value.Phone});
        }

        // PUT api/<MatchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Matchmaker value)
        {
            var matchmakerId = matchmakers.Find(matchmakerId => matchmakerId.Id == id);
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
            matchmakers.Remove(matchmakers.Find(matchmakerId => matchmakerId.Id == id));//matchmakerId
        }
    }
}
