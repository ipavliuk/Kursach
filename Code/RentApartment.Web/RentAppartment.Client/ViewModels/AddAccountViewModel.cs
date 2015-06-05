using Microsoft.Win32;
using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Utils;
using RentAppartment.Client.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentAppartment.Client.ViewModels
{
    public class AddAccountViewModel : ViewModelBase
    {
		private readonly IPasswordSupplier _pwdSupplier;

        public AddAccountViewModel(IPasswordSupplier pwdSupplier)
        {
            this.Account = new AccountDto();
	        _pwdSupplier = pwdSupplier;
            Init();
        }

		public AddAccountViewModel(AccountDto acc, IPasswordSupplier pwdSupplier)
        {
            this.Account = acc;
			_pwdSupplier = pwdSupplier;
            Init();
            isUpdate = true;
            
			this.GenderTypeSelectedItem = new DictItem
            {
                Id = (int)acc.Gender,
                Value = acc.GenderName
            };

			this.RoleTypeSelectedItem = new DictItem
            {
                Id = (int)acc.Roles,
                Value = acc.RolesName
            };

			this.SelectedImagePath = new ImageData()
			{
				Value = acc.PictureUrl
			};
			this.SelectedBirthDate = acc.Birthday.HasValue ? (DateTime) acc.Birthday : DateTime.Now;
        }

        private void Init()
        {
            var repo = RepositoryFactory.Instance.GetApartmentRepository();
            this.GenderTypes = new ObservableCollection<DictItem>(repo.GetGenderTypes().Select(item => new DictItem()
            {
                Id = item.Key,
                Value = item.Value
            }).ToList());

			this.RoleTypes = new ObservableCollection<DictItem>(repo.GetUserRoles().Select(item => new DictItem()
			{
				Id = item.Key,
				Value = item.Value
			}).ToList());
        }
        private bool isUpdate = false;

        private ObservableCollection<DictItem> genderTypes;
        public ObservableCollection<DictItem> GenderTypes
        {
            get
            {
                return this.genderTypes;
            }
            set
            {
                if (this.genderTypes != value)
                {
                    this.genderTypes = value;
                    OnPropertyChanged("GenderTypes");
                }
            }
        }

        private DictItem genderTypeSelectedItem;
        public DictItem GenderTypeSelectedItem
        {
            get
            {
                return this.genderTypeSelectedItem;
            }
            set
            {
                if (this.genderTypeSelectedItem != value)
                {
                    this.genderTypeSelectedItem = value;
                    OnPropertyChanged("GenderTypeSelectedItem");
                }
            }
        }

		private ObservableCollection<DictItem> roleTypes;
        public ObservableCollection<DictItem> RoleTypes
        {
            get
            {
                return this.roleTypes;
            }
            set
            {
                if (this.roleTypes != value)
                {
                    this.roleTypes = value;
                    OnPropertyChanged("RoleTypes");
                }
            }
        }
		private DictItem roleTypeSelectedItem;
		public DictItem RoleTypeSelectedItem
		{
			get
			{
				return this.roleTypeSelectedItem;
			}
			set
			{
				if (this.roleTypeSelectedItem != value)
				{
					this.roleTypeSelectedItem = value;
					OnPropertyChanged("RoleTypeSelectedItem");
				}
			}
		}

        private AccountDto account;
        public AccountDto Account
        {
            get
            {
                return this.account;
            }
            set
            {
                if (this.account != value)
                {
                    this.account = value;
                    OnPropertyChanged("Account");
                }
            }
        }

        private ImageData selectedImagePath;
        public ImageData SelectedImagePath
        {
            get
            {
                return this.selectedImagePath;
            }
            set
            {
                if (this.selectedImagePath != value)
                {
                    this.selectedImagePath = value;
                    OnPropertyChanged("SelectedImagePath");
                }
            }
        }


		private DateTime selectedBirthDate;
		public DateTime SelectedBirthDate
        {
            get
            {
				return this.selectedBirthDate;
            }
            set
            {
				if (this.selectedBirthDate != value)
                {
					this.selectedBirthDate = value;
					OnPropertyChanged("SelectedBirthDate");
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
                    this.saveCommand = new RelayCommand(o => this.SaveAccountAction());
                }
                return this.saveCommand;
            }
        }

        private void SaveAccountAction()
        {
            try
            {
                AccountDto acc = this.Account;
                if (acc != null)
                {
                    acc.Gender = (byte?)GenderTypeSelectedItem.Id;
	                acc.Roles = (byte) RoleTypeSelectedItem.Id;
                    acc.PictureUrl = SelectedImagePath.Value;
                    acc.AccountId = Guid.NewGuid().ToString("d");
					acc.Birthday = this.selectedBirthDate;
	                string pwd = _pwdSupplier.GetPassword();
	                if (pwd == null)
	                {
						//[TODO] :Show message
	                }
					
						
					acc.PasswordHash = CryptoHelper.CreateMD5Hash(pwd);

                    var repo = RepositoryFactory.Instance.GetApartmentRepository();
                    if (isUpdate)
                    {
                        repo.UpdateAccount(acc);
                    }
                    else
                    {
                        repo.CreateAccount(acc);
                    }
                    

                    CloseAction();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private ICommand loadImagesCommand;
        public ICommand LoadImagesCommand
        {
            get
            {
                if (this.loadImagesCommand == null)
                {
                    this.loadImagesCommand = new RelayCommand(o => this.LoadImagesCommandAction());
                }
                return this.loadImagesCommand;
            }
        }

        private void LoadImagesCommandAction()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Images files (*.jpg)|*.jpg|(*.png)|*.png|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true)
                {
                    var image = new ImageData();
                    image.Id = Guid.NewGuid().ToString();
                    image.Value = openFileDialog.FileName;


                    SelectedImagePath = image;

                }
            }
            catch (Exception)
            {
                throw;
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


    }
}
