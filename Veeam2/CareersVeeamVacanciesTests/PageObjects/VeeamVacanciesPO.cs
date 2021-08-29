using CareersVeeamVacanciesTests.DataObjects;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace CareersVeeamVacanciesTests.PageObjects
{
    class VeeamVacanciesPO
    {
        private IWebDriver driver;
        private string url = "https://careers.veeam.ru/vacancies";
        public string Url { get { return url; } }
      

        public VeeamVacanciesPO(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public void OpenCategoryList()
        {      
            var selectList = driver.FindElement(By.XPath("//button[contains(text(),'Все отделы')]"));
            selectList.Click();
        }
        public void SelectCareer(Data data)
        {
            var selectCareer = driver.FindElement(By.XPath($"//a[text()='{data.Career}']"));
            Console.WriteLine($"{data.Career}");
            selectCareer.Click();
        }
        public void OpenLanguageList()
        {
            var langList = driver.FindElement(By.XPath("//button[contains(text(),'Все языки')]"));
            langList.Click();
        }
        public void SelectLanguage(Data data)
        {
            var selectLang = driver.FindElement(By.XPath($"//label[contains(text(),'{data.TargetLanguage}')]"));           
            Console.WriteLine($"{data.TargetLanguage}");
            selectLang.Click();
        }
        public bool IsThereExpectedAmmount(int expected)
        {
            int actual = driver
                .FindElements(By.XPath("//div[@class='h-100 d-flex flex-column']/a"))
                .Count();
            Console.WriteLine($"expected: {expected} actual: {actual}");
            if (expected == actual)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}
