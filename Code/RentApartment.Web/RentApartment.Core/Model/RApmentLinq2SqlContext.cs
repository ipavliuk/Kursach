using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.Model
{
	class RApmentLinq2SqlContext : DataContext
	{
		public RApmentLinq2SqlContext(string connection) : base(connection)
		{
			
		}


	}
}
