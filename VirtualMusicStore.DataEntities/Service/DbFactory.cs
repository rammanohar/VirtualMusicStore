using System;
namespace VirtualMusicStore.DataEntities.Service
{
    using VirtualMusicStore.DataEntities.Interface;
    public class DbFactory :  IDbFactory 
    {
        StoreDbContext dbContext;

        public StoreDbContext Init()
        {
            return dbContext ?? (dbContext = new StoreDbContext());
        }

        void IDisposable.Dispose()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
        
    }
}
