	using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWPF.ViewModel
{
	class MainViewModel : ViewModelBase
	{


		private bool isUserLogedIn;
		public bool IsUserLogedIn
		{
			get { return isUserLogedIn; }
			set
			{
				if (value.Equals(isUserLogedIn)) return;
				isUserLogedIn = value;
				RaisePropertyChanged("IsUserLogedIn");
			}
		}
	}
}
