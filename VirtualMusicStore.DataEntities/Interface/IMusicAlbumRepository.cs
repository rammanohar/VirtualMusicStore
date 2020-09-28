namespace VirtualMusicStore.DataEntities.Interface
{
    using System.Collections.Generic;
    using VirtualMusicStore.DataEntities.Models;

    public interface IMusicAlbumRepository
    {
        bool AddMusicAlbum(Album album);

        bool DeleteMusicAlbum(int albumid);

        IEnumerable<Album> GetAllMusicAlbum();

        Album GetMusicAlbum(int id);

        bool UpdateMusicAlbum(Album album);
    }
}
