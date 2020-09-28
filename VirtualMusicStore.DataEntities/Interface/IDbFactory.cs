using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMusicStore.DataEntities.Interface
{
    public interface IDbFactory : IDisposable
    {
        StoreDbContext Init();
    }
}
