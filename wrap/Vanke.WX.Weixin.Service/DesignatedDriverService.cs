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
    public class DesignatedDriverService : GenericService<IDataContext, DesignatedDriver, DesignatedDriverModel>, IDesignatedDriverService
    {
        public DesignatedDriverService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<DesignatedDriver, DesignatedDriverModel>> ModelSelector()
        {
            return p => new DesignatedDriverModel
            {
                ID = p.ID,
                DriverName = p.DriverName,
                ServiceArea = p.ServiceArea,
                BusinessRequirement = p.BusinessRequirement,
                ContactPhone = p.ContactPhone,
                PersonalRequirement = p.PersonalRequirement,
                DrivingPhone = p.DrivingPhone,
                CustomFirstColumn = p.CustomFirstColumn,
                CustomSecondColumn = p.CustomSecondColumn,
                CustomThirdColumn = p.CustomThirdColumn
            };
        }

        protected override void ConvertToEntity(DesignatedDriverModel model, ref DesignatedDriver targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.DriverName = model.DriverName;
            targetEntity.ServiceArea = model.ServiceArea;
            targetEntity.BusinessRequirement = model.BusinessRequirement;
            targetEntity.ContactPhone = model.ContactPhone;
            targetEntity.PersonalRequirement = model.PersonalRequirement;
            targetEntity.DrivingPhone = model.DrivingPhone;
            targetEntity.CustomFirstColumn = model.CustomFirstColumn;
            targetEntity.CustomSecondColumn = model.CustomSecondColumn;
            targetEntity.CustomThirdColumn = model.CustomThirdColumn;

            if (targetEntity.ID > 0)
            {
                UnitOfWork.Set<DesignatedDriverPrice>().RemoveRange(targetEntity.DesignatedDriverPrices);
            }

            foreach (var price in model.Prices)
            {
                targetEntity.DesignatedDriverPrices.Add(new DesignatedDriverPrice
                {
                    Distance = price.Distance,
                    FirstTimePeriodsPrice = price.FirstTimePeriodsPrice,
                    SecondTimePeriodsPrice = price.SecondTimePeriodsPrice
                });
            }
        }

        public override async Task<DesignatedDriverModel> GetByKeyAsync(object key)
        {
            var driver =  await UnitOfWork.Set<DesignatedDriver>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);

            driver
                .Prices = await UnitOfWork.Set<DesignatedDriverPrice>()
                .Where(p => p.DesignatedDriverID == driver.ID)
                .Select(p => new DesignatedDriverPriceModel
                {
                    Distance = p.Distance,
                    FirstTimePeriodsPrice = p.FirstTimePeriodsPrice,
                    SecondTimePeriodsPrice = p.SecondTimePeriodsPrice
                })
                .ToListAsync();

            return driver;
        }

        public override async Task<IEnumerable<DesignatedDriverModel>> GetAllAsync()
        {
            var drivers = await UnitOfWork.Set<DesignatedDriver>().Where(p=>p.Status == DesignatedDriverStatus.Active).Select(ModelSelector()).ToListAsync();

            var dirverIds = drivers.Select(p => p.ID).ToList();

            var prices =
                await UnitOfWork.Set<DesignatedDriverPrice>()
                    .Where(p => dirverIds.Contains(p.DesignatedDriverID)).ToListAsync();

            drivers.ForEach(p => p.Prices = prices.Where(t => t.DesignatedDriverID == p.ID).Select(t => new DesignatedDriverPriceModel
            {
                Distance = t.Distance,
                FirstTimePeriodsPrice = t.FirstTimePeriodsPrice,
                SecondTimePeriodsPrice = t.SecondTimePeriodsPrice
            }).ToList());

            return drivers;
        }

        protected override async Task InsertEntityAsync(DesignatedDriver entity)
        {
            await CheckItemExist(entity);

            entity.Status = DesignatedDriverStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        protected override async Task UpdateEntityAsync(DesignatedDriver entity)
        {
            await CheckItemExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);
        }

        protected override Task RemoveEntityAsync(DesignatedDriver entity)
        {
            entity.Status = DesignatedDriverStatus.Removed;

            return base.UpdateEntityAsync(entity);
        }

        private async Task CheckItemExist(DesignatedDriver entity)
        {
            if (await UnitOfWork.Set<DesignatedDriver>().AnyAsync(p => p.DriverName.Equals(entity.DriverName) && p.ID != entity.ID))
            {
                throw new BusinessException("代驾公司名字已经存在");
            }
        }
    }
}
