using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Utils;
using RentAppartment.Client.Views;

namespace RentAppartment.Client.ViewModels
{
	class PersonalPageViewModel : ViewModelBase
	{
		public PersonalPageViewModel(AccountDto acc)
		{
			account = acc;
			InitUserData();
		}

		private void InitUserData()
		{
			try
			{
				var repo = RepositoryFactory.Instance.GetApartmentRepository();
				this.OwnedProperyListing = repo.GetPropertyByAccount(account.id);
				this.BookedProperyListing = repo.GetUserBookedProperties(account.id);
			}
			catch (Exception ex)
			{
				
			}
		}

		private List<PropertyDto> ownedProperyListing;
		public List<PropertyDto> OwnedProperyListing
		{
			get
			{
				return this.ownedProperyListing;
			}
			set
			{
				if (this.ownedProperyListing != value)
				{
					this.ownedProperyListing = value;
					OnPropertyChanged("OwnedProperyListing");
				}
			}
		}

		private List<PropertyDto> bookedProperyListing;
		public List<PropertyDto> BookedProperyListing
		{
			get
			{
				return this.bookedProperyListing;
			}
			set
			{
				if (this.bookedProperyListing != value)
				{
					this.bookedProperyListing = value;
					OnPropertyChanged("BookedProperyListing");
				}
			}
		}

		private AccountDto account;
		public AccountDto Account
		{
			get
			{
				return this.account;
			}
			set
			{
				if (this.account != value)
				{
					this.account = value;
					OnPropertyChanged("Account");
				}
			}
		}

	}
}
