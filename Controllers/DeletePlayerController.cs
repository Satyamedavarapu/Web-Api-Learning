using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web_Api_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeletePlayerController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public DeletePlayerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int playerId)
        {

            var Player = await _dataContext.PLAYERS.FindAsync(playerId);

            if(Player == null)
            {
                return NotFound("The player you are trying to delete does not exist");
            } else
            {

                _dataContext.PLAYERS.Remove(Player);
                await _dataContext.SaveChangesAsync();
                return Ok("The player deleted successfully");
            }


        } 


    }
}
