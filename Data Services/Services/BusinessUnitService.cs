using DataAccess;
using DataAccess.DBServices;
using DataAccess.DBServices.Interfaces;
using DataServices.IServices;
using Model;
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

        public BusinessUnitService() {
            service = new DBBusinessUnitService();
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
    }
}
