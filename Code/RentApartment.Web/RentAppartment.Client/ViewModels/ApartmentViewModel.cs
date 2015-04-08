using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RentAppartment.Client.Utils;

namespace RentAppartment.Client.ViewModels
{
    public class ApartmentViewModel : ViewModelBase
    {

        

        public ApartmentViewModel(PropertyDto appartmernt)
        {
			SelectedAppartment = appartmernt;
        }

        public ApartmentViewModel()
        {

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
