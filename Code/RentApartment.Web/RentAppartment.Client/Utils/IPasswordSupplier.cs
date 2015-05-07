using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAppartment.Client.Utils
{
	public interface IPasswordSupplier
	{
		string GetPassword();
	}
}
