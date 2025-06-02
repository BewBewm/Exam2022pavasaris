using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string ebayLink = "https://www.ebay.com";

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(ebayLink);
        }

        [TestCleanup]
        public void quitDriver()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Test1_field()
        {
            var searchInput = driver.FindElement(By.Id("gh-ac"));
            Assert.IsNotNull(searchInput);
        }

        [TestMethod]
        public void Test2_search()
        {
            var searchButton = driver.FindElement(By.Id("gh-search-btn")); //Nomainīju uz gh-search-btn, jo ebay šobrīd tāds ir aktuāls pogas "Search" ID
            Assert.IsNotNull(searchButton);
        }
    }
}
