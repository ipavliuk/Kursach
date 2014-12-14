using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RentApartment.Core.Common;
using RentApartment.Core.Infrastructure;
using RentApartment.Core.Model.EF;
using RentApartment.Service.DataContract.Entities;
using RentApartment.Service.DataContract.Response;

namespace RentApartment.Service
{
	public class Dictionaries : IDictionaries
	{

		public CountriesResponse GetCountries()
		{
			var response = new CountriesResponse();

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				IEnumerable<C_Country> countries = AdminManager.Instance.GetCountries();
				foreach (var item in countries)
				{
					var country = new Country()
					{
						Id = item.id,
						IsoCode =  item.IsoCode,
						Name = item.Name
					};
					response.Countries.Add(country);
				}

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}

		public RolesResponse GetRoles()
		{
			var response = new RolesResponse();

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				IEnumerable<C_Roles> roles = AdminManager.Instance.GetRoles();
				foreach (var item in roles)
				{
					var role = new Role()
					{
						RoleId = item.RoleId,
						RoleDescription = item.RoleDescription,
						RoleName = item.RoleName
					};
					response.Roles.Add(role);
				}

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}

		public CurrenciesResponse GetCurrencies()
		{
			var response = new CurrenciesResponse();

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				IEnumerable<C_Currency> currencies = AdminManager.Instance.GetCurrencies();

				foreach (var item in currencies)
				{
					var currency = new Currency()
					{
						Id = item.Id,
						Name = item.Currency,
						Country = item.Country,
						Code = item.Code,
						Symbol = item.Symbol
					};
					response.Currensies.Add(currency);
				}

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}

		public AmenitiesResponse GetAmenities()
		{
			var response = new AmenitiesResponse();

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				IEnumerable<C_Amenities> amenities = AdminManager.Instance.GetAmenities();

				foreach (var item in amenities)
				{
					var amenity = new Amenity()
					{
						id = item.id,
						Name = item.Name,
						Description = item.Description,
						IsActive = item.IsActive
					};
					response.Amenities.Add(amenity);
				}

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}
	}
}
