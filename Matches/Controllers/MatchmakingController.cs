using Matches.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Matches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchmakingController : ControllerBase
    {
        
        private static List<Matchmaking> matchmaking = new List<Matchmaking> { new Matchmaking { Id = 123456789, FirstName = " FirstName", LastName = "LastName", Email = "Email@gmail.com", Phone = "0554455445", Age = 19, IsChoen = false, status=Status.Single }  };

        // GET: api/<MatchmakingController>
        [HttpGet]
        public IEnumerable<Matchmaking> Get()
        {
           return matchmaking;  
        }

        // GET api/<MatchmakingController>/5
        [HttpGet("{id}")]
        public Matchmaking Get(int id)
        {
            for (int i = 0; i < matchmaking.Count; i++)
            {
                if (matchmaking[i].Id == id)
                    return matchmaking[i];
            }
            //return new HttpException(404,"page is not found!");
            Response.StatusCode = 404;
            //return new HttpNotFoundResult(); // 404
            return new Matchmaking();
        }

        // POST api/<MatchmakingController>
        [HttpPost]
        public void Post([FromBody] Matchmaking value)
        {
            matchmaking.Add(new Matchmaking { Id = value.Id, FirstName = value.FirstName, LastName = value.LastName, Age = value.Age, Phone = value.Phone, Email = value.Email, IsChoen = value.IsChoen, status = value.status });
        }

        // PUT api/<MatchmakingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Matchmaking value)
        {
            var matchmakingId = matchmaking.Find(matchmakingId => matchmakingId.Id == id);
            matchmakingId.FirstName = value.FirstName;
            matchmakingId.LastName = value.LastName;
            matchmakingId.Age = value.Age;  
            matchmakingId.Phone = value.Phone;  
            matchmakingId.Email = value.Email;
            matchmakingId.IsChoen = value.IsChoen;
            matchmakingId.status = value.status;
        }

        // DELETE api/<MatchmakingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var matchmakingId = matchmaking.Find(matchmakingId => matchmakingId.Id == id);
            matchmaking.Remove(matchmakingId);
        }
    }
}
