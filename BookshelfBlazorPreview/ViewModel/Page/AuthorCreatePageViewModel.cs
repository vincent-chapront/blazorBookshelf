using Microsoft.AspNetCore.Components;

namespace Bookshelf.ViewModel.Page
{
    public class AuthorCreatePageViewModel
    {
        protected readonly NavigationManager uriHelper;

        protected readonly ApiClient apiClient;

        public string FirstNameMessage { get; set; }
        public string FirstName { get; set; }
        public string LastNameMessage { get; set; }
        public string LastName { get; set; }

        public string Title { get { return $"Création d'un auteur"; } }

        public AuthorCreatePageViewModel(NavigationManager uriHelper, ApiClient apiClient)
        {
            this.uriHelper = uriHelper;
            this.apiClient = apiClient;
        }

        public void Ajouter()
        {
            if (Validate())
            {
                var author = apiClient.AddAuthor(LastName, FirstName).Result;
                uriHelper.NavigateTo("/author/" + author.Id);
            }
        }

        private bool Validate()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                FirstNameMessage = "Le champ \"Prénom\" est obligatoire";
                result = false;
            }
            else
            {
                FirstNameMessage = string.Empty;
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                LastNameMessage = "Le champ \"Nom\" est obligatoire";
                result = false;
            }
            else
            {
                LastNameMessage = string.Empty;
            }

            return result;
        }
    }
}