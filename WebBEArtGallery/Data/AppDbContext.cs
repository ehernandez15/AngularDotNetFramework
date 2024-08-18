using System.Data.Entity;
using WebBEArtGallery.Data.Entities;

namespace WebBEArtGallery.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=AppDbContext")
        {
        }

        // Define DbSet for each entity in your model
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        // Override OnModelCreating if you need to customize the EF configuration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the one-to-many relationship between Gallery and Artwork
            modelBuilder.Entity<Gallery>()
                .HasMany(g => g.Artworks)           // A Gallery can have many Artworks
                .WithOptional(a => a.Gallery)       // Each Artwork may optionally be associated with a Gallery
                .HasForeignKey(a => a.GalleryId)   // GalleryId in Artwork is the foreign key referencing Gallery
                .WillCascadeOnDelete(false);       // Disable cascade delete; Artworks will not be deleted when a Gallery is deleted

            // Configure the one-to-many relationship between Artist and Artwork
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Artworks)           // An Artist can have many Artworks
                .WithOptional(a => a.Artist)        // Each Artwork may optionally be associated with an Artist
                .HasForeignKey(a => a.ArtistId)    // ArtistId in Artwork is the foreign key referencing Artist
                .WillCascadeOnDelete(false);       // Disable cascade delete; Artworks will not be deleted when an Artist is deleted

            base.OnModelCreating(modelBuilder);    // Call the base class implementation of OnModelCreating
        }
    }
}