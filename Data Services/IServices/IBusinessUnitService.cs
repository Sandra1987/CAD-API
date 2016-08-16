using Model;
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
    }
}
