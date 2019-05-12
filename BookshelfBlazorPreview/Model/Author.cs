using System;

namespace Bookshelf.Model
{
    public class Author : IComparable
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(object obj)
        {
            return LastName.CompareTo(((Author)obj).LastName);
        }
    }
}