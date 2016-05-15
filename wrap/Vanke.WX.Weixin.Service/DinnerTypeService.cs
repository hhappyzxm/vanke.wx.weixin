using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Data.Repository.Interface;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.Service
{
    public class DinnerTypeService : CRUDService<IDataContext, IDinnerTypeRepository, DinnerType>, IDinnerTypeService
    {
        public DinnerTypeService(IDataContext dataContext, IDinnerTypeRepository repository) : base(dataContext, repository)
        {
        }

        protected override async Task BeforeInsertAsync(DinnerType entity)
        {
            await CheckTypeExist(entity);

            entity.Status = DinnerTypeStatus.Active;
            entity.CreatedOn = DateTime.Now;
        }

        protected override async Task BeforeUpdateAsync(DinnerType entity)
        {
            await CheckTypeExist(entity);

            entity.UpdatedOn = DateTime.Now;
        }

        public override async Task<IEnumerable<DinnerType>> GetAllAsync()
        {
            return await Repository.ToListAsync(p => p.Status == DinnerTypeStatus.Active);
        }

        private async Task CheckTypeExist(DinnerType entity)
        {
            if (await Repository.AnyAsync(p => p.Type.Equals(entity.Type) && p.ID != entity.ID))
            {
                throw new BusinessException("宴请类型已经存在");
            }
        }
    }
}
