namespace VirtualMusicStore.ServiceInterface
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using VirtualMusicStore.DataContract;

    [ServiceContract]
    public interface IMusicAlbumService
    {
        [OperationContract]
        List<Album> GetAllMusicAlbum();

        [OperationContract]
        Album GetMusicAlbum(int albumid);

        [OperationContract]
        bool AddMusicAlbum(Album album);

        [OperationContract]
        bool DeleteMusicAlbum(int albumid);

        [OperationContract]
        bool UpdateMusicAlbum(Album album);

    }
}
