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
using System.Windows.Shapes;
using RentAppartment.Client.Utils;

namespace RentAppartment.Client.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
	public partial class LoginView : Window, IPasswordSupplier
    {
        public LoginView()
        {
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

		public string GetPassword()
		{
			return pwdBox.Password;
		}
	}
}
