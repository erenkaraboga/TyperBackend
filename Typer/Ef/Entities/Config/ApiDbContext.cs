using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Typer.Ef.Entities;

namespace Typer.Ef
{
    public class ApiDbContext :DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {

        }
    }
}
