using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    /// <summary>
    /// Collections Utilities
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Gets the all duplicates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List">The list.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> List)
        {
            return List.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);
        }

        /// <summary>
        /// Gets the duplicates by predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="List">The list.</param>
        /// <param name="Predicate">The predicate.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> GetDuplicates<T, TResult>(this IEnumerable<T> List, Func<T, TResult> Predicate)
        {
            return List.Select(Predicate).GetDuplicates();
        }

        /// <summary>
        /// Check if a List contains an item based on Linq
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List"></param>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool Contains<T>(this IEnumerable<T> List, Func<T, bool> Expression)
        {
            var obj = List.Where(Expression).FirstOrDefault();
            if (obj == null) return false;
            else return List.Contains(obj);
        }

        public static bool ContainsAll<T>(this IEnumerable<T> List, IEnumerable<T> Values)
            => Values.All(x => List.Contains(x));

        public static bool ContainsAny<T>(this IEnumerable<T> List, IEnumerable<T> Values)
            => Values.Any(x => List.Contains(x));

        /// <summary>
        /// Removes all by expression.
        /// <para>ex: dictionary.RemoveAll((key, value) => value > 1); </para>
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dict">The dictionary.</param>
        /// <param name="match">The match.</param>
        public static void RemoveAll<K, V>(this IDictionary<K, V> dict, Func<K, V, bool> match)
        {
            foreach (var key in dict.Keys.ToArray()
                    .Where(key => match(key, dict[key])))
                dict.Remove(key);
        }

        /// <summary>
        /// Removes the first specified item by predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List">The list.</param>
        /// <param name="Predicate">The predicate.</param>
        public static void Remove<T>(this ICollection<T> List, Func<T, bool> Predicate)
        {
            var item = List.Where(Predicate).FirstOrDefault();
            List.Remove(item);
        }

        /// <summary>
        /// Replaces the specified new item by predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List">The list.</param>
        /// <param name="NewItem">The new item.</param>
        /// <param name="Predicate">The predicate.</param>
        public static void Replace<T>(this IList<T> List, T NewItem, Func<T, bool> Predicate)
        {
            var item = List.Where(Predicate).FirstOrDefault();
            var index = List.IndexOf(item);
            List.Remove(item);
            List.Insert(index, NewItem);
        }

        /// <summary>
        /// Using the <see cref="object.ToString()"/> method, creating a list of strings.
        /// </summary>
        /// <param name="Items">The items.</param>
        /// <returns></returns>
        public static string ToStrings<T>(this IEnumerable<T> Items)
        {
            var sb = new StringBuilder();

            foreach (var i in Items)
                sb.AppendLine(i?.ToString());
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Disposes all items.
        /// </summary>
        /// <param name="Items">The items.</param>
        public static void DisposeAll(this IEnumerable<IDisposable> Items)
        {
            foreach (var i in Items)
                i.Dispose();
        }

        public static void DisposeAll<T>(this IEnumerable<T> Items, Func<T, bool> Predicate)
            where T : IDisposable
        {
            foreach (var i in Items.Where(Predicate))
                i.Dispose();
        }

        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }

        public static string BuildString<T>(this IEnumerable<T> Items, string Seperator = " ")
        {
            var sb = new StringBuilder();

            var count = Items.Count();
            var nr = 0;
            foreach (var i in Items)
            {
                nr++;

                if (nr < count)
                    sb.Append(i + Seperator);
                else
                    sb.Append(i);
            }
            return sb.ToString();
        }

        // Does not work when using a derived collection. Ex: AMS.SmartSet.Add will be skipped and the parent ObservableCollection.Add will be used
        //public static void Add<T>(this ICollection<T> Collection, params T[] Items)
        //{
        //    foreach (var i in Items)
        //        Collection.Add(i);
        //}

        public static void Populate<T>(this T[] Items, T Value)
        {
            // TODO Paralel

            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = Value;
            }
        }

        public static void InsertAfter<T>(this IList<T> List, T Item, Func<T, bool> Predicate)
        {
            int id = 0;
            var item = List.Where(Predicate).LastOrDefault();
            if (item != null) id = List.IndexOf(item);

            List.Insert(id, Item);
        }

        public static void InsertBefore<T>(this IList<T> List, T Item, Func<T, bool> Predicate)
        {
            int id = 0;
            var item = List.Where(Predicate).FirstOrDefault();
            if (item != null) id = List.IndexOf(item);

            List.Insert(id, Item);
        }

        public static IEnumerable<T> TakeBetween<T>(this IEnumerable<T> Items, int StartIndex, int EndIndex)
            => Items.Skip(StartIndex).Take(EndIndex - StartIndex);

        public static IEnumerable<T> TakeBetween<T>(this IEnumerable<T> Items, Func<T, bool> StartPredicate, Func<T, bool> EndPredicate)
            => Items.SkipWhile(StartPredicate).TakeWhile(StartPredicate);

        public static T Cycle<T>(this IEnumerable<T> Collection, T Current)
        {
            var Items = Collection as IList<T> ?? Collection.ToList();

            int last = Items.IndexOf(Items.Last());
            var curr = Items.IndexOf(Current);

            var next = curr == last ? Items.First() : Items[curr + 1];

            return next;
        }

        public static void AddSorted<T>(this List<T> List, T item)
            where T : IComparable<T>
        {
            if (List.Count == 0) // Empty list
            {
                List.Add(item);
                return;
            }
            if (List[List.Count - 1].CompareTo(item) <= 0) //  Compare to Last entry
            {
                List.Add(item);
                return;
            }
            if (List[0].CompareTo(item) >= 0) // Compare to 1st entry
            {
                List.Insert(0, item);
                return;
            }
            int index = List.BinarySearch(item);
            if (index < 0) index = ~index;
            List.Insert(index, item);
        }

        public static int LastIndexOf<T>(this List<T> List, Func<T, bool> Predicate)
        {
            var item = List.Where(Predicate).LastOrDefault();
            if (item == null) return 0;
            else return List.LastIndexOf(item);
        }

        public static int IndexOf<T>(this IList<T> List, Func<T, bool> Predicate)
        {
            var item = List.Where(Predicate).FirstOrDefault();
            if (item == null) return 0;
            else return List.IndexOf(item);
        }

        public static IEnumerable<TResult> Distinct<TSource, TResult>(this IEnumerable<TSource> List, Func<TSource, TResult> Predicate)
            => List.Select(Predicate).Distinct();

        public static IEnumerable<TResult> DistinctMany<TSource, TResult>(this IEnumerable<TSource> List, Func<TSource, IEnumerable<TResult>> Predicate)
            => List.SelectMany(Predicate).Distinct();
    }
}
