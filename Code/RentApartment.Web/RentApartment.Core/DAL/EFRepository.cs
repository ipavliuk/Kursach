using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.DAL
{
	public class EFRepository : IRApmentRepository
	{
		private readonly RentApartmentsContext _db;

		public EFRepository(RentApartmentsContext db)
		{
			_db = db;
		}

		public Account GetAccountByEmail(string email)
		{
			return _db.Accounts.FirstOrDefault(acc => acc.Email == email);
		}

		public Account GetAccountById(int id)
		{
			return _db.Accounts.FirstOrDefault(a => a.id == id);
		}

		public ICollection<Account> GetAccounts()
		{
			return _db.Accounts.ToList();
		}

		public Reservations GetReservationById(int id)
		{
			return _db.Reservations.FirstOrDefault(r => r.ReservationId == id);
		}

		public Reservations GetReservationByPropertyId(int propertyId)
		{
			return _db.Reservations.FirstOrDefault(r => r.FK_PropertyListing == propertyId);
		}

		//Change return IQuerible
		public Reservations GetReservationByAccId(int accId)
		{
			return _db.Reservations.FirstOrDefault(r => r.FK_Account == accId);
		}

		public ICollection<Reservations> GetReservations()
		{
			return _db.Reservations.ToList();
		}

		public PropertyListing GetPropertyListingById(int id)
		{
			return _db.PropertyListing.FirstOrDefault(p => p.PropertyId == id);
		}

		//change to IQuerible
		public PropertyListing GetPropertyListingByAccId(int accId)
		{
			return _db.PropertyListing.FirstOrDefault(p => p.FK_Account == accId);
		}

		public ICollection<PropertyListing> GetPropertyListings()
		{
			return _db.PropertyListing.ToList();
		}

		public void Add(Account account)
		{
			_db.Accounts.Add(account);
			_db.SaveChanges();
		}

		public void Add(PropertyListing property)
		{
			_db.PropertyListing.Add(property);
			_db.SaveChanges();
		}

		public void Add(Reservations reservation)
		{
			_db.Reservations.Add(reservation);
			_db.SaveChanges();
		}

		public void Add(Messages message)
		{
			_db.Messages.Add(message);
			_db.SaveChanges();
		}

		public void Add(GuestReviews review)
		{
			_db.GuestReviews.Add(review);
			_db.SaveChanges();
		}

		public void Update(Account account)
		{
			throw new NotImplementedException();
		}

		public void Update(PropertyListing property)
		{
			throw new NotImplementedException();
		}

		public void Update(Reservations reservation)
		{
			throw new NotImplementedException();
		}

		public void Update(Messages message)
		{
			throw new NotImplementedException();
		}

		public void Update(GuestReviews review)
		{
			throw new NotImplementedException();
		}

		public void Remove(Account account)
		{
			throw new NotImplementedException();
		}

		public void Remove(PropertyListing property)
		{
			throw new NotImplementedException();
		}

		public void Remove(Reservations reservation)
		{
			throw new NotImplementedException();
		}

		public void Remove(Messages message)
		{
			throw new NotImplementedException();
		}

		public void Remove(GuestReviews review)
		{
			throw new NotImplementedException();
		}

		public void ComitChanges()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
