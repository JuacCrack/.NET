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
        private readonly ContactController _controller; //ALMACENAMOS LA INSTANCIA DE CLASE ContactController en la variable _controller
        private readonly Mock<IContactRepository> _repository; //UTILIZAMOS MOCK PARA SIMULAR LA INTERFAZ IContactRepository
        private List<Contact> _contacts; //ALMACENAMOS EL MODELO Contact EN LA VARIABLE _contacts

        [TestInitialize]
        public void Setup() //UTILIZAMOS LA VARIABLE _contacts PARA CREAR UNA NUEVA LISTA Contact QUE CONTIENE 2 CONTACTOS
        {
            _contacts = new List<Contact>(){
            new Contact { ContactId = 1, fullname = "Matias", company = "Samsung", profile = "Backend", image = "mati.jpg", email = "mati@gmail.com", birthdate = "1998/12/31", phonew = "82818882812", phonep = "9012929019", address = "Evergreen 124", CityFK = 1 },
            new Contact { ContactId = 2, fullname = "Messi", company = "Lg", profile = "Frontend", image = "messi.jpg", email = "messi@gmail.com", birthdate = "1980/04/12", phonew = "29019291292", phonep = "9291290290", address = "Dreyer 2221", CityFK = 2 }};

        }
        public APIControllerTest()
        {
            _repository = new Mock<IContactRepository>(); //CREAMOS UN OBJETO DE TIPO MOCK PARA SIMULAR LA INTERFAZ IContactRepository
            _controller = new ContactController(_repository.Object); //A LA VARIABLE _controller LE PASAMOS EL PARAMETRO _repository.Object COMO OBJETO DE CONSTRUCTOR
        }

        [TestMethod]
        public async Task Get_ShouldReturnAllContacts()
        {
            // Arrange
            _repository.Setup(repo => repo.GetAll()).ReturnsAsync(_contacts); // se establece que cuando se llama al método GetAll en el objeto _repository, debe devolver una lista de contactos llamada _contacts.

            // Act
            var result = await _controller.Get(); //se llama a la acción Get en el objeto _controller y se almacena el resultado en una variable llamada "result".

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult)); 
            var okResult = (OkObjectResult)result.Result;
            var returnedContacts = (List<Contact>)okResult.Value; //se comprueba si el resultado de la acción es una instancia de OkObjectResult 
            Assert.IsNotNull(returnedContacts); // Se verifica también que el objeto devuelto no sea nulo 
            Assert.AreEqual(2, returnedContacts.Count);// si el valor devuelto es una lista de contactos con 2 elementos

        }


        [TestMethod]
        public async Task Delete_ShouldDeleteContactAndReturnOkResult()
        {
            // Arrange
            int existingId = 1; //se establece un id existente para un contacto existente y se crea una instancia de "existingContact" a partir de ese id
            Contact existingContact = _contacts.First(c => c.ContactId == existingId);
            _repository.Setup(repo => repo.Get(existingId)).ReturnsAsync(existingContact); // Luego, se establece la llamada al método "Get" en el objeto "repository" para que devuelva el contacto existente.

            // Act
            var result = await _controller.Delete(existingId); // se ejecuta el método "Delete" en el objeto "controller" y se guarda el resultado en la variable "result"

            // Assert
            _repository.Verify(repo => repo.Delete(existingId), Times.Once()); // se verifica que el método "Delete" se haya llamado una vez en el objeto "repository"
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            var returnedContact = (Contact)okResult.Value; //se verifica que el resultado sea un objeto "OkObjectResult"
            Assert.IsNotNull(returnedContact); // Se verifica también que el objeto devuelto no sea nulo 
            Assert.AreEqual(existingContact, returnedContact); //comprueba que la variable "returnedContact" es igual a "existingContact"
        }

        [TestMethod]
        public async Task Get_ShouldReturnContactById()
        {
            // Arrange
            int id = 1; // se establece una variable "id" con un valor de 1
            Contact existingContact = _contacts.First(c => c.ContactId == id); // se busca un contacto existente en la lista de contactos con un ContactId igual a 1
            _repository.Setup(repo => repo.Get(id)).ReturnsAsync(existingContact); //Se utiliza repositorio simulado para establecer un comportamiento cuando se llame al método "Get" del repositorio con una ID 

            // Act
            var result = await _controller.Get(id); //se llama al método "Get" del controlador de contactos con una ID específica y se guarda el resultado en una variable "result"

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult)); //se verifica que el tipo de resultado sea de tipo "OkObjectResult" 
            var okResult = (OkObjectResult)result.Result;
            var returnedContact = (Contact)okResult.Value; //se verifica que el valor devuelto sea un objeto de tipo Contacto
            Assert.IsNotNull(returnedContact); // Se verifica también que el objeto devuelto no sea nulo 
            Assert.AreEqual(existingContact, returnedContact); // Se verifica que sea igual al contacto existente que se espera
        }

        [TestMethod]
        public async Task GetShuffle_ShouldReturnRandomContact()
        {
            // Arrange
            int count = _contacts.Count(); //se está utilizando el método "Count()" para obtener el número de elementos en la lista
            _repository.Setup(repo => repo.GetAll()).ReturnsAsync(_contacts); // se configura el repositorio para que devuelva una lista de contactos (_contacts)

            // Act
            var result = await _controller.GetShuffle(); //se almacena en la variable result el resultado de GetShuffle que fue utilizado del controlador

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result; //asegurarse de que el resultado sea un OkObjectResult
            var returnedContacts = (List<Contact>)okResult.Value; // Se realiza una conversión explícita de la propiedad Value de okResult a una Lista de Contact
            Assert.IsNotNull(returnedContacts); //que el valor devuelto dentro de este sea una lista no nula de contactos
            Assert.AreEqual(1, returnedContacts.Count); //La lista de contactos devuelta contenga 1 contacto
            Assert.IsTrue(returnedContacts.First().ContactId >= 1 && returnedContacts.First().ContactId <= count); // se verifica si ID del primer contacto en la lista está dentro del rango de 1 a la cantidad total de contactos
        }


        [TestMethod]
        public async Task UpdateContact_ShouldUpdateContactAndReturnOkResult()
        {
            // Arrange
            int existingId = 1; //Se establece una Id preexistente
            ContactDto request = new ContactDto //Se crea un nuevo modelo ContactDto
            {
                fullname = "Matias",
                company = "Samsung",
                profile = "Backend",
                image = "mati.jpg",
                email = "mati@gmail.com",
                birthdate = "1998/12/31",
                phonew = "82818882812",
                phonep = "9012929019",
                address = "Evergreen 124",
                CityFK = 1
            };

            Contact existingContact = _contacts.First(c => c.ContactId == existingId); //se almacena en la variable existingContact el resultado de la busqueda de la Id anterior
            _repository.Setup(repo => repo.Get(existingId)).ReturnsAsync(existingContact); //cuando se llame al método "Get" con el argumento "existingId", se debe retornar el valor "existingContact"

            // Act
            var result = await _controller.UpdateContact(existingId, request); //se utiliza el controlador y se ejecuta UpdateContact

            // Assert
            _repository.Verify(repo => repo.UpdateContact(existingId, request), Times.Once()); //Verifica que la función de actualización se haya ejecutado una vez 
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult)); 
            var okResult = (OkObjectResult)result.Result; //Se verifica que el resultado sea del tipo correcto (OkObjectResult)
            var returnedContact = (Contact)okResult.Value; //se verifica que el contacto actualizado tenga los valores correctos para cada uno de sus atributos
            Assert.IsNotNull(returnedContact); //Contacto no nulo
            Assert.AreEqual(existingContact, returnedContact); //Compara cada uno de los valores con los que va a actualizar
            Assert.AreEqual(request.fullname, returnedContact.fullname);
            Assert.AreEqual(request.company, returnedContact.company);
            Assert.AreEqual(request.profile, returnedContact.profile);
            Assert.AreEqual(request.image, returnedContact.image);
            Assert.AreEqual(request.email, returnedContact.email);
            Assert.AreEqual(request.birthdate, returnedContact.birthdate);
            Assert.AreEqual(request.phonew, returnedContact.phonew);
            Assert.AreEqual(request.phonep, returnedContact.phonep);
            Assert.AreEqual(request.address, returnedContact.address);
            Assert.AreEqual(request.CityFK, returnedContact.CityFK);
        }

        [TestMethod]
        public async Task GetEmail_ShouldReturnContactsByEmail()
        {
            // Arrange
            string email = "mati@gmail.com"; //se establece un valor de correo electrónico para la búsqueda 
            List<Contact> expectedContacts = _contacts.Where(c => c.email == email).ToList(); // se define una lista de contactos esperados que tienen el mismo correo electrónico
            _repository.Setup(repo => repo.GetEmail(email)).ReturnsAsync(expectedContacts); //se configura el repositorio para que devuelva esta lista de contactos esperados cuando se llama al método GetEmail con el correo electrónico 

            // Act
            var result = await _controller.GetEmail(email); // se almacena en la variable result el resultado de GetEmail con la busqueda de el email recibido

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result; // se verifica si el resultado es un tipo de resultado "OkObjectResult"
            var returnedContacts = (List<Contact>)okResult.Value; //se extrae el valor de resultado
            Assert.IsNotNull(returnedContacts); // se verifica si no es nulo 
            CollectionAssert.AreEqual(expectedContacts, returnedContacts); //se verifica si es igual a la lista de contactos esperados
        }

        [TestMethod]
        public async Task AddContact_ShouldAddContact()
        {
            // Arrange
            ContactDto request = new ContactDto //crea un nuevo modelo ContactDto
            {
                fullname = "John Doe",
                company = "Acme Inc.",
                profile = "Developer",
                image = "johndoe.jpg",
                email = "johndoe@acme.com",
                birthdate = "1985/01/01",
                phonew = "5551234567",
                phonep = "5552345678",
                address = "123 Main St.",
                CityFK = 1
            };

            // Act
            var result = await _controller.AddContact(request); //se llama al método "AddContact" en el controlador y se guarda el resultado en una variable "result"

            // Assert
            _repository.Verify(repo => repo.AddContact(It.Is<ContactDto>(c => // se verifica si se llamó correctamente al método "AddContact" en el repositorio
                c.fullname == request.fullname &&
                c.company == request.company &&
                c.profile == request.profile &&
                c.image == request.image &&
                c.email == request.email &&
                c.birthdate == request.birthdate &&
                c.phonew == request.phonew &&
                c.phonep == request.phonep &&
                c.address == request.address &&
                c.CityFK == request.CityFK
            )), Times.Once());
            Assert.IsInstanceOfType(result.Result, typeof(OkResult)); // se verifica que el resultado de "AddContact" sea un "OkResult"
        }

    }
}