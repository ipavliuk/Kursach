
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace TestDataHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountsCreator creator = new AccountsCreator();
            List<Account> users = creator.GenerateAcounts(5);

	        try
	        {
		        using (var dbEF = new RentApartmentsContext())
		        {

					dbEF.Account.AddRange(users);
					dbEF.SaveChanges();
					DataCreator data = new DataCreator();
					List<PropertyListing> props = data.GenerateProperties(users);
					dbEF.PropertyListing.AddRange(props);
					dbEF.SaveChanges();
		        }
	        
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ===> {0}", ex.Message);
            }


            
            Console.WriteLine("Press Enter....");
            Console.ReadLine();
        }
    }
}
