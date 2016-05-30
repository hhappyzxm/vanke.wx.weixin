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
    public class ItemStoragePlaceService : GenericService<IDataContext, ItemStoragePlace, ItemStoragePlaceModel>, IItemStoragePlaceService
    {
        public ItemStoragePlaceService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<ItemStoragePlace, ItemStoragePlaceModel>> ModelSelector()
        {
            return p => new ItemStoragePlaceModel
            {
                ID = p.ID,
                AreaID = p.AreaID,
                Place = p.Place,
                Status = p.Status
            };
        }

        protected override void ConvertToEntity(ItemStoragePlaceModel model, ref ItemStoragePlace targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.AreaID = model.AreaID;
            targetEntity.Place = model.Place;
            targetEntity.Status = model.Status;
        }

        public override async Task<ItemStoragePlaceModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<ItemStoragePlace>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<ItemStoragePlaceModel>> GetAllAsync()
        {
            return await (from p in UnitOfWork.Set<ItemStoragePlace>()
                join a in UnitOfWork.Set<ItemStorageArea>() on p.AreaID equals a.ID
                where p.Status == ItemStoragePlaceStatus.Active && a.Status == ItemStorageAreaStatus.Active
                select new ItemStoragePlaceModel
                {
                    ID = p.ID,
                    Area = a.Area,
                    Place = p.Place,
                    Status = p.Status
                }).ToListAsync();
        }

        protected override async Task InsertEntityAsync(ItemStoragePlace entity)
        {
            await CheckItemExist(entity);

            entity.Status = ItemStoragePlaceStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        public override async Task UpdateEntityAsync(ItemStoragePlace entity)
        {
            await CheckItemExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        public override async Task RemoveAsync(object key)
        {
            var entity = UnitOfWork.Set<ItemStoragePlace>().Find(key);
            entity.Status = ItemStoragePlaceStatus.Removed;

            await UpdateEntityAsync(entity);
        }

        private async Task CheckItemExist(ItemStoragePlace entity)
        {
            if (await UnitOfWork.Set<ItemStoragePlace>().AnyAsync(p => p.Place.Equals(entity.Place) && p.ID != entity.ID))
            {
                throw new BusinessException("存放地点已经存在");
            }
        }
    }
}
