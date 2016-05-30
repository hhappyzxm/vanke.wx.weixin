using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;

namespace Vanke.WX.Weixin.Service
{
    public class DinnerPlaceService : GenericService<IDataContext, DinnerPlace, DinnerPlaceModel>, IDinnerPlaceService
    {
        public DinnerPlaceService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<DinnerPlace, DinnerPlaceModel>> ModelSelector()
        {
            return p => new DinnerPlaceModel
            {
                ID = p.ID,
                Place = p.Place,
                Status = p.Status
            };
        }

        protected override void ConvertToEntity(DinnerPlaceModel model, ref DinnerPlace targetEntity)
        {
            targetEntity.ID = (long)model.ID;
            targetEntity.Place = model.Place;
            targetEntity.Status = model.Status;
        }

        public override async Task<DinnerPlaceModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<DinnerPlace>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<DinnerPlaceModel>> GetAllAsync()
        {
            return await
                UnitOfWork.Set<DinnerPlace>()
                    .Where(p => p.Status == DinnerPlaceStatus.Active)
                    .Select(ModelSelector())
                    .ToListAsync();
        }

        protected override async Task InsertEntityAsync(DinnerPlace entity)
        {
            await CheckPlaceExist(entity);

            entity.Status = DinnerPlaceStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        public override async Task UpdateEntityAsync(DinnerPlace entity)
        {
            await CheckPlaceExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        public override async Task RemoveAsync(object key)
        {
            var entity = UnitOfWork.Set<DinnerPlace>().Find(key);
            entity.Status = DinnerPlaceStatus.Removed;

            await UpdateEntityAsync(entity);
        }

        private async Task CheckPlaceExist(DinnerPlace entity)
        {
            if (await UnitOfWork.Set<DinnerPlace>().AnyAsync(p => p.Place.Equals(entity.Place) && p.ID != entity.ID))
            {
                throw new BusinessException("宴请地点已经存在");
            }
        }
    }
}
