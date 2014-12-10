using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class C_Currency
    {
        public C_Currency()
        {
            this.Reservations = new List<Reservation>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
