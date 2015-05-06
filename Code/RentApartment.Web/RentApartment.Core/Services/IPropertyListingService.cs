using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.Infrastructure
{
    interface IPropertyListingService
	{
		Account Authenticate(string login, string password);

		Account GetAccountById(int id);
        List<Account> GetAccountsByFilter(int? accountId, string name, string city);

		List<PropertyListing> GetPropertyByAccount(int accountId);
	    List<PropertyListing> GetBookedPropertyByAccount(int accountId);

		List<PropertyListing> GetPropertyByCityCountry(string city, int country);

		//List<PropertyListing> GetPropertyListings();

        List<Reservations> GetReservationsByDate(DateTime startDate, DateTime endDate, int? status, string city);

		List<Reservations> GetReservationsByAccount(int accountId);
        List<PropertyListing> GetPropertyListingByFilter(string city, int? homeType, int? roomNumbers);
		List<C_Country> GetCountries();
		List<C_Roles> GetRoles();
		List<C_Currency> GetCurrencies();
		List<C_Amenities> GetAmenities();

        List<DateTime> GetApartmentReservationDates(int apartmentId);

        bool MakeApartmentReservation(int accountId, int propertyId, DateTime startDate, DateTime endDate, string note);
		bool CreateProperty(PropertyListing property, List<C_Amenities> amenities);
        bool UpdateProperty(PropertyListing property);
        bool RemoveProperty(int propertyId);

        bool CreateAccount(Account account);
        bool UpdateAccount(Account account);
        bool RemoveAccount(int accountId);
    }
}
