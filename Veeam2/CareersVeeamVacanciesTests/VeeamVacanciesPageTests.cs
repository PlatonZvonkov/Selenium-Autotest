using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.IO;


namespace CareersVeeamVacanciesTests
{
    public class VeeamVacanciesPageTests
    {
        private IWebDriver driver;
        private ExternalData data;
        private WebDriverWait wait;
        private By _categoryList;
        private By _career;
        private By _languageList;
        private By _language;
        private int _expectedNumber;
        private string _targetUrl;
        private By _vacancies;


        [OneTimeSetUp]
        public void Setup()
        {    
            driver = new FirefoxDriver();  
            data = new ExternalData(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IncomingData.json")));
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 3));

        }
        
        [TestCase(0)]
        public void Step1_EnteringCategoryList_WithoughtExceptions(int i)
        {
            // Arrange
            driver.Navigate().GoToUrl(data.found[i].Url);
            driver.Manage().Window.Maximize();
            _categoryList = By.XPath(data.found[i].CategoryList);
            _career = By.XPath(data.found[i].Career);
            _languageList = By.XPath(data.found[i].LanguageList);
            _language = By.XPath(data.found[i].TargetLanguage);
            _expectedNumber = data.found[i].ExpectedNumber;
            _targetUrl = data.found[i].TargetUrl;
            _vacancies = By.XPath(data.found[i].Vacancies);
            
            // Act
            var selectList = driver.FindElement(_categoryList);
            selectList.Click(); 
            var selectCareer = driver.FindElement(_career);
            selectCareer.Click();
            var selectLang = driver.FindElement(_languageList);          
            selectLang.Click();
            var selectEnglish = driver.FindElement(_language);            
            selectEnglish.Click();
            int expected = _expectedNumber; //at the  creation moment of this test there was 6 vacancies                      
            wait.Until(url => url.Url == _targetUrl);       
            var actual = driver.FindElements(_vacancies).Count();
            
            //Assert
            Assert.AreEqual(_targetUrl, driver.Url);
            Assert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
        }
        
    }
}