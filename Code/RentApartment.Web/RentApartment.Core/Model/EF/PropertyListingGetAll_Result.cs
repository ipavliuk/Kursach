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
    
    public partial class PropertyListingGetAll_Result
    {
        public int PropertyId { get; set; }
        public int FK_Account { get; set; }
        public byte State { get; set; }
        public Nullable<long> PricePerNight { get; set; }
        public Nullable<long> PricePerMonth { get; set; }
        public Nullable<long> PricePerWeek { get; set; }
        public string Photos { get; set; }
        public string GreatTitle { get; set; }
        public string GreatSummary { get; set; }
        public byte BedRoom { get; set; }
        public int Bathroom { get; set; }
        public byte HomeType { get; set; }
        public byte RoomType { get; set; }
        public byte Accommodates { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State2 { get; set; }
        public string Zip { get; set; }
        public int FK__Country { get; set; }
    }
}
