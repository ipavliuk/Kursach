using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestDataHelper
{
    internal class ApiDataLoader
    {
        // call
        public string LoadRandomUsers(int number)
        {
            string json = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://api.randomuser.me/");
                    HttpResponseMessage response = client.GetAsync(string.Format("?results={0}", number)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //string jsonMessage;
                        using (Stream responseStream = response.Content.ReadAsStreamAsync().Result)
                        {
                            json = new StreamReader(responseStream).ReadToEnd();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Response with Bad status code => {0}", response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception during load data from random api => {0}", ex.Message));
            }

            return json;
        }
                
    }
}
