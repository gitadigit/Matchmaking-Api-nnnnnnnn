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
        private DataContext _dataContext;
        public MatchmakingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        // GET: api/<MatchmakingController>
        [HttpGet]
        public IEnumerable<Matchmaking> Get()
        {
           return _dataContext.matchmaking;  
        }

        // GET api/<MatchmakingController>/5
        [HttpGet("{id}")]
        public ActionResult<Matchmaking> Get(int id)
        {
            //for (int i = 0; i < _dataContext.matchmaking.Count; i++)
            //{
            //    if (_dataContext.matchmaking[i].Id == id)
            //        return _dataContext.matchmaking[i];
            //}
            ////return new HttpException(404,"page is not found!");
            //Response.StatusCode = 404;
            ////return new HttpNotFoundResult(); // 404
            //return new Matchmaking();
            var match = _dataContext.matchmaking.Find(p => p.Id == id);
            if (match == null)
                return NotFound();
            return match;
        }

        // POST api/<MatchmakingController>
        [HttpPost]
        public void Post([FromBody] Matchmaking value)
        {
            _dataContext.matchmaking.Add(new Matchmaking { Id = value.Id, FirstName = value.FirstName, LastName = value.LastName, Age = value.Age, Phone = value.Phone, Email = value.Email, IsChoen = value.IsChoen, status = value.status });
        }

        // PUT api/<MatchmakingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Matchmaking value)
        {
            var matchmakingId = _dataContext.matchmaking.Find(matchmakingId => matchmakingId.Id == id);
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
            var matchmakingId = _dataContext.matchmaking.Find(matchmakingId => matchmakingId.Id == id);
            _dataContext.matchmaking.Remove(matchmakingId);
        }
    }
}
