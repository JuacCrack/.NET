using Api.Controllers;
using Core.DTO;
using Core.PersonRepository.Implementations;
using Core.PersonRepository.Interfaces;
using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            new Contact { ContactId = 1, fullname = "Matias", company = "Samsung", profile = "Backend", image = "mati.jpg", email = "mati@gmail.com", birthdate = "1998/12/31", phonew = "82818882812", phonep = "9012929019", address = "Evergreen 124", CityFK = 1 },
            new Contact { ContactId = 2, fullname = "Messi", company = "Lg", profile = "Frontend", image = "messi.jpg", email = "messi@gmail.com", birthdate = "1980/04/12", phonew = "29019291292", phonep = "9291290290", address = "Dreyer 2221", CityFK = 2 }};

   
        }
        public APIControllerTest()
        {
            _repository = new Mock<IContactRepository>();
            _controller = new ContactController(_repository.Object);
        }

        [TestMethod]
        public async Task Get_ShouldReturnAllContacts()
        {
            // Arrange
            _repository.Setup(repo => repo.GetAll()).ReturnsAsync(_contacts);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            var returnedContacts = (List<Contact>)okResult.Value;
            Assert.IsNotNull(returnedContacts);
            Assert.AreEqual(2, returnedContacts.Count);

        }

    }
}