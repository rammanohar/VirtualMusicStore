namespace VirtualMusicStore.Service
{
    using Autofac;
    using VirtualMusicStore.DataEntities.Interface;
    using VirtualMusicStore.DataEntities.Service;
    using VirtualMusicStore.ServiceInterface;

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

            builder.RegisterType<MusicAlbumService>().As<IMusicAlbumService>();
            builder.RegisterType<MusicAlbumRepository>().As<IMusicAlbumRepository>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();

            // build container
            return builder.Build();
        }
    }
}