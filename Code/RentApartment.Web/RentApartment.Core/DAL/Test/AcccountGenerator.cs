using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Infrastructure;

namespace RentApartment.Core.DAL.Test
{
	internal class AcccountGenerator
	{
		public static RentApartment.Core.Model.EF.Account GenerateADOEF(string rm)
		{
			string accId = Guid.NewGuid().ToString("N");
			return new RentApartment.Core.Model.EF.Account()
			{
				AccountId = accId,
				PasswordHash = accId.ToSha256(""),
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
				FK__Roles = 1
			};
		}

		//public static RentApartment.Core.Model.Account GenerateLinq2SQl()
		//{
		//	string accId = Guid.NewGuid().ToString("N");
		//	return new RentApartment.Core.Model.Account()
		//	{
		//		AccountId = accId,
		//		PasswordHash = accId.ToSha256(""),
		//		FirstName = "_linq2sql" + accId,
		//		LastName = "LastName" + accId,
		//		Email = "email@gmail.com",
		//		Gender = 0,
		//		IsValidated = false,
		//		Mobile = "022555546",
		//		FK__Country = 10,
		//		City = "Vinnitsya",
		//		Address = "600-ritchya st 55, ap.12",
		//		PostalCode = "21000",
		//		IsEmailConfirmed = true,
		//		Language = 5
		//	};
		//}
	}
}
