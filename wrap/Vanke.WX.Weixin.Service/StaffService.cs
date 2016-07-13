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
    public class StaffService : GenericService<IDataContext, Staff, StaffModel>, IStaffService
    {
        public StaffService(IDataContext dataContext) : base(dataContext)
        {
        }

        protected override Expression<Func<Staff, StaffModel>> ModelSelector()
        {
            return p => new StaffModel
            {
                ID = p.ID,
                RealName = p.RealName,
                LoginName = p.LoginName,
                Password = p.Password,
                Email = p.Email,
                Status = p.Status
            };
        }

        protected override void ConvertToEntity(StaffModel model, ref Staff targetEntity)
        {
            targetEntity.ID = model.ID;
            targetEntity.LoginName = model.LoginName;
            targetEntity.Password = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(model.Password));
            targetEntity.RealName = model.RealName;
            targetEntity.Email = model.Email;
            targetEntity.Status = model.Status;

            if (targetEntity.ID > 0)
            {
                UnitOfWork.Set<StaffRole>().RemoveRange(targetEntity.StaffRoles);
            }

            foreach (var role in model.Roles)
            {
                targetEntity.StaffRoles.Add(new StaffRole
                {
                    Role = role,
                });
            }
        }

        public override async Task<StaffModel> GetByKeyAsync(object key)
        {
            var staff =  await UnitOfWork.Set<Staff>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.ID == (long)key);
            staff.Roles =
               await UnitOfWork.Set<StaffRole>()
                    .Where(p => p.StaffID == staff.ID)
                    .Select(p => p.Role)
                    .ToListAsync();

            return staff;
        }

        public async Task<StaffModel> GetByLoginNameAsync(string loginName)
        {
            return await UnitOfWork.Set<Staff>().Select(ModelSelector()).SingleOrDefaultAsync(p => p.LoginName.Equals(loginName));
        }

        public override async Task<IEnumerable<StaffModel>> GetAllAsync()
        {
            return await GetAllAsync(string.Empty);
        }

        public async Task<IEnumerable<StaffModel>> GetAllAsync(string realName)
        {
            var query = from s in UnitOfWork.Set<Staff>()
                where s.Status == StaffStatus.Active
                select new StaffModel
                {
                    ID = s.ID,
                    RealName = s.RealName,
                    LoginName = s.LoginName,
                    Email = s.Email,
                    Status = s.Status,
                };

            if (!string.IsNullOrEmpty(realName))
            {
                query = query.Where(p => p.RealName.Contains(realName));
            }

            var staffs = await query.ToListAsync();

            var staffIds = staffs.Select(p => p.ID).ToList();

            var roles =
                await UnitOfWork.Set<StaffRole>()
                    .Where(p => staffIds.Contains(p.StaffID))
                    .Select(p => new { StaffID = p.StaffID, Role = p.Role }).ToListAsync();

            staffs.ForEach(p => p.Roles = roles.Where(t => t.StaffID == p.ID).Select(t => t.Role).ToList());

            return staffs;
        }

        public Staff GetByOpenID(string openId)
        {
            return UnitOfWork.Set<Staff>().SingleOrDefault(p => p.WeixinOpenID == openId);
        }

        public void BindOpenId(int staffId, string openId)
        {
            var staff = UnitOfWork.Set<Staff>().Find(staffId);
            staff.WeixinOpenID = openId;
            staff.OpenIDBindTime = DateTime.Now;

            UnitOfWork.SaveChanges();
        }

        protected override async Task InsertEntityAsync(Staff entity)
        {
            await CheckItemExist(entity);

            entity.Status = StaffStatus.Active;
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.InsertEntityAsync(entity);
        }

        protected override async Task UpdateEntityAsync(Staff entity)
        {
            await CheckItemExist(entity);

            entity.UpdatedOn = DateTime.Now;
            entity.UpdatedBy = (long)AccountManager.Instance.CurrentLoginUser.ID;

            await base.UpdateEntityAsync(entity);

            AccountManager.Instance.Remove(AccountManager.Instance.CurrentLoginUser.ID.ToString());
        }

        protected override Task RemoveEntityAsync(Staff entity)
        {
            entity.Status = StaffStatus.Removed;

            return base.UpdateEntityAsync(entity);
        }

        private async Task CheckItemExist(Staff entity)
        {
            if (await UnitOfWork.Set<Staff>().AnyAsync(p => p.LoginName.Equals(entity.LoginName) && p.ID != entity.ID))
            {
                throw new BusinessException("用户名已经存在");
            }
        }
    }
}
