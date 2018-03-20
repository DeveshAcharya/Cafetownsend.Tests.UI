using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafetownsend.Tests.UI.Helpers
{
	public static class CollectionHelper
	{
		public static void RemoveAll<T>(this IList<T> source,
			Func<T, bool> predicate)
		{
			if (source == null)
				throw new ArgumentNullException("source", "source is null.");

			if (predicate == null)
				throw new ArgumentNullException("predicate", "predicate is null.");

			source.Where(predicate).ToList().ForEach(e => source.Remove(e));
		}
	}
}
