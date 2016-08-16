using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBServices.Interfaces
{
    public interface IDBUserService
    {
        Guid GetAccountIDByCredentials(string emailAddress, string password);

        void SaveToken(Token token);

        bool CheckIfTokenIsValid(string tokenValue);

        bool ChangePassword(string userName, string password, string newPassword);
    }
}
