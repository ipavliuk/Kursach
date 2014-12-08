using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model;
using RentApartment.Core.Model.EF;

namespace DALTest
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new RentApartmentsContext())
			{
				Account account = new Account()
				{
					AccountId = Guid.NewGuid().ToString("N"),
					FirstName = "Druidd",
					LastName = "Pavl",
					Language = 4,
					PostalCode = "21000",
					Email = "bla@gmail.com"
				};

				db.Accounts.Add(account);

				db.SaveChanges();


				var query = from a in db.Accounts
					orderby a.FirstName
					select a;

				foreach (var item in query)
				{
					Console.WriteLine("Acount First Name => " + item.FirstName);
				}

				Console.ReadLine();
			}
		}
	}
}
