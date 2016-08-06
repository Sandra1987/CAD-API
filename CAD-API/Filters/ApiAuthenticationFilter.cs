using DataServices.IServices;
using DataServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace CAD_API.Filters
{
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        public ApiAuthenticationFilter() { }

        public ApiAuthenticationFilter(bool isActive): base(isActive) { }

        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            IUserService userService = new UserService();
            Guid userId = userService.Authenticate(username, password);
            if (userId != null)
            {
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                    basicAuthenticationIdentity.UserId = userId;
                return true;
            }
            return false;
        }
    }
}