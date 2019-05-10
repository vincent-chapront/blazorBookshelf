using System;

namespace Bookshelf.ViewModel.Table
{
    public class PublisherRowViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int NumberOfBooks { get; set; }
    }
}