using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Typer.Ef;
using Typer.Ef.Entities;

namespace Typer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public UsersController(ApiDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public async Task<IActionResult> getUsers()
        {
            var data = _dbContext.Users.Include(a => a.Posts).ToList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var user = await _dbContext.Users.Include(a => a.Posts).FirstOrDefaultAsync(a => a.UserId == id);
            if (user == null) return NotFound("No User Found");
            else
            {
                return Ok(user);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostUser([FromForm] User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return NotFound("No User Found");
            else
            {
                _dbContext.Remove(user);
                await _dbContext.SaveChangesAsync();
                return Ok("Deleted");
            }
        }

    }
}
