using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RentApartment.Core.Common;
using RentApartment.Core.Infrastructure;
using RentApartment.Core.Model.EF;
using RentApartment.Service.DataContract.Request;
using RentApartment.Service.DataContract.Response;

namespace RentApartment.Service
{
	public class Accounts : IAccounts
	{

		public AuthenticationResponse Authenticate(AuthenticationRequest request)
		{
			var response = new AuthenticationResponse();


			if (request == null)
			{
				response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
				return response;
			}

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				Account acc = AdminManager.Instance.Authenticate(request.Login, request.Password);

				response.AuthenticationResult = acc != null && acc.id > 0;
				response.AccountProfile = TranslateAccountEntityToAccount(acc);
			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}

		public GetAccountProfileResponce GetAccountPropfile(GetAccountProfileRequest request)
		{
			var response = new GetAccountProfileResponce();


			if (request == null)
			{
				response.ErrorId = (int)RApmentErrors.FailedProceedRequest;
				return response;
			}

			if (request.AccountId < 1)
			{
				response.ErrorId = (int)RApmentErrors.NotAllMandatoryFields;
				response.ErrorDesc = "Not all mandatory fields";
				return response;
			}

			try
			{
				response.ErrorId = (int)RApmentErrors.Ok;

				Account acc = AdminManager.Instance.GetAccountById(request.AccountId);
				response.AccountProfile = TranslateAccountEntityToAccount(acc);

			}
			catch (Exception ex)
			{
				response.ErrorId = (int)RApmentErrors.OperationError;
				response.ErrorDesc = ex.Message;
				//Logger.Instance.Error("AuthenticateChatHost - ", ex);
			}

			return response;
		}

		private AccountProfile TranslateAccountEntityToAccount(Account accountEF)
		{

			if (accountEF == null)
				return new AccountProfile();

			AccountProfile acc = new AccountProfile()
			{
				id = accountEF.id,
				AccountId = accountEF.AccountId,
				Address = accountEF.Address,
				City = accountEF.City,
				Country = accountEF.C_Country.Name,
				Email = accountEF.Email,
				FirstName = accountEF.FirstName,
				Gender = accountEF.Gender,
				ImageSourceId = accountEF.ImageSourceId,
				IsEmailConfirmed = accountEF.IsEmailConfirmed,
				IsValidated = accountEF.IsValidated,
				Language = accountEF.Language,
				LastName = accountEF.LastName,
				Mobile = accountEF.Mobile,
				PostalCode = accountEF.PostalCode,
				Roles = accountEF.C_Roles.RoleName
			};

			return acc;
		}
	}
}
