using Microsoft.AspNetCore.Components;

namespace Bookshelf.ViewModel.Page
{
    public class PublisherCreatePageViewModel
    {
        protected readonly NavigationManager uriHelper;

        protected readonly ApiClient apiClient;
        public string NameMessage { get; set; }
        public string Name { get; set; }

        public string Title { get { return $"Création d'un éditeur"; } }

        public PublisherCreatePageViewModel(NavigationManager uriHelper, ApiClient apiClient)
        {
            this.uriHelper = uriHelper;
            this.apiClient = apiClient;
        }

        public void Ajouter()
        {
            if (Validate())
            {
                var author = apiClient.AddPublisher(Name).Result;
                uriHelper.NavigateTo("/publisher/" + author.Id);
            }
        }

        private bool Validate()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(Name))
            {
                NameMessage = "Le champ \"Nom\" est obligatoire";
                result = false;
            }
            else
            {
                NameMessage = string.Empty;
            }

            return result;
        }
    }
}