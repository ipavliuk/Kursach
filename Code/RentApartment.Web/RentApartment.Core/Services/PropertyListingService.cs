using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.Infrastructure
{
    internal class PropertyListingService : IPropertyListingService, IDisposable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(PropertyListingService));

		private readonly RentApartmentsContext _db = new RentApartmentsContext();

		public Account Authenticate(string login, string password)
		{
			Account account = null;
			try
			{
				string hash = password.ToSha256("");
				account = _db.Account.FirstOrDefault(a => login == a.Email && a.PasswordHash == hash);

			}
			catch (Exception ex)
			{
				log.Error("Exception when auth account => ", ex);
			}

			return account;
		}

		public Account GetAccountById(int id)
		{
			Account account = null;
			try
			{
				account = _db.Account.FirstOrDefault(a => a.id == id);

			}
			catch (Exception ex)
			{
				log.Error("Exception when get account by Id => ", ex);
			}

			return account;
		}
        public IEnumerable<Account> GetAccountsByFilter(int? accountId, string name, string city)
        {
            try
            {
                var acc = _db.Account.Where(a => accountId != null && a.id == accountId)
                           .Where(a => name != null && a.FirstName == name)
                           .Where(a => city != null && a.City == city);
                return acc;
            }
            catch (Exception ex)
            {
                log.Error("Exception when get accounts => ", ex);
            }
            return new List<Account>();
        }
		public IEnumerable<PropertyListing> GetPropertyByAccount(int accountId)
		{
			try
			{
				return _db.PropertyListing.Where(prop => prop.FK_Account == accountId);
			}
			catch (Exception ex)
			{
				log.Error("Exception when get property by account Id => ", ex);
			}

            return new List<PropertyListing>();
		}
        public IEnumerable<PropertyListing> GetPropertyByPropertyId(int propertyId)
        {
            try
            {
                return _db.PropertyListing.Where(prop => prop.PropertyId == propertyId);
            }
            catch (Exception ex)
            {
                log.Error("Exception when get property by property Id => ", ex);
            }

            return new List<PropertyListing>();
        }

        public IEnumerable<PropertyListing> GetPropertyListingByFilter(string city, int? homeType, int? roomNumbers)
        {
            try
            {
                var loc = _db.PropertyListing.Where(prop => prop.City == city)
							.Where(p => homeType != null && p.HomeType == homeType || homeType == null)
							.Where(p=> roomNumbers != null && p.BedRoom == roomNumbers || roomNumbers ==null);
				return loc;
            }	
            catch (Exception ex)
            {
                log.Error("Exception when get property by property Id => ", ex);
            }

            return new List<PropertyListing>();
        }
		public IEnumerable<PropertyListing> GetPropertyByCityCountry(string city, int country)
		{
			try
			{
				return _db.PropertyListing.Where(prop => prop.FK__Country == country && prop.City == city);
			}
			catch (Exception ex)
			{
				log.Error("Exception when get property by city and country => ", ex);
			}

            return new List<PropertyListing>();

		}
        public IEnumerable<PropertyListing> GetPropertyByCity(string city)
        {
            try
            {
                return _db.PropertyListing.Where(prop => prop.City == city);
            }
            catch (Exception ex)
            {
                log.Error("Exception when get property by city => ", ex);
            }

            return new List<PropertyListing>();

        }
		/*public IEnumerable<PropertyListing> GetPropertyListings()
		{

		}*/

		//For now in UTC
		public IEnumerable<Reservations> GetReservationsByDate(DateTime startDate, DateTime endDate, int status)
		{
			try
			{
				return _db.Reservations.Where(res => res.ReservationStart >= startDate && res.ReservationEnd <= endDate && res.ReservationStatus == status);
			}
			catch (Exception ex)
			{
				log.Error("Exception when get reservations by date  => ", ex);
			}
            return new List<Reservations>();
		}

		public IEnumerable<Reservations> GetReservationsByAccount(int accountId)
		{
			try
			{
				return _db.Reservations.Where(res => res.FK_Account == accountId);
			}
			catch (Exception ex)
			{
				log.Error("Exception when get reservations by date  => ", ex);
			}

            return new List<Reservations>();
		}

       

		public void Dispose()
		{
			_db.Dispose();
		}



		public IEnumerable<C_Country> GetCountries()
		{
			return _db.C_Country;
		}

		public IEnumerable<C_Roles> GetRoles()
		{
			return _db.C_Roles;
		}

		public IEnumerable<C_Currency> GetCurrencies()
		{
			return _db.C_Currency;
		}

		public IEnumerable<C_Amenities> GetAmenities()
		{
			return _db.C_Amenities;
		}
	}
}
