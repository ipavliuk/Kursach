using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.DAL
{
	interface IRampentService
	{
		Account GetAccountByEmail(string email);
		Account GetAccountById(int id);
		ICollection<Account> GetAccounts();

		Reservations GetReservationById(int Id);
		Reservations GetReservationByPropertyId(int propertyId);
		Reservations GetReservationByAccId(int accId);
		ICollection<Reservations> GetReservations();


		PropertyListing GetPropertyListingById(int id);
		PropertyListing GetPropertyListingByAccId(int accId);
		ICollection<PropertyListing> GetPropertyListings();


		void Add(Account account);
		void Add(PropertyListing property);
		void Add(Reservations reservation);
		void Add(Messages message);
		void Add(GuestReviews review);

		void Update(Account account);
		void Update(PropertyListing property);
		void Update(Reservations reservation);
		void Update(Messages message);
		void Update(GuestReviews review);

		void Remove(Account account);
		void Remove(PropertyListing property);
		void Remove(Reservations reservation);
		void Remove(Messages message);
		void Remove(GuestReviews review);

		void ComitChanges();
	}
}
