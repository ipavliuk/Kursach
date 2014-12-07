using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.Model
{
	class Reservations
	{
		public int ReservationId { get; set; }
		public int FK_Account { get; set; }
		public int FK_PropertyListing { get; set; }
		public int ReservationStatus { get; set; }
		public System.DateTime ReservationStart { get; set; }
		public System.DateTime ReservationEnd { get; set; }
		public string ReservationNote { get; set; }
		public int FK__Currency { get; set; }

		//public C_Currency C_Currency { get; set; }
		//public Account Account { get; set; }
		//public PropertyListing PropertyListing { get; set; }
	}
}
