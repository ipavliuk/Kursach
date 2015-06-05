using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentApartment.Core.DAL;
using RentApartment.Core.DAL.Test;
using RentApartment.Core.Model.EF;

namespace DALUnitTest
{
	/// <summary>
	/// Summary description for DataBaseWrapperTest
	/// </summary>
	[TestClass]
	public class DataBaseWrapperTest
	{

		private readonly Account account;
		public DataBaseWrapperTest()
		{
			account = AcccountGenerator.GenerateADOEF("Ado");
		}

		DataAccessorWrapper db = new DataAccessorWrapper();
		

	
		[TestMethod]
		public void Create_Account_GetBy_PWD_DELETE_Test()
		{
			Assert.IsNotNull(account);
			int newId = db.CreateAccount(account.AccountId, account.PasswordHash, account.FirstName, account.LastName, account.Email, account.FK__Country, 1);
			Assert.IsTrue(newId != 0);
			account.id = (int)newId;

			var accNew = db.GetAccountByPwd("", account.PasswordHash);
			Assert.IsNotNull(accNew);
			Assert.IsNotNull(accNew.AccountId == account.AccountId);
			if(accNew != null)
			{
				Console.WriteLine("new accId is => {0}", accNew.id);
				db.DeleteAccount(accNew.id);

				var accNew2 = db.GetAccountByPwd("", account.PasswordHash);
				Assert.IsTrue(string.IsNullOrEmpty(accNew2.AccountId));	
			}

			
			
			
		}


		
	}
}
