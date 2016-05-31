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
    public class IdleAssetService : GenericService<IDataContext, IdleAsset, IdleAssetModel>, IIdleAssetService
    {
        public IdleAssetService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<IdleAsset, IdleAssetModel>> ModelSelector()
        {
            return p => new IdleAssetModel
            {
                ID = p.ID,
                AreaID = p.AreaID,
                PlaceID = p.PlaceID,
                ItemID =  p.ItemID,
                Quantity = p.Quantity,
                Unit = p.Unit,
                ManagerStaffID = p.ManagerStaffID,
                Comment = p.Comment,
                Status = p.Status
            };
        }

        protected override void ConvertToEntity(IdleAssetModel model, ref IdleAsset targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.AreaID = model.AreaID;
            targetEntity.PlaceID = model.PlaceID;
            targetEntity.ItemID = model.ItemID;
            targetEntity.Quantity = model.Quantity;
            targetEntity.Unit = model.Unit;
            targetEntity.ManagerStaffID = model.ManagerStaffID;
            targetEntity.Comment = model.Comment;
            targetEntity.Status = model.Status;
        }

        public override async Task<IdleAssetModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<IdleAsset>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<IdleAssetModel>> GetAllAsync()
        {
            return await (from ia in UnitOfWork.Set<IdleAsset>()
                join a in UnitOfWork.Set<ItemStorageArea>() on ia.AreaID equals a.ID
                join p in UnitOfWork.Set<ItemStoragePlace>() on ia.PlaceID equals p.ID
                join i in UnitOfWork.Set<Item>() on ia.ItemID equals i.ID
                join s in UnitOfWork.Set<Staff>() on ia.ManagerStaffID equals s.ID
                where ia.Status == IdleAssetStatus.Active
                select new IdleAssetModel
                {
                    ID = ia.ID,
                    Area = a.Area,
                    Place = p.Place,
                    Item = i.Name,
                    Quantity = ia.Quantity,
                    Unit = ia.Unit,
                    ManagerStaff = s.RealName,
                    Comment = ia.Comment,
                    Status = ia.Status
                }).ToListAsync();
        }

        protected override async Task InsertEntityAsync(IdleAsset entity)
        {
            entity.Status = IdleAssetStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        protected override async Task UpdateEntityAsync(IdleAsset entity)
        {
            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        protected override Task RemoveEntityAsync(IdleAsset entity)
        {
            entity.Status = IdleAssetStatus.Removed;

            return base.UpdateEntityAsync(entity);
        }
    }
}
