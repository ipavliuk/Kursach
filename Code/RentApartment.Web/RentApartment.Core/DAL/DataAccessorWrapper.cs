﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using RentApartment.Core.Model;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.DAL
{
	public class DataAccessorWrapper
	{
		private const string spAccountCreate = "AccountCreate";
		private const string spAccountUpdate = "AccountUpdate";
		private const string spAccountGetbyPassword = "AccountGetbyPassword";
		private const string spAccountGetbyId = "AccountGetbyId";
		private const string spAccountGetAll = "AccountGetAll";
		private const string spAccountDelete = "AccountDelete";

		//_CountryGetById
		//_RolesGetById

		public void CreateAccount(int accountId, string passwordHash, string firstName, string lastName, string email, int countryId)
		{
			try
			{
				using (var conn = GetConnection())
				using (SqlCommand command = new SqlCommand(spAccountCreate, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{	
					command.Parameters.AddWithValue("AccountId", accountId);
					command.Parameters.AddWithValue("PasswordHash", passwordHash);
					command.Parameters.AddWithValue("FirstName", firstName);
					command.Parameters.AddWithValue("LastName", lastName);
					command.Parameters.AddWithValue("Email", email);
					command.Parameters.AddWithValue("Country", countryId);

					command.ExecuteNonQuery();
					
				}
			}
			catch (Exception)
			{
				
			}
		}

		public Account GetAccountGetbyId(int accountId)
		{
			Account a = new Account();

			try
			{
				using (var conn = GetConnection())
				using (SqlCommand command = new SqlCommand(spAccountGetbyId, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					command.Parameters.AddWithValue("Acc_Id", accountId);
					
					
					using (var reader = command.ExecuteReader())
					{
						
						if (reader.Read())
						{
							a.CreateAccount(reader);
						}
					}
				}
			}
			catch (Exception)
			{

			}

			return a;
		}

		public Account GetAccountByPwd(string pwdHash)
		{

			Account a = new Account();
			try
			{
				using (var conn = GetConnection())
				using (SqlCommand command = new SqlCommand(spAccountGetbyPassword, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					command.Parameters.AddWithValue("PwdHash", pwdHash);


					using (var reader = command.ExecuteReader())
					{

						if (reader.Read())
						{
							a.CreateAccount(reader);
						}
					}
				}
			}
			catch (Exception)
			{

			}

			return a;
		}
		public void DeleteAccount(int id)
		{
			try
			{
				using (var conn = GetConnection())
				using (SqlCommand command = new SqlCommand(spAccountDelete, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					command.Parameters.AddWithValue("Acc_Id", id);
					

					command.ExecuteNonQuery();
				}
			}
			catch (Exception)
			{

			}
		}
		private SqlConnection GetConnection()
		{
			//get opened sqlConnection
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["csRapment"].ConnectionString);
			conn.Open();

			return conn;
		}

		//private Account ConvertToAccount(SqlDataReader reader)
		//{
		//	try
		//	{
		//		Account acc = new Account();
		//		acc.id = Int32.Parse(reader["id"].ToString());
		//		acc.AccountId = reader["AccountId"].ToString();
		//		acc.PasswordHash = reader["PasswordHash"].ToString();
		//		acc.FirstName = reader["PasswordHash"].ToString();
		//		acc.LastName = reader["LastName"].ToString();
		//		acc.Email = reader["Email"].ToString();
		//		acc.IsEmailConfirmed = Boolean.Parse(reader["IsEmailConfirmed"].ToString());
		//		//[FK__Country]
		//		//[FK__Roles]
		//		acc.City = reader["City"].ToString();
		//		acc.Address = reader["Address"].ToString();
		//		acc.Mobile = reader["Mobile"].ToString();
		//		string gender = reader["Gender"].ToString();

		//		acc.Gender = string.IsNullOrEmpty(gender) ? (Byte?)Byte.Parse(gender) : null;
		//		acc.PostalCode = reader["PostalCode"].ToString();

		//		string lang = reader["Language"].ToString();
		//		acc.Language = string.IsNullOrEmpty(lang) ? (int?)Int32.Parse(lang): null;

		//		acc.IsValidated = Boolean.Parse(reader["IsValidated"].ToString());
		//		acc.ImageSourceId = reader["ImageSourceId"].ToString();

		//	}
		//	catch (Exception)
		//	{
				
		//		throw;
		//	}
			
		//}
		
	}
}
