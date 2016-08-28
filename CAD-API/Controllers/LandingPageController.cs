using DataServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CAD_API.Controllers
{
    [RoutePrefix("api/landingPage")]
    public class LandingPageController : ApiController
    {
        IBusinessUnitService businessUnitService;

        public LandingPageController(IBusinessUnitService businessUnitService)
        {
            this.businessUnitService = businessUnitService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAvailableLocations()
        {
            //NAPRAVITI METOD KOJI VRACA DOSTUPNE LOKACIJE <Country, List<Cities>>
            var availableLocations = businessUnitService.GetCountriesWithCities();
            return Ok(availableLocations);
        }

        [HttpGet]
        [Route("getAvailablePromotionsForLocation")]
        public IHttpActionResult GetAvailablePromotionsForLocation(String cityName)
        {
            var result = businessUnitService.GetPromotionsForCity(cityName, Model.Helper.RetrievalOptions.GetFollowingOnes);
            return Ok(result);
        }
    }
}
