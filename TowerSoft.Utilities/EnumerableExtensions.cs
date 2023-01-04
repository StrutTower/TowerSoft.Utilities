using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerSoft.Utilities {
    /// <summary>
    /// Extensions for IEnumerables
    /// </summary>
    public static class EnumerableExtensions {
        /// <summary>
        /// Returns true if the IEnumerable is not null and has at least one item
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool SafeAny<TSource>(this IEnumerable<TSource>? source) {
            if (source == null) return false;
            using (IEnumerator<TSource> e = source.GetEnumerator()) {
                if (e.MoveNext()) return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if the IEnumerable is not null and has at least one item that matches the included Linq statement
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">Linq statement to match against</param>
        /// <returns></returns>
        public static bool SafeAny<TSource>(this IEnumerable<TSource>? source, Func<TSource, bool> predicate) {
            if (source == null) return false;
            if (predicate == null) throw new ArgumentNullException("predicate");
            foreach (TSource element in source) {
                if (predicate(element)) return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the generic type matches the supplied type
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type">Type to compare to</param>
        /// <returns></returns>
        public static bool IsOfType<T>(this IEnumerable<T> source, Type type) {
            Type sourceType = source.GetType();
            Type genericType = sourceType.GetGenericArguments().First();
            return genericType == type;
        }

        /// <summary>
        /// Splits a IEnumerable into batches
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="size">Max number of items to include in each batch.</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int size) {
            return items.Select((item, index) => new { item, index })
                        .GroupBy(x => x.index / size)
                        .Select(g => g.Select(x => x.item));
        }
    }
}
