using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI.ChatServer.Core.DataBaseAccess.Entities
{
	public class DataBaseResponse
	{
		public static readonly int ErrorCodeSuccess = 0;

		public int ErrorCode { get; set; }

		public string ErrorMessage { get; set; }

		public bool HasError { get { return ErrorCode != DataBaseResponse.ErrorCodeSuccess; } }

		public Dictionary<string, object> OutputParams { get; private set; }

		public DataBaseResponse()
		{
			OutputParams = new Dictionary<string, object>();
		}

		public override string ToString()
		{
			return string.Format("(DbErrorCode: {0}, DbErrorMessage: {1})", ErrorCode, ErrorMessage);
		}

	}
}
