using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Blazor_Automated_Email_Marketing_System.Tests
{
    public class StagingTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
#if GITHUB_ACTIONS
            var chromeOptions = new ChromeOptions();
            chromeOptions.BinaryLocation = "/usr/bin/chromium-browser"; // Path to Chromium binary in Ubuntu runner

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.UseSpecCompliantProtocol = true;

            _driver = new ChromeDriver(chromeDriverService, chromeOptions);
#else
            _driver = new ChromeDriver();
#endif
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
            _driver.Quit();
            _driver.Dispose();
        }
    }
}