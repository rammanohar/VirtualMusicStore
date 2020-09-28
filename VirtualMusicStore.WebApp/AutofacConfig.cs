namespace VirtualMusicStore.WebApp
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using System.Web.Mvc;
    using VirtualMusicStore.WebApp.Service;
    using VirtualMusicStore.WebApp.Service.Interface;
    public class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            // Register all controllers in the Mvc Application assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            // Registration Service Layer Service
            builder.RegisterType<MusicService>().As<IMusicService>();

            // Registration filter
            builder.RegisterFilterProvider();

            var container = builder.Build();

            // Setting Dependency Injection Parser
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}