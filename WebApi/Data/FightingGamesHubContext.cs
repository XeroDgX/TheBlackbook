using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class TheBlackbookContext: DbContext
    {
        protected readonly IConfiguration _configuration;

        public TheBlackbookContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("TheBlackbookDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Games { get; set;}
        public DbSet<Character> Characters { get; set;}
        public DbSet<Player> Players { get; set;}
        public DbSet<SetMatch> SetMatches { get; set;}
        public DbSet<Set> Sets { get; set;}


    }
}
