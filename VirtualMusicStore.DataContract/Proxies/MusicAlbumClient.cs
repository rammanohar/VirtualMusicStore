namespace VirtualMusicStore.ClientService.Proxies
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using VirtualMusicStore.ApplicationServices.DataContract;
    using VirtualMusicStore.ApplicationServices.Interface;

    public class MusicAlbumClient : ClientBase<IMusicAlbumService>, IMusicAlbumService
    {
        public bool AddMusicAlbum(Album album)
        {
           return Channel.AddMusicAlbum(album);
        }

        public bool DeleteMusicAlbum(int albumid)
        {
            return Channel.DeleteMusicAlbum(albumid); 
        }

        public List<Album> GetAllMusicAlbum()
        {
            return Channel.GetAllMusicAlbum(); 
        }

        public Album GetMusicAlbum(int albumid)
        {
            return Channel.GetMusicAlbum(albumid);
        }

        public bool UpdateMusicAlbum(Album album)
        {
            return Channel.UpdateMusicAlbum(album);
        }
    }
}
