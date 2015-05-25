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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<GuestReviews> GuestReviews { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<PropertyListing> PropertyListing { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<DB_Errors_Log> DB_Errors_Log { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual ObjectResult<f_AmenitiesGetById_Result> f_AmenitiesGetById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<f_AmenitiesGetById_Result>("f_AmenitiesGetById", idParameter);
        }
    
        public virtual ObjectResult<f_CountryGetById_Result> f_CountryGetById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<f_CountryGetById_Result>("f_CountryGetById", idParameter);
        }
    
        public virtual ObjectResult<f_CurrencyGetById_Result> f_CurrencyGetById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<f_CurrencyGetById_Result>("f_CurrencyGetById", idParameter);
        }
    
        public virtual ObjectResult<f_RolesGetById_Result> f_RolesGetById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<f_RolesGetById_Result>("f_RolesGetById", idParameter);
        }
    
        public virtual int AddAmenitiesToProperty(Nullable<int> propertyListingId, Nullable<int> amenityId)
        {
            var propertyListingIdParameter = propertyListingId.HasValue ?
                new ObjectParameter("PropertyListingId", propertyListingId) :
                new ObjectParameter("PropertyListingId", typeof(int));
    
            var amenityIdParameter = amenityId.HasValue ?
                new ObjectParameter("AmenityId", amenityId) :
                new ObjectParameter("AmenityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddAmenitiesToProperty", propertyListingIdParameter, amenityIdParameter);
        }
    
        public virtual int PropertyListingCreate(ObjectParameter o_ErrCode, ObjectParameter o_ErrMsg, Nullable<int> accountId, Nullable<byte> state, Nullable<long> pricePerNight, Nullable<long> pricePerMonth, Nullable<long> pricePerWeek, string photos, string greatTitle, string greatSummary, Nullable<byte> bedRoom, Nullable<int> bathroom, Nullable<byte> homeType, Nullable<byte> roomType, Nullable<byte> accommodates, string address1, string address2, string city, string state2, string zip, Nullable<int> country)
        {
            var accountIdParameter = accountId.HasValue ?
                new ObjectParameter("AccountId", accountId) :
                new ObjectParameter("AccountId", typeof(int));
    
            var stateParameter = state.HasValue ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(byte));
    
            var pricePerNightParameter = pricePerNight.HasValue ?
                new ObjectParameter("PricePerNight", pricePerNight) :
                new ObjectParameter("PricePerNight", typeof(long));
    
            var pricePerMonthParameter = pricePerMonth.HasValue ?
                new ObjectParameter("PricePerMonth", pricePerMonth) :
                new ObjectParameter("PricePerMonth", typeof(long));
    
            var pricePerWeekParameter = pricePerWeek.HasValue ?
                new ObjectParameter("PricePerWeek", pricePerWeek) :
                new ObjectParameter("PricePerWeek", typeof(long));
    
            var photosParameter = photos != null ?
                new ObjectParameter("Photos", photos) :
                new ObjectParameter("Photos", typeof(string));
    
            var greatTitleParameter = greatTitle != null ?
                new ObjectParameter("GreatTitle", greatTitle) :
                new ObjectParameter("GreatTitle", typeof(string));
    
            var greatSummaryParameter = greatSummary != null ?
                new ObjectParameter("GreatSummary", greatSummary) :
                new ObjectParameter("GreatSummary", typeof(string));
    
            var bedRoomParameter = bedRoom.HasValue ?
                new ObjectParameter("BedRoom", bedRoom) :
                new ObjectParameter("BedRoom", typeof(byte));
    
            var bathroomParameter = bathroom.HasValue ?
                new ObjectParameter("Bathroom", bathroom) :
                new ObjectParameter("Bathroom", typeof(int));
    
            var homeTypeParameter = homeType.HasValue ?
                new ObjectParameter("HomeType", homeType) :
                new ObjectParameter("HomeType", typeof(byte));
    
            var roomTypeParameter = roomType.HasValue ?
                new ObjectParameter("RoomType", roomType) :
                new ObjectParameter("RoomType", typeof(byte));
    
            var accommodatesParameter = accommodates.HasValue ?
                new ObjectParameter("Accommodates", accommodates) :
                new ObjectParameter("Accommodates", typeof(byte));
    
            var address1Parameter = address1 != null ?
                new ObjectParameter("Address1", address1) :
                new ObjectParameter("Address1", typeof(string));
    
            var address2Parameter = address2 != null ?
                new ObjectParameter("Address2", address2) :
                new ObjectParameter("Address2", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var state2Parameter = state2 != null ?
                new ObjectParameter("State2", state2) :
                new ObjectParameter("State2", typeof(string));
    
            var zipParameter = zip != null ?
                new ObjectParameter("Zip", zip) :
                new ObjectParameter("Zip", typeof(string));
    
            var countryParameter = country.HasValue ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PropertyListingCreate", o_ErrCode, o_ErrMsg, accountIdParameter, stateParameter, pricePerNightParameter, pricePerMonthParameter, pricePerWeekParameter, photosParameter, greatTitleParameter, greatSummaryParameter, bedRoomParameter, bathroomParameter, homeTypeParameter, roomTypeParameter, accommodatesParameter, address1Parameter, address2Parameter, cityParameter, state2Parameter, zipParameter, countryParameter);
        }
    
        public virtual int PropertyListingDelete(ObjectParameter o_ErrCode, ObjectParameter o_ErrMsg, Nullable<int> propertyId)
        {
            var propertyIdParameter = propertyId.HasValue ?
                new ObjectParameter("PropertyId", propertyId) :
                new ObjectParameter("PropertyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PropertyListingDelete", o_ErrCode, o_ErrMsg, propertyIdParameter);
        }
    
        public virtual ObjectResult<PropertyListingGetAll_Result> PropertyListingGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PropertyListingGetAll_Result>("PropertyListingGetAll");
        }
    
        public virtual ObjectResult<PropertyListingGetByAccountId_Result> PropertyListingGetByAccountId(Nullable<int> accId)
        {
            var accIdParameter = accId.HasValue ?
                new ObjectParameter("AccId", accId) :
                new ObjectParameter("AccId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PropertyListingGetByAccountId_Result>("PropertyListingGetByAccountId", accIdParameter);
        }
    
        public virtual ObjectResult<PropertyListingGetByPropertyId_Result> PropertyListingGetByPropertyId(Nullable<int> propertyId)
        {
            var propertyIdParameter = propertyId.HasValue ?
                new ObjectParameter("PropertyId", propertyId) :
                new ObjectParameter("PropertyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PropertyListingGetByPropertyId_Result>("PropertyListingGetByPropertyId", propertyIdParameter);
        }
    
        public virtual int PropertyListingUpdate(ObjectParameter o_ErrCode, ObjectParameter o_ErrMsg, Nullable<int> propertyId, Nullable<byte> state, Nullable<long> pricePerNight, Nullable<long> pricePerMonth, Nullable<long> pricePerWeek, string photos, string greatTitle, string greatSummary, Nullable<byte> bedRoom, Nullable<int> bathroom, Nullable<byte> homeType, Nullable<byte> roomType, Nullable<byte> accommodates, string address1, string address2, string city, string state2, string zip, Nullable<int> country)
        {
            var propertyIdParameter = propertyId.HasValue ?
                new ObjectParameter("PropertyId", propertyId) :
                new ObjectParameter("PropertyId", typeof(int));
    
            var stateParameter = state.HasValue ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(byte));
    
            var pricePerNightParameter = pricePerNight.HasValue ?
                new ObjectParameter("PricePerNight", pricePerNight) :
                new ObjectParameter("PricePerNight", typeof(long));
    
            var pricePerMonthParameter = pricePerMonth.HasValue ?
                new ObjectParameter("PricePerMonth", pricePerMonth) :
                new ObjectParameter("PricePerMonth", typeof(long));
    
            var pricePerWeekParameter = pricePerWeek.HasValue ?
                new ObjectParameter("PricePerWeek", pricePerWeek) :
                new ObjectParameter("PricePerWeek", typeof(long));
    
            var photosParameter = photos != null ?
                new ObjectParameter("Photos", photos) :
                new ObjectParameter("Photos", typeof(string));
    
            var greatTitleParameter = greatTitle != null ?
                new ObjectParameter("GreatTitle", greatTitle) :
                new ObjectParameter("GreatTitle", typeof(string));
    
            var greatSummaryParameter = greatSummary != null ?
                new ObjectParameter("GreatSummary", greatSummary) :
                new ObjectParameter("GreatSummary", typeof(string));
    
            var bedRoomParameter = bedRoom.HasValue ?
                new ObjectParameter("BedRoom", bedRoom) :
                new ObjectParameter("BedRoom", typeof(byte));
    
            var bathroomParameter = bathroom.HasValue ?
                new ObjectParameter("Bathroom", bathroom) :
                new ObjectParameter("Bathroom", typeof(int));
    
            var homeTypeParameter = homeType.HasValue ?
                new ObjectParameter("HomeType", homeType) :
                new ObjectParameter("HomeType", typeof(byte));
    
            var roomTypeParameter = roomType.HasValue ?
                new ObjectParameter("RoomType", roomType) :
                new ObjectParameter("RoomType", typeof(byte));
    
            var accommodatesParameter = accommodates.HasValue ?
                new ObjectParameter("Accommodates", accommodates) :
                new ObjectParameter("Accommodates", typeof(byte));
    
            var address1Parameter = address1 != null ?
                new ObjectParameter("Address1", address1) :
                new ObjectParameter("Address1", typeof(string));
    
            var address2Parameter = address2 != null ?
                new ObjectParameter("Address2", address2) :
                new ObjectParameter("Address2", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var state2Parameter = state2 != null ?
                new ObjectParameter("State2", state2) :
                new ObjectParameter("State2", typeof(string));
    
            var zipParameter = zip != null ?
                new ObjectParameter("Zip", zip) :
                new ObjectParameter("Zip", typeof(string));
    
            var countryParameter = country.HasValue ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PropertyListingUpdate", o_ErrCode, o_ErrMsg, propertyIdParameter, stateParameter, pricePerNightParameter, pricePerMonthParameter, pricePerWeekParameter, photosParameter, greatTitleParameter, greatSummaryParameter, bedRoomParameter, bathroomParameter, homeTypeParameter, roomTypeParameter, accommodatesParameter, address1Parameter, address2Parameter, cityParameter, state2Parameter, zipParameter, countryParameter);
        }
    
        public virtual int ReservationsCreate(Nullable<int> accountId, Nullable<int> propertyListingId, Nullable<int> reservationStatus, Nullable<System.DateTime> reservationStart, Nullable<System.DateTime> reservationEnd, string reservationNote, Nullable<int> currencyId)
        {
            var accountIdParameter = accountId.HasValue ?
                new ObjectParameter("AccountId", accountId) :
                new ObjectParameter("AccountId", typeof(int));
    
            var propertyListingIdParameter = propertyListingId.HasValue ?
                new ObjectParameter("PropertyListingId", propertyListingId) :
                new ObjectParameter("PropertyListingId", typeof(int));
    
            var reservationStatusParameter = reservationStatus.HasValue ?
                new ObjectParameter("ReservationStatus", reservationStatus) :
                new ObjectParameter("ReservationStatus", typeof(int));
    
            var reservationStartParameter = reservationStart.HasValue ?
                new ObjectParameter("ReservationStart", reservationStart) :
                new ObjectParameter("ReservationStart", typeof(System.DateTime));
    
            var reservationEndParameter = reservationEnd.HasValue ?
                new ObjectParameter("ReservationEnd", reservationEnd) :
                new ObjectParameter("ReservationEnd", typeof(System.DateTime));
    
            var reservationNoteParameter = reservationNote != null ?
                new ObjectParameter("ReservationNote", reservationNote) :
                new ObjectParameter("ReservationNote", typeof(string));
    
            var currencyIdParameter = currencyId.HasValue ?
                new ObjectParameter("CurrencyId", currencyId) :
                new ObjectParameter("CurrencyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ReservationsCreate", accountIdParameter, propertyListingIdParameter, reservationStatusParameter, reservationStartParameter, reservationEndParameter, reservationNoteParameter, currencyIdParameter);
        }
    
        public virtual int ReservationsDelete(Nullable<int> reservationId)
        {
            var reservationIdParameter = reservationId.HasValue ?
                new ObjectParameter("ReservationId", reservationId) :
                new ObjectParameter("ReservationId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ReservationsDelete", reservationIdParameter);
        }
    
        public virtual ObjectResult<ReservationsGetAll_Result> ReservationsGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReservationsGetAll_Result>("ReservationsGetAll");
        }
    
        public virtual ObjectResult<ReservationsGetByAccId_Result> ReservationsGetByAccId(Nullable<int> accId)
        {
            var accIdParameter = accId.HasValue ?
                new ObjectParameter("AccId", accId) :
                new ObjectParameter("AccId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReservationsGetByAccId_Result>("ReservationsGetByAccId", accIdParameter);
        }
    
        public virtual ObjectResult<ReservationsGetById_Result> ReservationsGetById(Nullable<int> reservationId)
        {
            var reservationIdParameter = reservationId.HasValue ?
                new ObjectParameter("ReservationId", reservationId) :
                new ObjectParameter("ReservationId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReservationsGetById_Result>("ReservationsGetById", reservationIdParameter);
        }
    
        public virtual ObjectResult<ReservationsGetByPropertyId_Result> ReservationsGetByPropertyId(Nullable<int> propertyId)
        {
            var propertyIdParameter = propertyId.HasValue ?
                new ObjectParameter("PropertyId", propertyId) :
                new ObjectParameter("PropertyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReservationsGetByPropertyId_Result>("ReservationsGetByPropertyId", propertyIdParameter);
        }
    
        public virtual int ReservationsUpdate(Nullable<int> reservationId, Nullable<int> propertyListingId, Nullable<int> reservationStatus, Nullable<System.DateTime> reservationStart, Nullable<System.DateTime> reservationEnd, string reservationNote, Nullable<int> currencyId)
        {
            var reservationIdParameter = reservationId.HasValue ?
                new ObjectParameter("ReservationId", reservationId) :
                new ObjectParameter("ReservationId", typeof(int));
    
            var propertyListingIdParameter = propertyListingId.HasValue ?
                new ObjectParameter("PropertyListingId", propertyListingId) :
                new ObjectParameter("PropertyListingId", typeof(int));
    
            var reservationStatusParameter = reservationStatus.HasValue ?
                new ObjectParameter("ReservationStatus", reservationStatus) :
                new ObjectParameter("ReservationStatus", typeof(int));
    
            var reservationStartParameter = reservationStart.HasValue ?
                new ObjectParameter("ReservationStart", reservationStart) :
                new ObjectParameter("ReservationStart", typeof(System.DateTime));
    
            var reservationEndParameter = reservationEnd.HasValue ?
                new ObjectParameter("ReservationEnd", reservationEnd) :
                new ObjectParameter("ReservationEnd", typeof(System.DateTime));
    
            var reservationNoteParameter = reservationNote != null ?
                new ObjectParameter("ReservationNote", reservationNote) :
                new ObjectParameter("ReservationNote", typeof(string));
    
            var currencyIdParameter = currencyId.HasValue ?
                new ObjectParameter("CurrencyId", currencyId) :
                new ObjectParameter("CurrencyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ReservationsUpdate", reservationIdParameter, propertyListingIdParameter, reservationStatusParameter, reservationStartParameter, reservationEndParameter, reservationNoteParameter, currencyIdParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> AccountCreate(ObjectParameter o_ErrCode, ObjectParameter o_ErrMsg, string accountId, string passwordHash, string firstName, string lastName, string email, Nullable<int> country, string city, string address, string mobile, Nullable<byte> gender, string postalCode, Nullable<int> language, string imageSourceId)
        {
            var accountIdParameter = accountId != null ?
                new ObjectParameter("AccountId", accountId) :
                new ObjectParameter("AccountId", typeof(string));
    
            var passwordHashParameter = passwordHash != null ?
                new ObjectParameter("PasswordHash", passwordHash) :
                new ObjectParameter("PasswordHash", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var countryParameter = country.HasValue ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(int));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(byte));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("PostalCode", postalCode) :
                new ObjectParameter("PostalCode", typeof(string));
    
            var languageParameter = language.HasValue ?
                new ObjectParameter("Language", language) :
                new ObjectParameter("Language", typeof(int));
    
            var imageSourceIdParameter = imageSourceId != null ?
                new ObjectParameter("ImageSourceId", imageSourceId) :
                new ObjectParameter("ImageSourceId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("AccountCreate", o_ErrCode, o_ErrMsg, accountIdParameter, passwordHashParameter, firstNameParameter, lastNameParameter, emailParameter, countryParameter, cityParameter, addressParameter, mobileParameter, genderParameter, postalCodeParameter, languageParameter, imageSourceIdParameter);
        }
    
        public virtual int AccountDelete(ObjectParameter o_ErrCode, ObjectParameter o_ErrMsg, Nullable<int> acc_Id)
        {
            var acc_IdParameter = acc_Id.HasValue ?
                new ObjectParameter("Acc_Id", acc_Id) :
                new ObjectParameter("Acc_Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AccountDelete", o_ErrCode, o_ErrMsg, acc_IdParameter);
        }
    
        public virtual int AccountUpdate(ObjectParameter o_ErrCode, ObjectParameter o_ErrMsg, Nullable<int> acc_Id, string passwordHash, string firstName, string lastName, string email, Nullable<bool> isEmailConfirmed, Nullable<int> country, Nullable<byte> roles, string city, string address, string mobile, Nullable<byte> gender, string postalCode, Nullable<int> language, Nullable<bool> isValidated, string imageSourceId)
        {
            var acc_IdParameter = acc_Id.HasValue ?
                new ObjectParameter("Acc_Id", acc_Id) :
                new ObjectParameter("Acc_Id", typeof(int));
    
            var passwordHashParameter = passwordHash != null ?
                new ObjectParameter("PasswordHash", passwordHash) :
                new ObjectParameter("PasswordHash", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var isEmailConfirmedParameter = isEmailConfirmed.HasValue ?
                new ObjectParameter("IsEmailConfirmed", isEmailConfirmed) :
                new ObjectParameter("IsEmailConfirmed", typeof(bool));
    
            var countryParameter = country.HasValue ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(int));
    
            var rolesParameter = roles.HasValue ?
                new ObjectParameter("Roles", roles) :
                new ObjectParameter("Roles", typeof(byte));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var mobileParameter = mobile != null ?
                new ObjectParameter("Mobile", mobile) :
                new ObjectParameter("Mobile", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(byte));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("PostalCode", postalCode) :
                new ObjectParameter("PostalCode", typeof(string));
    
            var languageParameter = language.HasValue ?
                new ObjectParameter("Language", language) :
                new ObjectParameter("Language", typeof(int));
    
            var isValidatedParameter = isValidated.HasValue ?
                new ObjectParameter("IsValidated", isValidated) :
                new ObjectParameter("IsValidated", typeof(bool));
    
            var imageSourceIdParameter = imageSourceId != null ?
                new ObjectParameter("ImageSourceId", imageSourceId) :
                new ObjectParameter("ImageSourceId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AccountUpdate", o_ErrCode, o_ErrMsg, acc_IdParameter, passwordHashParameter, firstNameParameter, lastNameParameter, emailParameter, isEmailConfirmedParameter, countryParameter, rolesParameter, cityParameter, addressParameter, mobileParameter, genderParameter, postalCodeParameter, languageParameter, isValidatedParameter, imageSourceIdParameter);
        }
    
        public virtual ObjectResult<PropertyListingGetByCity_Result> PropertyListingGetByCity(ObjectParameter o_ErrCode, ObjectParameter o_ErrMsg, string city)
        {
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PropertyListingGetByCity_Result>("PropertyListingGetByCity", o_ErrCode, o_ErrMsg, cityParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_HandleSPErrors(ObjectParameter iO_ErrCode, ObjectParameter iO_ErrMsg)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_HandleSPErrors", iO_ErrCode, iO_ErrMsg);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
