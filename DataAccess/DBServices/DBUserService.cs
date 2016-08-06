using DataAccess.DBServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBServices
{
    public class DBUserService : IDBUserService
    {
        public Guid GetUserIDByCredentials(string emailAddress, string password) {
            using(var context = new CADEntities()) {
                var account = context.Accounts.Where(x => x.EmailAddress.Equals(emailAddress) && x.Password.Equals(password)).SingleOrDefault();
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
    }
}
