using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EZ.Framework.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data;
using Vanke.WX.Weixin.Service;
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
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (base.AuthorizeCore(httpContext))
            {
                return true;
            }

            try
            {
                var weixinCode = httpContext.Request.QueryString["Code"];
                if (string.IsNullOrEmpty(weixinCode))
                {
                    var url =
                             $@"https://open.weixin.qq.com/connect/oauth2/authorize?appid={WeixinAppId}&redirect_uri={HttpUtility.UrlEncode(httpContext.Request.Url.ToString(), System.Text.Encoding.UTF8)}&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";

                    httpContext.Response.Redirect(url);
                }
                else
                {
                    var client = new System.Net.WebClient { Encoding = System.Text.Encoding.UTF8 };

                    var url =
                        $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={WeixinAppId}&secret={WeixinAppSecret}&code={weixinCode}&grant_type=authorization_code";

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

                    var staffService = new StaffService(new DataContext("SQLConnection"));
                    var staff = staffService.GetByOpenID(weixinOpenId);
                    if (staff != null && DateTime.Now < staff.OpenIDBindTime.Value.AddMonths(1))
                    {
                        var identityUser = new IdentityUser() {Id = staff.ID};
                        var identity = identityUser.GenerateUserIdentity();
                        httpContext.User = new ClaimsPrincipal(identity);

                        var authManager = HttpContext.Current.GetOwinContext().Authentication;
                        authManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                        authManager.SignIn(new AuthenticationProperties (), identity);

                        return true;
                    }
                    else
                    {
                        var iz = httpContext.Request.RawUrl.IndexOf('?');
                        var redirectUri =
                            HttpUtility.UrlEncode(
                                iz == -1
                                    ? httpContext.Request.RawUrl
                                    : httpContext.Request.RawUrl.Substring(0, httpContext.Request.RawUrl.IndexOf('?')),
                                System.Text.Encoding.UTF8);
                        httpContext.Response.Redirect($"/weixin/login#?openid={weixinOpenId}&redirect_uri={redirectUri}");
                    }
                }
            }
            catch (Exception ex)
            {
                httpContext.Response.Write(ex.Message);
            }
            

            return false;
        }
    }
}