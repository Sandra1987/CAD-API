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
    [RoutePrefix("profile")]
    public class BusinessUnitController : ApiController
    {
        IBusinessUnitService service;

        public BusinessUnitController() {
            service = new BusinessUnitService();
        }

        [Route("register")]
        [HttpPut]
        //provjeriti da li koristiti FromUri ili FromParamBody, ili ne treba ni jedno
        public IHttpActionResult RegisterBusinessUnit(BusinessUnitRegistrationModel registrationData) {

            if (ModelState.IsValid)
            {
                var businessUnitID = service.SaveBusinessUnit(registrationData);

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
    }
}
