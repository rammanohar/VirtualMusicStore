namespace VirtualMusicStore.DataEntities
{
    using System.Data.Entity;
    using VirtualMusicStore.DataEntities.Models;
    public class DbInitializer : CreateDatabaseIfNotExists<StoreDbContext>
    {
        protected override void Seed(StoreDbContext context)
        {
            base.Seed(context);

            context.Albums.Add(new Album
            {
                AlbumName = "Mick Spears",
                Artist = "Mike",
                Label = "Mike",
                LabelType = LabelType.CD,
                Stock = 10

            });

            context.SaveChanges();

        }
    }
}
