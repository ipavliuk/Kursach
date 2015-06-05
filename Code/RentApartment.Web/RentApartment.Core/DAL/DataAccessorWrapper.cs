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
		private const string spAccountAuthenticate = "AccountAuthenticate";
		private const string spAccountGetbyEmail = "AccountGetbyEmail";
		private const string spAccountGetbyId = "AccountGetbyId";
		private const string spAccountGetAll = "AccountGetAll";
		private const string spAccountDelete = "AccountDelete";

		private static readonly ILog log = LogManager.GetLogger(typeof (DataAccessorWrapper));

		public int CreateAccount(string accountSystemId, string passwordHash, string firstName, string lastName, string email, int countryId, byte gender, bool passErrorParams = true)
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
					command.Parameters.AddWithValue("Gender", gender);
					if (passErrorParams)
					{
						command.Parameters.Add(new SqlParameter("@O_ErrCode", SqlDbType.Int, 4) { Direction = ParameterDirection.Output });
						command.Parameters.Add(new SqlParameter("@O_ErrMsg", SqlDbType.VarChar, 2000) { Direction = ParameterDirection.Output });
					}

					newId = Convert.ToInt32(command.ExecuteScalar());
				}
			}
			catch (Exception ex)
			{
				log.Error("Exception when creating Account", ex);
			}

			return newId;
		}

		public Account GetAccountGetbyId(int accountId, bool passErrorParams = false)
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
					if (passErrorParams)
					{
						command.Parameters.Add(new SqlParameter("@O_ErrCode", SqlDbType.Int, 4) { Direction = ParameterDirection.Output });
						command.Parameters.Add(new SqlParameter("@O_ErrMsg", SqlDbType.VarChar, 2000) { Direction = ParameterDirection.Output });
					}
					
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

		public Account GetAccountByPwd(string login, string pwdHash, bool passErrorParams = true)
		{

			Account a = new Account();
			try
			{
				using (var conn = GetConnection())
				using (SqlCommand command = new SqlCommand(spAccountAuthenticate, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					command.Parameters.AddWithValue("Login", login);
					
					command.Parameters.AddWithValue("PwdHash", pwdHash);
					if (passErrorParams)
					{
						command.Parameters.Add(new SqlParameter("@O_ErrCode", SqlDbType.Int, 4) { Direction = ParameterDirection.Output });
						command.Parameters.Add(new SqlParameter("@O_ErrMsg", SqlDbType.VarChar, 2000) { Direction = ParameterDirection.Output });
					}

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

		public Account GetAccountByEmail(string email, bool passErrorParams = false)
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
					if (passErrorParams)
					{
						command.Parameters.Add(new SqlParameter("@O_ErrCode", SqlDbType.Int, 4) { Direction = ParameterDirection.Output });
						command.Parameters.Add(new SqlParameter("@O_ErrMsg", SqlDbType.VarChar, 2000) { Direction = ParameterDirection.Output });
					}

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

		public void DeleteAccount(int id, bool passErrorParams = true)
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
					if (passErrorParams)
					{
						command.Parameters.Add(new SqlParameter("@O_ErrCode", SqlDbType.Int, 4) { Direction = ParameterDirection.Output });
						command.Parameters.Add(new SqlParameter("@O_ErrMsg", SqlDbType.VarChar, 2000) { Direction = ParameterDirection.Output });
					}

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
	}
}
