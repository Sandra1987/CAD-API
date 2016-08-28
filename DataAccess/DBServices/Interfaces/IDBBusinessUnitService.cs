﻿using Model;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBServices.Interfaces
{
    public interface IDBBusinessUnitService
    {
        Guid RegisterBusinessUnit(BusinessUnitRegistrationModel businessUnitData);
        BusinessUnit GetBusinessUnitInformation(Guid businessUnitID);
        void ChangeBusinessUnitInformation(BusinessUnitRegistrationModel businessUnitData);
        void SavePromotion(PromotionModel promotionData);
        List<Promotion> GetPromotionsForBusinessUnit(Guid businessUnitID);
        List<Tuple<Promotion, Guid, String>> GetPromotionsForCity(String cityName, RetrievalOptions option);
        List<Country> GetCountriesWithCities();
    }
}
