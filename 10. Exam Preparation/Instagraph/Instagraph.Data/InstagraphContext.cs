namespace Instagraph.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class InstagraphProfile : DbContext
    {
        public InstagraphProfile() { }

        public InstagraphProfile(DbContextOptions options)
            :base(options) { }

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>()
                 .HasMany(p => p.Users)
                 .WithOne(p => p.ProfilePicture)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Picture>()
                .HasMany(p => p.Posts)
                .WithOne(p => p.Picture)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany(ps => ps.Comments)
                .WithOne(ps => ps.Post)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Username);

            modelBuilder.Entity<User>()
                .HasMany(up => up.Posts)
                .WithOne(up => up.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(uc => uc.Comments)
                .WithOne(uc => uc.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFollower>()
                .HasKey(uf => new { uf.UserId, uf.FollowerId });

            modelBuilder.Entity<UserFollower>()
                .HasOne(uf => uf.User)
                .WithMany(uf => uf.UserFollowers)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFollower>()
                .HasOne(u => u.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(u => u.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
