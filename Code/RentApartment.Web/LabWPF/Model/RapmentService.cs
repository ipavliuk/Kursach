using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWPF.AccountService;
using LabWPF.RApmentAdministrationService;
using LabWPF.Utils;

namespace LabWPF.Model
{
	internal class RapmentService
	{
		public void GetReservations(int? accountId, DateTime? startDate, DateTime? endDate, int status)
		{
			//using (SafeWcfClient<, > client = new SafeWcfClient<ProviderClient, IProvider>())
			//{
			//	try
			//	{
			//		GenericConfigurableEntity config;
			//		Logger.Instance.Info("Getting configuration for server: " + ServerId);
			//		int errorCode = client.Client.GetConfigurationForEntity(ServerId, false, out config);
			//		if (errorCode == 0)
			//		{
			//			Logger.Instance.Info("Got server configuration for server: " + ServerId);

			//			return config;
			//		}
			//		else
			//		{
			//			Logger.Instance.Fatal("Failed to get config for GS {0}", ServerId);
			//		}
			//	}
			//	catch (Exception e)
			//	{
			//		Logger.Instance.Fatal("Error when getting configuration for server", e);
			//	}
			//}

			using (var client = new SafeWcfClient<RApmentAdministrationClient, IRApmentAdministration>())
			{
				
			}
		}
	}
}
