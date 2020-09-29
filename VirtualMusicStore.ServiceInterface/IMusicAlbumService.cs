namespace VirtualMusicStore.ServiceInterface
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using VirtualMusicStore.DataContract;

    [ServiceContract]
    public interface IMusicAlbumService
    {
        [OperationContract]
        List<Album> GetAllMusicAlbum();

        [OperationContract]
        Task<List<Album>> GetAllMusicAlbumByAsync();

        [OperationContract]
        Album GetMusicAlbum(int albumid);

        [OperationContract]
        Task<Album> GetMusicAlbumByAsync(int albumid);

        [OperationContract]
        bool AddMusicAlbum(Album album);

        [OperationContract]
        Task<bool> AddMusicAlbumByAsync(Album album);

        [OperationContract]
        bool DeleteMusicAlbum(int albumid);
        [OperationContract]
        Task<bool> DeleteMusicAlbumByAsync(int albumid);

        [OperationContract]
        bool UpdateMusicAlbum(Album album);

        [OperationContract]
        Task<bool> UpdateMusicAlbumByAsync(Album album);

    }
}
