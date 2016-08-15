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
        public void TestMethod()
        {
            var model = new BusinessUnitRegistrationModel();
            model.DateOfFoundation = DateTime.Now;
            model.FullDescription = "First business unit test.";
            model.Name = "BU Sandra";
            model.Password = "1234";
            model.ShortDescription = "Testing.";
            model.UserName = "sandra_bosic@hotmail.com";
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
            service.SaveBusinessUnit(model);

        }
    }
}
