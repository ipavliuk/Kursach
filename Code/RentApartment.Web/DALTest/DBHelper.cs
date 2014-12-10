using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.DAL;
using RentApartment.Core.Model.EF;

namespace DALTest
{
	

	public class ADODBHelper
	{
		DataAccessorWrapper db = new DataAccessorWrapper();

		public void CreateAccount(int accountId, string passwordHash, string firstName, string lastName, string email, int countryId)
		{
			db.CreateAccount(accountId, passwordHash, firstName, lastName, email, countryId); 
		}
	}



}
