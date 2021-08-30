using OpenQA.Selenium;
using System;
using System.Linq;

namespace CareersVeeamVacanciesTests.PageObjects
{
    /**
     * This page object describing only those elements that Task document required.
     * Home Page and Other elements can be added later...
     **/
    class VacanciesRuPO
    {
        private IWebDriver driver;
        private string url = "https://careers.veeam.ru/vacancies";
        public string Url { get { return url; } }
      

        public VacanciesRuPO(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public void OpenCategoryList()
        {      
            var selectList = driver.FindElement(By.XPath("//button[contains(text(),'Все отделы')]"));
            selectList.Click();
        }
        public void SelectCareer(string career)
        {
            var selectCareer = driver.FindElement(By.XPath($"//a[text()='{career}']"));
            Console.WriteLine($"{career}");
            selectCareer.Click();
        }
        public void OpenLanguageList()
        {
            var langList = driver.FindElement(By.XPath("//button[contains(text(),'Все языки')]"));
            langList.Click();
        }
        public void SelectLanguage(string targetLanguage)
        {
            var selectLang = driver.FindElement(By.XPath($"//label[contains(text(),'{targetLanguage}')]"));           
            Console.WriteLine($"{targetLanguage}");
            selectLang.Click();
        }
        public bool IsThereExpectedAmmount(int expected)
        {
            // XPath will be ("//div[@class='h-100 d-flex flex-column']/a") .
            int actual = driver
                .FindElements(By.CssSelector("div.h-100>a.card"))
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
