using RentAppartment.Client.RApmentAdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAppartment.Client.Utils
{
    public class UserManager
    {
        #region Initialisation Singlenton
        private UserManager() { }

        private static readonly Lazy<UserManager> _instance =
            new Lazy<UserManager>(() => new UserManager(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        public static UserManager Instance
		{
			get 
			{ return _instance.Value; }
		}

		#endregion

        public AccountDto Account { get; set; }

        public bool IsLogedIn { get 
                                {
                                    return Account != null; 
                                } 
                                
                              }

        public void logout()
        {
            Account = null;

        }
    }
}
