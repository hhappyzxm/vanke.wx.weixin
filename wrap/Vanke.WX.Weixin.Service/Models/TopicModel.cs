using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework;

namespace Vanke.WX.Weixin.Service.Models
{
    public class TopicModel : IModel
    {
        public long ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PostOn { get; set; }

        public long PostBy { get; set; }
    }
}
