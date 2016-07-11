using System.Collections.Generic;
using System.Linq;

namespace draw_poker.util
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// 先頭から指定の数だけ取り出す
        /// </summary>
        public static IEnumerable<T> Pop<T>(this IEnumerable<T> self, int count)
        {
            var result = self.Take(count);
            self = self.Skip(count);
            return result;
        }

        /// <summary>
        /// 指定の数のグループに分ける
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> self, int chunkSize)
        {
            while (self.Any())
            {
                yield return self.Take(chunkSize);
                self = self.Skip(chunkSize);
            }
        }
    }
}
