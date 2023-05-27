using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Blazor_Automated_Email_Marketing_System.Tests;

public class StagingTests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
#if GITHUB_ACTIONS
            // Use Chromium binary in Ubuntu runner for GitHub Actions
            var chromeOptions = new ChromeOptions();
            chromeOptions.BinaryLocation = "/usr/bin/chromium-browser";
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.UseSpecCompliantProtocol = true;
            _driver = new ChromeDriver(chromeDriverService, chromeOptions);
#else
        // Use Chrome driver on local machine
        _driver = new ChromeDriver();
#endif
        // Maximize the browser window
        _driver.Manage().Window.Maximize();
    }

    [Test]
    [Category("Integration")]
    public void BrowserIntegration_CheckPageTitle()
    {
        // Arrange
        var expectedTitle = "AutoEMS";
        // Act
        _driver.Navigate().GoToUrl("https://localhost:7160/");
        // Wait until the page title contains the expected value
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.Title.Contains(expectedTitle));
        // Assert
        Assert.AreEqual(expectedTitle, _driver.Title);
    }

    [TearDown]
    public void TearDown()
    {
        // Quit the driver and dispose of its resources
        _driver.Quit();
        _driver.Dispose();
    }
}