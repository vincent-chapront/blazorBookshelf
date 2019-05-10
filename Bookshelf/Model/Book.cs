using System;
using System.Collections.Generic;

namespace Bookshelf.Model
{
    public class Book
    {
        public Guid Id { get; set; }

        public Guid IdPublisher { get; set; }

        public List<Guid> IdAuthors { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}