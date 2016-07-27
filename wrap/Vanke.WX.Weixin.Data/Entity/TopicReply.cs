using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class TopicReply : IEntity
    {
        public long ID { get; set; }

        public long TopicID { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime ReplyOn { get; set; }

        public long ReplyBy { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
