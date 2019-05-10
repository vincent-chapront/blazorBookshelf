using System.Collections.Generic;
using Bookshelf.Model;

namespace Bookshelf.ViewModel.Table
{
    public class BookSummaryViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Publisher Publisher { get; set; }

        public List<Author> Authors { get; set; }
    }
}