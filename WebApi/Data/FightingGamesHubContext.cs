using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class TheBlackbookContext : DbContext
    {

        public TheBlackbookContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SetMatchView>(smv =>
            smv.HasNoKey()
            );
            modelBuilder.Entity<SetView>(sv =>
            sv.HasNoKey()
            );
            //modelBuilder.Entity<SetMatch>(sv =>
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<SetMatch> SetMatches { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<SetView> SetView { get; set; }
        public DbSet<SetMatchView> SetMatchView { get; set; }

    }
}
