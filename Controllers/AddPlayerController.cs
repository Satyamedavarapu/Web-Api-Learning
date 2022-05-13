using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web_Api_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddPlayerController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public AddPlayerController(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PLAYERS playerToAdd)

        {

            if(playerToAdd.TeamId == null || playerToAdd.TeamId == 0)
            {
                return BadRequest("Team Id cannot be null");
            }
             
            else if (playerToAdd.PlayerName.Length == 0)
            {
                return BadRequest("Player name cannot be null");
            }

            else { 
             _dataContext.PLAYERS.Add(playerToAdd);

            await _dataContext.SaveChangesAsync();

            return Ok("Player added successfully");

            }

        }
    }
}
