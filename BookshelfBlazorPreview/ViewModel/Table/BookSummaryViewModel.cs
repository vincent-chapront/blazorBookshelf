using System;
using System.Collections.Generic;
using Bookshelf.Model;

namespace Bookshelf.ViewModel.Table
{
    public class BookSummaryViewModel:IComparable
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Publisher Publisher { get; set; }

        public List<Author> Authors { get; set; }

        public int CompareTo(object obj)
        {
            return Title.CompareTo(obj);
        }
    }
}