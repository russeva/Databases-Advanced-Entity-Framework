namespace VaporStore.Data
{
	using Microsoft.EntityFrameworkCore;
    using VaporStore.Data.Models;

    public class VaporStoreDbContext : DbContext
	{
		public VaporStoreDbContext()
		{}

		public VaporStoreDbContext(DbContextOptions options)
			: base(options)
		{}

        public DbSet<Card> Cards { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameTag> GameTags { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (!options.IsConfigured)
			{
				options.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder model)
		{
            model.Entity<Card>()
                .HasMany(c => c.Purchases)
                .WithOne(c => c.Card)
                .HasForeignKey(c => c.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Developer>()
                .HasMany(d => d.Games)
                .WithOne(d => d.Developer)
                .HasForeignKey(d => d.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<Game>()
                .HasMany(gp => gp.Purchases)
                .WithOne(gp => gp.Game)
                .HasForeignKey(gp => gp.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            model.Entity<GameTag>()
                .HasKey(pk => new { pk.TagId, pk.GameId });

            model.Entity<Genre>()
                 .HasMany(gn => gn.Games)
                 .WithOne(gn => gn.Genre)
                 .HasForeignKey(gn => gn.GenreId)
                 .OnDelete(DeleteBehavior.Restrict);

            model.Entity<User>()
                .HasMany(u => u.Cards)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
		}
	}
}