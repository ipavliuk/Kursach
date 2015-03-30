using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using RentApartment.Core.Common;
using RentApartment.Core.Infrastructure;
using RentApartment.Core.Model.EF;
using RentApartment.Service.DataContract.Entities;
using RentApartment.Service.DataContract.Response;

namespace RentApartment.Service
{
	public class Dictionaries : IDictionaries
	{

		public Dictionaries()
		{
			Mapper.CreateMap<C_Country, CountryDto>();
			Mapper.CreateMap<C_Roles, RoleDto>();
			Mapper.CreateMap<C_Currency, CurrencyDto>();
			Mapper.CreateMap<C_Amenities, AmenityDto>();
		}

		public CountriesResponse GetCountries()
		{
			var response = new CountriesResponse();

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				IEnumerable<C_Country> countries = RentApartmentManager.Instance.GetCountries();
				//foreach (var item in countries)
				//{
				//	var country = new CountryDto()
				//	{
				//		Id = item.id,
				//		IsoCode =  item.IsoCode,
				//		Name = item.Name
				//	};
				//	response.Countries.Add(country);
				//}
				List<CountryDto> countriesDto = Mapper.Map<List<C_Country>, List<CountryDto>>(countries.ToList());
				response.Countries = countriesDto;
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

				IEnumerable<C_Roles> roles = RentApartmentManager.Instance.GetRoles();
				//foreach (var item in roles)
				//{
				//	var role = new Role()
				//	{
				//		RoleId = item.RoleId,
				//		RoleDescription = item.RoleDescription,
				//		RoleName = item.RoleName
				//	};
				//	response.Roles.Add(role);
				//}
				List<RoleDto> rolesDto = Mapper.Map<List<C_Roles>, List<RoleDto>>(roles.ToList());
				response.Roles = rolesDto;
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

				IEnumerable<C_Currency> currencies = RentApartmentManager.Instance.GetCurrencies();

				//foreach (var item in currencies)
				//{
				//	var currency = new CurrencyDto()
				//	{
				//		Id = item.Id,
				//		Name = item.Currency,
				//		Country = item.Country,
				//		Code = item.Code,
				//		Symbol = item.Symbol
				//	};
				//	response.Currensies.Add(currency);
				//}
				List<CurrencyDto> currenciesDto = Mapper.Map<List<C_Currency>, List<CurrencyDto>>(currencies.ToList());
				response.Currensies = currenciesDto;

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

				IEnumerable<C_Amenities> amenities = RentApartmentManager.Instance.GetAmenities();

				//foreach (var item in amenities)
				//{
				//	var amenity = new AmenityDto()
				//	{
				//		id = item.id,
				//		Name = item.Name,
				//		Description = item.Description,
				//		IsActive = item.IsActive
				//	};
				//	response.Amenities.Add(amenity);
				//}
				List<AmenityDto> amenitiesDto = Mapper.Map<List<C_Amenities>, List<AmenityDto>>(amenities.ToList());
				response.Amenities = amenitiesDto;
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
