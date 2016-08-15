using DataAccess.DBServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBServices
{
    public class DBUserService : IDBUserService
    {
        public Guid GetAccountIDByCredentials(string emailAddress, string password) {
            using(var context = new CADEntities()) {
                var account = context.Accounts.Where(x => x.EmailAddress.Equals(emailAddress) && x.Password.Equals(Utils.HashPassword(password))).SingleOrDefault();
                if (account != null)
                    return account.AccountID;
            }
            return Guid.Empty;
        }

        public void SaveToken(Token token) {
            try
            {
                using (var context = new CADEntities())
                {
                    var existingToken = context.Tokens.SingleOrDefault(x => x.AccountRefID == token.AccountRefID);
                    if(existingToken != null)
                    {
                        existingToken.TokenValue = token.TokenValue;
                        existingToken.ExpirationDate = token.ExpirationDate;
                    } else {
                        context.Tokens.Add(token);
                    }

                    context.SaveChanges();

                }
            }
            catch (Exception ex) { 
                //Logovati
            }
        }

        public bool CheckIfTokenIsValid(string tokenValue) { 
            try
            {
                using (var context = new CADEntities())
                {
                    var  existingToken = context.Tokens.SingleOrDefault(x => x.TokenValue.Equals(tokenValue));
                    if (existingToken == null || existingToken.ExpirationDate < DateTime.Now)
                        return false;

                    existingToken.ExpirationDate = ((DateTime)existingToken.ExpirationDate).AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //Logovati
            }

            return true;
        }

    }
}
