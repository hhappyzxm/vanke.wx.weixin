using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EZ.Framework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.ViewModels
{
    public class AdminViewModel : IViewModel
    {
        public long ID { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }
    }
}