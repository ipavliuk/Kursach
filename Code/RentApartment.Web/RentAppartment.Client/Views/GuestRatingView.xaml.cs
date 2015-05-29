using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RentAppartment.Client.Views
{
	/// <summary>
	/// Interaction logic for GuestRatingView.xaml
	/// </summary>
	public partial class GuestRatingView : Window
	{
		public GuestRatingView()
		{
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			InitializeComponent();
		}

		private void rtFifteen_RatingChanged(object sender, RatingChangedEventArgs e)
		{
			this.txtScore.Text = rtFifteen.Value.ToString();
		}



	}
}
