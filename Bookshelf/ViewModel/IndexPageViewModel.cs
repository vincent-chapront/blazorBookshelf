using Bookshelf.Model;
using Microsoft.AspNetCore.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.ViewModel
{
    public class IndexPageViewModel : PageViewModel
    {

        public string PublisherFullName { get; set; }

        public IndexPageViewModel(IUriHelper uriHelper, ApiClient apiClient)
            :base(uriHelper, apiClient){}

        public async void UpdatePage()
        {
            var publishersDto = await apiClient.GetAllPublishers();
            var authorsDto = await apiClient.GetAllAuthors();
            var booksDto = await apiClient.GetAllBooks();

            BooksAll =
                booksDto
                .Select(x =>
                    new BookSummaryViewModel
                    {
                        Title = x.Title,
                        Year = x.Year,
                        Publisher = publishersDto.Where(p => p.Id == x.IdPublisher).FirstOrDefault() ?? new Publisher { Id = Guid.Empty, Name = "N/A" },
                        Authors =
                            x.IdAuthors
                            ?.Select(a => authorsDto.FirstOrDefault(b => b.Id == a))
                            .Where(a => a != null)
                            .ToList()
                    });
        }

        public override void AuthorChangedHandler(Guid idAuthor)
        {
            uriHelper.NavigateTo("/Author/" + idAuthor.ToString());
        }

        public override void PublisherChangedHandler(Guid idPublisher)
        {
            uriHelper.NavigateTo("/publisher/" + idPublisher.ToString());
        }
    }
}
