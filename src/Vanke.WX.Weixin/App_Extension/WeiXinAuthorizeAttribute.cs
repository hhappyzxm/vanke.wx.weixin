using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Service.Interface;

namespace Vanke.WX.Weixin.App_Extension
{
    public class WeixinAuthorizeAttribute : AuthorizeAttribute
    {
        public const string WeixinAppId = "wx2e963727cc5c5c76";
        public const string WeixinAppSecret = "ca8c529cdeb6e6aa5b21c9ac2c737308";

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            var weixinCode = httpContext.Request.QueryString["Code"];

            if (string.IsNullOrEmpty(weixinCode))
            {
                IPrincipal user = httpContext.User;
                if (!user.Identity.IsAuthenticated)
                {
                    var url =
                        string.Format(
                            @"https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect",
                            WeixinAppId,
                            HttpUtility.UrlEncode(httpContext.Request.Url.ToString(), System.Text.Encoding.UTF8));

                    httpContext.Response.Redirect(url);

                    return false;
                }
            }
            else
            {
                var client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.UTF8;

                var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", 
                    WeixinAppId, 
                    WeixinAppSecret, 
                    weixinCode);

                var responseData = client.DownloadString(url);
                var serializer = new JavaScriptSerializer();
                var responseObj = serializer.Deserialize<Dictionary<string, string>>(responseData);

                string errMsg;
                if (responseObj.TryGetValue("errmsg", out errMsg))
                {
                    throw new Exception(errMsg);
                }

                string weixinOpenId;
                if (!responseObj.TryGetValue("openid", out weixinOpenId))
                {
                    throw new Exception("Can not found open id of weixin");
                }

                var staffService = IoC.Container.GetInstance<IStaffService>();
                var staff = staffService.GetByOpenID(weixinOpenId);
                if (staff != null)
                {
                    return true;
                }
                else
                {
                    httpContext.Response.Redirect(string.Format("/weixin/login?openid={0}", weixinOpenId));
                }
            }

            return false;
        }
    }
}