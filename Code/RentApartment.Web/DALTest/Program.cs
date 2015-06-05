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
				test.Run(1000);
				Console.ReadLine();
			}
			catch (Exception)
			{

				throw;
			}


		}
	}
}
