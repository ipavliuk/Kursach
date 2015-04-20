﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.Infrastructure
{
	public sealed class RentApartmentManager
	{
		#region Initialisation Singlenton
		private RentApartmentManager() { }

		private static readonly Lazy<RentApartmentManager> _instance = 
			new Lazy<RentApartmentManager>(() => new RentApartmentManager(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

		public static RentApartmentManager Instance
		{
			get 
			{ return _instance.Value; }
		}

		#endregion

		public Account Authenticate(string login, string password)
		{
			var service = new PropertyListingService();
			Account acc =  service.Authenticate(login, password);
			
			return acc;
		}


        public IEnumerable<PropertyListing> LoadPropertyListingByFilter(string city, int? ownerId, 
                                                               int? propertyId, int? homeType, int? roomNumbers )
        {
            var service = new PropertyListingService();
            //PropertyListing
            if (propertyId != null)
            {
                return service.GetPropertyByPropertyId((int)propertyId);
            }
            else if (ownerId != null)
            {
                return service.GetPropertyByAccount((int) ownerId);
            }
            else
            {
               return  service.GetPropertyListingByFilter(city, homeType, roomNumbers);
            }

        }

		public Account GetAccountById(int id)
		{
			var service = new PropertyListingService();

			return service.GetAccountById(id);
		}


		public IEnumerable<PropertyListing> GetPropertyByAccount(int accountId)
		{
			var service = new PropertyListingService();

			return service.GetPropertyByAccount(accountId);
		}

		public IEnumerable<PropertyListing> GetPropertyByCityCountry(string city, int country)
		{
			var service = new PropertyListingService();

			return service.GetPropertyByCityCountry(city, country);

		}
        public IEnumerable<PropertyListing> GetPropertyByCity(string city)
        {
            var service = new PropertyListingService();

            return service.GetPropertyByCity(city);

        }

		public IEnumerable<Reservations> GetReservations(int? accountId, DateTime? startDate, DateTime? endDate, int? status, string city)
		{
			var service = new PropertyListingService();
			
			

			return (accountId != null && accountId != 0)
                ? service.GetReservationsByDate(startDate ?? DateTime.UtcNow.AddMonths(-1), endDate ?? DateTime.UtcNow, status, city)
				: service.GetReservationsByAccount((int)accountId);
	
		}

        public IEnumerable<Account> GetAccounts(int? accountId, string name, string city)
        {
            var service = new PropertyListingService();
            return service.GetAccountsByFilter(accountId, name, city);
        }

		private IEnumerable<Reservations> GetReservationsByDate(DateTime startDate, DateTime endDate, int? status, string city)
		{
			var service = new PropertyListingService();

			return service.GetReservationsByDate(startDate, endDate, status, city);
		}

		private IEnumerable<Reservations> GetReservationsByAccount(int accountId)
		{
			var service = new PropertyListingService();

			return service.GetReservationsByAccount(accountId);

		}

		public IEnumerable<C_Country> GetCountries()
		{
			var service = new PropertyListingService();

			return service.GetCountries();
		}

		public IEnumerable<C_Roles> GetRoles()
		{
			var service = new PropertyListingService();

			return service.GetRoles();
		}

		public IEnumerable<C_Currency> GetCurrencies()
		{
			var service = new PropertyListingService();

			return service.GetCurrencies();
		}

		public IEnumerable<C_Amenities> GetAmenities()
		{
			var service = new PropertyListingService();

			return service.GetAmenities();
		}

        public IEnumerable<DateTime> GetApartmentReservations(int propertyId)
        {
            var service = new PropertyListingService();

            return service.GetApartmentReservationDates(propertyId);
        }

        public bool MakeApartmentReservation(int accountId, int propertyId, DateTime startDate, DateTime endDate, string note)
        {
            var service = new PropertyListingService();

            return service.MakeApartmentReservation(accountId, propertyId, startDate, endDate, note);
        }
        
        public bool CreateProperty(PropertyListing property)
        {
            var service = new PropertyListingService();

            return service.CreateProperty(property);   
        }

        public bool UpdateProperty(PropertyListing property)
        {
            var service = new PropertyListingService();

            return service.UpdateProperty(property);   
        }
    }
}
