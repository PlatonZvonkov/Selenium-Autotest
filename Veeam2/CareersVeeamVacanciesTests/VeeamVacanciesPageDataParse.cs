using System.Text.Json;
using CareersVeeamVacanciesTests.DataObjects;
using System.Collections.Generic;

namespace CareersVeeamVacanciesTests
{
    public class ExternalData
    {
        // Reading from json array and storing it to list.       
        DataCollection data;
        public List<Data> found;       
       public ExternalData(string connection)
        {  
            data = JsonSerializer.Deserialize<DataCollection>(connection);
            found = data.TestData;
        }
    }
}