using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Utils;
using RentAppartment.Client.ViewModels;

namespace RentAppartment.Client.Views
{
    public class AccountViewModel : ViewModelBase
    {
        public AccountViewModel()
        {

        }

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

        private AccountDto selectedAccount;

        public AccountDto SelectedAccount
        {
            get
            {
                return this.selectedAccount;
            }
            set
            {
                if (this.selectedAccount != value)
                {
                    this.selectedAccount = value;
                    OnPropertyChanged("SelectedAccount");
                }
            }
        }

        //Filter data
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


        private int? accountId;
        public int? AccountId
        {
            get
            {
                return this.accountId;
            }
            set
            {
                if (this.accountId != value)
                {
                    this.accountId = value;
                    OnPropertyChanged("AccountId");
                }
            }
        }
        private string lastName;
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    OnPropertyChanged("LastName");
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

        private ICommand addAccountCommand;
        public ICommand AddAccountCommand
        {
            get
            {
                if (this.addAccountCommand == null)
                {
                    this.addAccountCommand = new RelayCommand(o => this.AddAccountCommandAction());
                }
                return this.addAccountCommand;
            }
        }

        private void AddAccountCommandAction()
        {
            var view = new AddAccountView();
            var vm = new AddAccountViewModel();

            view.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => view.Close());


            view.Show();
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

        private void EditItemAction()
        {
            var view = new AddAccountView();
            var vm = new AddAccountViewModel(this.SelectedAccount);

            view.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => view.Close());


            view.Show();
        }
        

        private ICommand deleteAccountCommand;
        public ICommand DeleteAccountCommand
		{
			get
			{
                if (this.deleteAccountCommand == null)
				{
                    this.deleteAccountCommand = new RelayCommand(o => this.DeleteItemAction());
				}
                return this.deleteAccountCommand;
			}
		}

        private void DeleteItemAction()
        {
            try
            {
                if (this.SelectedAccount == null)
                {
                    //Add logs
                }

                var repo = RepositoryFactory.Instance.GetApartmentRepository();
                if (repo.RemoveAccount(this.SelectedAccount.id))
                {
                    this.Accounts.Remove(this.SelectedAccount);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        
		private void SearchAction()
		{
            try
            {
                var repo = RepositoryFactory.Instance.GetApartmentRepository();
                Accounts = repo.GetAccounts(AccountId, LastName, City);

            }
            catch (Exception)
            {

                throw;
            }
		}
    }
}
