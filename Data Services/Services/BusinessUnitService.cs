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
    }
}
