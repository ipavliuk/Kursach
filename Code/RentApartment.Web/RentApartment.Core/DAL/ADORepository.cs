using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.DAL
{
	public class ADORepository : IRApmentRepository
	{
		DataAccessorWrapper datawrapepr = new DataAccessorWrapper();

		public Account GetAccountByEmail(string email)
		{
			throw new NotImplementedException();
		}

		public Account GetAccountById(int id)
		{
			return datawrapepr.GetAccountGetbyId(id);
		}

		public ICollection<Account> GetAccounts()
		{
			throw new NotImplementedException();
		}

		public Reservations GetReservationById(int Id)
		{
			throw new NotImplementedException();
		}

		public Reservations GetReservationByPropertyId(int propertyId)
		{
			throw new NotImplementedException();
		}

		public Reservations GetReservationByAccId(int accId)
		{
			throw new NotImplementedException();
		}

		public ICollection<Reservations> GetReservations()
		{
			throw new NotImplementedException();
		}

		public PropertyListing GetPropertyListingById(int id)
		{
			throw new NotImplementedException();
		}

		public PropertyListing GetPropertyListingByAccId(int accId)
		{
			throw new NotImplementedException();
		}

		public ICollection<PropertyListing> GetPropertyListings()
		{
			throw new NotImplementedException();
		}

		public void Add(Account account)
		{
			throw new NotImplementedException();
		}

		public void Add(PropertyListing property)
		{
			throw new NotImplementedException();
		}

		public void Add(Reservations reservation)
		{
			throw new NotImplementedException();
		}

		public void Add(Messages message)
		{
			throw new NotImplementedException();
		}

		public void Add(GuestReviews review)
		{
			throw new NotImplementedException();
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
			
		}
	}
}
