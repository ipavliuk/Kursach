using System.Collections.Generic;

namespace RentApartment.Core.DAL.DBAccessor.Entities
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
