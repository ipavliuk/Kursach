﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RentApartmentsContext : DbContext
    {
        public RentApartmentsContext()
            : base("name=RentApartmentsContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C_Amenities> C_Amenities { get; set; }
        public virtual DbSet<C_Country> C_Country { get; set; }
        public virtual DbSet<C_Currency> C_Currency { get; set; }
        public virtual DbSet<C_Roles> C_Roles { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<GuestReviews> GuestReviews { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<PropertyListing> PropertyListing { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
    }
}
