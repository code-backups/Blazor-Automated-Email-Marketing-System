using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace Blazor_Automated_Email_Marketing_System.Tests
{
    public class ProductionTests
    {
        private ChromeDriver _driver = null!;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Environment.CurrentDirectory);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test, Category("Production")]
        public void SmokeTest()
        {
            _driver.Navigate().GoToUrl("http://localhost:5143/");

            Task.Delay(TimeSpan.FromSeconds(5)).Wait();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            IWebElement header = _driver.FindElement(By.TagName("h1"));

            Assert.AreEqual("Automated Email Marketing System", header.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}