namespace VirtualMusicStore.DataEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using VirtualMusicStore.DataEntities.Models;

    /// <summary>
    /// DbContext is the primary class that is responsible for interacting with the database.
    /// </summary>
    public class StoreDbContext : DbContext
    {
        /// <summary>Initializes a new instance of the <see cref="StoreDbContext"/> class.</summary>
        /// <param name="options">The options.</param>
        public StoreDbContext() : base("VirtualMusicContext")
        {
            Database.SetInitializer<StoreDbContext>(new DbInitializer());
        }

        /// <summary>
        /// Gets or sets the Attribute Definitions DB Set.
        /// </summary>
        /// <value>The DB Set of <see cref="AttributeDefinition"/>.</value>
        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// Create the model with relationships/keys
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Validate arguments
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Album>()
                .HasKey(e => e.AlbumName)
                .HasIndex(e => e.AlbumName);


            // Call base
            base.OnModelCreating(modelBuilder);
        }
    }
}
