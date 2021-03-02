using Microsoft.EntityFrameworkCore;
using Homework_0302.Models;

namespace Homework_0302.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
        public DbSet<Homework> Homework {get; set;}
    }
}