using RentAppartment.Client.Utils;
using RentAppartment.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RentAppartment.Client.RApmentAdminService;

namespace RentAppartment.Client.Views
{
    public class ReservationsViewModel : ViewModelBase
    {
		private string city;
		public string City
		{
			get
			{
				return this.city;
			}
			set
			{
				if (this.city != value)
				{
					this.city = value;
					OnPropertyChanged("City");
				}
			}
		}


		private DateTime? startDate;
		public DateTime? StartDate
		{
			get
			{
				return this.startDate;
			}
			set
			{
				if (this.startDate != value)
				{
					this.startDate = value;
					OnPropertyChanged("StartDate");
				}
			}
		}
		private DateTime? endDate;
		public DateTime? EndDate
		{
			get
			{
				return this.endDate;
			}
			set
			{
				if (this.endDate != value)
				{
					this.endDate = value;
					OnPropertyChanged("EndDate");
				}
			}
		}

		private List<ReservationDto> reservations;
		public List<ReservationDto> Reservations
		{
			get
			{
				return this.reservations;
			}
			set
			{
				if (this.reservations != value)
				{
					this.reservations = value;
					OnPropertyChanged("Reservations");
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

        private void SearchAction()
        {
			try
			{
				var repo = RepositoryFactory.Instance.GetApartmentRepository();
				Reservations = repo.GetReservations(City, StartDate, EndDate);
				
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
