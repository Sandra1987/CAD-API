using DataAccess;
using DataAccess.DBServices;
using DataAccess.DBServices.Interfaces;
using DataServices.IServices;
using Model;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        IDBBusinessUnitService service;

        public BusinessUnitService(IDBBusinessUnitService service) {
            this.service = service;
        }

        public Guid SaveBusinessUnit(BusinessUnitRegistrationModel businessUnitData) {
            return service.RegisterBusinessUnit(businessUnitData);
        }

        public BusinessUnitRegistrationModel GetBusinessUnitData(Guid businessUnitID) {
            BusinessUnit businessUnitData = service.GetBusinessUnitInformation(businessUnitID);

            if (businessUnitData == null)
                return null;

            BusinessUnitRegistrationModel result = new BusinessUnitRegistrationModel()
            {
                BusinessUnitID = businessUnitData.BusinessUnitID,
                DateOfFoundation = (DateTime)businessUnitData.DateOfFoundation,
                FullDescription = businessUnitData.Description,
                Name = businessUnitData.Name,
                ShortDescription = businessUnitData.ShortDescription
            };

            AddressModel address = new AddressModel()
            {
                City = businessUnitData.Location.City,
                Country = businessUnitData.Location.Country.Name,
                CountryISOCode = businessUnitData.Location.Country.ISOCode,
                StreetName = businessUnitData.Location.Street,
                StreetNumber = businessUnitData.Location.StreetNumber,
                ZIP = businessUnitData.Location.ZIP
            };

            result.Address = address;

            return result;

        }

        public void SavePromotion(PromotionModel promotion)
        {
            service.SavePromotion(promotion);
        }

        public BusinessUnitProfileDataModel GetBusinessUnitProfileData(Guid businessUnitID){

            var businessUnitData = service.GetBusinessUnitInformation(businessUnitID);
            var promotionsData = service.GetPromotionsForBusinessUnit(businessUnitID);

            BusinessUnitRegistrationModel businessUnit = new BusinessUnitRegistrationModel()
            {
                BusinessUnitID = businessUnitData.BusinessUnitID,
                DateOfFoundation = (DateTime)businessUnitData.DateOfFoundation,
                FullDescription = businessUnitData.Description,
                Name = businessUnitData.Name,
                ShortDescription = businessUnitData.ShortDescription
            };

            List<PromotionModel> promotions = new List<PromotionModel>();
            foreach(var promotion in promotionsData)
            {
                PromotionModel prom = new PromotionModel(){
                    //Provjeriti da li su ovdje uopste ukljuceni businessUniti, iako mislim da mi ovdje i ne treba
                    //BusinessUnitRefID = item.BusinessUnits.Single().BusinessUnitID,
                    PromotionID = promotion.PromotionID,
                    Desctiption = promotion.Description,
                    Title = promotion.Title,
                    StartTime = promotion.StartDateAndTime,
                    EndTime = promotion.EndDateAndTime
                };

                promotions.Add(prom);
            }

            BusinessUnitProfileDataModel result = new BusinessUnitProfileDataModel()
            {
                BusinessUnit = businessUnit,
                Promotions = promotions
            };

            return result;
        }

        public List<PromotionModel> GetPromotionsForCity(String cityName, RetrievalOptions option) {
            List<PromotionModel> result = new List<PromotionModel>();

            var promotions = service.GetPromotionsForCity(cityName, option);
            foreach (var promotion in promotions)
            {
                PromotionModel prom = new PromotionModel()
                {
                    PromotionID = promotion.Item1.PromotionID,
                    Desctiption = promotion.Item1.Description,
                    Title = promotion.Item1.Title,
                    StartTime = promotion.Item1.StartDateAndTime,
                    EndTime = promotion.Item1.EndDateAndTime,
                    BusinessUnitRefID = promotion.Item2,
                    BusinessUnitName = promotion.Item3
                };

                result.Add(prom);
            }

            return result;
        }

        public List<AvailablePlacesModel> GetCountriesWithCities() {
            List<AvailablePlacesModel> result = new List<AvailablePlacesModel>();

            var countriesWithCities = service.GetCountriesWithCities();

            foreach (var country in countriesWithCities)
            {
                AvailablePlacesModel place = new AvailablePlacesModel();

                place.CountryIsoCode = country.ISOCode;
                place.CountryName = country.Name;

                place.CityNames = country.Locations.Select(x => x.City).Distinct().ToList();

                result.Add(place);
            }

            return result;
        }
    }
}
