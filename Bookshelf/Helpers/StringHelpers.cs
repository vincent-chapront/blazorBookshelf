using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Helpers
{
    public static class StringHelpers
    {
        public static string JoinEx(this IEnumerable<string> values, string separator)
        {
            return String.Join(separator, values);
        }
    }
}
