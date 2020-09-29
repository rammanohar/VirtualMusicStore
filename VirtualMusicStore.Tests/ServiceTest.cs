namespace VirtualMusicStore.Tests
{
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using VirtualMusicStore.DataEntities.Interface;

    [TestFixture]
    public class ServiceTest
    {
        IMusicAlbumRepository AlbumsRepository;
        [SetUp]
        public void Setup()
        {
            //Repositories
            var albumsRepository = new Mock<IMusicAlbumRepository>();

            List<DataEntities.Models.Album> listAlbums = new List<DataEntities.Models.Album>()
                    {
                             new DataEntities.Models.Album()
                            {
                                Id = 1,
                                AlbumName = "Super Spears",
                                Artist = "Mike",
                                Label = "Virgin",
                                LabelType = DataEntities.Models.LabelType.CD,
                                Stock = 10

                             },
                            new DataEntities.Models.Album()
                            {
                                Id = 2,
                                AlbumName = "Super Spears",
                                Artist = "Mike",
                                Label = "Virgin",
                                LabelType = DataEntities.Models.LabelType.CD,
                                Stock = 10

                            }
                    };

            albumsRepository.Setup(x => x.GetAllMusicAlbum()).Returns(listAlbums);
            albumsRepository.Setup(x => x.GetMusicAlbum(1)).Returns(listAlbums.Single(a => a.Id == 1));

            albumsRepository.Setup(x => x.AddMusicAlbum(It.IsAny<DataEntities.Models.Album>())).Returns(
                (DataEntities.Models.Album target) =>
                {
                    listAlbums.Add(target);
                    return true;
                });

            albumsRepository.Setup(x => x.UpdateMusicAlbum(It.IsAny<DataEntities.Models.Album>())).Returns(
                (DataEntities.Models.Album target) =>
                {
                    var original = listAlbums.Single(item => item.Id == target.Id);
                    if (original == null) return false;
                    original.AlbumName = target.AlbumName;
                    original.Artist = target.Artist;
                    original.Label = target.Label;
                    original.LabelType = target.LabelType;
                    original.Stock = target.Stock;
                    return true;
                });


            albumsRepository.Setup(x => x.DeleteMusicAlbum(It.IsAny<int>())).Returns(
                (int target) =>
                {
                    var original = listAlbums.Single(item => item.Id == target);
                    listAlbums.Remove(original);
                    return true;
                });

            this.AlbumsRepository = albumsRepository.Object;

        }

        [Test]
        public void GetAllMusicAlbumTest()
        {
            Service.MusicAlbumService testService = new Service.MusicAlbumService(this.AlbumsRepository);
            var result = testService.GetAllMusicAlbum();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetAllMusicAlbumAsyncTest()
        {
            Service.MusicAlbumService testService = new Service.MusicAlbumService(this.AlbumsRepository);
            var result = await testService.GetAllMusicAlbumByAsync();
            Assert.That(result.Count, Is.EqualTo(2));
        }


        [Test]
        public void GetMusicAlbumTest()
        {
            Service.MusicAlbumService testService = new Service.MusicAlbumService(this.AlbumsRepository);
            var result = testService.GetMusicAlbum(1);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task GetMusicAlbumAsyncTest()
        {
            Service.MusicAlbumService testService = new Service.MusicAlbumService(this.AlbumsRepository);
            var result = await testService.GetMusicAlbumByAsync(1);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void AddMusicAlbumTest()
        {
            var albumModel = new DataContract.Album
            {
                Id = 3,
                AlbumName = "Super Spears",
                Artist = "Mike",
                Label = "Virgin",
                LabelType = DataContract.LabelType.CD,
                Stock = 10
            };

            Service.MusicAlbumService testService = new Service.MusicAlbumService(this.AlbumsRepository);

            var result = testService.AddMusicAlbum(albumModel);
            Assert.That(result, Is.EqualTo(true));

            var count = this.AlbumsRepository.GetAllMusicAlbum().Count();
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public async Task AddMusicAlbumAsyncTestAsync()
        {
            var albumModel = new DataContract.Album
            {
                Id = 3,
                AlbumName = "Super Spears",
                Artist = "Mike",
                Label = "Virgin",
                LabelType = DataContract.LabelType.CD,
                Stock = 10
            };

            Service.MusicAlbumService testService = new Service.MusicAlbumService(this.AlbumsRepository);

            var result = await testService.AddMusicAlbumByAsync(albumModel);
            Assert.That(result, Is.EqualTo(true));

            var count = this.AlbumsRepository.GetAllMusicAlbum().Count();
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void UpdateMusicAlbumTest()
        {
            var albumModel = new DataContract.Album
            {
                Id = 1,
                Artist = "Mike",
                Label = "Virgin",
                LabelType = DataContract.LabelType.CD,
                Stock = 10
            };
            Service.MusicAlbumService testService = new Service.MusicAlbumService(this.AlbumsRepository);
            var result = testService.UpdateMusicAlbum(albumModel);

            var updatedalbumModel = testService.GetMusicAlbum(1);

            Assert.That(result, Is.EqualTo(true));

            Assert.That(updatedalbumModel.AlbumName, Is.EqualTo(albumModel.AlbumName));
        }

        [Test]
        public async Task UpdateMusicAlbumAsyncTest()
        {
            var albumModel = new DataContract.Album
            {
                Id = 1,
                Artist = "Mike",
                Label = "Virgin",
                LabelType = DataContract.LabelType.CD,
                Stock = 10
            };
            Service.MusicAlbumService testService = new Service.MusicAlbumService(this.AlbumsRepository);
            var result = await testService.UpdateMusicAlbumByAsync(albumModel);

            var updatedalbumModel = await testService.GetMusicAlbumByAsync(1);

            Assert.That(result, Is.EqualTo(true));

            Assert.That(updatedalbumModel.AlbumName, Is.EqualTo(albumModel.AlbumName));
        }

        [Test]
        public void DeleteMusicAlbumTest()
        {
            Service.MusicAlbumService testService = new Service.MusicAlbumService(AlbumsRepository);
            var result = testService.DeleteMusicAlbum(1);
            Assert.That(result, Is.EqualTo(true));

            var albumModels = testService.GetAllMusicAlbum();
            Assert.That(albumModels.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteMusicAlbumAsyncTest()
        {
            Service.MusicAlbumService testService = new Service.MusicAlbumService(AlbumsRepository);
            bool result = await testService.DeleteMusicAlbumByAsync(1);
            Assert.That(result, Is.EqualTo(true));

            var albumModels = testService.GetAllMusicAlbumByAsync();
            Assert.That(albumModels.Result.Count, Is.EqualTo(1));
        }
    }
}
