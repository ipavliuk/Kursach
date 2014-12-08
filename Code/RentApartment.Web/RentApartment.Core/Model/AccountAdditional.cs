using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.Model.EF
{
	public partial class Account
	{
		public void CreateAccount(SqlDataReader reader)
		{
			try
			{
				this.id = Int32.Parse(reader["id"].ToString());
				this.AccountId = reader["AccountId"].ToString();
				this.PasswordHash = reader["PasswordHash"].ToString();
				this.FirstName = reader["PasswordHash"].ToString();
				this.LastName = reader["LastName"].ToString();
				this.Email = reader["Email"].ToString();
				this.IsEmailConfirmed = Boolean.Parse(reader["IsEmailConfirmed"].ToString());
				//[FK__Country]
				//[FK__Roles]
				this.City = reader["City"].ToString();
				this.Address = reader["Address"].ToString();
				this.Mobile = reader["Mobile"].ToString();
				string gender = reader["Gender"].ToString();

				this.Gender = string.IsNullOrEmpty(gender) ? (Byte?)Byte.Parse(gender) : null;
				this.PostalCode = reader["PostalCode"].ToString();

				string lang = reader["Language"].ToString();
				this.Language = string.IsNullOrEmpty(lang) ? (int?)Int32.Parse(lang) : null;

				this.IsValidated = Boolean.Parse(reader["IsValidated"].ToString());
				this.ImageSourceId = reader["ImageSourceId"].ToString();

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
