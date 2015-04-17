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
	public class PropertyListingViewModel : ViewModelBase
	{
        public PropertyListingViewModel()
        {
            //Init combo boxes
            var repo = RepositoryFactory.Instance.GetApartmentRepository();
            this.HomeTypes = repo.GetHomeTypes();

            this.RoomNumbers = Enumerable.Range(1, 6).ToList();
        }

		//Filter data
		private string location;
		public string Location
		{
			get
			{
				return this.location;
			}
			set
			{
				if (this.location != value)
				{
					this.location = value;
					OnPropertyChanged("Location");
				}
			}
		}

		private int? roomNumberSelectedItem;
		public int? RoomNumberSelectedItem
		{
			get
			{
				return this.roomNumberSelectedItem;
			}
			set
			{
				if (this.roomNumberSelectedItem != value)
				{
					this.roomNumberSelectedItem = value;
					OnPropertyChanged("RoomNumberSelectedItem");
				}
			}
		}

		private int? ownerId;
		public int? OwnerId
		{
			get
			{
				return this.ownerId;
			}
			set
			{
				if (this.ownerId != value)
				{
					this.ownerId = value;
					OnPropertyChanged("OwnerId");
				}
			}
		}
		private int? homeTypeSelectedItem;
		public int? HomeTypeSelectedItem
		{
			get
			{
				return this.homeTypeSelectedItem;
			}
			set
			{
				if (this.homeTypeSelectedItem != value)
				{
					this.homeTypeSelectedItem = value;
					OnPropertyChanged("HomeTypeSelectedItem");
				}
			}
		}

		private int? propertyId;
		public int? PropertyId
		{
			get
			{
				return this.propertyId;
			}
			set
			{
				if (this.propertyId != value)
				{
					this.propertyId = value;
					OnPropertyChanged("PropertyId");
				}
			}
		}
        private Dictionary<int,string> homeTypes;
        public Dictionary<int, string> HomeTypes
        {
            get
            {
                return this.homeTypes;
            }
            set
            {
                if (this.homeTypes != value)
                {
                    this.homeTypes = value;
                    OnPropertyChanged("HomeTypes");
                }
            }
        }
        private List<int> roomNumbers;
        public List<int> RoomNumbers
        {
            get
            {
                return this.roomNumbers;
            }
            set
            {
                if (this.roomNumbers != value)
                {
                    this.roomNumbers = value;
                    OnPropertyChanged("RoomNumbers");
                }
            }
        }

		private List<PropertyDto> properyListing;
		public List<PropertyDto> ProperyListing
		{
			get
			{
				return this.properyListing;
			}
			set
			{
				if (this.properyListing != value)
				{
					this.properyListing = value;
					OnPropertyChanged("ProperyListing");
				}
			}
		}

		private PropertyDto selectedProperty;

		public PropertyDto SelectedProperty
		{
			get
			{
				return this.selectedProperty;
			}
			set
			{
				if (this.selectedProperty != value)
				{
					this.selectedProperty = value;
					OnPropertyChanged("SelectedProperty");
				}
			}
		}
		//commands
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get
			{
				if (this.searchCommand == null)
				{
					this.searchCommand = new RelayCommand(o => this.SearchAction());
				}
				return this.searchCommand;
			}
		}
        private ICommand selectCommand;
        public ICommand SelectCommand
        {
            get
            {
                if (this.selectCommand == null)
                {
                    this.selectCommand = new RelayCommand(o => this.SelectAction());
                }
                return this.selectCommand;
            }
        }

		private ICommand addApartmentCommand;
		public ICommand AddApartmentCommand
		{
			get
			{
				if (this.addApartmentCommand == null)
				{
					this.addApartmentCommand = new RelayCommand(o => this.AddApartmentCommandAction());
				}
				return this.addApartmentCommand;
			}
		}

		private void AddApartmentCommandAction()
		{
			// Create view Model and start dialog
			var view = new AddApartmentView();
			view.DataContext = new AddApartmentViewModel();

			view.Show();
		}

		private void SearchAction()
		{
			
			//CarViewModel viewModel = this.CreateCarViewModel();

			
			var repo = RepositoryFactory.Instance.GetApartmentRepository();
			this.ProperyListing = repo.GetPropertyListings(location, ownerId, propertyId, homeTypeSelectedItem, roomNumberSelectedItem);
			
			//viewModel.Appointments = AppointmentsHelper.Instance.LoadAppointments(rentalOrders);

			//viewModel.View.ShowDialog();

			//AppointmentsHelper.Instance.SaveAppointments(viewModel.Appointments, rentalOrders, this.SelectedCar);

			//ModelCache.Instance.OnRentalOrdersChanged(this, null);
		}

        private void SelectAction()
        {
            // Create view Model and start dialog
			var view = new ApartmentView();
	        view.DataContext = new ApartmentViewModel(selectedProperty);
	        
			view.Show();
			
            //viewModel.View.ShowDialog();
        }

	}
}
