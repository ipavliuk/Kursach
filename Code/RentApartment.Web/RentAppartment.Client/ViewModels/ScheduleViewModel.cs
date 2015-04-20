using RentAppartment.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentAppartment.Client.Views
{
	public class ScheduleViewModel : ViewModelBase
	{
        public ScheduleViewModel(List<DateTime> reservations, int propertyId, int accountId)
        {
            _propertyId = propertyId;
            _accountId = accountId;
            BlackOutDates = reservations;

            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(1);
        }


        private readonly int _propertyId;
        private readonly int _accountId;

        private string reservationNotes;
        public string ReservationNotes
        {
            get
            {
                return this.reservationNotes;
            }
            set
            {
                if (this.reservationNotes != value)
                {
                    this.reservationNotes = value;
                    OnPropertyChanged("ReservationNotes");
                }
            }
        }
        private DateTime startDate;
        public DateTime StartDate
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
        private DateTime endDate;
        public DateTime EndDate
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
        private List<DateTime> blackOutDates;
        public List<DateTime> BlackOutDates
		{
			get
			{
                return this.blackOutDates;
			}
			set
			{
                if (this.blackOutDates != value)
				{
                    this.blackOutDates = value;
					OnPropertyChanged("BlackOutDates");
				}
			}
		}
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (this.saveCommand == null)
                {
                    this.saveCommand = new RelayCommand(o => this.ReservationAction());
                }
                return this.saveCommand;
            }
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (this.cancelCommand == null)
                {
                    this.cancelCommand = new RelayCommand(o => this.CancelCommandAction());
                }
                return this.cancelCommand;
            }
        }

        public Action CloseAction { get; set; }

        private void CancelCommandAction()
        {
            CloseAction();
        }

        private void ReservationAction()
        {
            try
            {
                var repo = RepositoryFactory.Instance.GetApartmentRepository();
                repo.MakeReservation(_accountId, _propertyId, this.StartDate, this.EndDate, this.ReservationNotes);

                CloseAction();
            }
            catch (Exception)
            {

                throw;
            }
        }
	}
}
