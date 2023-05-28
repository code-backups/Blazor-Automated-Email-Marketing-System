using Blazor_Automated_Email_Marketing_System.Models;
using NUnit.Framework;

namespace Blazor_Automated_Email_Marketing_System.Tests
{
    public class StagingTests
    {
        // Simple integration test verifies interaction between different components of Subscriber model - first name and last name to create a correct full name.

        [Test]
        [Category("Integration")]
        public void Models_Integration()
        {
            // Arrange - Create an instance of the Subscriber model
            var subscriber = new Subscriber
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "johndoe@notadomain.com",
                TagIdsCsv = "1,2,3"
            };
            // Act - Combine firstname, lastname of Subscriber - create full name
            var fullName = $"{subscriber.FirstName} {subscriber.LastName}";

            // Assert - Verify that the full name is equal to "John Doe"
            Assert.AreEqual("John Doe", fullName);
        }
    }
}