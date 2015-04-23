using RentAppartment.Client.Utils;
using RentAppartment.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentAppartment.Client.ViewModels
{
    public class ReservationsViewModel : ViewModelBase
    {




        //commands
        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new RelayCommand(o => this.SearchAction());
                }
                return this.searchCommand;
            }
        }

        private void SearchAction()
        {
            throw new NotImplementedException();
        }
    }
}
