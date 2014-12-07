using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WI.ChatServer.Core.DataBaseAccess.Entities;

namespace WI.ChatServer.Core.DataBaseAccess
{
	public interface IDataAccessor
	{
		ListDbResponse<T> ExecuteStoredProcedure<T>(
			string connectionString,
			string spName,
			bool passErrorParams,
			Func<DataRow, T> convertDataTableToObjFunc,
			Action<SqlConnection, SqlCommand> addParametersAction);


		DataBaseResponse ExecuteStoredProcedure(
			string connectionString,
			string spName,
			bool passErrorParams,
			Action<SqlConnection, SqlCommand> addParametersAction);


		string ExecuteStoredProcedureReader(
			string connectionString,
			string spName,
			bool passErrorParams,
			Action<SqlConnection, SqlCommand> addParametersAction);

		object ExecuteScalar(string connectionString, string spName, Action<SqlConnection, SqlCommand> addParametersAction);


	}
}
