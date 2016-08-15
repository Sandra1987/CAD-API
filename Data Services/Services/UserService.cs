using DataAccess;
using DataAccess.DBServices;
using DataAccess.DBServices.Interfaces;
using DataServices.IServices;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Services
{
    public class UserService : IUserService
    {
        private IDBUserService service;

        public UserService() {
            service = new DBUserService(); 
        }

        public Guid Authenticate(string email, string password)
        {
            return service.GetAccountIDByCredentials(email, password);
        }

        public TokenModel GenerateToken(Guid accountID) {
            TokenModel token = new TokenModel()
            {
                AccountID = accountID,
                Token = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]))
            };

            service.SaveToken(new Token()
            {
                AccountRefID = token.AccountID,
                ExpirationDate = token.ExpirationDate,
                TokenID = Guid.NewGuid(),
                TokenValue = token.Token
            });

            return token;
        }

        public bool ValidateToken(string tokenValue) {
            return service.CheckIfTokenIsValid(tokenValue);
        }
    }
}
