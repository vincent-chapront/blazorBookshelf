using Bookshelf.Model;
using System.Collections.Generic;

namespace Bookshelf.ViewModel
{
    public class BookSummaryViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Publisher Publisher { get; set; }

        public List<Author> Authors { get; set; }
    }
}
