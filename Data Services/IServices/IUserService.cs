using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.IServices
{
    public interface IUserService
    {
        Guid Authenticate(string email, string password);

        TokenModel GenerateToken(Guid accountID);

        bool ValidateToken(string tokenValue);

        //bool Kill(string tokenId);

        //bool DeleteByUserId(Guid userId);

        bool ChangePassword(AccountModel account);
    }
}
