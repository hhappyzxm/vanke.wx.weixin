using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EZ.Framework;
using Vanke.WX.Weixin.Common;

namespace Vanke.WX.Weixin.Data.Entity
{
    public partial class Topic : IEntity
    {
        public Topic()
        {
            TopicReplies = new HashSet<TopicReply>();
        }

        public long ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostOn { get; set; }

        public long PostBy { get; set; }

        public TopicStatus Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopicReply> TopicReplies { get; set; }
    }
}
