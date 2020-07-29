using MallMembership.BusinessLayer;
using MallMembership.Entities;
using MallMemebership.DataLayer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MallMembership.UnitTests
{
    [TestFixture]
   public class BusinessLayerTests
    {
        Mock<IAddressDL> mock;
        AddressInfo addressInfo;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IAddressDL>();

            addressInfo = new AddressInfo
            {
                Country = "India",
                State = "Karnataka",
                City = "Bangalore",
                Street = "ChurchStreet"
            };
        }

        [Test]
        public void AddAddress()
        {
            mock.Setup(x => x.AddAddressDA(addressInfo)).Returns(true);
            IAddressBusiness addressBusiness = new AddressBusiness(mock.Object);
            bool result = addressBusiness.AddAddressBL(addressInfo);
            Assert.IsTrue(result);
        }

        [Test]
        public void GetEmployeeById()
        {
            int id = 1;
            mock.Setup(x => x.GetAddressByIdDA(id)).Returns(addressInfo);
            IAddressBusiness addressBusiness = new AddressBusiness(mock.Object);

            AddressInfo address = addressBusiness.GetAddressByIdBL(id);

            Assert.IsNotNull(address);
            Assert.AreEqual(addressInfo.Country, address.Country);
            Assert.AreEqual(addressInfo.State, address.State);
            Assert.AreEqual(addressInfo.City, address.City);
            Assert.AreEqual(addressInfo.Street, address.Street);

        }
    }
}
