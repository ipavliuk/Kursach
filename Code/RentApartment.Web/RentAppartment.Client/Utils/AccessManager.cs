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

        public bool GetViewAccess(string role, string view)
        {
            bool isAccessed = false;
            try 
	        {
                if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(view))
                {
                    return true;
                }
                     
		         string access = config.UserRole.Single(ur => ur.Role == role).AccessType;
                 var views = config.AccesTypesSpec.Single(at => at.AccessType == access).Views;
                 isAccessed = views.Single(v => v.View == view).Access == "Disabled" ? false : true;
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
           
            return isAccessed;
        }

        public bool GetViewControlAccess(string role, string view, string control)
        {
            bool isAccessed = false;
            try
            {
                if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(view) || string.IsNullOrEmpty(control))
                {
                    return true;
                }

                List<ViewCtrl> views = config.UserRole.Single(ur => ur.Role == role).Views;
                if (views != null)
                {
                    List<Control> controls = views.SingleOrDefault(v => v.View == view).Controls;
                    var permission = controls.SingleOrDefault(ctrl => ctrl.Name == control);

                    isAccessed = permission.Permis != null && permission.Permis == "Disabled" ? false : true;
                }
                else
                {
                    isAccessed = true;
                }

            }
            catch (Exception)
            {
                
                throw;
            }
            
            return isAccessed;
        }
	}
}
