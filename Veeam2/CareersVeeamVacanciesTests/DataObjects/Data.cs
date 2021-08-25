namespace CareersVeeamVacanciesTests.DataObjects
{
    /**
    * Object to store incoming parameterized data
    */
    public class Data
    {        
        public string Url { get; set; }
        public string TargetUrl { get; set; }
        public string CategoryList { get; set; }
        public string Career { get; set; }
        public string LanguageList { get; set; }
        public string TargetLanguage { get; set; }
        public int ExpectedNumber { get; set; }
        public string Vacancies { get; set; }
    }
}
