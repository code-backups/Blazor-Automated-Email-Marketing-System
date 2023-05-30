using Blazor_Automated_Email_Marketing_System.Models;
using NUnit.Framework;

namespace Blazor_Automated_Email_Marketing_System.Tests
{
    public class DevelopmentTests
    {
        private List<Subscriber>? _subscribers;
        private List<EmailMessage>? _emailMessages;
        private int SelectedSubscriberId { get; set; }
        private EmailMessage? _emailMessageTemplate;

        [Test]
        [Category("Development")]
        public void UnitTest()
        {
            // Arrange - Set up mock data
            var subscribers = new List<Subscriber>
            {
                new Subscriber { Id = 1, FirstName = "John", LastName = "Doe", EmailAddress = "johndoe@example.com" }
            };

            var emailMessages = new List<EmailMessage>
            {
                new EmailMessage
                {
                    Subject = "{{FirstName}} Don't Miss Out on Our Exclusive Sale!",
                    Body = "Hi {{FirstName}} {{LastName}}, We wanted to let you know about our exclusive sale for our valued subscribers. Get huge reductions off all purchases with the code 123456. Our latest collection includes Glass Hammers, Sky Hooks and Blinker Fluid. Order now to take advantage of this limited-time offer. Kind regards, The {{CompanyName}} Team"
                }
            };

            _subscribers = subscribers;
            _emailMessages = emailMessages;
            SelectedSubscriberId = _subscribers.FirstOrDefault()?.Id ?? 0;
            _emailMessageTemplate = _emailMessages.FirstOrDefault()!;

            // Act - Personalise email message
            var selectedSubscriber = _subscribers.FirstOrDefault(s => s.Id == SelectedSubscriberId);
            if (selectedSubscriber == null || _emailMessageTemplate == null) return;

            _emailMessageTemplate.Body = _emailMessageTemplate.Body!
                .Replace("{{FirstName}}", selectedSubscriber.FirstName)
                .Replace("{{LastName}}", selectedSubscriber.LastName)
                .Replace("{{EmailAddress}}", selectedSubscriber.EmailAddress)
                .Replace("{{Product1}}", "Glass Hammers")
                .Replace("{{Product2}}", "Sky Hooks")
                .Replace("{{Product3}}", "Blinker Fluid")
                .Replace("{{CompanyName}}", "Funny Stuff");

            _emailMessageTemplate.Subject = _emailMessageTemplate.Subject!
                .Replace("{{FirstName}}", selectedSubscriber.FirstName)
                .Replace("{{LastName}}", selectedSubscriber.LastName);

            // Assert - Compare expected and actual results
            Assert.NotNull(_emailMessageTemplate);
            Assert.AreEqual("John Don't Miss Out on Our Exclusive Sale!", _emailMessageTemplate.Subject);
            Assert.That(_emailMessageTemplate.Body, Does.Contain("Hi John Doe,"));
            // Assert.That(_emailMessageTemplate.Body, Does.Contain("no-one@no-domain.com")); // fail
        }
    }
}
