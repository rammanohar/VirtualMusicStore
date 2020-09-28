namespace VirtualMusicStore.WebApp.Service
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.ServiceModel;
    using VirtualMusicStore.DataContract;
    using VirtualMusicStore.ServiceInterface;
    using VirtualMusicStore.WebApp.Models;
    using VirtualMusicStore.WebApp.Service.Interface;
    public class MusicService : IMusicService
    {

        public bool AddMusicAlbum(AlbumVm albumVm)
        {

            var album = new Album
            {
                AlbumName = albumVm.AlbumName,
                Label = albumVm.Label,
                Artist = albumVm.Artist,
                Stock = albumVm.Stock,
                LabelType = (LabelType)albumVm.LabelType
            };
            return CreateChannel().AddMusicAlbum(album);
        }

        public bool DeleteMusicAlbum(int albumid)
        {
            return CreateChannel().DeleteMusicAlbum(albumid);
        }

        public List<AlbumVm> GetAllMusicAlbum()
        {
            //Call the service method on this channel as below 
            List<Album> result = CreateChannel().GetAllMusicAlbum();

            var albumsList = result.Select(a => new AlbumVm
            {
                Id = a.Id,
                AlbumName = a.AlbumName,
                Artist = a.Artist,
                Label = a.Label,
                LabelType = (LabelTypeVm)a.LabelType,
                Stock = a.Stock
            }).ToList();

            return albumsList;
        }

        public AlbumVm GetMusicAlbum(int albumid)
        {
            var album = CreateChannel().GetMusicAlbum(albumid);
            var albumvm = new AlbumVm
            {
                Id = album.Id,
                AlbumName = album.AlbumName,
                Label = album.Label,
                Artist = album.Artist,
                Stock = album.Stock,
                LabelType = (LabelTypeVm)album.LabelType
            };

            return albumvm;
        }

        public bool UpdateMusicAlbum(AlbumVm albumVm)
        {
            var album = new Album
            {
                Id = albumVm.Id,
                Label = albumVm.Label,
                Artist = albumVm.Artist,
                Stock = albumVm.Stock,
                LabelType = (LabelType)albumVm.LabelType
            };

            return CreateChannel().UpdateMusicAlbum(album);
        }

        private IMusicAlbumService CreateChannel()
        {
            ChannelFactory<IMusicAlbumService> channelFactory = null;
            try
            {

                //Create a binding of the type exposed by service 
                BasicHttpBinding binding = new BasicHttpBinding();

                //Create EndPoint address
                var serviceEndpoint = ConfigurationManager.AppSettings["MusicService"];

                EndpointAddress endpointAddress = new EndpointAddress(serviceEndpoint);

                //Pass Binding and EndPoint address to ChannelFactory
                channelFactory = new ChannelFactory<IMusicAlbumService>(binding, endpointAddress);

                //Now create the new channel as below
                return channelFactory.CreateChannel();
            }
            catch (TimeoutException)
            {
                //Timeout error
                if (channelFactory != null)
                    channelFactory.Abort();

                throw;
            }
            catch (FaultException)
            {
                if (channelFactory != null)
                    channelFactory.Abort();

                throw;
            }
            catch (CommunicationException)
            {
                //Communication error    
                if (channelFactory != null)
                    channelFactory.Abort();

                throw;
            }
            catch (Exception)
            {
                if (channelFactory != null)
                    channelFactory.Abort();

                throw;
            }
        }
    }
}