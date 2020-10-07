namespace VirtualMusicStore.Client.ProxyService
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using VirtualMusicStore.Client.Contract;
    using VirtualMusicStore.Client.DataContract;

    public class MusicStoreClient : ClientBase<IMusicAlbumService>, IMusicAlbumService
    {
        #region IArticleService Members

        public bool AddMusicAlbum(Album album)
        {
            return Channel.AddMusicAlbum(album);
        }

        public Task<bool> AddMusicAlbumByAsync(Album album)
        {
            return Channel.AddMusicAlbumByAsync(album);
        }

        public bool DeleteMusicAlbum(int albumid)
        {
            return Channel.DeleteMusicAlbum(albumid);
        }

        public Task<bool> DeleteMusicAlbumByAsync(int albumid)
        {
            return Channel.DeleteMusicAlbumByAsync(albumid);
        }

        public List<Album> GetAllMusicAlbum()
        { 
            var albums = Channel.GetAllMusicAlbum();
            return albums;
        }

        public Task<List<Album>> GetAllMusicAlbumByAsync()
        {
            return Channel.GetAllMusicAlbumByAsync();
        }

        public Album GetMusicAlbum(int albumid)
        {
            return Channel.GetMusicAlbum(albumid);
        }

        public Task<Album> GetMusicAlbumByAsync(int albumid)
        {
            return Channel.GetMusicAlbumByAsync(albumid);
        }

        public bool UpdateMusicAlbum(Album album)
        {
            return Channel.UpdateMusicAlbum(album);
        }

        public Task<bool> UpdateMusicAlbumByAsync(Album album)
        {
            return Channel.UpdateMusicAlbumByAsync(album);
        }

        #endregion
        public void CleanUp()
        {
            try
            {
                if (base.State != CommunicationState.Faulted)
                    base.Close();
                else
                    base.Abort();
            }
            catch (Exception ex)
            {
                base.Abort();
            }
        }
      
    }
}
