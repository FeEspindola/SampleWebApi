using Commander.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.API.Data
{
    public class CommandsContext : DbContext
    {
        public CommandsContext(DbContextOptions<CommandsContext> options)
            : base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }


    }
}