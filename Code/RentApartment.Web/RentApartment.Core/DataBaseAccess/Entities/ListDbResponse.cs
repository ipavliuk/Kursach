using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WI.ChatServer.Core.DataBaseAccess.Entities
{
	public class ListDbResponse<T> : DataBaseResponse
	{
		public List<T> DbList { get; set; }

		public override string ToString()
		{
			if (DbList == null)
			{
				return string.Format(base.ToString() + ", list is null");
			}
			else
			{
				return string.Format(base.ToString() + ", Count: {0}", DbList.Count);
			}
		}
	}
}
