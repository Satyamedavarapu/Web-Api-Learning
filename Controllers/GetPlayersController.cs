using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace Web_Api_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPlayersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public GetPlayersController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet("/api/GetTeamPlayers")]

        public  IEnumerable<PLAYERS> GetPlayers(int teamID)
        {
            var queryResult = from p in _dataContext.PLAYERS
                              where p.TeamId == teamID
                              select p;

          return queryResult;
        }

/*
        public async Task<IActionResult> GetAsyncTeamPlayers(int teamId)
        {

            var TeamPlayers = await _dataContext.PLAYERS.Where(p => p.TeamId == teamId).ToListAsync();
            return Ok(TeamPlayers);


        }
        */


        /*
        public IEnumerable<PLAYERS> getPlayers()
        {
            var query = from p in _dataContext.PLAYERS
                        where p.TeamId == 0
                        select p;


            foreach(var player in query)
            {
               Console.WriteLine(player.PlayerName);
            }
        }
        */


    


        [HttpGet("/api/GetTeams")]
        public  IEnumerable<TEAMS> GetAsyncTeams(int teamId)
        {


            if (teamId == 0)
            {

                var Teams = from t in _dataContext.TEAMS
                            where t.id != 0
                            select t;

                return Teams;
            }
            else
            {
                var Teams = from t in _dataContext.TEAMS
                            where t.id == teamId
                            select t;
                return Teams;
            }
        }


        [HttpGet("api/PlayerNames")]
        public  IQueryable<PLAYERS> playerName(int nameLength)
        {
            var Players = _dataContext.PLAYERS.AsQueryable().
                          Where(p => p.PlayerName.Length > nameLength);
            return Players;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsyncPlayers(int id)
        {


            if (id == 0)
            {
                var players = await _dataContext.PLAYERS.ToListAsync();
                return Ok(players);

            }
            else
            {
                var player = await _dataContext.PLAYERS.FindAsync(id);
                return Ok(player);
            }

        }
    }
}
