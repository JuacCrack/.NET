using ContactsAPI.Controllers;
using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace ContactsAPI.Tests
{
    public class ContactsControllerTests
    {
        [Fact]
        public async void GetContacts_ReturnsOkResult_WithContactsInDb()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DbContextAPI>()
                .UseInMemoryDatabase(databaseName: "GetContacts_ReturnsOkResult_WithContactsInDb")
                .Options;
            using (var context = new DbContextAPI(options))
            {
                // Act
                var contact = new Contact
                {
                    ContactId = 1,
                    name = "Juan",
                    company = "Samsung",
                    profile = "Backend",
                    image = "juan.jpg",
                    email = "juan@gmail.com",
                    birthdate = "1990/10/05",
                    phonew = "388293823823",
                    phonep = "2983892983",
                    address = "Evergreen 1234"
                };
                await context.Contacts.AddAsync(contact);
                await context.SaveChangesAsync();
                var controller = new ContactsController(context);
                var result = await controller.GetContacts() as OkObjectResult;

                // Assert
                Assert.IsType<OkObjectResult>(result);
                var contacts = result.Value as List<Contact>;
                Assert.Equal(1, contacts.Count());
                Assert.Equal("Juan", contacts[0].name);
                Assert.Equal("Samsung", contacts[0].company);
                Assert.Equal("Backend", contacts[0].profile);
                Assert.Equal("juan.jpg", contacts[0].image);
                Assert.Equal("juan@gmail.com", contacts[0].email);
                Assert.Equal("1990/10/05", contacts[0].birthdate);
                Assert.Equal("388293823823", contacts[0].phonew);
                Assert.Equal("2983892983", contacts[0].phonep);
                Assert.Equal("Evergreen 1234", contacts[0].address);

            }
        }
    }
}



