using Api.Controllers;
using Core.DTO;
using Core.PersonRepository.Interfaces;
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
        private readonly ContactController _controller;//INYECTAMOS EL CONTACTCONTROLLER DEL PROYECTO API
        private readonly Mock<IContactRepository> _repository;//INYECTAMOS EL REPOSITORIO CON MOCK DEL PROYECTO CORE
        private List<Contact> _contacts;//INYECTAMOS EL MODELO DE CONTACT DEL PROYECTO DATA

        [TestInitialize]
        public void Setup()
        {
            _contacts = new List<Contact>(){//UTILIZAMOS LA INYECCION DEL MODELO CONTACT PARA SIMULAR UNA LISTA DE 2 CONTACTOS
                new Contact { ContactId = Guid.Parse("67c8b72f-75e9-4e2e-9edc-79a9219f08c3"), fullname = "Matias", company = "Samsung", profile = "Backend", image = "mati.jpg", email = "mati@gmail.com", birthdate = "1998/12/31", phonew = "82818882812", phonep = "9012929019", address = "Evergreen 124", CityFK = 1 },
                new Contact { ContactId = Guid.Parse("67c8b72f-75e9-4e2e-9edc-78a9219f08c4"), fullname = "Messi", company = "Lg", profile = "Frontend", image = "messi.jpg", email = "messi@gmail.com", birthdate = "1980/04/12", phonew = "29019291292", phonep = "9291290290", address = "Dreyer 2221", CityFK = 2 }};
        }

        public APIControllerTest()
        {
            _repository = new Mock<IContactRepository>();//UTILIZAMOS MOCK PARA SIMULAR UTILIZAR EL REPOSITORIO 
            _controller = new ContactController(_repository.Object);//EL CONTROLADOR UTILIZA EL REPOSITORIO SIMULADO POR MOCK
        }

        [TestMethod]
        public async Task UpdateContact_ShouldUpdatePersonInRepository()
        {
            // Arrange
            var request = new ContactDto
            {
                fullname = "John Doe",
                company = "ACME Inc.",
                profile = "Software Engineer",
                image = "image.jpg",
                email = "johndoe@example.com",
                birthdate = "1980/01/01",
                phonew = "555-555-5555",
                phonep = "555-555-5555",
                address = "123 Main St.",
                CityFK = 1
            };
            var id = Guid.Parse("67c8b72f-75e9-4e2e-9edc-79a9219f08c3");
            _repository.Setup(repo => repo.UpdateContact(id, request)).Returns(Task.CompletedTask);

            // Act
            await _controller.UpdateContact(id, request);

            // Assert
            _repository.Verify(repo => repo.UpdateContact(id, request), Times.Once());
        }


        [TestMethod]
        public async Task AddContact_ShouldAddPersonToRepository()
        {
            // Arrange
            var request = new ContactDto
            {
                fullname = "John Doe",
                company = "ACME Inc.",
                profile = "Software Engineer",
                image = "image.jpg",
                email = "johndoe@example.com",
                birthdate = "1980/01/01",
                phonew = "555-555-5555",
                phonep = "555-555-5555",
                address = "123 Main St.",
                CityFK = 1
            };
            _repository.Setup(repo => repo.AddContact(request)).Returns(Task.CompletedTask);

            // Act
            await _controller.AddContact(request);

            // Assert
            _repository.Verify(repo => repo.AddContact(request), Times.Once());
        }

        [TestMethod]
        public async Task DeleteContact_ShouldRemoveContactFromRepository()
        {
            // Arrange
            var id = Guid.Parse("67c8b72f-75e9-4e2e-9edc-79a9219f08c3");
            _repository.Setup(repo => repo.Delete(id)).Returns(Task.CompletedTask);

            // Act
            await _controller.Delete(id);

            // Assert
            _repository.Verify(repo => repo.Delete(id), Times.Once());
        }

        [TestMethod]
        public async Task Get_ShouldReturnContactWithGivenId()
        {
            // Arrange
            var id = Guid.Parse("67c8b72f-75e9-4e2e-9edc-79a9219f08c3");
            var expected = _contacts.SingleOrDefault(c => c.ContactId == id);
            _repository.Setup(repo => repo.Get(id)).ReturnsAsync(expected);

            // Act
            var result = await _controller.Get(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }


    }
}
