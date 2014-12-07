using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.DAL
{
	interface IRApmentRepository: IDisposable // ???
	{
		Account GetAccountByEmail(string email);
	}
}
