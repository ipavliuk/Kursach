using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Repository.Hierarchy;
using RentApartment.Core.Model.EF;
using RentApartment.Core.DAL.Enums;

namespace RentApartment.Core.Infrastructure
{
    internal class PropertyListingService : IPropertyListingService, IDisposable
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(PropertyListingService));

		//private readonly RentApartmentsContext _db = new RentApartmentsContext();

		public Account Authenticate(string login, string password)
		{
			Account account = null;
			try
			{
				using (var _db = new RentApartmentsContext())
				{
					string hash = password.ToSha256("");
					account = _db.Account.FirstOrDefault(a => login == a.Email && a.PasswordHash == hash);
				}
				

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
				using (var _db = new RentApartmentsContext())
				{
					account = _db.Account.FirstOrDefault(a => a.id == id);
				}
				

			}
			catch (Exception ex)
			{
				log.Error("Exception when get account by Id => ", ex);
			}

			return account;
		}
        public List<Account> GetAccountsByFilter(int? accountId, string name, string city)
        {
            try
            {
	            using (var _db = new RentApartmentsContext())
	            {
					var acc = _db.Account.Where(a => accountId != null && a.id == accountId || accountId == null)
										.Where(a => a.FirstName == name || string.IsNullOrEmpty(name))
										.Where(a => a.City == city || string.IsNullOrEmpty(city)).ToList();
					return acc;
	            }
                
            }
            catch (Exception ex)
            {
                log.Error("Exception when get accounts => ", ex);
            }
            return new List<Account>();
        }
		public List<PropertyListing> GetPropertyByAccount(int accountId)
		{
			try
			{
				using (var _db = new RentApartmentsContext())
				{
					return _db.PropertyListing.Where(prop => prop.FK_Account == accountId).ToList();
				}
				
			}
			catch (Exception ex)
			{
				log.Error("Exception when get property by account Id => ", ex);
			}

            return new List<PropertyListing>();
		}
        public List<PropertyListing> GetPropertyByPropertyId(int propertyId)
        {
            try
            {
	            using (var _db = new RentApartmentsContext())
	            {
					return _db.PropertyListing.Where(prop => prop.PropertyId == propertyId).ToList();
	            }
                
            }
            catch (Exception ex)
            {
                log.Error("Exception when get property by property Id => ", ex);
            }

            return new List<PropertyListing>();
        }

        public List<PropertyListing> GetPropertyListingByFilter(string city, int? homeType, int? roomNumbers)
        {
            try
            {
	            using (var _db = new RentApartmentsContext())
	            {
					var loc = _db.PropertyListing.Include(p => p.Account)
							.Include(p => p.C_Amenities).Include(p => p.Reservations)
							.Where(prop => prop.City == city)
							.Where(p => homeType != null && p.HomeType == homeType || homeType == null)
							.Where(p => roomNumbers != null && p.BedRoom == roomNumbers || roomNumbers == null).ToList();
					return loc;
	            }
               
            }	
            catch (Exception ex)
            {
                log.Error("Exception when get property by property Id => ", ex);
            }

            return new List<PropertyListing>();
        }
		public List<PropertyListing> GetPropertyByCityCountry(string city, int country)
		{
			try
			{
				using (var _db = new RentApartmentsContext())
				{
					return _db.PropertyListing.Where(prop => prop.FK__Country == country && prop.City == city).ToList();
				}
				
			}
			catch (Exception ex)
			{
				log.Error("Exception when get property by city and country => ", ex);
			}

            return new List<PropertyListing>();

		}
        public List<PropertyListing> GetPropertyByCity(string city)
        {
            try
            {
	            using (var _db = new RentApartmentsContext())
	            {
					return _db.PropertyListing.Where(prop => prop.City == city).ToList();
	            }
                
            }
            catch (Exception ex)
            {
                log.Error("Exception when get property by city => ", ex);
            }

            return new List<PropertyListing>();

        }
		/*public List<PropertyListing> GetPropertyListings()
		{

		}*/

		//For now in UTC
		public List<Reservations> GetReservationsByDate(DateTime startDate, DateTime endDate, int? status, string city)
		{
			try
			{
				using (var _db = new RentApartmentsContext())
				{
					return _db.Reservations.Where(res => res.ReservationStart >= startDate 
								&& res.ReservationEnd <= endDate && (status != null && res.ReservationStatus == status)
								&& res.PropertyListing.City == city).ToList();
				}
                
			}
			catch (Exception ex)
			{
				log.Error("Exception when get reservations by date  => ", ex);
			}
            return new List<Reservations>();
		}

		public List<Reservations> GetReservationsByAccount(int accountId)
		{
			try
			{
				using (var _db = new RentApartmentsContext())
				{
					return _db.Reservations.Where(res => res.FK_Account == accountId).ToList();
				}
			
			}
			catch (Exception ex)
			{
				log.Error("Exception when get reservations by date  => ", ex);
			}

            return new List<Reservations>();
		}

        public List<DateTime> GetApartmentReservationDates(int apartmentId)
        {
            try
            {
	            using (var _db = new RentApartmentsContext())
	            {
					var reservations = _db.Reservations.Where(res => res.FK_PropertyListing == apartmentId).ToList();
					return reservations.SelectMany(r =>
					{
						var start = r.ReservationStart;
						var end = r.ReservationEnd;
						return Enumerable.Range(0, 1 + end.Subtract(start).Days)
						.Select(offset => start.AddDays(offset));
					}).ToList();
	            }
                
                 
            }
            catch (Exception ex)
            {
                log.Error("Exception when get reservation dates by apartment  => ", ex);
            }

            return new List<DateTime>();
        }

		//public void Dispose()
		//{
		//	_db.Dispose();
		//}

		private bool disposed = false;

		//protected virtual void Dispose(bool disposing)
		//{
		//	if (!this.disposed)
		//	{
		//		if (disposing)
		//		{
		//			_db.Dispose();
		//		}
		//	}
		//	this.disposed = true;
		//}

		public void Dispose()
		{
			//Dispose(true);
			GC.SuppressFinalize(this);
		}


		public List<C_Country> GetCountries()
		{
			using (var _db = new RentApartmentsContext())
			{
				return _db.C_Country.ToList();
			}
			
		}

		public List<C_Roles> GetRoles()
		{
			using (var _db = new RentApartmentsContext())
			{
				return _db.C_Roles.ToList();
			}
			
		}

		public List<C_Currency> GetCurrencies()
		{
			using (var _db = new RentApartmentsContext())
			{
				return _db.C_Currency.ToList();
			}
			
		}

		public List<C_Amenities> GetAmenities()
		{
			using (var _db = new RentApartmentsContext())
			{
				return _db.C_Amenities.ToList();
			}
			
		}

        public bool MakeApartmentReservation(int accountId, int propertyId, DateTime startDate, DateTime endDate, string note)
        {
            bool result = true;
            try 
	        {
		        using (var _db = new RentApartmentsContext())
		        {
					var reservation = new Reservations
					{
						FK_PropertyListing = propertyId,
						FK_Account = accountId,
						ReservationStart = startDate,
						ReservationEnd = endDate,
						ReservationNote = note,
						ReservationStatus = (int)ReservationStatus.Open,
						FK__Currency = 3
					};

					_db.Reservations.Add(reservation);
					int id = _db.SaveChanges();
					result = id == 0 ? false : true;
		        }
            }
	        catch (Exception)
	        {
		
		        throw;
	        }
            return result;
        }

        public bool CreateProperty(PropertyListing property, List<C_Amenities> amenities)
        {
            bool result = true;
            try
            {
	            using (var _db = new RentApartmentsContext())
	            {
		            property.Currency = 1;
					_db.PropertyListing.Add(property);

					foreach (var cAmenitiese in amenities)
					{
						var amenity = _db.C_Amenities.SingleOrDefault(a => a.id == cAmenitiese.id);
						if (amenity == null)
						{
							amenity = cAmenitiese;
						}

						property.C_Amenities.Add(amenity);

					}


					int id = _db.SaveChanges();

					result = id == 0 ? false : true;
	            }
				
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool UpdateProperty(PropertyListing property)
        {
            bool result = true;
            try
            {
	            using (var _db = new RentApartmentsContext())
	            {
					_db.PropertyListing.Add(property);
					int id = _db.SaveChanges();
					result = id == 0 ? false : true;
	            }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
