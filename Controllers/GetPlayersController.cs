using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAsyncTeamPlayers(int teamId)
        {

            var TeamPlayers = await _dataContext.PLAYERS.Where(p => p.TeamId == teamId).ToListAsync();
            return Ok(TeamPlayers);


        }





        [HttpGet("/api/GetTeams")]
        public async Task<IActionResult> GetAsyncTeams(int teamId)
        {


            if (teamId == 0)
            {
                var Teams = await _dataContext.TEAMS.ToListAsync();
                return Ok(Teams);
            }
            else
            {
                var Teams = await _dataContext.TEAMS.Where(t => t.id == teamId).ToListAsync();
                return Ok(Teams);
            }
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
