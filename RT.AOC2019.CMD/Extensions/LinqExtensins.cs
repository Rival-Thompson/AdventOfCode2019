using System;
using System.Collections.Generic;
using System.Linq;

namespace RT.AOC2019.CMD.Extensions
{
  public static class LinqExtensions
  {
    public static IEnumerable<TSource> Duplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
    {
      var grouped = source.GroupBy(selector);
      var moreThan1 = grouped.Where(i => i.IsMultiple());
      return moreThan1.SelectMany(i => i);
    }

    public static IEnumerable<TSource> Duplicates<TSource, TKey>(this IEnumerable<TSource> source)
    {
      return source.Duplicates(i => i);
    }

    public static bool IsMultiple<T>(this IEnumerable<T> source)
    {
      var enumerator = source.GetEnumerator();
      return enumerator.MoveNext() && enumerator.MoveNext();
    }

    ///<summary>Finds the index of the first item matching an expression in an enumerable.</summary>
    ///<param name="items">The enumerable to search.</param>
    ///<param name="predicate">The expression to test the items against.</param>
    ///<returns>The index of the first matching item, or -1 if no items match.</returns>
    public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
      if (items == null) throw new ArgumentNullException("items");
      if (predicate == null) throw new ArgumentNullException("predicate");

      int retVal = 0;
      foreach (var item in items)
      {
        if (predicate(item)) return retVal;
        retVal++;
      }
      return -1;
    }
    ///<summary>Finds the index of the first occurrence of an item in an enumerable.</summary>
    ///<param name="items">The enumerable to search.</param>
    ///<param name="item">The item to find.</param>
    ///<returns>The index of the first matching item, or -1 if the item was not found.</returns>
    public static int IndexOf<T>(this IEnumerable<T> items, T item) { return items.FindIndex(i => EqualityComparer<T>.Default.Equals(item, i)); }
  }

}
