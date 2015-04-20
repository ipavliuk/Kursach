using RentAppartment.Client.DataAccess;
using RentAppartment.Client.RApmentAdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAppartment.Client.Utils
{
    public class RepositoryFactory
    {
        #region Initialisation Singlenton
        private RepositoryFactory() { }

        private static readonly Lazy<RepositoryFactory> _instance =
            new Lazy<RepositoryFactory>(() => new RepositoryFactory(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        public static RepositoryFactory Instance
		{
			get 
			{ return _instance.Value; }
		}

		#endregion

        public IRApmentAdministration Service { get; set; }

        public AppartmentsRepository GetApartmentRepository()
        {
            return new AppartmentsRepository(Service);
        }

        
    }
}
