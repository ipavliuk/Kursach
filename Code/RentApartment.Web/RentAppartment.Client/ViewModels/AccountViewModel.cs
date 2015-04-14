using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Utils;

namespace RentAppartment.Client.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {

		private List<AccountDto> accounts;
		public List<AccountDto> Accounts
		{
			get
			{
				return this.accounts;
			}
			set
			{
				if (this.accounts != value)
				{
					this.accounts = value;
					OnPropertyChanged("Accounts");
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
        private ICommand editAccountCommand;
        public ICommand EditAccountCommand
        {
            get
            {
                if (this.editAccountCommand == null)
                {
                    this.editAccountCommand = new RelayCommand(o => this.EditItemAction());
                }
                return this.editAccountCommand;
            }
        }

        private object EditItemAction()
        {
            throw new NotImplementedException();
        }

        private ICommand deleteAccountCommand;
        public ICommand DeleteAccountCommand
		{
			get
			{
				if (this.searchCommand == null)
				{
					this.searchCommand = new RelayCommand(o => this.DeleteItemAction());
				}
				return this.searchCommand;
			}
		}

        private object DeleteItemAction()
        {
            throw new NotImplementedException();
        }
        
		private object SearchAction()
		{
			throw new NotImplementedException();
		}
    }
}
