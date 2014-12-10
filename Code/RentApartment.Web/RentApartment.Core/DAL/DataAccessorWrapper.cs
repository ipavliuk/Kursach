using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using log4net;
using RentApartment.Core.Model.EF;

namespace RentApartment.Core.DAL
{
	public class DataAccessorWrapper
	{
		private const string spAccountCreate = "AccountCreate";
		private const string spAccountUpdate = "AccountUpdate";
		private const string spAccountGetbyPassword = "AccountGetbyPassword";
		private const string spAccountGetbyEmail = "AccountGetbyEmail";
		private const string spAccountGetbyId = "AccountGetbyId";
		private const string spAccountGetAll = "AccountGetAll";
		private const string spAccountDelete = "AccountDelete";

		private static readonly ILog log = LogManager.GetLogger(typeof (DataAccessorWrapper));
		//_CountryGetById
		//_RolesGetById

		public int CreateAccount(string accountSystemId, string passwordHash, string firstName, string lastName, string email, int countryId)
		{
			int newId = 0;
			try
			{
				using (var conn = GetConnection())
				using (SqlCommand command = new SqlCommand(spAccountCreate, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					command.Parameters.AddWithValue("AccountId", accountSystemId);
					command.Parameters.AddWithValue("PasswordHash", passwordHash);
					command.Parameters.AddWithValue("FirstName", firstName);
					command.Parameters.AddWithValue("LastName", lastName);
					command.Parameters.AddWithValue("Email", email);
					command.Parameters.AddWithValue("Country", countryId);

					newId = Convert.ToInt32(command.ExecuteScalar());
					
					
				}
			}
			catch (Exception ex)
			{
				log.Error("Exception when creating Account", ex);
			}

			return newId;
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
			catch (Exception ex)
			{
				log.Error("Exception when getting Account by id", ex);
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
			catch (Exception ex)
			{
				log.Error("Exception when getting Account by pwd", ex);
			}

			return a;
		}

		public Account GetAccountByEmail(string email)
		{

			Account a = new Account();
			try
			{
				using (var conn = GetConnection())
				using (SqlCommand command = new SqlCommand(spAccountGetbyEmail, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					command.Parameters.AddWithValue("Email", email);


					using (var reader = command.ExecuteReader())
					{

						if (reader.Read())
						{
							a.CreateAccount(reader);
						}
					}
				}
			}
			catch (Exception ex)
			{
				log.Error("Exception when getting Account by email", ex);
			}

			return a;
		}

		public IList<Account> GetAccounts()
		{
			List<Account> acounts = new List<Account>();

			try
			{
				using (var conn = GetConnection())
				using (SqlCommand command = new SqlCommand(spAccountGetAll, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					//command.Parameters.AddWithValue("Email", email);
					//using (var reader = command.ExecuteReader())
					//{

					//	if (reader.Read())
					//	{
					//		a.CreateAccount(reader);
					//	}
					//}
					DataSet ds = new DataSet();
					SqlDataAdapter adapter = new SqlDataAdapter(command);
					adapter.Fill(ds);

					if (ds.Tables.Count >= 1)
					{
						acounts = ds.Tables[0].AsEnumerable().Select(row =>
						{
							Account a = new Account();
							a.CreateAccount(row);
							return a;
						}).ToList();
					}


				}
			}
			catch (Exception ex)
			{
				log.Error("Exception when getting Account by email", ex);
			}

			return acounts;
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
			catch (Exception ex)
			{
				log.Error("Exception when deleting Account by id", ex);
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
