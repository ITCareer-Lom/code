namespace TheGameMVC.Database
{
    using Microsoft.EntityFrameworkCore;
    using TheGameMVC.Model.Characters;
    using TheGameMVC.Model.Game_Engine;

    public class GameContext : DbContext
    {
        internal static string ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;initial catalog = Game; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework";
        public GameContext() { }

        public GameContext(DbContextOptions options) : base(options) { }

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
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Level>().HasMany(l => l.Enemies).WithOne(e => e.Level).HasForeignKey(e => e.LevelId).OnDelete(DeleteBehavior.NoAction); 
            //modelBuilder.Entity<Level>().HasMany(l => l.Helpers).WithOne(h => h.Level).HasForeignKey(e => e.LevelId).OnDelete(DeleteBehavior.NoAction); 
            //modelBuilder.Entity<Creature>().HasMany(h => h.Items).WithOne(i => i.Owner).HasForeignKey(i => i.OwnerId).OnDelete(DeleteBehavior.SetNull);
        }

        public void ResetDatabase(bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                Database.EnsureDeleted();
            }

            if (Database.EnsureCreated())
            {
                return;
            }
        }
    }
}
