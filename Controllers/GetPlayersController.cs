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

        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
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
