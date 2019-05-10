using System;
using System.Collections.Generic;
using System.Linq;
using Bookshelf.Model;
using Microsoft.AspNetCore.Components;

namespace Bookshelf.ViewModel.Page
{
    public class BookCreatePageViewModel
    {
        protected readonly IUriHelper uriHelper;

        protected readonly ApiClient apiClient;

        public List<Publisher> Publishers { get; set; }

        public string PublisherMessage { get; set; }
        public string PublisherId { get; set; }

        public string TitleMessage { get; set; }
        public string Title { get; set; }
        public string YearMessage { get; set; }
        public string Year { get; set; }

        public string PageTitle => "Création d'un livre";

        public BookCreatePageViewModel(IUriHelper uriHelper, ApiClient apiClient)
        {
            this.uriHelper = uriHelper;
            this.apiClient = apiClient;
        }

        public async void LoadAsync()
        {
            Publishers = await apiClient.GetAllPublishers();
            PublisherId = Publishers.First().Id.ToString();
        }

        public void Ajouter()
        {
            if (Validate())
            {
                var book = apiClient.AddBook(Title, int.Parse(Year), new Guid(PublisherId)).Result;
                //uriHelper.NavigateTo("/book/" + book.Id);
                uriHelper.NavigateTo("/books/");
            }
        }

        private bool Validate()
        {
            return true;
            //     bool result=true;
            //     if(string.IsNullOrWhiteSpace(FirstName))
            //     {
            //         FirstNameMessage="Le champ \"Prénom\" est obligatoire";
            //         result=false;
            //     }
            //     else
            //     {
            //         FirstNameMessage=string.Empty;
            //     }

            //     if(string.IsNullOrWhiteSpace(LastName))
            //     {
            //         LastNameMessage="Le champ \"Nom\" est obligatoire";
            //         result=false;
            //     }
            //     else
            //     {
            //         LastNameMessage=string.Empty;
            //     }

            //     return result;
        }
    }
}