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
    
    public partial class AccountGetbyEmail_Result
    {
        public int id { get; set; }
        public string AccountId { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public int FK__Country { get; set; }
        public byte FK__Roles { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public Nullable<byte> Gender { get; set; }
        public string PostalCode { get; set; }
        public bool IsValidated { get; set; }
        public string PictureUrl { get; set; }
    }
}
