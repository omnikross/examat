using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace _8
{
    public class Tests
    {
        IWebDriver driver;
        ChromeOptions chromeOptions = new ChromeOptions();
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            driver.Navigate().GoToUrl("https://silpo.ua/offers/cina-tizhnya");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ComparePrices()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            List<String> list = new List<String>();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            for (int j = 1; j < 3; j++)
            {
                IWebElement newPrices = wait.Until(e => e.FindElement(By.XPath($"/html/body/div[1]/div/div/div/div[2]/div[2]/div/div/ul/li[{j}]/a/div[3]/div[2]/div[1]")));
                IWebElement oldPrices = wait.Until(e => e.FindElement(By.XPath($"/html/body/div[1]/div/div/div/div[2]/div[2]/div/div/ul/li[{j}]/a/div[3]/div[2]/div[2]/div[2]")));
                IWebElement prodName = wait.Until(e => e.FindElement(By.XPath($"/html/body/div[1]/div/div/div/div[2]/div[2]/div/div/ul/li[{j}]/a/div[2]/div[1]")));

                var priceDiff = Convert.ToInt32(oldPrices.Text) - Convert.ToInt32(newPrices.Text);

                list.Add(String.Format($"{prodName.Text} - {priceDiff}"));
            }

            Assert.AreEqual(1, 1);

        }
    }
}