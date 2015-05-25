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


	public class AccesTypesSpec
	{
		[JsonProperty("FullAccess")]
		public FullAccess FullAccess { get; set; }

		[JsonProperty("AdminAccess")]
		public AdminAccess AdminAccess { get; set; }

		[JsonProperty("ClientAccess")]
		public ClientAccess ClientAccess { get; set; }
	}

	public class Views
	{
		public string PropertyListingView { get; set; }
		public string AccountViews { get; set; }
		public string Reservation { get; set; }
		public string PersonalPage { get; set; }
	}

	public class FullAccess
	{
		public Views Views { get; set; }
	}

	public class AdminAccess
	{
		public Views Views { get; set; }
	}


	public class ClientAccess
	{
		public Views Views { get; set; }
	}

	public class Admin
	{
		public string AccessType { get; set; }
	}

	public class PropertyViewControls
	{
		public string txtCity { get; set; }
		public string txtIdOwner { get; set; }
		public string txtIdProperty { get; set; }
		public string apartmentType { get; set; }
		public string roomNumber { get; set; }
		public string gridPropertyList { get; set; }
	}

	public class PropertyListingView
	{
		public PropertyViewControls Controls { get; set; }
	}

	public class Client
	{
		public string AccessType { get; set; }
		public PropertyListingView PropertyListingView { get; set; }
	}

	public class UserRole
	{
		public string God { get; set; }
		public Admin Admin { get; set; }
		public Client Client { get; set; }
	}

}
