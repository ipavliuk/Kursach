using System;
using System.Collections.Generic;
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
					foreach (string filename in openFileDialog.FileNames)
					{
						//lbFiles.Items.Add(Path.GetFileName(filename));
					}
						

				}
			}
			catch (Exception)
			{
				
			}
		}
	}
}
