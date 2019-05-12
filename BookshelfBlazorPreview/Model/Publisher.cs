using System;

namespace Bookshelf.Model
{
    public class Publisher : IComparable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            return Name.CompareTo(((Publisher)obj).Name);
        }
    }
}