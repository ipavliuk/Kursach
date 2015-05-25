using RentAppartment.Client.RApmentAdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAppartment.Client.Utils
{
    public class AuthenticateUserManager
    {
        #region Initialisation Singlenton
        private AuthenticateUserManager() { }

        private static readonly Lazy<AuthenticateUserManager> _instance =
            new Lazy<AuthenticateUserManager>(() => new AuthenticateUserManager(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

        public static AuthenticateUserManager Instance
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

	    public bool SignIn(string login, string password)
	    {

			try
			{
				var repo = RepositoryFactory.Instance.GetApartmentRepository();
				AccountDto acc = repo.Authenticate(login, password);
				if (acc != null)
				{
					Account = acc;
					return true;
				}

			}
		    catch (Exception)
		    {
			    
			    throw;
		    }
		    return false;
	    }

	    public void Logout()
        {
            Account = null;

        }

        public bool IsAdmin()
        {
            return true;
            if (Account != null && Account.Roles == "Admin")
            {
                return true;
            }

            return false;
           // Account.Roles == 
        }

        public string GetUserNickName()
        {
            if (Account != null)
            {
                return Account.Login;
            }
            return null;
        }
    }
}
