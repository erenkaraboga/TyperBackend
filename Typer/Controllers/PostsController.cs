using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Typer.Ef;
using Typer.Ef.Entities;

namespace Typer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public PostsController(ApiDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public async Task<IActionResult> getPosts()
        {
            var data = _dbContext.Posts;
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            if (post == null) return NotFound("No User Found");
            else
            {
                return Ok(post);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostUser([FromForm] Post post)
        {
            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            if (post == null) return NotFound("No User Found");
            else
            {
                _dbContext.Remove(post);
                await _dbContext.SaveChangesAsync();
                return Ok("Deleted");
            }
        }
    }
}
