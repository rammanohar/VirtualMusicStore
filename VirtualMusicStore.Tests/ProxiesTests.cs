namespace VirtualMusicStore.Tests
{
    using Autofac;
    using Autofac.Integration.Wcf;
    using NUnit.Framework;
    using System;
    using System.ServiceModel;
    using VirtualMusicStore.Service;
    using VirtualMusicStore.ServiceInterface;

    [TestFixture]
    public class ProxiesTests
    {
        IContainer container = null;
        ServiceHost svcMusicAlbumHost = null;
        Uri svcAMusicAlbumServiceURI = new Uri("http://localhost:18850/MusicAlbum.svc");


        [SetUp]
        public void Setup()
        {
            try
            {
                container = Bootstrapper.BuildContainer();

                svcMusicAlbumHost = new ServiceHost(typeof(MusicAlbumService), svcAMusicAlbumServiceURI);

                svcMusicAlbumHost.AddDependencyInjectionBehavior<IMusicAlbumService>(container);

                svcMusicAlbumHost.Open();
            }
            catch (Exception)
            {
                svcMusicAlbumHost = null;
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (svcMusicAlbumHost != null && svcMusicAlbumHost.State != CommunicationState.Closed)
                    svcMusicAlbumHost.Close();

            }
            catch (Exception)
            {
                svcMusicAlbumHost = null;
            }
            finally
            {
                svcMusicAlbumHost = null;
            }
        }

        [Test]
        public void test_self_host_connection()
        {
            Assert.That(svcMusicAlbumHost.State, Is.EqualTo(CommunicationState.Opened));
        }
               
    }
 }
