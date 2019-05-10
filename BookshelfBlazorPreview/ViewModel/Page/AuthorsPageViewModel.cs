using System.Collections.Generic;
using System.Linq;
using Bookshelf.ViewModel.Table;
using Microsoft.AspNetCore.Components;

namespace Bookshelf.ViewModel.Page
{
    public class AuthorsPageViewModel
    {
        protected readonly IUriHelper uriHelper;

        protected readonly ApiClient apiClient;

        public IEnumerable<AuthorRowViewModel> AuthorsAll { get; set; }

        public string Title { get { return "Liste des auteurs"; } }

        public AuthorsPageViewModel(IUriHelper uriHelper, ApiClient apiClient)
        {
            this.uriHelper = uriHelper;
            this.apiClient = apiClient;
        }

        public async void UpdatePage()
        {
            var authorsAll = await apiClient.GetAllAuthors();
            var books = await apiClient.GetAllBooks();
            AuthorsAll =
                authorsAll
                .Select(x => new AuthorRowViewModel
                {
                    Id = x.Id,
                    Name = x.LastName + " " + x.FirstName,
                    NumberOfBooks = books.Count(y => y.IdAuthors.Contains(x.Id))
                });
        }
    }
}