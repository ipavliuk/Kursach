//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentApartment.Core.Model.EF
{
    using System;
    
    public partial class ReservationsGetById_Result
    {
        public int ReservationId { get; set; }
        public int FK_Account { get; set; }
        public int FK_PropertyListing { get; set; }
        public int ReservationStatus { get; set; }
        public System.DateTime ReservationStart { get; set; }
        public System.DateTime ReservationEnd { get; set; }
        public string ReservationNote { get; set; }
        public int FK__Currency { get; set; }
    }
}
