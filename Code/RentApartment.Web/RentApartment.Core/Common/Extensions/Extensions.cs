using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Core.Infrastructure
{
	public static class Extensions
	{

		public static void ThrowIfNull<T>(this T item, string message) where T : class
		{
			if (item == null)
			{
				throw new ArgumentNullException(message);
			}
		}

		public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> work) where TSource : class
		{
			work.ThrowIfNull("Source is null");
			
			foreach (var item in source)
			{
				work(item);
			}
		}
	}

}
