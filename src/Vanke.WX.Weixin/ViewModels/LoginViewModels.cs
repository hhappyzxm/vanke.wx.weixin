using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EZ.Framework;
using Vanke.WX.Weixin.Data.Entity;

namespace Vanke.WX.Weixin.ViewModels
{
    public class LoginViewModel : IViewModel
    {
        public string LoginName { get; set; }

        public string Password { get; set; }
    }
}