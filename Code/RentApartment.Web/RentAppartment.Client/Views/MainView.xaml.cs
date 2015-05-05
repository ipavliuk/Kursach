using RentAppartment.Client.ViewModels;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //Create MainViewModel
            DataContext = new MainViewModel();

            //var view = new LoginView();
            //var vm = new LoginViewModel();
            //view.DataContext = vm;
            //view.ShowDialog();

            //DataContext = new PropertyListingViewModel();
        }
    }
}
