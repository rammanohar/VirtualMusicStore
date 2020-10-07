using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using VirtualMusicStore.DataEntitiyInterface;
using VirtualMusicStore.ServiceInterface;

namespace VirtualMusicStore.Service
{
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
            try
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
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public async Task<bool> AddMusicAlbumByAsync(DataContract.Album album)
        {
            var dbAlbum = new DataEntities.Models.Album
            {
                AlbumName = album.AlbumName,
                Label = album.Label,
                Artist = album.Artist,
                Stock = album.Stock,
                LabelType = (DataEntities.Models.LabelType)album.LabelType
            };
            return await Task.FromResult(albumRepository.AddMusicAlbum(dbAlbum));
        }

        public bool DeleteMusicAlbum(int albumid)
        {
            try
            {
                return albumRepository.DeleteMusicAlbum(albumid);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public async Task<bool> DeleteMusicAlbumByAsync(int albumid)
        {
            return await Task.FromResult(albumRepository.DeleteMusicAlbum(albumid));
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

        public async Task<List<DataContract.Album>> GetAllMusicAlbumByAsync()
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

            return await Task.FromResult(albumsList);
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

        public async Task<DataContract.Album> GetMusicAlbumByAsync(int albumid)
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

            return await Task.FromResult(album);
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

        public async Task<bool> UpdateMusicAlbumByAsync(DataContract.Album album)
        {
            var dbAlbum = new DataEntities.Models.Album
            {
                Id = album.Id,
                Label = album.Label,
                Artist = album.Artist,
                Stock = album.Stock,
                LabelType = (DataEntities.Models.LabelType)album.LabelType
            };

            return await Task.FromResult(albumRepository.UpdateMusicAlbum(dbAlbum));
        }
    }
}