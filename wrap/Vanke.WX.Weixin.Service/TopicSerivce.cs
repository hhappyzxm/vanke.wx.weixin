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
    public class TopicSerivce : Service<IDataContext>, ITopicService
    {
        public TopicSerivce(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task InsertAsync(TopicModel model)
        {
            var newEntity = new Topic
            {
                Title = model.Title,
                Content = model.Content,
                PostBy = (long)AccountManager.Instance.CurrentLoginUser.ID,
                PostOn = DateTime.Now,
                Status = TopicStatus.Active
            };

            UnitOfWork.Set<Topic>().Add(newEntity);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(object key)
        {
            var entity = UnitOfWork.Set<Topic>().Find(key);
            entity.Status = TopicStatus.Removed;

            await UnitOfWork.SaveChangesAsync();
        }
    }
}
