﻿using System;
using System.IO;
using System.Web.Routing;

namespace Vanke.WX.Weixin
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}