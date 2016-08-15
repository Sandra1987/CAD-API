using DataServices.IServices;
using DataServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CAD_API.ActionFilters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string token = "Token";
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            IUserService userService = new UserService();

            if (filterContext.Request.Headers.Contains(token))
            {
                var tokenValue = filterContext.Request.Headers.GetValues(token).First();

                if (!userService.ValidateToken(tokenValue))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                    filterContext.Response = responseMessage;
                }
            }
            else {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}