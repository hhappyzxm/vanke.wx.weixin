using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
    public class EmployeeDiscountService : GenericService<IDataContext, EmployeeDiscount, EmployeeDiscountModel>, IEmployeeDiscountService
    {
        public EmployeeDiscountService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<EmployeeDiscount, EmployeeDiscountModel>> ModelSelector()
        {
            return p => new EmployeeDiscountModel
            {
                ID = p.ID,
                Type = p.Type,
                Name = p.Name,
                ImagePath = p.ImagePath,
                Address = p.Address,
                Phone = p.Phone,
                Discount = p.Discount
            };
        }

        protected override void ConvertToEntity(EmployeeDiscountModel model, ref EmployeeDiscount targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.Type = model.Type;
            targetEntity.Name = model.Name;
            targetEntity.ImagePath = model.ImagePath;
            targetEntity.Address = model.Address;
            targetEntity.Phone = model.Phone;
            targetEntity.Discount = model.Discount;
        }

        public override async Task<EmployeeDiscountModel> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<EmployeeDiscount>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
        }

        public override async Task<IEnumerable<EmployeeDiscountModel>> GetAllAsync()
        {
            return await GetAllAsync(null);
        }

        public async Task<IEnumerable<EmployeeDiscountModel>> GetAllAsync(EmployeeDiscountType? filterType)
        {
            var query = UnitOfWork.Set<EmployeeDiscount>()
                .Where(p => p.Status == EmployeeDiscountStatus.Active);

            if (filterType.HasValue)
            {
                query = query.Where(p => p.Type == filterType.Value);
            }

            return await query.Select(ModelSelector()).ToListAsync();
        }

        protected override async Task InsertEntityAsync(EmployeeDiscount entity)
        {
            await CheckItemExist(entity);

            entity.Status = EmployeeDiscountStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        protected override async Task UpdateEntityAsync(EmployeeDiscount entity)
        {
            await CheckItemExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        protected override Task RemoveEntityAsync(EmployeeDiscount entity)
        {
            entity.Status = EmployeeDiscountStatus.Removed;

            return base.UpdateEntityAsync(entity);
        }

        private async Task CheckItemExist(EmployeeDiscount entity)
        {
            if (await UnitOfWork.Set<EmployeeDiscount>().AnyAsync(p => p.Name.Equals(entity.Name) && p.ID != entity.ID))
            {
                throw new BusinessException("名称已经存在");
            }
        }
    }
}
