namespace VirtualMusicStore.WebApp.Service.Interface
{
    using System.Collections.Generic;
    using VirtualMusicStore.WebApp.Models;

    public interface IMusicService
    {
        List<AlbumVm> GetAllMusicAlbum();

        AlbumVm GetMusicAlbum(int albumid);

        bool AddMusicAlbum(AlbumVm album);

        bool DeleteMusicAlbum(int albumid);

        bool UpdateMusicAlbum(AlbumVm album);
    }
}
