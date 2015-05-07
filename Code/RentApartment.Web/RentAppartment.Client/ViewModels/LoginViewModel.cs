using RentAppartment.Client.Utils;
using RentAppartment.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentAppartment.Client.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
		private readonly IPasswordSupplier _pwdSupplier;

		public LoginViewModel(IPasswordSupplier pwdSupplier)
		{
			_pwdSupplier = pwdSupplier;
		}

	    

        private string logIn;
        public string LogIn
        {
            get
            {
                return this.logIn;
            }
            set
            {
                if (this.logIn != value)
                {
                    this.logIn = value;
                    OnPropertyChanged("LogIn");
                }
            }
        }

        public string Password
        {
            get
            {
				return _pwdSupplier.GetPassword();
            }
            
        }

        #region Commands
        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new RelayCommand(o => this.LoginCommandAction());
                }
                return this.loginCommand;
            }
        }

        private void LoginCommandAction()
        {

			AuthenticateUserManager.Instance.SignIn(this.LogIn, this.Password);
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
        #endregion
    }
}
