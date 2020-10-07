
namespace VirtualMusicStore.Tests
{
    using Autofac.Util;
    using System.Collections.Generic;
    using VirtualMusicStore.Client.DataContract;

    public class ClientInjectionClass : Disposable
    {
        public Client.Contract.IMusicAlbumService MusicAlbumServiceProxy;
        public ClientInjectionClass(Client.Contract.IMusicAlbumService musicAlbumServiceProxy)
        {
            this.MusicAlbumServiceProxy = musicAlbumServiceProxy;
        }

        #region IDisposable
        protected void DisposeCore()
        {
            base.Dispose();
            try
            {
                (MusicAlbumServiceProxy as Client.ProxyService.MusicStoreClient).CleanUp();
            }
            catch
            {
                this.MusicAlbumServiceProxy = null;
            }
        }
        #endregion

        #region Methods

        public List<Album> GetAllMusicAlbum()
        {
             var albums = this.MusicAlbumServiceProxy.GetAllMusicAlbum();

            return albums;
        }

        public Album GetMusicAlbum(int id)
        {
            return this.MusicAlbumServiceProxy.GetMusicAlbum(id);
        }

        #endregion
    }
}
