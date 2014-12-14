using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.Infrastructure
{
	public sealed class AdminManager
	{
		#region Initialisation Singlenton
		private AdminManager() { }

		private static readonly Lazy<AdminManager> _instance = 
			new Lazy<AdminManager>(() => new AdminManager(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

		public static AdminManager Instance
		{
			get 
			{ return _instance.Value; }
		}

		#endregion

		public Account Authenticate(string login, string password)
		{
			var service = new AdministrationService();
			Account acc =  service.Authenticate(login, password);
			
			return acc;
		}

		public Account GetAccountById(int id)
		{
			var service = new AdministrationService();

			return service.GetAccountById(id);
		}


		public IEnumerable<PropertyListing> GetPropertyByAccount(int accountId)
		{
			var service = new AdministrationService();

			return service.GetPropertyByAccount(accountId);
		}

		public IEnumerable<PropertyListing> GetPropertyByCityCountry(string city, int country)
		{
			var service = new AdministrationService();

			return service.GetPropertyByCityCountry(city, country);

		}

		public IEnumerable<Reservations> GetReservations(int? accountId, DateTime? startDate, DateTime? endDate, int status)
		{
			var service = new AdministrationService();
			
			

			return (accountId != null && accountId != 0) 
				? service.GetReservationsByDate(startDate?? DateTime.MinValue, endDate ?? DateTime.UtcNow, status)
				:service.GetReservationsByAccount((int)accountId);
	
		}

		private IEnumerable<Reservations> GetReservationsByDate(DateTime startDate, DateTime endDate, int status)
		{
			var service = new AdministrationService();

			return service.GetReservationsByDate(startDate, endDate, status);
		}

		private IEnumerable<Reservations> GetReservationsByAccount(int accountId)
		{
			var service = new AdministrationService();

			return service.GetReservationsByAccount(accountId);

		}

		public IEnumerable<C_Country> GetCountries()
		{
			var service = new AdministrationService();

			return service.GetCountries();
		}

		public IEnumerable<C_Roles> GetRoles()
		{
			var service = new AdministrationService();

			return service.GetRoles();
		}

		public IEnumerable<C_Currency> GetCurrencies()
		{
			var service = new AdministrationService();

			return service.GetCurrencies();
		}

		public IEnumerable<C_Amenities> GetAmenities()
		{
			var service = new AdministrationService();

			return service.GetAmenities();
		}
	}
}
