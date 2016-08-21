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
        public ApiAuthenticationFilter() {
        }

        public ApiAuthenticationFilter(bool isActive): base(isActive) { }

        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var userService = actionContext.ControllerContext.Configuration
                               .DependencyResolver.GetService(typeof(IUserService)) as IUserService;
            Guid accountId = userService.Authenticate(username, password);
            if (accountId != null)
            {
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                    basicAuthenticationIdentity.AccountId = accountId;
                return true;
            }
            return false;
        }
    }
}