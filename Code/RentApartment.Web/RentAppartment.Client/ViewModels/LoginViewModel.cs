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

        private string password;
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    OnPropertyChanged("Password");
                }
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

        private object LoginCommandAction()
        {
            throw new NotImplementedException();
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
