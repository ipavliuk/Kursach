using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RentAppartment.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.SetupService();

            //ContainerViewModel viewModel = new ContainerViewModel();
            //viewModel.Initialize();
            //viewModel.View.Show();
        }

        private void SetupService()
        {
            RepositoryFactory.Instance.Service = new  RApmentAdministrationClient();
			//var rep = RepositoryFactory.Instance.GetApartmentRepository();
			//var list = rep.GetProperties("Phoenix", null, null, null, null);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            RApmentAdministrationClient service = RepositoryFactory.Instance.Service as RApmentAdministrationClient;
            if (service != null)
            {
                service.Close();
            }
            base.OnExit(e);
        }
    }
}
