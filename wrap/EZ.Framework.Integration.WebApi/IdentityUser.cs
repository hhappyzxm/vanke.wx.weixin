using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace EZ.Framework.Integration.WebApi
{
    public class IdentityUser
    {
        public object Id { get; set; }
        public string UserName { get; set; }

        private IList<string> _roles;
        public IList<string> Roles
        {
            get { return _roles ?? (_roles = new List<string>()); }
            set { _roles = value; }
        }


        public ClaimsIdentity GenerateUserIdentity(string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Name, UserName),
                new Claim(ClaimTypes.Role, Roles == null ? "" : string.Join(",", Roles))
            };

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            return new ClaimsIdentity(claims, authenticationType);
        }
    }
}
