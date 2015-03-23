using RentApartment.Core.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataHelper
{
    internal class PropertyCreator
    {
        public List<PropertyListing> GeneratePropertyList(int number)
        {
            var properties = new List<PropertyListing>();

            try
            {
                var property = new PropertyListing() 
                {
                    
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception CreateProperties => {0}", ex.Message);
            }

            return properties;
        }
    }
}
