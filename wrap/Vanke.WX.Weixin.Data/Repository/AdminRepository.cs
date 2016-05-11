﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework.Core;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;

namespace Vanke.WX.Weixin.Data.Repository
{
    public class AdminRepository : EFRepository<Admin>, IAdminRepository
    {
        public AdminRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
