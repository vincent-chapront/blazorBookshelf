using System;
using System.Linq;
using Bookshelf.ViewModel.Table;
using Microsoft.AspNetCore.Components;

namespace Bookshelf.ViewModel.Page
{
    public class PublisherPageViewModel : PageViewModel
    {
        public string PublisherFullName { get; set; }

        public string Title { get { return $"Liste des livres publiés par {PublisherFullName}"; } }

        public PublisherPageViewModel(IUriHelper uriHelper, ApiClient apiClient)
            : base(uriHelper, apiClient) { }

        public async void UpdatePage(Guid id)
        {
            var publisherDto = await apiClient.GetPublisher(id);
            var authorsDto = await apiClient.GetAllAuthors();
            var booksDto = await apiClient.GetAllBooksByPublisher(id);
            PublisherFullName = publisherDto.Name;
            BooksAll =
                booksDto
                .Select(x =>
                    new BookSummaryViewModel
                    {
                        Title = x.Title,
                        Year = x.Year,
                        Publisher = publisherDto,
                        Authors =
                            x.IdAuthors
                            ?.Select(a => authorsDto.FirstOrDefault(b => b.Id == a))
                            .Where(a => a != null)
                            .ToList()
                    });
        }

        public override void AuthorChangedHandler(Guid idAuthor)
        {
            uriHelper.NavigateTo("/author/" + idAuthor.ToString());
        }

        public override void PublisherChangedHandler(Guid idPublisher)
        {
            uriHelper.NavigateTo("/publisher/" + idPublisher.ToString());
            UpdatePage(idPublisher);
        }
    }
}