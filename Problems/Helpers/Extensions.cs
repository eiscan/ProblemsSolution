using System.Collections.Generic;
using System.Linq;

namespace Problems.Helpers
{
    public static class Extensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }

        public static bool TryGetKey<K, V>(this IDictionary<K, V> instance, V value, out K key)
        {
            foreach (var entry in instance)
            {
                if (!entry.Value.Equals(value))
                {
                    continue;
                }
                key = entry.Key;
                return true;
            }
            key = default(K);
            return false;
        }
    }
}
