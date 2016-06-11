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
    public class ExternalPersonnelDiningRegisterService : Service<IDataContext>, IExternalPersonnelDiningRegisterService
    {
        public ExternalPersonnelDiningRegisterService(IDataContext dataContext) : base(dataContext)
        {
        }
        
        public async Task CancelAsync(long key)
        {
            var entity = await UnitOfWork.Set<ExternalPersonnelDiningRegisterHistory>().FindAsync(key);

            entity.Status= ExternalPersonnelDiningRegisterStatus.Cancelled;
            entity.CancelledBy = (long)AccountManager.Instance.CurrentLoginUser.ID;
            entity.CancelledOn = DateTime.Now;

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExternalPersonnelDiningRegisterModel>> GetAllAsync(ExternalPersonnelDiningRegisterStatus[] filterStatuses = null)
        {
            var query = from register in UnitOfWork.Set<ExternalPersonnelDiningRegisterHistory>()
                        join staff in UnitOfWork.Set<Staff>() on register.StaffID equals staff.ID
                        select new
                        {
                            Register = register,
                            Staff = staff,
                        };

            if (filterStatuses == null)
            {
                query = query.Where(p => p.Register.Status != ExternalPersonnelDiningRegisterStatus.Removed);
            }
            else
            {
                foreach (var status in filterStatuses)
                {
                    query = query.Where(p => p.Register.Status == status);
                }
            }

            return await query.Select(p => new ExternalPersonnelDiningRegisterModel
            {
                ID = p.Register.ID,
                Staff = p.Staff.RealName,
                Status = p.Register.Status,
                CardQuantity = p.Register.CardQuantity,
                Comment = p.Register.Comment,
                RegisteredOn = p.Register.RegisteredOn,
                CancelledOn = p.Register.CancelledOn
            }).ToListAsync();
        }

        public async Task InsertAsync(ExternalPersonnelDiningRegisterModel model)
        {
            var entity = new ExternalPersonnelDiningRegisterHistory()
            {
                StaffID = model.StaffID,
                CardQuantity = model.CardQuantity,
                Comment = model.Comment,
                RegisteredOn = DateTime.Now,
                Status = ExternalPersonnelDiningRegisterStatus.Active};

            UnitOfWork.Set<ExternalPersonnelDiningRegisterHistory>().Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
