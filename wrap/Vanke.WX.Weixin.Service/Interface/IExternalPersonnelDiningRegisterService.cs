using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EZ.Framework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Service.Interface
{
    public interface IExternalPersonnelDiningRegisterService : ICRUDAsyncService<ExternalPersonnelDiningRegisterHistory>
    {
    }
}
