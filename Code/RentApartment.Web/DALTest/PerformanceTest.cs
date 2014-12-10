using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.DAL;
using RentApartment.Core.Infrastructure;



namespace DALTest
{
	internal class PerformanceTest
	{
		private class Test
		{
			public static Test Create(Action iteration, string name)
			{
				return new Test() { IterationAction = iteration, Name = name };
			}

			public void AddExecutionTime(long ellapsedTime, long count)
			{
				ElapsedMilliseconds += ellapsedTime;
				IterNumber += count;
			}

			public Action IterationAction { get; set; }
			public string Name { get; set; }

			public long ElapsedMilliseconds { get; set; }
			public long IterNumber { get; set; }
		}


		private class Tests : List<Test>
		{

			public void Add(Action action, string name)
			{
				this.Add(Test.Create(action, name));
			}

			public void Run(int iterations)
			{
				Stopwatch watch = new Stopwatch();

				
				foreach (var iteration in this)
				{
					for (int i = 0; i < iterations; i++)
					{
						watch.Start();
						iteration.IterationAction();
						watch.Stop();
						iteration.AddExecutionTime(watch.ElapsedMilliseconds, i);
					}
				}
				this.OrderBy(t=>t.ElapsedMilliseconds)
					.ForEach(t => Console.WriteLine(t.Name + " took an avarage " + t.ElapsedMilliseconds / t.IterNumber + "ms Iterations: " + t.IterNumber));

				Console.WriteLine("");
			}
		}


		public void Run(int iter)
		{
			Tests tests = new Tests();
			DataAccessorWrapper db = new DataAccessorWrapper();
			var acc = AcccountGenerator.GenerateADOEF("Ado_net");
			tests.Add(() => db.CreateAccount(acc.AccountId, acc.PasswordHash, acc));

		}
	}

	internal class AcccountGenerator
	{
		public static RentApartment.Core.Model.EF.Account GenerateADOEF(string rm)
		{
			string accId = Guid.NewGuid().ToString("N");
			return new RentApartment.Core.Model.EF.Account()
			{
				AccountId = accId,
				PasswordHash = "123456".ToSha256(""),
				FirstName = "_" + rm + accId,
				LastName = "LastName" + accId,
				Email = "email@gmail.com",
				Gender = 0,
				IsValidated = false,
				Mobile = "022555546",
				FK__Country = 10,
				City = "Vinnitsya",
				Address = "600-ritchya st 55, ap.12",
				PostalCode = "21000",
				IsEmailConfirmed = false,
				Language = 5
			};
		}

		public static RentApartment.Core.Model.Account GenerateLinq2SQl()
		{
			string accId = Guid.NewGuid().ToString("N");
			return new RentApartment.Core.Model.Account()
			{
				AccountId = accId,
				PasswordHash = "123456".ToSha256(""),
				FirstName = "_linq2sql" + accId,
				LastName = "LastName" + accId,
				Email = "email@gmail.com",
				Gender = 0,
				IsValidated = false,
				Mobile = "022555546",
				FK__Country = 10,
				City = "Vinnitsya",
				Address = "600-ritchya st 55, ap.12",
				PostalCode = "21000",
				IsEmailConfirmed = true,
				Language = 5
			};
		}
	}

}
