using Bookshelf.Model;
using System;
using System.Linq;
using Microsoft.AspNetCore.Components.Services;

namespace Bookshelf.ViewModel
{
    public class AuthorPageViewModel : PageViewModel
    {
        public string AuthorFullName { get; set; }

        public AuthorPageViewModel(IUriHelper uriHelper, ApiClient apiClient)
            : base(uriHelper, apiClient){}

        public async void UpdatePage(Guid id)
        {
            var publishersDto = await apiClient.GetAllPublishers();
            var authorsDto = await apiClient.GetAllAuthors();
            var authorDto = await apiClient.GetAuthor(id);
            var booksDto = await apiClient.GetAllBooksByAuthor(id);
            AuthorFullName = authorDto.FirstName + " " + authorDto.LastName;
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
            uriHelper.NavigateTo("/author/" + idAuthor.ToString());
            UpdatePage(idAuthor);
        }

        public override void PublisherChangedHandler(Guid idPublisher)
        {
            uriHelper.NavigateTo("/publisher/" + idPublisher.ToString());
        }
    }
}