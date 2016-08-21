using CAD_API.Filters;
using DataServices.IServices;
using DataServices.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CAD_API.Controllers
{
    [ApiAuthenticationFilter]
    [RoutePrefix("login")]
    public class AuthenticationController : ApiController
    {
        IUserService userService;

        public AuthenticationController(IUserService userService){
            this.userService = userService;
        }


        [Route("")]
        [HttpPost]
        public HttpResponseMessage Login() {
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated) {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var accountId = basicAuthenticationIdentity.AccountId;
                    return GetAuthToken(accountId);
                }
            }
            return null;
        }
        

        private HttpResponseMessage GetAuthToken(Guid accountId){
            TokenModel token = userService.GenerateToken(accountId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.Token);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry" );
            return response;

        }
    }

    }

