namespace TheGameMVC.Database
{
    using Microsoft.EntityFrameworkCore;
    using TheGameMVC.Model.Characters;
    using TheGameMVC.Model.Game_Engine;

    public class GameContext : DbContext
    {
        public GameContext() { }

        public GameContext(DbContextOptions options)
        : base(options) { }

        public DbSet<Hero> Heros { get; set; }

        public DbSet<Enemy> Enemies { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Map> Maps { get; set; }

        public DbSet<Helper> Helpers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
