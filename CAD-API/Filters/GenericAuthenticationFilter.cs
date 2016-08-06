using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CAD_API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class GenericAuthenticationFilter : AuthorizationFilterAttribute
    {
        private readonly bool isActive;

        public GenericAuthenticationFilter() { }

        public GenericAuthenticationFilter(bool isActive) {
            this.isActive = isActive;
        }

        public override void OnAuthorization(HttpActionContext filterContext) {
            if (!isActive) return;

            BasicAuthenticationIdentity identity = FetchAuthHeader(filterContext);
            if (identity == null) {
                ChallengeAuthRequest(filterContext);
                return;
            }

            Thread.CurrentPrincipal = new GenericPrincipal(identity, null);

            if (!OnAuthorizeUser(identity.Name, identity.Password, filterContext))
            {
                ChallengeAuthRequest(filterContext);
                return;
            }

            base.OnAuthorization(filterContext);
        }

        protected virtual bool OnAuthorizeUser(string user, string pass, HttpActionContext filterContext)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return false;
            return true;
        }

        //This method extracts username and password from httpActionContext and retrieve it.
        protected virtual BasicAuthenticationIdentity FetchAuthHeader(HttpActionContext filterContext)
        {
            string authHeaderValue = null;
            var authRequest = filterContext.Request.Headers.Authorization;

            if (string.IsNullOrEmpty(authRequest.Parameter))
            {
                return null;
            }

            if (authRequest != null && !String.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic") {
                authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authRequest.Parameter));
            }

            var credentials = authHeaderValue.Split(':');
            return credentials.Length < 2 ? null : new BasicAuthenticationIdentity(credentials[0], credentials[1]);
        }

        public static void ChallengeAuthRequest(HttpActionContext filterContext) {
            var dnsHost = filterContext.Request.RequestUri.DnsSafeHost;
            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            filterContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", dnsHost));
        }
    }
}