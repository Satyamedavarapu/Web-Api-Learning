using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdatePlayerController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UpdatePlayerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(int playerId, PLAYERS playerToUpdate)
        {
            var player = await _dataContext.PLAYERS.FindAsync(playerId);
           
            if (player == null)
            {
                return BadRequest("Player does not exist");
            }
            else
            {            
                player.PlayerName = playerToUpdate.PlayerName;
                player.TeamId = playerToUpdate.TeamId;
                await _dataContext.SaveChangesAsync();
                return Ok("Player updated successfully");
            }
        }
    }
}
