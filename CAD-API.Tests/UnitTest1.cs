using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAD_API.Controllers;
using Model;
using DataServices.Services;

namespace CAD_API.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCompanyRegistration()
        {
            var model = new BusinessUnitRegistrationModel();
            model.DateOfFoundation = DateTime.Now;
            model.FullDescription = "First business unit test.";
            model.Name = "BU Sandra";
            model.Account.Password = "1234";
            model.ShortDescription = "Testing.";
            model.Account.Email = "sandra_bosic@hotmail.com";
            var address = new AddressModel()
            {
                City = "Brcko",
                Country = "Bosnia",
                CountryISOCode = "bih",
                StreetName = "Jevrejska",
                StreetNumber = "5",
                ZIP = "333222"
            };
            model.Address = address;

            var service = new BusinessUnitService();
            //service.SaveBusinessUnit(model);

        }

        [TestMethod]
        public void TestChangePassword()
        {
            var service = new UserService();
            service.ChangePassword(new AccountModel() { NewPassword = "1111", Email = "sandra_bosic@hotmail.com", Password = "asd" });
        }

        [TestMethod]
        public void TestGetBUData() {
            var service = new BusinessUnitService();
            var result = service.GetBusinessUnitData(Guid.Parse("b121f950-7f97-4aad-b99a-5d970bb948ec"));
        }
    }
}
