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
        private readonly ContactController _controller;//INYECTAMOS EL CONTACTCONTROLLER DEL PROYECTO API
        private readonly Mock<IContactRepository> _repository;//INYECTAMOS EL REPOSITORIO CON MOCK DEL PROYECTO CORE
        private List<Contact> _contacts;//INYECTAMOS EL MODELO DE CONTACT DEL PROYECTO DATA

        [TestInitialize]
        public void Setup()
        {
            _contacts = new List<Contact>(){//UTILIZAMOS LA INYECCION DEL MODELO CONTACT PARA SIMULAR UNA LISTA DE 2 CONTACTOS
                new Contact { ContactId = Guid.Parse("67c8b72f-75e9-4e2e-9edc-79a9219f08c3"), name = "Matias", company = "Samsung", profile = "Backend", image = "mati.jpg", email = "mati@gmail.com", birthdate = "1998/12/31", phonew = "82818882812", phonep = "9012929019", address = "Evergreen 124", CityFK = 1 },
                new Contact { ContactId = Guid.Parse("67c8b72f-75e9-4e2e-9edc-78a9219f08c3"), name = "Messi", company = "Lg", profile = "Frontend", image = "messi.jpg", email = "messi@gmail.com", birthdate = "1980/04/12", phonew = "29019291292", phonep = "9291290290", address = "Dreyer 2221", CityFK = 2 }};
        }

        public APIControllerTest()
        {
            _repository = new Mock<IContactRepository>();//UTILIZAMOS MOCK PARA SIMULAR UTILIZAR EL REPOSITORIO 
            _controller = new ContactController(_repository.Object);//EL CONTROLADOR UTILIZA EL REPOSITORIO SIMULADO POR MOCK
        }


        [TestMethod]//TRAER TODOS LOS CONTACTOS
        public void Get_ShouldReturnAllPersons()
        {
            // Arrange
            _repository.Setup(repo => repo.GetAll()).Returns(_contacts);//configura el repositorio para que devuelva una lista predeterminada de contactos al llamar al método "GetAll"

            // Act
            var result = _controller.Get().Result;// llama al método "Get" en el controlador "ContactController" y se almacena el resultado en la variable "result".

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));//se realizan varias afirmaciones para verificar que el resultado es el esperado 
            var returnedPersons = (result as OkObjectResult).Value as List<Contact>;//Se verifica que "result" es una instancia de "OkObjectResult", que el valor devuelto es una lista de contactos 
            Assert.IsNotNull(returnedPersons);
            Assert.AreEqual(2, returnedPersons.Count);//la cantidad de contactos es 2.

        }

        [TestMethod]
        public void Get_ShouldReturnContactById()
        {
            // Arrange
            Guid id = Guid.Parse("67c8b72f-75e9-4e2e-9edc-79a9219f08c3");
            _repository.Setup(repo => repo.Get(id)).Returns(_contacts[0]);//se da la id para el contacto que se desea obtener y se configura el repositorio mock para que retorne el contacto específico

            // Act
            var result = _controller.Get(id).Result;//se invoca el método Get del controlador con la id especificada y se almacena el resultado.

            // Assert
            var okResult = result as OkObjectResult;// verifica que la operación se ha completado correctamente 
            Assert.IsNotNull(okResult);//se retorna un objeto
            var returnedContact = okResult.Value as Contact;
            Assert.IsNotNull(returnedContact);//se convierte el valor devuelto en un objeto Contact
            Assert.AreEqual(id, returnedContact.ContactId);//se comprueban sus propiedades para asegurarse de que sean las esperadas
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
