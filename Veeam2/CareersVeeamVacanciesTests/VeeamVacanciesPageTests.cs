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

        /**
         * At the moment of creation of this test 
         * vacancies ammounts on site have been corresponding with JSON array's expected values
         **/
        [TestCaseSource("InLineData")]
        public void Check_AmmountOf_ExpectedVacances(TestData data)
        {   
            // Arrange    
            var careerPage = new VacanciesRuPO(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().GoToUrl(careerPage.Url);
            driver.Manage().Window.Maximize();                  

            // Act            
            careerPage.OpenCategoryList();
            careerPage.SelectCareer(data.Career);
            careerPage.OpenLanguageList();
            careerPage.SelectLanguage(data.TargetLanguage);                     

            //Assert
            Assert.IsTrue(careerPage.IsThereExpectedAmmount(data.ExpectedNumber));            
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }

        /**
        * Method that provides test data for multiple test cases
        * via extracting it from connection string (for now its just a file)
        **/
        public static IEnumerable<TestData> InLineData()
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