using System.Collections.Generic;
using System.Linq;

namespace draw_poker.util
{
    public static class ListExtensions
    {
        /// <summary>
        /// 先頭にあるオブジェクトを削除せずに返します
        /// </summary>
        public static T Peek<T>(this IList<T> self)
        {
            return self[0];
        }

        /// <summary>
        /// 先頭にあるオブジェクトを削除し、返します
        /// </summary>
        public static T Pop<T>(this IList<T> self)
        {
            var result = self[0];
            self.RemoveAt(0);
            return result;
        }

        /// <summary>
        /// 末尾にオブジェクトを追加します
        /// </summary>
        public static void Push<T>(this IList<T> self, T item)
        {
            self.Insert(0, item);
        }

        /// <summary>
        /// Break a list of items into chunks of a specific size
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
}
