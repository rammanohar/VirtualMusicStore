using System;
using VirtualMusicStore.DataEntities;
using VirtualMusicStore.DataEntitiyInterface;

namespace VirtualMusicStore.DataEntitiyRepository
{
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
