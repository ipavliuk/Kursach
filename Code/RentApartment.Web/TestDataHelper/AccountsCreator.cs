using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RentApartment.Core.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataHelper
{
    internal class AccountsCreator
    {
        public List<Account> GenerateAcounts(int numbers)
        {
            var accounts = new List<Account>();
            try
            {
                var loader = new ApiDataLoader();
                string data = loader.LoadRandomUsers(numbers);
                accounts = ParseJsonData(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception during load data from random api => {0}", ex.Message));
            }
            return accounts;
        }

        private List<Account> ParseJsonData(string json)
        {

            var result = new List<Account>();
            try 
	        {	        
		        JObject root = JObject.Parse(json);//(JObject)JsonConvert.DeserializeObject(json);
                JArray arr = (JArray)root["results"];
                foreach (var item in arr)
                {
                    JObject user = (JObject)item["user"];
                    result.Add(new Account()
                    {
                        AccountId = Guid.NewGuid().ToString("N"),
                        FirstName = (string)user["name"]["first"],
                        LastName = (string)user["name"]["last"],
                        Gender = (byte?)((string)user["gender"]== "male" ? 0 : 1),
                        Email = (string)user["email"],
                        Address = (string)user["location"]["street"],
                        City = (string)user["location"]["city"],
                        PostalCode = (string)user["location"]["zip"],
                        Mobile = (string)user["cell"],
						Login = (string)user["username"],
                        PasswordHash = (string)user["md5"],
						PictureUrl = (string)user["picture"]["medium"],
                        FK__Roles = 1,
                        FK__Country = 187 // USA
                        //item[]
                    });
                }
	        }
	        catch (Exception ex)
	        {
                Console.WriteLine(string.Format("Exception in ParseJsonData => {0}", ex.Message));
	        }
            

            return result;
        }
    }
}
