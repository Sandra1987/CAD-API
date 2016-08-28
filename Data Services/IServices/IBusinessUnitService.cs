using Model;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.IServices
{
    public interface IBusinessUnitService
    {
        Guid SaveBusinessUnit(BusinessUnitRegistrationModel businessUnitData);

        BusinessUnitRegistrationModel GetBusinessUnitData(Guid businessUnitID);

        void SavePromotion(PromotionModel promotion);

        BusinessUnitProfileDataModel GetBusinessUnitProfileData(Guid businessUnitID);

        List<PromotionModel> GetPromotionsForCity(String cityName, RetrievalOptions option);

        List<AvailablePlacesModel> GetCountriesWithCities();
    }
}
