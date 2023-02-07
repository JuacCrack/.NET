using Api.Controllers;
using Core.PersonRepository.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APITest.Api.Controller
{
    [TestClass]
    public class APIControllerTest
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactRepository> _repository;
        private List<Contact> _contacts;

        [TestInitialize]
        public void Setup()
        {
            _contacts = new List<Contact>(){
                new Contact { ContactId = Guid.Parse("67c8b72f-75e9-4e2e-9edc-79a9219f08c3"), name = "Matias", company = "Samsung", profile = "Backend", image = "mati.jpg", email = "mati@gmail.com", birthdate = "1998/12/31", phonew = "82818882812", phonep = "9012929019", address = "Evergreen 124", CityFK = 1 },
                new Contact { ContactId = Guid.Parse("67c8b72f-75e9-4e2e-9edc-78a9219f08c3"), name = "Messi", company = "Lg", profile = "Frontend", image = "messi.jpg", email = "messi@gmail.com", birthdate = "1980/04/12", phonew = "29019291292", phonep = "9291290290", address = "Dreyer 2221", CityFK = 2 }};
        }

        public APIControllerTest()
        {
            _repository = new Mock<IContactRepository>();
            _controller = new ContactController(_repository.Object);
        }


        [TestMethod]
        public void Get_ShouldReturnAllPersons()
        {
            // Arrange
            _repository.Setup(repo => repo.GetAll()).Returns(_contacts);

            // Act
            var result = _controller.Get().Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var returnedPersons = (result as OkObjectResult).Value as List<Contact>;
            Assert.IsNotNull(returnedPersons);
            Assert.AreEqual(2, returnedPersons.Count);

        }

        [TestMethod]
        public void Get_ShouldReturnContactById()
        {
            // Arrange
            Guid id = Guid.Parse("67c8b72f-75e9-4e2e-9edc-79a9219f08c3");
            _repository.Setup(repo => repo.Get(id)).Returns(_contacts[0]);

            // Act
            var result = _controller.Get(id).Result;

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var returnedContact = okResult.Value as Contact;
            Assert.IsNotNull(returnedContact);
            Assert.AreEqual(id, returnedContact.ContactId);
            Assert.AreEqual("Matias", returnedContact.name);
            Assert.AreEqual("Samsung", returnedContact.company);
            Assert.AreEqual("Backend", returnedContact.profile);
            Assert.AreEqual("mati.jpg", returnedContact.image);
            Assert.AreEqual("mati@gmail.com", returnedContact.email);
            Assert.AreEqual("1998/12/31", returnedContact.birthdate);
            Assert.AreEqual("82818882812", returnedContact.phonew);
            Assert.AreEqual("9012929019", returnedContact.phonep);
            Assert.AreEqual("Evergreen 124", returnedContact.address);
            Assert.AreEqual(1, returnedContact.CityFK);
        }

    }
}
