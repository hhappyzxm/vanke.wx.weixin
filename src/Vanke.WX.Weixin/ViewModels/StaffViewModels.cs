using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vanke.WX.Weixin.ViewModels
{
    public class StaffEditViewModel
    {
        public long ID { get; set; }

        public string RealName { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}