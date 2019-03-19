using Microsoft.AspNetCore.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.ViewModel
{
    public class PublisherPageViewModel : PageViewModel
    {
        public string PublisherFullName { get; set; }

        public PublisherPageViewModel(IUriHelper uriHelper, ApiClient apiClient)
            : base(uriHelper, apiClient){}

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
