using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using RentAppartment.Client.Utils;

namespace RentAppartment.Client.ViewModels
{
	public class AddApartmentViewModel : ViewModelBase
	{
		public class Url
		{
			public string Value { get; set; }
		}

		private List<Url> imagesUrl;
		public List<Url> ImagesUrl
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
				openFileDialog.Multiselect = true;
				openFileDialog.Filter = "Images files (*.png)|*.png|(*.jpg)|*.jpg|All files (*.*)|*.*";
				openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				if (openFileDialog.ShowDialog() == true)
				{
					//add items to image list

					var list = new List<Url>();
					foreach (string filename in openFileDialog.FileNames)
					{
						var url = new Url();
						url.Value = filename;

						list.Add(url);
					}
					ImagesUrl = list;

				}
			}
			catch (Exception)
			{
				
			}
		}
	}
}
