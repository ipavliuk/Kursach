using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
				this.ProperyListing = repo.GetPropertyByAccount(account.id);
				this.Reservations = repo.GetUserBookedProperties(account.id);
			}
			catch (Exception ex)
			{
				
			}
		}

		private List<PropertyDto> ownedProperyListing;
		public List<PropertyDto> ProperyListing
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
					OnPropertyChanged("ProperyListing");
				}
			}
		}
		private ReservationDto selectedReservation;

		public ReservationDto SelectedReservation
		{
			get
			{
				return this.selectedReservation;
			}
			set
			{
				if (this.selectedReservation != value)
				{
					this.selectedReservation = value;
					OnPropertyChanged("SelectedReservation");
				}
			}
		}

		private List<ReservationDto> bookedProperyListing;
		public List<ReservationDto> Reservations
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
					OnPropertyChanged("Reservations");
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


		private ICommand addReview;
        public ICommand AddReview
        {
            get
            {
                if (this.addReview == null)
                {
                    this.addReview = new RelayCommand(o => this.AddReviewAction());
                }
                return this.addReview;
            }
        }

		private void AddReviewAction()
		{
			try
			{
				if (SelectedReservation == null)
				{
					return;
				}

				var view = new GuestRatingView();
				var vm = new GuestRatingViewModel(SelectedReservation.PropertyListing.PropertyId);
				view.DataContext = vm;

				if (vm.CloseAction == null)
					vm.CloseAction = new Action(() => view.Close());

				view.Show();
			}
			catch (Exception)
			{
				
				throw;
			}
			

		}


	}
}
