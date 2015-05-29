using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RentAppartment.Client.Utils;
using RentAppartment.Client.Views;

namespace RentAppartment.Client.ViewModels
{
	class GuestRatingViewModel : ViewModelBase
	{
		public GuestRatingViewModel(int propertyId)
		{
			_propertyId = propertyId;
			//Score = 10;
		}

		private readonly int _propertyId;

		private int score;
		public int Score
		{
			get
			{
				return this.score;
			}
			set
			{
				if (this.score != value)
				{
					this.score = value;
					OnPropertyChanged("Score");
				}
			}
		}



		private string reviewNotes;
		public string ReviewNotes
		{
			get
			{
				return this.reviewNotes;
			}
			set
			{
				if (this.reviewNotes != value)
				{
					this.reviewNotes = value;
					OnPropertyChanged("ReviewNotes");
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
					this.saveCommand = new RelayCommand(o => this.SaveReviewAction());
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

		private void SaveReviewAction()
		{
			try
			{
				var repo = RepositoryFactory.Instance.GetApartmentRepository();

				repo.AddReview(_propertyId, AuthenticateUserManager.Instance.Account.id, this.Score, this.ReviewNotes);

				CloseAction();
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
