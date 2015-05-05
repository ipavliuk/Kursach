using RentAppartment.Client.Utils;
using RentAppartment.Client.ViewModels;
using RentAppartment.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentAppartment.Client.Views
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
           
        }

        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            private set
            {
                currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        private ICommand navigatePropertyListCommand;
        public ICommand NavigatePropertyListCommand
        {
            get
            {
                if (this.navigatePropertyListCommand == null)
                {
                    this.navigatePropertyListCommand = new RelayCommand(o => this.NavigatePropertyCommandAction());
                }
                return this.navigatePropertyListCommand;
            }
        }

        private void NavigatePropertyCommandAction()
        {
            this.CurrentView = new PropertyListingViewModel();
        }


        private ICommand navigateAccountsCommand;
        public ICommand NavigateAccountsCommand
        {
            get
            {
                if (this.navigateAccountsCommand == null)
                {
                    this.navigateAccountsCommand = new RelayCommand(o => this.NavigateAccountsCommandAction());
                }
                return this.navigateAccountsCommand;
            }
        }

        private void NavigateAccountsCommandAction()
        {
            this.CurrentView = new AccountViewModel();
        }

        //
        private ICommand navigateReservationsCommand;
        public ICommand NavigateReservationsCommand
        {
            get
            {
                if (this.navigateReservationsCommand == null)
                {
                    this.navigateReservationsCommand = new RelayCommand(o => this.NavigateReservationsCommandAction());
                }
                return this.navigateReservationsCommand;
            }
        }

        private void NavigateReservationsCommandAction()
        {
            this.CurrentView = new ReservationsViewModel();
        }
    
        private ICommand userGuideCommand;
        public ICommand UserGuideCommand
        {
            get
            {
                if (this.userGuideCommand == null)
                {
                    this.userGuideCommand = new RelayCommand(o => this.UserGuideCommandAction());
                }
                return this.userGuideCommand;
            }
        }

        private void UserGuideCommandAction()
        {
            //Show dialog with user guide
        }

        private ICommand aboutCommand;
        public ICommand AboutCommand
        {
            get
            {
                if (this.aboutCommand == null)
                {
                    this.aboutCommand = new RelayCommand(o => this.AboutCommandAction());
                }
                return this.aboutCommand;
            }
        }

        private void AboutCommandAction()
        {
            //Show About dialog 
        }
        
    }

}
