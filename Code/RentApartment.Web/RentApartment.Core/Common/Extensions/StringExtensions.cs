using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.Infrastructure
{
	public static class StringExtensions
	{
		public static string ToSha256(this string value, string salt)
		{
			string saltedValue = ((salt ?? "") + value);

			return String.Join("", SHA256.Create()
						 .ComputeHash(Encoding.Default.GetBytes(saltedValue))
						 .Select(b => b.ToString("x2")));
		}
	}
}
