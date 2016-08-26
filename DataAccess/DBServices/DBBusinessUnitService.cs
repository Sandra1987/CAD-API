using DataAccess.DBServices.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.DBServices
{
    public class DBBusinessUnitService : IDBBusinessUnitService
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 

        public Guid RegisterBusinessUnit(BusinessUnitRegistrationModel businessUnitData) { 
            try
            {
                using (var context = new CADEntities())
                {
                    //First check if email already exists
                    var existingAccount = context.Accounts.SingleOrDefault(x => x.EmailAddress.ToLower().Equals(businessUnitData.Account.Email.ToLower()));
                    if (existingAccount != null)
                        return Guid.Empty;

                    Account account = new Account()
                    {
                        AccountID = Guid.NewGuid(),
                        EmailAddress = businessUnitData.Account.Email,
                        IsCompany = true,
                        IsPerson = false,
                        Password = Utils.HashPassword(businessUnitData.Account.Password)
                    };

                    var country = context.Countries.SingleOrDefault(x => x.ISOCode.ToLower().Equals(businessUnitData.Address.CountryISOCode.ToLower()));
                    if(country == null)
                    {
                        country = new Country()
                        {
                            CountryID = Guid.NewGuid(),
                            ISOCode = businessUnitData.Address.CountryISOCode,
                            Name = businessUnitData.Address.Country
                        };
                    }

                    var location = new Location()
                    {
                        City = businessUnitData.Address.City,
                        Letitude = businessUnitData.Address.Latitude,
                        LocationID = Guid.NewGuid(),
                        Longitude = businessUnitData.Address.Longitude,
                        Street = businessUnitData.Address.StreetName,
                        StreetNumber = businessUnitData.Address.StreetNumber,
                        ZIP = businessUnitData.Address.ZIP
                    };
                    location.Country = country;

                    BusinessUnit businessUnit = new BusinessUnit()
                    {
                        BusinessUnitID = Guid.NewGuid(),
                        DateOfFoundation = businessUnitData.DateOfFoundation,
                        Description = businessUnitData.FullDescription,
                        Name = businessUnitData.Name
                    };

                    //context.Accounts.Add(account);

                    businessUnit.Account = account;
                    businessUnit.Location = location;
                    context.BusinessUnits.Add(businessUnit);

                    context.SaveChanges();

                    return businessUnit.BusinessUnitID;
                }
            }
            catch (Exception ex) {
                //return Guid.Empty;
                logger.Error("Exception occured in RegisterBusinessUnit method.", ex);
                throw;
            }
        }

        public void ChangeBusinessUnitInformation(BusinessUnitRegistrationModel businessUnitData)
        {
            try {
                using(var context = new CADEntities()){
                    var country = context.Countries.SingleOrDefault(x => x.ISOCode.ToLower().Equals(businessUnitData.Address.CountryISOCode.ToLower()));
                    if (country == null)
                    {
                        country = new Country()
                        {
                            CountryID = Guid.NewGuid(),
                            ISOCode = businessUnitData.Address.CountryISOCode,
                            Name = businessUnitData.Address.Country
                        };
                    }

                    var businessUnit = context.BusinessUnits.Include(x => x.Location).Single(x => x.BusinessUnitID == businessUnitData.BusinessUnitID);
                    businessUnit.DateOfFoundation = businessUnitData.DateOfFoundation;
                    businessUnit.Description = businessUnitData.FullDescription;
                    businessUnit.Name = businessUnitData.Name;

                    businessUnit.Location.City = businessUnitData.Address.City;
                    businessUnit.Location.Letitude = businessUnitData.Address.Latitude;
                    businessUnit.Location.LocationID = Guid.NewGuid();
                    businessUnit.Location.Longitude = businessUnitData.Address.Longitude;
                    businessUnit.Location.Street = businessUnitData.Address.StreetName;
                    businessUnit.Location.StreetNumber = businessUnitData.Address.StreetNumber;
                    businessUnit.Location.ZIP = businessUnitData.Address.ZIP;

                    businessUnit.Location.Country = country;

                    context.SaveChanges();
                }
            } catch(Exception ex) {
                logger.Error("Exception occured in ChangeBusinessUnitInformation method.", ex);
                throw;
            }
        }

        public BusinessUnit GetBusinessUnitInformation(Guid businessUnitID) { 
            try
            {
                using (var context = new CADEntities())
                {
                    return context.BusinessUnits.Include(x => x.Location.Country).SingleOrDefault(x => x.BusinessUnitID == businessUnitID);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Exception occured in GetBusinessUnitInformation method.", ex);
                throw;
            }

        }
    }
}
