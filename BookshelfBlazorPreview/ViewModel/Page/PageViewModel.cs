using System;
using System.Collections.Generic;
using Bookshelf.ViewModel.Table;
using Microsoft.AspNetCore.Components;

namespace Bookshelf.ViewModel.Page
{
    public abstract class PageViewModel
    {
        protected readonly IUriHelper uriHelper;

        protected readonly ApiClient apiClient;

        public IEnumerable<BookSummaryViewModel> BooksAll { get; set; } = null;

        public PageViewModel(IUriHelper uriHelper, ApiClient apiClient)
        {
            this.uriHelper = uriHelper;
            this.apiClient = apiClient;
        }

        public abstract void AuthorChangedHandler(Guid idAuthor);

        public abstract void PublisherChangedHandler(Guid idPublisher);
    }
}