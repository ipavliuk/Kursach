using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RentAppartment.Client.Utils;
using System.Collections.ObjectModel;

namespace RentAppartment.Client.Views
{
    public class ApartmentViewModel : ViewModelBase
    {

        

        public ApartmentViewModel(PropertyDto appartmernt)
        {
			this.SelectedAppartment = appartmernt;
            var repo = RepositoryFactory.Instance.GetApartmentRepository();
            Amenities = new AmenitiesProvider(repo.GetAmenitites());
            Amenities.SetAmenitiesModel(appartmernt.C_Amenities.ToList());

            this.HomeTypes = new ObservableCollection<DictItem>(repo.GetHomeTypes().Select(item => new DictItem()
            {
                Id = item.Key,
                Value = item.Value
            }).ToList());
            this.HomeTypeSelectedItem = new DictItem
            {
                Id = appartmernt.HomeType,
                Value = appartmernt.HomeTypeName
            };
        }

        public ApartmentViewModel()
        {

        }

        private AmenitiesProvider amenities;
        public AmenitiesProvider Amenities
        {
            get
            {
                return this.amenities;
            }
            set
            {
                if (this.amenities != value)
                {
                    this.amenities = value;
                    OnPropertyChanged("Amenities");
                }
            }
        }
		private PropertyDto selectedAppartment;
		public PropertyDto SelectedAppartment
		{
			get
			{
				return this.selectedAppartment;
			}
			set
			{
				if (this.selectedAppartment != value)
				{
					this.selectedAppartment = value;
					OnPropertyChanged("SelectedAppartment");
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

		//Test command
		private ICommand okCommand;
		public ICommand OkCommand
		{
			get
			{
				if (this.okCommand == null)
				{
					this.okCommand = new RelayCommand(o => this.OkAction());
				}
				return this.okCommand;
			}
		}

		private object OkAction()
		{
			return null;
		}
	}

}
