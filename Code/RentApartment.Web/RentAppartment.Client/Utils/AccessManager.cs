using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RentAppartment.Client.Utils
{
	public class AccessManager
	{
		#region Initialisation Singlenton
        private AccessManager() { }

		private static readonly Lazy<AccessManager> _instance =
			new Lazy<AccessManager>(() => new AccessManager(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);

		public static AccessManager Instance
		{
			get 
			{ return _instance.Value; }
		}

		#endregion

		private AccessConfig config = new AccessConfig();

		public void LoadConfig()
		{
			try
			{
				using (var reader = new StreamReader("Configuration\\AccessConfig.json"))
				{
					string json = reader.ReadToEnd();
					config = JsonConvert.DeserializeObject<AccessConfig>(json);

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(string.Format("Exception during load data from random api => {0}", ex.Message));
			}
		}
	}
}
