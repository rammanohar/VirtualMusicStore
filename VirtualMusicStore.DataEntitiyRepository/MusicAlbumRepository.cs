using System.Collections.Generic;
using System.Linq;
using VirtualMusicStore.DataEntities;
using VirtualMusicStore.DataEntities.Models;
using VirtualMusicStore.DataEntitiyInterface;

namespace VirtualMusicStore.DataEntitiyRepository
{
    public class MusicAlbumRepository : IMusicAlbumRepository
    {
        private readonly IDbFactory dbFactory;
        private StoreDbContext dbContext;
        public MusicAlbumRepository(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dbContext = this.dbFactory.Init();
        }

        public bool AddMusicAlbum(Album album)
        {
           var query = dbFactory.Init().Albums.Where(a => a.AlbumName == album.AlbumName);
            if (!query.Any())
            {
                dbContext.Albums.Add(album);
                dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteMusicAlbum(int albumid)
        {
            var query = dbContext.Albums.Where(a => a.Id == albumid);
            if (query.Any())
            {
                dbContext.Albums.Remove(query.Single());
                dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Album> GetAllMusicAlbum()
        {

            var album = (dbContext.Albums.ToList());

            return (IEnumerable<Album>)album;
        }
        public Album GetMusicAlbum(int Id)
        {

            var query = dbContext.Albums.Where(a => a.Id == Id);
            if (query.Any())
            {
                return (query.Single());
            }
            else
            {
                return null;
            }
        }
        public bool UpdateMusicAlbum(Album album)
        {
            var query = dbContext.Albums.Where(a => a.Id == album.Id);
            if (query.Any())
            {
                var dbAlbum = query.Single();
                dbAlbum.Label = album.Label;
                dbAlbum.Artist = album.Artist;
                dbAlbum.Stock = album.Stock;
                dbAlbum.LabelType = album.LabelType;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}