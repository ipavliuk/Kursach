using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWPF.ViewModel
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		internal void RaisePropertyChanged(string property)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(property));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
