using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBServices.Interfaces
{
    public interface IDBUserService
    {
        Guid GetUserIDByCredentials(string emailAddress, string password);

        void SaveToken(Token token);
    }
}
