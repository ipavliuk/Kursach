using RentAppartment.Client.RApmentAdminService;
using RentAppartment.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAppartment.Client.ViewModels
{
    public class ApartmentViewModel : ViewModelBase
    {

        private PropertyDto _appartment;

        public ApartmentViewModel(PropertyDto appartmernt)
        {
            _appartment = appartmernt;
        }

        public ApartmentViewModel()
        {

        }
    }
}
