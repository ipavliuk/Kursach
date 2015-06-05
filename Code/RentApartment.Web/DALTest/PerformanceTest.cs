using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.DAL;
using RentApartment.Core.DAL.Enums;
using RentApartment.Core.DAL.Test;
using RentApartment.Core.Infrastructure;
using RentApartment.Core.Model.EF;


namespace DALTest
{
	internal class PerformanceTest
	{
		private class Test
		{
			public static Test Create(Action<int> iteration, string name)
			{
				return new Test() { IterationAction = iteration, Name = name };
			}

			public void AddExecutionTime(long ellapsedTime, long count)
			{
				ElapsedMilliseconds += ellapsedTime;
				IterNumber++;
			}

			public Action<int> IterationAction { get; set; }
			public string Name { get; set; }

			public long ElapsedMilliseconds { get; set; }
			public long IterNumber { get; set; }
		}


		private class Tests : List<Test>
		{

			public void Add(Action<int> action, string name)
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
						iteration.IterationAction(i);
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
			Console.WriteLine("----------------------");
			Console.WriteLine("ADO.NET Test ");
			DataAccessorWrapper db = new DataAccessorWrapper();
			var acc = AcccountGenerator.GenerateADOEF("Ado_net_");
			tests.Add((n) => acc.id = db.CreateAccount(acc.AccountId, acc.PasswordHash, acc.FirstName, acc.LastName, acc.Email, acc.FK__Country, (byte)GenderType.Male), "AdoNet_CreateAccount");
			tests.Add((n) => db.GetAccountByPwd("",acc.PasswordHash,false).ThrowIfNull("No item in DB ADO.NEt GetAccountByPwd"), "AdoNet_GetByPwd");
			tests.Add((n) => db.GetAccountGetbyId(acc.id).ThrowIfNull("No item in DB ADO.NEt GetAccountByPwd"), "AdoNet_GetAccountGetbyId");
			tests.Add((n) => db.GetAccountByEmail(acc.Email).ThrowIfNull("No item in DB ADO.NEt GetAccountByEmail"), "AdoNet_GetAccountByEmail");
			tests.Add((n) => db.DeleteAccount(acc.id), "AdoNet_DeleteAccount");
			Console.WriteLine("Results:");
			tests.Run(iter);
			tests.Clear();

			Console.WriteLine("----------------------");
			Console.WriteLine("Ef Test ");
			///Run EF test
			Account[] array = new Account[iter];
			for (int i = 0; i < iter; i++)
			{
				array[i] = AcccountGenerator.GenerateADOEF("EF_");
			}

			var dbEF = new RentApartmentsContext();
			tests.Add((n) => { dbEF.Account.Add(array[n]); dbEF.SaveChanges(); }, "EF_CreateAccount");

			tests.Add((n) =>
			{
				var accEf = array[n];
				dbEF.Account.Single(a => a.id == accEf.id);
			}, "EF_GetAccountById");
			tests.Add((n) =>
			{
				var accEf = array[n];
				dbEF.Account.FirstOrDefault(a => a.Email == accEf.Email);
			}, "EF_GetAccountByEmail");
			tests.Add((n) =>
			{
				var accEf = array[n];
				dbEF.Account.Single(a => a.PasswordHash == accEf.PasswordHash);
			}, "EF_GetAccountByPwd");
			tests.Add((n) =>
			{
				var accEf = array[n];
				dbEF.Account.Remove((dbEF.Account.Single(a => a.id == accEf.id))); dbEF.SaveChanges();
			}, "EF_Remove");
			Console.WriteLine("Results:");
			tests.Run(iter);
			dbEF.Dispose();

		}
	}

	

}
