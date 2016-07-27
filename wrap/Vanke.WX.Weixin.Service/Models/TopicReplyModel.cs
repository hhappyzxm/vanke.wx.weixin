using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZ.Framework;

namespace Vanke.WX.Weixin.Service.Models
{
    public class TopicReplyModel : IModel
    {
        public long TopicID { get; set; }

        public string Content { get; set; }

        public DateTime ReplyOn { get; set; }

        public long ReplyBy { get; set; }
    }
}
