using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.DAL.Test;
using RentApartment.Core.Model.EF;

namespace DALTest
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				PerformanceTest test = new PerformanceTest();
				test.Run(100);
				Console.ReadLine();
			}
			catch (Exception)
			{

				throw;
			}



			

			//using (var db = new RentApartmentsContext())
			//{
			//	Account account = AcccountGenerator.GenerateADOEF("EF_");

			//	db.Account.Add(account);

			//	db.SaveChanges();


			//	db.Account.Remove((db.Account.Single(a => a.id == account.id)));
			//	db.SaveChanges();
			//	var query = from a in db.Account
			//				orderby a.FirstName
			//				select a;

			//	foreach (var item in query)
			//	{
			//		Console.WriteLine("acount first name => " + item.FirstName);
			//	}

			//	Console.ReadLine();
			//}
		}
	}
}
