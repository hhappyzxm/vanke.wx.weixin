using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace EZ.Framework.Integration.WebApi
{
    public class IdentityUser
    {
        public object Id { get; set; }
        public string UserName { get; set; }
        public IList<string> Roles { get; set; }

        public Dictionary<string, string> UserData { get; set; }


        public ClaimsIdentity GenerateUserIdentity(string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                
            };

            if (!string.IsNullOrEmpty(UserName))
            {
                claims.Add(new Claim(ClaimTypes.Name, UserName));
            }

            if (Roles != null && Roles.Count > 0)
            {
                claims.Add(new Claim(ClaimTypes.Role, string.Join(",", Roles)));
            }

            if (UserData != null && UserData.Count > 0)
            {
                claims.Add(new Claim(ClaimTypes.UserData, Newtonsoft.Json.JsonConvert.SerializeObject(UserData)));
            }

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            return new ClaimsIdentity(claims, authenticationType);
        }
    }
}
