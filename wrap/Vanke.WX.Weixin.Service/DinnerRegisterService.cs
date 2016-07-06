using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EZ.Framework.Integration.WebApi;
using EZ.Framework.NoRepository.EntityFramework;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;
using EZ.Framework;

namespace Vanke.WX.Weixin.Service
{
    public class DinnerRegisterService : Service<IDataContext>, IDinnerRegisterService
    {
        public DinnerRegisterService(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task CancelAsync(long key)
        {
            var entity = await UnitOfWork.Set<DinnerRegisterHistory>().FindAsync(key);

            entity.Status = DinnerRegisterStatus.Cancelled;
            entity.CancelledBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
            entity.CancelledOn = DateTime.Now;

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task ReadAsync(long key)
        {
            var entity = await UnitOfWork.Set<DinnerRegisterHistory>().FindAsync(key);

            entity.IsRead = true;
            entity.ReadBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
            entity.ReadOn = DateTime.Now;

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<DinnerRegisterModel>> GetAllAsync(
            DinnerRegisterStatus[] filterStatuses = null, long? registerBy = null)
        {
            var query = from registerHistory in UnitOfWork.Set<DinnerRegisterHistory>()
                        join staff in UnitOfWork.Set<Staff>() on registerHistory.StaffID equals staff.ID
                        join t1 in UnitOfWork.Set<Staff>() on registerHistory.ReadBy equals t1.ID into tt1
                        from readStaff in tt1.DefaultIfEmpty()
                        join t2 in UnitOfWork.Set<Staff>() on registerHistory.CancelledBy equals t2.ID into tt2
                        from cancelStaff in tt2.DefaultIfEmpty()
                        join type in UnitOfWork.Set<DinnerType>() on registerHistory.TypeID equals type.ID
                        join place in UnitOfWork.Set<DinnerPlace>() on registerHistory.PlaceID equals place.ID
                        select new
                        {
                            RegisterHistory = registerHistory,
                            Staff = staff,
                            Type = type,
                            Place = place,
                            ReadStaff = readStaff,
                            CancelStaff = cancelStaff
                        };

            if (filterStatuses == null)
            {
                query = query.Where(p => p.RegisterHistory.Status != DinnerRegisterStatus.Removed);
            }
            else
            {
                foreach (var status in filterStatuses)
                {
                    query = query.Where(p => p.RegisterHistory.Status == status);
                }
            }

            if (registerBy.HasValue)
            {
                query = query.Where(p => p.RegisterHistory.StaffID == registerBy);
            }

            return await query.Select(p => new DinnerRegisterModel
            {
                ID = p.RegisterHistory.ID,
                Staff = p.Staff.RealName,
                Department = p.RegisterHistory.Department,
                Type = p.Type.Type,
                Place = p.Place.Place,
                DinnerDate = p.RegisterHistory.DinnerDate,
                PeopleCount = p.RegisterHistory.PeopleCount,
                Comment = p.RegisterHistory.Comment,
                Status = p.RegisterHistory.Status,
                RegisteredOn = p.RegisterHistory.RegisteredOn,
                CancelledOn = p.RegisterHistory.CancelledOn,
                CancelledStaff = p.CancelStaff == null ? string.Empty : p.CancelStaff.RealName,
                IsRead = p.RegisterHistory.IsRead,
                ReadTime = p.RegisterHistory.ReadOn,
                ReadStaff = p.ReadStaff == null ? string.Empty : p.ReadStaff.RealName
            }).OrderByDescending(p => p.RegisteredOn).ToListAsync();
        }

        public async Task<IEnumerable<DinnerRegisterModel>> GetOwnHistoriesAsync()
        {
            return await this.GetAllAsync(null, (long)AccountManager.Instance.CurrentLoginUser.ID);
        }

        public async Task InsertAsync(DinnerRegisterModel model)
        {
            var entity = new DinnerRegisterHistory
            {
                StaffID = (long)AccountManager.Instance.CurrentLoginUser.ID,
                PeopleCount = model.PeopleCount,
                DinnerDate = model.DinnerDate,
                Department = model.Department,
                TypeID = model.TypeID,
                PlaceID = model.PlaceID,
                Comment = model.Comment,
                RegisteredOn = DateTime.Now,
                Status = DinnerRegisterStatus.Active
            };

            UnitOfWork.Set<DinnerRegisterHistory>().Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
