using Bookshelf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf
{
    public class ApiClient
    {
        private readonly List<Book> books;
        private readonly List<Publisher> publishers;
        private readonly List<Author> authors;
        public ApiClient()
        {
            Author fancherDave = new Author { Id = Guid.NewGuid(), FirstName = "Dave" , LastName = "Fancher" };
            Author lipovacaMiran = new Author { Id = Guid.NewGuid(), FirstName = "Miran" , LastName = "Lipovaca" };
            Author shottsWilliamEJr = new Author { Id = Guid.NewGuid(), FirstName = "Williams E.", LastName = "Shotts Jr." };
            Author feldmanRichard = new Author { Id = Guid.NewGuid(), FirstName = "Richard" , LastName = "Feldman" };

            authors = new List<Author>
                { fancherDave, lipovacaMiran, shottsWilliamEJr, feldmanRichard};

            Publisher noStarch = new Publisher { Id = Guid.NewGuid(), Name = "No Starch" };
            Publisher manning = new Publisher { Id = Guid.NewGuid(), Name = "Manning" };
            publishers = new List<Publisher>
                { noStarch, manning};

            books = new List<Book> {
                new Book{Id=Guid.NewGuid(), Title="The book of F#", IdPublisher=noStarch.Id, Year=2014, IdAuthors=new List<Guid>{fancherDave.Id } },
                new Book{Id=Guid.NewGuid(), Title="Learn you a Haskell for greater good", IdPublisher=noStarch.Id, Year=2011, IdAuthors=new List<Guid>{ lipovacaMiran.Id } },
                new Book{Id=Guid.NewGuid(), Title="The Linux command line", IdPublisher=noStarch.Id, Year=2012, IdAuthors=new List<Guid>{shottsWilliamEJr.Id } },
                new Book{Id=Guid.NewGuid(), Title="Elm in action V6", IdPublisher=manning.Id, Year=2019, IdAuthors=new List<Guid>{feldmanRichard.Id} },
                new Book{Id=Guid.NewGuid(), Title="Fake book", IdPublisher=manning.Id, Year=2019, IdAuthors=new List<Guid>{feldmanRichard.Id, fancherDave.Id} },
            };
        }

#region Books
        public async Task<List<Book>> GetAllBooks()
        {
            return books;
        }

        public async Task<List<Book>> GetAllBooksByAuthor(Guid id)
        {
            return books.Where(x => x.IdAuthors.Contains(id)).ToList() ;
        }

        public async Task<List<Book>> GetAllBooksByPublisher(Guid id)
        {
            return books.Where(x => x.IdPublisher == id).ToList() ;
        }

        public async Task<Book> AddBook(string title, int year, Guid publisherId)
        {
            var book = new Book
            {
                Title = title,
                Year = year,
                Id = Guid.NewGuid(),
                IdAuthors = new List<Guid>(),
                IdPublisher = publisherId
            };
            books.Add(book);
            Console.WriteLine("AddBook : " + book.Id);
            return book;
        }

        #endregion Books

        #region Authors
        public async Task<List<Author>> GetAllAuthors()
        {
            return authors;
        }

        public async Task<Author> GetAuthor(Guid id)
        {
            return authors.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Author> AddAuthor(string lastName, string firstName)
        {
            var author = new Author{
                FirstName=firstName,
                LastName=lastName,
                Id=Guid.NewGuid()
                } ;
            authors.Add(author);
            Console.WriteLine("AddAuthor : "+author.Id);
            return author;
        }
#endregion Authors

#region Publishers
        public async Task<List<Publisher>> GetAllPublishers()
        {
            return publishers;
        }

        public async Task<Publisher> GetPublisher(Guid id)
        {
            return publishers.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Publisher> AddPublisher(string name)
        {
            var publisher = new Publisher{
                Name=name,
                Id=Guid.NewGuid()
                } ;
            publishers.Add(publisher);
            Console.WriteLine("AddAuthor : "+publisher.Id);
            return publisher;
        }
#endregion Publishers

        public async Task<bool> Login(UserModel model)
        {
#if DEBUG
            return true;
#endif
            if(model.Name=="vchapront" && model.Password=="aze")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
