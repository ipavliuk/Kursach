﻿using RentAppartment.Client.Utils;
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
	    private const string LOG_IN = "Log In";
		private const string LOG_OUT = "Log Out";
        private const string LOG_IN_Text = "Увійдіть у систему...";
        private const string Welcome_Text = "Вітаємо користувача, ";

		public MainViewModel()
		{
			this.SignInOutText = LOG_IN;
            this.LoginText = LOG_IN_Text;
            this.CurrentView = new WelcomePageView();
			AccessManager.Instance.LoadConfig();
			this.AvatarImage = "../Images/_user.png";
            this.IsScheduleViewAccessed = true;
            this.IsAccountViewAccessed = true;
		}

	    

	    
        private string avatarImage;
		public string AvatarImage
        {
			get { return avatarImage; }
            private set
            {
				avatarImage = value;
				OnPropertyChanged("AvatarImage");
            }
        }
		private string loginText;
		public string LoginText
		{
			get { return loginText; }
			private set
			{
				loginText = value;
				OnPropertyChanged("LoginText");
			}
		}

        private string loginName;
        public string LoginName
        {
            get { return loginName; }
            private set
            {
                loginName = value;
                OnPropertyChanged("LoginName");
            }
        }
        private string loginUserRole;
        public string LoginUserRole
        {
            get { return loginUserRole; }
            private set
            {
                loginUserRole = value;
                OnPropertyChanged("LoginUserRole");
            }
        }
		private bool isLogedIn;
		public bool IsLogedIn
        {
			get { return isLogedIn; }
            private set
            {
				isLogedIn = value;
				OnPropertyChanged("IsLogedIn");
            }
        }

        private bool isAdmin;
        public bool IsAdmin
        {
            get { return isAdmin; }
            private set
            {
                isAdmin = value;
                OnPropertyChanged("IsAdmin");
            }
        }

		private string signInOutText;
		public string SignInOutText
		{
			get { return signInOutText; }
			private set
			{
				signInOutText = value;
				OnPropertyChanged("SignInOutText");
			}
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
        //Access view properties
        private bool isScheduleViewAccessed;
        public bool IsScheduleViewAccessed
        {
            get { return isScheduleViewAccessed; }
            private set
            {
                isScheduleViewAccessed = value;
                OnPropertyChanged("IsScheduleViewAccessed");
            }
        }

        private bool isAccountViewAccessed;
        public bool IsAccountViewAccessed
        {
            get { return isAccountViewAccessed; }
            private set
            {
                isAccountViewAccessed = value;
                OnPropertyChanged("IsAccountViewAccessed");
            }
        }

        public void SetAccessforControls()
        {
 
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

        private ICommand navigatePersonalPageCommand;
        public ICommand NavigatePersonalPageCommand
        {
            get
            {
                if (this.navigatePersonalPageCommand == null)
                {
                    this.navigatePersonalPageCommand = new RelayCommand(o => this.NavigatePersonalPageCommandAction());
                }
                return this.navigatePersonalPageCommand;
            }
        }

        private void NavigatePersonalPageCommandAction()
        {
            try
            {
                this.CurrentView = new PersonalPageViewModel(AuthenticateUserManager.Instance.Account);
            }
            catch (Exception)
            {
                
                throw;
            }
            
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

		private ICommand signInOutCommand;
		 public ICommand SignInOutCommand
        {
            get
            {
				if (this.signInOutCommand == null)
                {
					this.signInOutCommand = new RelayCommand(o => this.SignInOutCommandAction());
                }
				return this.signInOutCommand;
            }
        }

		 private void SignInOutCommandAction()
		 {
			 if (this.IsLogedIn)
			 {
				 AuthenticateUserManager.Instance.Logout();
				 this.SignInOutText = LOG_IN;
                 this.IsLogedIn = false;
                 this.IsAdmin = false;
                 this.LoginText = LOG_IN_Text;
                 this.AvatarImage = string.Empty;
                 this.IsAccountViewAccessed = true;
                 this.IsScheduleViewAccessed = true;
                 this.LoginName = "";
                 this.LoginUserRole = "";
                 this.CurrentView = new WelcomePageViewModel();
				 return;
			 }
			var view = new LoginView();
			var vm = new LoginViewModel(view);
			view.DataContext = vm;
			if (vm.CloseAction == null)
				 vm.CloseAction = new Action(() => view.Close());

			bool? res = view.ShowDialog();

			if (AuthenticateUserManager.Instance.IsLogedIn)
			{
				this.SignInOutText = LOG_OUT;
                this.IsAdmin = AuthenticateUserManager.Instance.IsAdmin();
                this.IsLogedIn = true;
                this.LoginText = Welcome_Text;
                this.LoginName = AuthenticateUserManager.Instance.GetUserNickName();
                this.LoginUserRole = AuthenticateUserManager.Instance.Account.RolesName;
                this.AvatarImage = AuthenticateUserManager.Instance.Account.PictureUrl;
                string role = AuthenticateUserManager.Instance.Account.RolesName;
                this.IsAccountViewAccessed = AccessManager.Instance.GetViewAccess(role,
                                    "AccountViews");
                this.IsScheduleViewAccessed = AccessManager.Instance.GetViewAccess(role,
                                    "Reservation");
			}
			else
			{
                this.IsLogedIn = false;
                this.IsAdmin = false;
                this.LoginText = LOG_IN_Text;
				this.AvatarImage = "../Images/_user.png";
                this.IsAccountViewAccessed = true;
                this.IsScheduleViewAccessed = true;
                this.LoginName = "";
                this.LoginUserRole = "";
			}
		}

        private void SetControlAvailability(string role)
        {
           // this.CurrentView = 
        }

	}

}

