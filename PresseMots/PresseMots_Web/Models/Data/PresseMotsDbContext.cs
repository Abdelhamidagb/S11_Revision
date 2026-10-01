using Microsoft.EntityFrameworkCore;
using PresseMots.Models;


namespace PresseMots.Models.Data
{
    public class PresseMotsDbContext : DbContext
    {
        public PresseMotsDbContext(){}

        public PresseMotsDbContext(DbContextOptions<PresseMotsDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<StoryTag> StoryTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Ne pas supprimer!
            modelBuilder.SetEntityRelationships();
            modelBuilder.GenerateData();

            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

            // Ajoute la clé primaire composite pour la table intermédiaire
            modelBuilder.Entity<StoryTag>()
                .HasKey(st => new { st.StoryId, st.TagId });
            #endregion
        }

    }
}
