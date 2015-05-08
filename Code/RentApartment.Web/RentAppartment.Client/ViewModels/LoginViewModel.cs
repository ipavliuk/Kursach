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
        private string loginMessage;
        public string LoginMessage
        {
            get
            {
                return this.loginMessage;
            }
            set
            {
                if (this.loginMessage != value)
                {
                    this.loginMessage = value;
                    OnPropertyChanged("LoginMessage");
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
                    this.loginCommand = new RelayCommand(o => this.LoginCommandAction(), null);
                }
                return this.loginCommand;
            }
        }

        private bool LoginCommandAction()
        {

			bool result = AuthenticateUserManager.Instance.SignIn(this.LogIn, this.Password);
            if (!result)
            {
                this.LoginMessage = "Користувач не ідентифікований, введіть дані знову";
     
            }
            return result;
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
