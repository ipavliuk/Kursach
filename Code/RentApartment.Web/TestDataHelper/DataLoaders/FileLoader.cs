using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataHelper.DO;

namespace TestDataHelper
{
    internal class FileLoader
    {
        public List<GeneratedData> LoadData()
        {
            List<GeneratedData> items = new List<GeneratedData>();
            try
            {
                using (var reader = new StreamReader("generated.json"))
                {
                    string json = reader.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<GeneratedData>>(json);
    
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception during load data from random api => {0}", ex.Message));
            }
            return items;
        }
    }
}
