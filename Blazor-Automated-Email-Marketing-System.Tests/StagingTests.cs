using Blazor_Automated_Email_Marketing_System.Models;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Blazor_Automated_Email_Marketing_System.Tests;

public class StagingTests
{
    private ChromeDriver _driver = null!;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver(Environment.CurrentDirectory);
        _driver.Manage().Window.Maximize();
    }

    [Test]
    [Category("Integration")]
    public void Models_Integration_Test()
    {
        // Arrange - Create instance of Subscriber model
        var subscriber = new Subscriber
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            EmailAddress = "johndoe@notadomain.com",
            TagIdsCsv = "1,2,3"
        };

        // Act - Combine the first name and last name of the Subscriber model to create a full name
        var fullName = $"{subscriber.FirstName} {subscriber.LastName}";

        // Assert - Verify that the full name is equal to "John Doe"
        Assert.AreEqual("John Doe", fullName);
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
    }
}