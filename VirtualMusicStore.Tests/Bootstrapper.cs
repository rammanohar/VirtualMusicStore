namespace VirtualMusicStore.Tests
{
    using Autofac;
    using VirtualMusicStore.Service;

    public static class Bootstrapper
    {
        /// <summary>
        /// Configures and builds Autofac IOC container.
        /// </summary>
        /// <returns></returns>
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // register services
            builder.RegisterType<MusicAlbumService>().As<VirtualMusicStore.ServiceInterface.IMusicAlbumService>();

            // build container
            return builder.Build();
        }
    }
}
