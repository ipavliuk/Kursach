using RentApartment.Core.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataHelper
{
    internal class DataCreator
    {
        
        public List<PropertyListing> GenerateProperties(List<Account> accounts)
        {
            var props = new List<PropertyListing>();
            try
            {
                var loader = new FileLoader();
                Random rand = new Random();
                props = loader.LoadData().Select(item => new PropertyListing 
                {
                    Address1 = item.Adress,
                    City = item.City,
                    Zip = item.Zip,
                    RoomType = (byte)rand.Next(1, 3),
                    //State = item.Region,//Change to string
                    PricePerNight = rand.Next(75, 200),
                    PricePerWeek = rand.Next(750, 1400),
                    HomeType = (byte)rand.Next(1, 4),
                    BedRoom = (byte)rand.Next(1, 4),
                    Bathroom = (int)rand.Next(0, 2),
                    //Account = accounts[(int)rand.Next(0, accounts.Count - 1)]
                    FK_Account = accounts[(int)rand.Next(0, accounts.Count - 1)].id,
                    FK__Country = 187,//USA
                    GreatTitle = "This is the Great title",
                    GreatSummary = "This house is the best for renting"

                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception during load data from random api => {0}", ex.Message));
            }
            return props;
        }
    }
}
