using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.Infrastructure
{
	interface IAccountService
	{
		Account Authenticate(string login, string password);

		Account GetAccountById(int id);

		IEnumerable<PropertyListing> GetPropertyByAccount(int accountId);

		IEnumerable<PropertyListing> GetPropertyByCityCountry(string city, int country);

		//IEnumerable<PropertyListing> GetPropertyListings();

		IEnumerable<Reservations> GetReservationsByDate(DateTime startDate, DateTime endDate, int status);

		IEnumerable<Reservations> GetReservationsByAccount(int accountId);

		IEnumerable<C_Country> GetCountries();
		IEnumerable<C_Roles> GetRoles();
		IEnumerable<C_Currency> GetCurrencies();
		IEnumerable<C_Amenities> GetAmenities();
	}
}
