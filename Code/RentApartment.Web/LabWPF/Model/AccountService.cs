using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWPF.AccountService;
using LabWPF.Utils;

namespace LabWPF.Model
{
	internal class AccountService
	{
		public Account Authenticate(string login, string password)
		{

			using (SafeWcfClient<AccountsClient, IAccounts> client = new SafeWcfClient<AccountsClient, IAccounts>())
			{
			}

			return  new Account();
		}
	}
}
