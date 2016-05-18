using System;
using System.Linq;
using System.Linq.Expressions;
using EZ.Framework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.Service.Models
{
    public class ItemModel : IModel
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Item, ItemModel>> GetSelector()
        {
            return p => new ItemModel
            {
                ID = p.ID,
                Name = p.Name
            };
        }

        public ItemModel FromEntity(Item item)
        {
            ID = item.ID;
            Name = item.Name;

            return this;
        }


    }
}