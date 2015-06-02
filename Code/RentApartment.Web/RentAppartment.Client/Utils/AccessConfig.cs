using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RentAppartment.Client.Utils
{
	public class AccessConfig
	{
        public List<AccesTypesSpec> AccesTypesSpec { get; set; }
        public List<UserRole> UserRole { get; set; }
	}


    public class Views
    {
        public string View { get; set; }
        public string Access { get; set; }
    }

    public class AccesTypesSpec
    {
        public string AccessType { get; set; }
        public List<Views> Views { get; set; }
    }

    public class UserRole
    {
        public string Role { get; set; }
        public string AccessType { get; set; }
        public List<ViewCtrl> Views { get; set; }
    }
    public class Control
    {
        public string Name { get; set; }
        public string Permis { get; set; }
    }

    public class ViewCtrl
    {
        public string View { get; set; }
        public List<Control> Controls { get; set; }
    }

   
}
