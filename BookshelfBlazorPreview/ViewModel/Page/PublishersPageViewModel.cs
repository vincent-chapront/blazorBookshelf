using System.Collections.Generic;
using System.Linq;
using Bookshelf.ViewModel.Table;
using Microsoft.AspNetCore.Components;

namespace Bookshelf.ViewModel.Page
{
    public class PublishersPageViewModel
    {
        protected readonly IUriHelper uriHelper;

        protected readonly ApiClient apiClient;

        public IEnumerable<PublisherRowViewModel> PublishersAll { get; set; }

        public string Title { get { return "Liste des éditeurs"; } }

        public PublishersPageViewModel(IUriHelper uriHelper, ApiClient apiClient)
        {
            this.uriHelper = uriHelper;
            this.apiClient = apiClient;
        }

        public async void UpdatePage()
        {
            var publishersAll = await apiClient.GetAllPublishers();
            var books = await apiClient.GetAllBooks();
            PublishersAll =
                publishersAll
                .Select(x => new PublisherRowViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    NumberOfBooks = books.Count(y => y.IdPublisher == x.Id)
                });
        }
    }
}