using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.IO;
using CareersVeeamVacanciesTests.PageObjects;
using System.Collections.Generic;
using CareersVeeamVacanciesTests.DataObjects;

namespace CareersVeeamVacanciesTests
{
    public class VeeamVacanciesPageTests
    {
        private IWebDriver driver; 

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();           
        } 
        
        [TestCaseSource("TestData")]
        public void Check_AmmountOf_ExpectedVacances(Data data)
        {   
            // Arrange    
            var careerPage = new VeeamVacanciesPO(driver);
            driver.Navigate().GoToUrl(careerPage.Url);
            driver.Manage().Window.Maximize();

            // Act            
            careerPage.OpenCategoryList();
            careerPage.SelectCareer(data);
            careerPage.OpenLanguageList();
            careerPage.SelectLanguage(data);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            //Assert
            Assert.IsTrue(careerPage.IsThereExpectedAmmount(data.ExpectedNumber));            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }
        
        public static IEnumerable<Data> TestData()
        {            
            ExternalData data = new ExternalData(
                File.ReadAllText(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "IncomingData.json"), Encoding.UTF8));
            foreach (var item in data.found)
            {
                yield return item;
            }
        }
    }
}