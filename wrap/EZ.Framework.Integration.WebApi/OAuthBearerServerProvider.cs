using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace EZ.Framework.Integration.WebApi
{
    public class OAuthBearerServerProvider : OAuthAuthorizationServerProvider
    {
        private bool _allowAllClient;

        public OAuthBearerServerProvider(bool allowAllClient = true)
        {
            _allowAllClient = allowAllClient;
        }

        /// <summary>
        /// 通过传递标准的clientId和clientSecret来获取Token.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            ////获取客户端传递的标准的clientId和clientSecret
            //string clientId, clientSecret;
            //context.TryGetBasicCredentials(out clientId, out clientSecret);
            ////这里可以加入验证clientId和clientSecret是否合法的代码
            //if (clientId == _publicIdentity && clientSecret == "123")
            //{
            //    context.Validated();
            //}
            //return Task.FromResult(0);

            if (_allowAllClient)
            {
                context.Validated();
            }

            return Task.FromResult(0);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

            return Task.FromResult(0);
        }

        /// <summary>
        /// 当Tocken通过验证以后,以系统的一个_publicIdentity登录进入系统.
        /// 登录成功以后,所有Authorize的WebApi都可以继续访问.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        //{
        //    context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

        //    using (AuthRepository _repo = new AuthRepository())
        //    {
        //        IdentityUser user = await _repo.FindUser(context.UserName, context.Password);

        //        if (user == null)
        //        {
        //            context.SetError("invalid_grant", "The user name or password is incorrect.");
        //            return;
        //        }
        //    }

        //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
        //    identity.AddClaim(new Claim("sub", context.UserName));
        //    identity.AddClaim(new Claim("role", "user"));

        //    context.Validated(identity);

        //    //var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
        //    //oAuthIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, context.ClientId)); //User id
        //    //oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.sc)); //User name
        //    //var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
        //    //context.Validated(ticket);
        //    //return base.GrantClientCredentials(context);
        //}
    }
}