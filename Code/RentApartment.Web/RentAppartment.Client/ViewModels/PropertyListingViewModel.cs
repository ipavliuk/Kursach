using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Utils;
using RentAppartment.Client.Views;


namespace RentAppartment.Client.Views
{
	public class PropertyListingViewModel : ViewModelBase
	{
        private const string ViewId = "PropertyListingView";
		public class DictItem
		{
			public int Id { get; set; }

			public string Value { get; set; }
		}

		public PropertyListingViewModel()
        {
            //Init combo boxes
            var repo = RepositoryFactory.Instance.GetApartmentRepository();

			this.HomeTypes = new ObservableCollection<DictItem>(repo.GetHomeTypes().Select(item => new DictItem()
																{
																	Id = item.Key,
																	Value = item.Value
																}).ToList());

            this.RoomNumbers = Enumerable.Range(1, 6).ToList();

            string role = AuthenticateUserManager.Instance.Account.RolesName;
            this.IsIdTextOwnerAccessable = AccessManager.Instance.GetViewControlAccess(role,
                                ViewId, "txtIdOwner");
            this.IsIdTextPropertyAccessable = AccessManager.Instance.GetViewControlAccess(role,
                                ViewId, "txtIdProperty");
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

		private DictItem homeTypeSelectedItem;
		public DictItem HomeTypeSelectedItem
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

		public ObservableCollection<DictItem> HomeTypes { get; private set; }
		

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



        private bool isIdTextOwnerAccessable;
        public bool IsIdTextOwnerAccessable
		{
			get
			{
                return this.isIdTextOwnerAccessable;
			}
			set
			{
                if (this.isIdTextOwnerAccessable != value)
				{
                    this.isIdTextOwnerAccessable = value;
                    OnPropertyChanged("IsIdTextOwnerAccessable");
				}
			}
		}
        private bool isIdTextPropertyAccessable;
        public bool IsIdTextPropertyAccessable
        {
            get
            {
                return this.isIdTextPropertyAccessable;
            }
            set
            {
                if (this.isIdTextPropertyAccessable != value)
                {
                    this.isIdTextPropertyAccessable = value;
                    OnPropertyChanged("IsIdTextPropertyAccessable");
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

        private ICommand editCommand;
        public ICommand EditCommand
		{
			get
			{
                if (this.editCommand == null)
				{
                    this.editCommand = new RelayCommand(o => this.EditCommandAction());
				}
                return this.editCommand;
			}
		}

        
        private ICommand deletePropertyCommand;
        public ICommand DeletePropertyCommand
		{
			get
			{
                if (this.deletePropertyCommand == null)
				{
                    this.deletePropertyCommand = new RelayCommand(o => this.DeletePropertyCommandAction());
				}
                return this.deletePropertyCommand;
			}
		}

       

        private ICommand scheduleApartmentCommand;
        public ICommand ScheduleApartmentCommand
		{
			get
			{
                if (this.scheduleApartmentCommand == null)
				{
                    this.scheduleApartmentCommand = new RelayCommand(o => this.ScheduleApartmentCommandAction());
				}
                return this.scheduleApartmentCommand;
			}
		}

        private void DeletePropertyCommandAction()
        {
            try
            {
                if (this.SelectedProperty == null)
                {
                    //Add logs
                }

                var repo = RepositoryFactory.Instance.GetApartmentRepository();
                if (repo.RemoveProperty(this.SelectedProperty.PropertyId))
                {
                    this.ProperyListing.Remove(this.SelectedProperty);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void EditCommandAction()
        {
            
            var view = new AddApartmentView();
            var vm = new AddApartmentViewModel(this.SelectedProperty);

            view.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => view.Close());

           
			view.Show();
        }

        private void ScheduleApartmentCommandAction()
        {
            if (SelectedProperty == null)
            {
                //TODO - add to log
                return;
            }
                
            try
            {
                var repo = RepositoryFactory.Instance.GetApartmentRepository();
                List<DateTime> reservations = repo.GetApartmentReservations(SelectedProperty.PropertyId);

                var view = new ScheduleView();
                var vm = new ScheduleViewModel(reservations, SelectedProperty.PropertyId,
                    AuthenticateUserManager.Instance.IsLogedIn  ? AuthenticateUserManager.Instance.Account.id
                                                                : 0); // test only
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
        
		private void AddApartmentCommandAction()
		{
			// Create view Model and start dialog
           

            var view = new AddApartmentView();
            var vm = new AddApartmentViewModel();

            view.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => view.Close());

           
			view.Show();
		}

		private void SearchAction()
		{
			
			//CarViewModel viewModel = this.CreateCarViewModel();

			
			var repo = RepositoryFactory.Instance.GetApartmentRepository();
			this.ProperyListing = repo.GetPropertyListings(Location, OwnerId, PropertyId, HomeTypeSelectedItem != null ? (int?)HomeTypeSelectedItem.Id : null , roomNumberSelectedItem);
			
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
