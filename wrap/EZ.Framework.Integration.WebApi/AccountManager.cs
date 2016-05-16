using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EZ.Framework.Integration.WebApi
{
    public class AccountManager
    {
        private static Lazy<AccountManager> _instance;
        private readonly object _lock = new object();
        private readonly Dictionary<string, ICurrentLogin> _users;

        private AccountManager(Func<string, string, IdentityUser> findFunc, Func<object, ICurrentLogin> getUserInfoFunc)
        {
            _users = new Dictionary<string, ICurrentLogin>();
            _find = findFunc;
            _getUserInfo = getUserInfoFunc;
        }

        public static AccountManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Please call method AccountManager.Register first.");
                }
                return _instance.Value;
            }
        }

        public static void Register(Func<string, string, IdentityUser> findFunc, Func<object, ICurrentLogin> getUserInfoUserFunc)
        {
            if (_instance != null)
            {
                throw new Exception("Instance has been generated. Please call method AccountManager.Instance for using");
            }

            _instance = new Lazy<AccountManager>(() => new AccountManager(findFunc, getUserInfoUserFunc));
        }

        private readonly Func<string, string, IdentityUser> _find;

        private readonly Func<object, ICurrentLogin> _getUserInfo;

        private IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        public ClaimsIdentity CreateIdentity(string userName, string password)
        {
            var identityUser = _find(userName, password);
            if (identityUser != null)
            {
                return CreateIdentity(identityUser);
            }

            return null;
        }

        private ClaimsIdentity CreateIdentity(IdentityUser identityUser, string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
        {
            return identityUser.GenerateUserIdentity(authenticationType);
        }

        public ICurrentLogin SignIn(string userName, string password, bool isPersistent = false)
        {
            ICurrentLogin currentLogin = null;

            var identityUser = _find(userName, password);
            if (identityUser != null)
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = CreateIdentity(identityUser);
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);

                currentLogin = _getUserInfo(identityUser.Id);
                Add(identityUser.Id.ToString(), currentLogin);
            }

            return currentLogin;
        }

        public void SignOut()
        {
            var identity = HttpContext.Current.User.Identity;
            AuthenticationManager.SignOut();
            Remove(identity.GetUserId());
        }

        private void Add(string key, ICurrentLogin user)
        {
            lock (_lock)
            {
                if (_users.ContainsKey(key))
                {
                    _users[key] = user;
                }
                else
                {
                    _users.Add(key, user);
                }
            }
        }

        private void Remove(string key)
        {
            // If cookie timeout or be cleared, can not get useid from identity.
            if (string.IsNullOrEmpty(key))
            {
                return;
            }

            lock (_lock)
            {
                if (_users.ContainsKey(key))
                {
                    _users.Remove(key);
                }
            }
        }

        public ICurrentLogin CurrentLoginUser
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.User == null)
                {
                    return null;
                }

                var identity = HttpContext.Current.User.Identity;
                if (!identity.IsAuthenticated)
                {
                    return null;
                }

                var userId = identity.GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return null;
                }

                ICurrentLogin user;

                lock (_lock)
                {
                    if (!_users.TryGetValue(userId, out user))
                    {
                        user = _getUserInfo(long.Parse(userId));
                        if (user != null)
                        {
                            Add(userId, user);
                        }
                        return user;
                    }
                }

                return user;
            }
        }

        public bool TryGetLoginUser(string userId, out ICurrentLogin user)
        {
            lock (_lock)
            {
                return _users.TryGetValue(userId, out user);
            }
        }
    }
}