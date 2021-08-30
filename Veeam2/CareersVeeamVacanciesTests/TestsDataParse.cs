using System.Text.Json;
using CareersVeeamVacanciesTests.DataObjects;
using System.Collections.Generic;

namespace CareersVeeamVacanciesTests
{
    /**
     * This class provides parser of incoming JSON data to collection of TestData objects
     **/
    public class ExternalData
    {
        // Reading from json array and storing it to list.       
        readonly DataCollection data;
        public List<TestData> found;       
       public ExternalData(string connection)
        {  
            data = JsonSerializer.Deserialize<DataCollection>(connection);
            found = data.TestData;
        }
    }
}