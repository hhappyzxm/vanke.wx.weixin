using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EZ.Framework.Integration.WebApi;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service
{
    public class SettingService : GenericService<IDataContext, Setting, SettingModel>, ISettingService
    {
        public SettingService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<Setting, SettingModel>> ModelSelector()
        {
            return p => new SettingModel
            {
                ID = p.ID,
                IdleAssetDescription = p.IdleAssetDescription
            };
        }

        protected override void ConvertToEntity(SettingModel model, ref Setting targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.IdleAssetDescription = model.IdleAssetDescription;
        }

        public override async Task<SettingModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<Setting>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<SettingModel>> GetAllAsync()
        {
            return await
                UnitOfWork.Set<Setting>()
                    .Select(ModelSelector())
                    .ToListAsync();
        }
    }
}
