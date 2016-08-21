using DataServices.IServices;
using DataServices.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CAD_API.Controllers
{
    [RoutePrefix("api/profile")]
    public class BusinessUnitController : ApiController
    {
        IBusinessUnitService businessUnitService;
        IUserService userService;

        public BusinessUnitController(IBusinessUnitService businessUnitService, IUserService userService) {
            this.businessUnitService = businessUnitService;
            this.userService = userService;
        }

        [Route("register")]
        [HttpPut]
        //provjeriti da li koristiti FromUri ili FromParamBody, ili ne treba ni jedno
        public IHttpActionResult RegisterBusinessUnit(BusinessUnitRegistrationModel registrationData) {

            if (ModelState.IsValid)
            {
                var businessUnitID = businessUnitService.SaveBusinessUnit(registrationData);

                if (businessUnitID == null || businessUnitID == Guid.Empty)
                {
                    return Unauthorized();
                }

                return Ok(businessUnitID);
            }
            else {
                return InternalServerError();
            }
        }

        [Route("changePassword")]
        [HttpPost]
        public HttpResponseMessage ChangePassword(AccountModel accountData) {
            if (!userService.ChangePassword(accountData))
                return Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Wrong email or password."));
            else
                return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("profileData")]
        //businessUnitID treba da se proslijedi u url-u kroz query string
        public IHttpActionResult GetBusinessUnitData(Guid businessUnitID)
        {
            var result = businessUnitService.GetBusinessUnitData((Guid)businessUnitID);
            return Ok(result);
        }
    }
}
