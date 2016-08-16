using Model;
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
    }
}
