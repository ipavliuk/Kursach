﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RentAppartment.Client.Views;
using RentAppartment.Client.ViewModels;

namespace RentAppartment.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			//Create MainViewModel
            DataContext = new MainViewModel();
			//DataContext = new PropertyListingViewModel();
		}
    }
}
