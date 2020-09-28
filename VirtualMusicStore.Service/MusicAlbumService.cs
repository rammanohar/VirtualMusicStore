﻿namespace VirtualMusicStore.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    using VirtualMusicStore.DataEntities.Interface;
    using VirtualMusicStore.ServiceInterface;

    [ServiceBehavior]
    public class MusicAlbumService : IMusicAlbumService
    {
        private readonly IMusicAlbumRepository albumRepository;

        public MusicAlbumService(IMusicAlbumRepository repository)
        {
            albumRepository = repository;
        }
        public bool AddMusicAlbum(DataContract.Album album)
        {
            var dbAlbum = new DataEntities.Models.Album
            {
                AlbumName = album.AlbumName,
                Label = album.Label,
                Artist = album.Artist,
                Stock = album.Stock,
                LabelType = (DataEntities.Models.LabelType)album.LabelType
            };

            return albumRepository.AddMusicAlbum(dbAlbum);
        }

        public bool DeleteMusicAlbum(int albumid)
        {
            return albumRepository.DeleteMusicAlbum(albumid);
        }

        public List<DataContract.Album> GetAllMusicAlbum()
        {
            var albums = albumRepository.GetAllMusicAlbum();

            var albumsList = albums.Select(a => new DataContract.Album
            {
                Id = a.Id,
                AlbumName = a.AlbumName,
                Artist = a.Artist,
                Label = a.Label,
                LabelType = (DataContract.LabelType)a.LabelType,
                Stock = a.Stock
            }).ToList();

            return albumsList;
        }

        public DataContract.Album GetMusicAlbum(int albumid)
        {
            var dbAlbum = albumRepository.GetMusicAlbum(albumid);

            var album = new DataContract.Album
            {
                Id = dbAlbum.Id,
                AlbumName = dbAlbum.AlbumName,
                Label = dbAlbum.Label,
                Artist = dbAlbum.Artist,
                Stock = dbAlbum.Stock,
                LabelType = (DataContract.LabelType)dbAlbum.LabelType
            };

            return album;
        }

        public bool UpdateMusicAlbum(DataContract.Album album)
        {
            var dbAlbum = new DataEntities.Models.Album
            {
                Id = album.Id,
                Label = album.Label,
                Artist = album.Artist,
                Stock = album.Stock,
                LabelType = (DataEntities.Models.LabelType)album.LabelType
            };

            return albumRepository.UpdateMusicAlbum(dbAlbum);
        }
    }
}