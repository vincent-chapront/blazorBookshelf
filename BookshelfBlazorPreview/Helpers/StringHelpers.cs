using System.Collections.Generic;

namespace Bookshelf.Helpers
{
    public static class StringHelpers
    {
        public static string JoinEx(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values);
        }
    }
}