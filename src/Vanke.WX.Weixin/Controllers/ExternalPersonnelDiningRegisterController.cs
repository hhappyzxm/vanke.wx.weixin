using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Controllers
{
    public class ExternalPersonnelDiningRegisterController : GenericApiController
    {
        private readonly IExternalPersonnelDiningRegisterService _externalPersonnelDiningRegisterService = IoC.Container.GetInstance<IExternalPersonnelDiningRegisterService>();

        
    }
}
