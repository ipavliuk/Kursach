using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using RentApartment.Core.DAL.DBAccessor.Entities;
using WI.ChatServer.Core.DataBaseAccess;

namespace RentApartment.Core.DAL.DBAccessor
{
	public class DataAccessor: IDataAccessor
	{
		/// <summary>
		/// Calling SP which returns Selected data from DB
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="connectionString"></param>
		/// <param name="spName"></param>
		/// <param name="passErrorParams"></param>
		/// <param name="convertDataTableToObjFunc"></param>
		/// <param name="addParametersAction"></param>
		/// <returns></returns>
		public ListDbResponse<T> ExecuteStoredProcedure<T>(string connectionString, 
												 string spName, 
												 bool passErrorParams, 
												 Func<DataRow, T> convertDataTableToObjFunc, 
												 Action<SqlConnection, SqlCommand> addParametersAction)
		{
			try
			{
				if (convertDataTableToObjFunc == null)
				{
					throw new ArgumentNullException("convertDataTableToObjFunc");
				}

				if (addParametersAction == null)
				{
					throw new ArgumentNullException("addParametersAction");
				}


				using (var conn = new SqlConnection(connectionString))
				using (var command = new SqlCommand(spName, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					//TODO: check with DBA output parameters can have different names
					if (passErrorParams)
					{
						command.Parameters.Add(new SqlParameter("@O_ErrCode", SqlDbType.Int, 4) { Direction = ParameterDirection.Output });
						command.Parameters.Add(new SqlParameter("@O_ErrMsg", SqlDbType.VarChar, 2000) { Direction = ParameterDirection.Output });
					}

					conn.Open();
					addParametersAction(conn, command);



					DataSet ds = new DataSet();
					using (SqlDataAdapter da = new SqlDataAdapter(command))
					{
						// Fill the DataSet using default values for DataTable names, etc
						da.Fill(ds);
					}

					List<T> returnedList = null;
					if (ds.Tables.Count >= 1)
						returnedList = ds.Tables[0].AsEnumerable().Select(row => convertDataTableToObjFunc(row)).ToList();

					ListDbResponse<T> listWithError = new ListDbResponse<T>
					{
						DbList = returnedList
					};


					if (passErrorParams)
					{
						listWithError.ErrorCode = (int)command.Parameters["@O_ErrCode"].Value;
						listWithError.ErrorMessage = command.Parameters["@O_ErrMsg"].Value as string;
					}
					else
					{
						listWithError.ErrorCode = DataBaseResponse.ErrorCodeSuccess;
						listWithError.ErrorMessage = String.Empty;
					}

					foreach (SqlParameter param in command.Parameters)
					{
						if (param.Direction == ParameterDirection.Input || param.Direction == ParameterDirection.InputOutput)
						{
							object paramVal = command.Parameters[param.ParameterName].Value;
							listWithError.OutputParams.Add(param.ParameterName, paramVal);
						}
					}

					return listWithError;
				}
			}
			catch (Exception ex)
			{
				//Logger.Instance.Error(string.Format("Exception was thrown in DataAccessor.ExecuteSoredProcedure. BD => {0} \n SP => {1}", connectionString, spName), ex);
				throw;
			}

			
		}

		/// <summary>
		/// Calling SP which can INSERT, DELETE, UPDATE to DB
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="spName"></param>
		/// <param name="passErrorParams"></param>
		/// <param name="addParametersAction"></param>
		/// <returns></returns>
		public DataBaseResponse ExecuteStoredProcedure(string connectionString, 
											string spName, 
											bool passErrorParams, 
											Action<SqlConnection, SqlCommand> addParametersAction)
		{
			try
			{
				if (addParametersAction == null)
				{
					throw new ArgumentNullException("addParametersAction");
				}

				DataBaseResponse dbResponse = null;


				using (var conn = new SqlConnection(connectionString))
				using (var command = new SqlCommand(spName, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					//TODO: check with DBA output parameters can have different names
					if (passErrorParams)
					{
						command.Parameters.Add(new SqlParameter("@O_ErrCode", SqlDbType.Int, 4) { Direction = ParameterDirection.Output });
						command.Parameters.Add(new SqlParameter("@O_ErrMsg", SqlDbType.VarChar, 2000) { Direction = ParameterDirection.Output });
					}

					conn.Open();
					addParametersAction(conn, command);
					
					command.ExecuteNonQuery();

					
					if (passErrorParams)
					{
						dbResponse = new DataBaseResponse
						{
							ErrorCode = (int)command.Parameters["@O_ErrCode"].Value,
							ErrorMessage = command.Parameters["@O_ErrMsg"].Value as string
						};
					}
					else
					{
						dbResponse = new DataBaseResponse
						{
							ErrorCode = DataBaseResponse.ErrorCodeSuccess,
							ErrorMessage = string.Empty
						};
					}

					foreach (SqlParameter param in command.Parameters)
					{
						if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
						{
							object paramVal = command.Parameters[param.ParameterName].Value;
							dbResponse.OutputParams.Add(param.ParameterName, paramVal);
						}
					}

					return dbResponse;
				}

			}
			catch (Exception ex)
			{
				//Logger.Instance.Error(string.Format("Exception was thrown in DataAccessor.ExecuteSoredProcedure. BD => {0} \n SP => {1}", connectionString, spName), ex);
				throw;
			}

			

			
			//return new DataBaseResponse();	
		}



		public string ExecuteStoredProcedureReader(
			string connectionString,
			string spName,
			bool passErrorParams,
			Action<SqlConnection, SqlCommand> addParametersAction)
		{

			try
			{
				if (addParametersAction == null)
				{
					throw new ArgumentNullException("addParametersAction");
				}

				DataBaseResponse dbResponse = null;

				string response = string.Empty;

				using (var conn = new SqlConnection(connectionString))
				using (var command = new SqlCommand(spName, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					//TODO: check with DBA output parameters can have different names
					if (passErrorParams)
					{
						command.Parameters.Add(new SqlParameter("@O_ErrCode", SqlDbType.Int, 4) { Direction = ParameterDirection.Output });
						command.Parameters.Add(new SqlParameter("@O_ErrMsg", SqlDbType.VarChar, 2000) { Direction = ParameterDirection.Output });
					}

					conn.Open();
					addParametersAction(conn, command);

					

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							response += reader.GetString(0);
							
						}
					}

					if (passErrorParams)
					{
						dbResponse = new DataBaseResponse
						{
							ErrorCode = (int)command.Parameters["@O_ErrCode"].Value,
							ErrorMessage = command.Parameters["@O_ErrMsg"].Value as string
						};
					}
					else
					{
						dbResponse = new DataBaseResponse
						{
							ErrorCode = DataBaseResponse.ErrorCodeSuccess,
							ErrorMessage = string.Empty
						};
					}

					foreach (SqlParameter param in command.Parameters)
					{
						if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
						{
							object paramVal = command.Parameters[param.ParameterName].Value;
							dbResponse.OutputParams.Add(param.ParameterName, paramVal);
						}
					}

					
				}

				return response;
			}
			catch (Exception ex)
			{
				//Logger.Instance.Error(string.Format("Exception was thrown in DataAccessor.ExecuteSoredProcedure. BD => {0} \n SP => {1}", connectionString, spName), ex);
				return null;
			}




		//	return new DataBaseResponse();	
		}

		/// <summary>
		/// Get Scalar result of calling SP
		/// </summary>
		/// <param name="connectionString"></param>
		/// <param name="spName"></param>
		/// <param name="addParametersAction"></param>
		/// <returns></returns>
		public object ExecuteScalar(string connectionString, string spName , Action<SqlConnection, SqlCommand> addParametersAction)
		{
			try
			{
				using (var conn = new SqlConnection(connectionString))
				using (var command = new SqlCommand(spName, conn)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					conn.Open();
					addParametersAction(conn, command);
					object scalarResult = command.ExecuteScalar();

					return scalarResult;
				}
			}
			catch (Exception ex)
			{
				//Logger.Instance.Error(string.Format("Exception was thrown in DataAccessor.ExecuteScalar. BD => {0} \n SP => {1}", connectionString, spName), ex);
				throw;
			}
		}

		
	}
}
