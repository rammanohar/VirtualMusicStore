namespace VirtualMusicStore.DataEntitiyInterface
{
    using System;
    using VirtualMusicStore.DataEntities;

    public interface IDbFactory : IDisposable
    {
        StoreDbContext Init();
    }
}
