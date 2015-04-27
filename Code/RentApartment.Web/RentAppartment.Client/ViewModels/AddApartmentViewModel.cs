using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using RentAppartment.Client.Utils;
using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.ViewModels;

namespace RentAppartment.Client.Views
{
	public class AddApartmentViewModel : ViewModelBase
	{
		public class AccountDtoLite
		{
			public int AccountId { get; set; }

			public string ShowedInfo { get; set; }
		}

		public AddApartmentViewModel(PropertyDto property)
        {
            this.Appartment = property;
            var repo = RepositoryFactory.Instance.GetApartmentRepository();
            Amenities = new AmenitiesProvider(repo.GetAmenitites());
            Amenities.SetAmenitiesModel(property.C_Amenities.ToList());
			_accounts = repo.GetAccounts(property.Account.id, "", "");
			this.HomeTypes = new ObservableCollection<DictItem>(repo.GetHomeTypes().Select(item => new DictItem()
			{
				Id = item.Key,
				Value = item.Value
			}).ToList());
			this.Owners = GenerateSimpleAccount(_accounts);
            this.CanOwnerEnable = false;
			isUpdate = true;
        }

        public AddApartmentViewModel()
        {
            this.Appartment = new PropertyDto();
            var repo = RepositoryFactory.Instance.GetApartmentRepository();
            Amenities = new AmenitiesProvider(repo.GetAmenitites());
	        _accounts = repo.GetAccounts(null, "", "");
			this.HomeTypes = new ObservableCollection<DictItem>(repo.GetHomeTypes().Select(item => new DictItem()
			{
				Id = item.Key,
				Value = item.Value
			}).ToList());

			this.Owners = GenerateSimpleAccount(_accounts);
            this.CanOwnerEnable = true;
        }

		private List<AccountDtoLite> GenerateSimpleAccount(List<AccountDto> accounts)
		{
			var generatedAccount = new List<AccountDtoLite>();

			if (accounts == null)
				return generatedAccount;
			try
			{
				generatedAccount = accounts.Select(acc => new AccountDtoLite
											{
												AccountId = acc.id,
												ShowedInfo = string.Format("Name: {0}  {1}; Addres: {2}", acc.FirstName, acc.LastName, acc.City)
											}).ToList();
			}
			catch (Exception)
			{
				
			}

			return generatedAccount;
		}

		private AccountDto GetAccountFromSimple()
		{
			var account = new AccountDto();
			try
			{
				//if (OwnerSelectedItem != null)
				{
					account = _accounts.Where(acc => acc.id == OwnerSelectedItem.AccountId).FirstOrDefault();
				}
					
				
			}
			catch (Exception)
			{
				
				throw;
			}

			return account;
		}

		public class DictItem
		{
			public int Id { get; set; }

			public string Value { get; set; }
		}
		private DictItem homeTypeSelectedItem;
		public DictItem HomeTypeSelectedItem
		{
			get
			{
				return this.homeTypeSelectedItem;
			}
			set
			{
				if (this.homeTypeSelectedItem != value)
				{
					this.homeTypeSelectedItem = value;
					OnPropertyChanged("HomeTypeSelectedItem");
				}
			}
		}

		public ObservableCollection<DictItem> HomeTypes { get; private set; }

		private List<AccountDto> _accounts;

		public class ImageData
		{
            public string Id { get; set; }
			public string Value { get; set; }
		}

        private bool isUpdate = false;

        private bool canOwnerEnable;
        public bool CanOwnerEnable
        {
            get
            {
                return this.canOwnerEnable;
            }
            set
            {
                if (this.canOwnerEnable != value)
                {
                    this.canOwnerEnable = value;
                    OnPropertyChanged("CanOwnerEnable");
                }
            }
        }
		private List<AccountDtoLite> owners;
		public List<AccountDtoLite> Owners
        {
            get
            {
                return this.owners;
            }
            set
            {
                if (this.owners != value)
                {
                    this.owners = value;
                    OnPropertyChanged("Owners");
                }
            }
        }

		private AccountDtoLite ownerSelectedItem;
		public AccountDtoLite OwnerSelectedItem
        {
            get
            {
				return this.ownerSelectedItem;
            }
            set
            {
				if (this.ownerSelectedItem != value)
                {
					this.ownerSelectedItem = value;
					OnPropertyChanged("OwnerSelectedItem");
                }
            }
        }
        

        private AmenitiesProvider amenities;
        public AmenitiesProvider Amenities
        {
            get
            {
                return this.amenities;
            }
            set
            {
                if (this.amenities != value)
                {
                    this.amenities = value;
                    OnPropertyChanged("Amenities");
                }
            }
        }
        private PropertyDto appartment;
        public PropertyDto Appartment
        {
            get
            {
                return this.appartment;
            }
            set
            {
                if (this.appartment != value)
                {
                    this.appartment = value;
                    OnPropertyChanged("Appartment");
                }
            }
        }

		private List<ImageData> imagesUrl;
        public List<ImageData> ImagesUrl
		{
			get
			{
				return this.imagesUrl;
			}
			set
			{
				if (this.imagesUrl != value)
				{
					this.imagesUrl = value;
					OnPropertyChanged("ImagesUrl");
				}
			}
		}

        private ImageData selectedImage;
        public ImageData SelectedImage
        {
            get
            {
                return this.selectedImage;
            }
            set
            {
                if (this.selectedImage != value)
                {
                    this.selectedImage = value;
                    OnPropertyChanged("SelectedImage");
                }
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

        private ICommand deleteImageCommand;
        public ICommand DeleteImageCommand
		{
			get
			{
                if (this.deleteImageCommand == null)
				{
                    this.deleteImageCommand = new RelayCommand(o => this.DeleteImageAction());
				}
                return this.deleteImageCommand;
			}
		}

        
        private ICommand saveCommand;
        public ICommand SaveCommand
		{
			get
			{
                if (this.saveCommand == null)
				{
                    this.saveCommand = new RelayCommand(o => this.SavePropertyAction());
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
        
        private void SavePropertyAction()
        {
            try
            {
                PropertyDto ap = this.Appartment;
                if (ap != null)
                {
                    ap.C_Amenities = this.Amenities.GetSelectedAmenitites().ToArray();
                    var repo = RepositoryFactory.Instance.GetApartmentRepository();
					ap.Account = isUpdate == true ? this.Appartment.Account : GetAccountFromSimple();
                    repo.UpdateProperty(ap);

                    CloseAction(); 
                }
              
               
            }
            catch (Exception)
            {
                
                throw;
            }
        }
            
        private void DeleteImageAction()
        {
            try
            {
                //First step: copy the actual list to a temporary one
                var tempCollection = new List<ImageData>(this.ImagesUrl);
            
                tempCollection.RemoveAll(item => item.Id == this.SelectedImage.Id);
                this.ImagesUrl = tempCollection;
                
    
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        
		private void LoadImagesCommandAction()
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Multiselect = true;
				openFileDialog.Filter = "Images files (*.png)|*.png|(*.jpg)|*.jpg|All files (*.*)|*.*";
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				if (openFileDialog.ShowDialog() == true)
				{
					//add items to image list

                    var list = new List<ImageData>();
                    
					foreach (string filename in openFileDialog.FileNames)
					{
                        var image = new ImageData();
                        image.Id = Guid.NewGuid().ToString();
						image.Value = filename;

						list.Add(image);
					}
					ImagesUrl = list;

				}
			}
			catch (Exception)
			{
                throw;
			}
		}
	}
}
