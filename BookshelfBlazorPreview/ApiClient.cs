using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Model;

namespace Bookshelf
{
    public class ApiClient
    {
        private readonly List<Book> books;
        private readonly List<Publisher> publishers;
        private readonly List<Author> authors;

        public ApiClient()
        {
            Author createAuthor(string firstName, string lastName) { return new Author { Id = Guid.NewGuid(), FirstName = firstName, LastName = lastName }; }
            Publisher createPublisher(string name) { return new Publisher { Id = Guid.NewGuid(), Name = name }; }
            Book createBook(string title, Guid publisherId, int year, params Guid[] authorsId)
            {
                return new Book
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    IdPublisher = publisherId,
                    Year = year,
                    IdAuthors = authorsId.ToList()
                };
            }

            Author fancherDave = createAuthor("Dave", "Fancher");
            Author lipovacaMiran = createAuthor("Miran", "Lipovaca");
            Author shottsWilliamEJr = createAuthor("Williams E.", "Shotts Jr.");
            Author feldmanRichard = createAuthor("Richard", "Feldman");
            Author skeetJon = createAuthor("Jon", "Skeet");
            Author abrahamIsaac = createAuthor("Isaac", "Abraham");
            Author bennetJim = createAuthor("Jim", "Bennet");
            Author lauretArnaud = createAuthor("Arnaud", "Lauret");
            Author gammelgaardChristian = createAuthor("Christian Horsdal", "Gammelgaard");
            Author petricekTomas = createAuthor("Tomas", "Petricek");

            authors = new List<Author>
                { fancherDave, lipovacaMiran, shottsWilliamEJr, feldmanRichard
            , skeetJon, abrahamIsaac, bennetJim, lauretArnaud, gammelgaardChristian, petricekTomas};

            Publisher noStarch = createPublisher("No Starch");
            Publisher manning = createPublisher("Manning");
            publishers = new List<Publisher>
                { noStarch, manning};

            books = new List<Book> {
                createBook("The book of F#", noStarch.Id, 2014, fancherDave.Id ),
                createBook("Learn you a Haskell for greater good", noStarch.Id, 2011,  lipovacaMiran.Id ),
                createBook("The Linux command line", noStarch.Id, 2012, shottsWilliamEJr.Id ),
                createBook("Elm in action V6", manning.Id, 2019, feldmanRichard.Id),
                createBook("Real-world Functional Programming", manning.Id, 2019, petricekTomas.Id, skeetJon.Id),
                createBook("Microservices in .Net Core", manning.Id, 2019, gammelgaardChristian.Id),
                createBook("The Design of Wab APIs", manning.Id, 2019, lauretArnaud.Id),
                createBook("Xamarin in Action", manning.Id, 2019, bennetJim.Id),
                createBook("Get Programming with F#", manning.Id, 2019, abrahamIsaac.Id),
                createBook("C# in Depth, Third Edition", manning.Id, 2019, skeetJon.Id),
                createBook("C# in Depth, Fourth Edition", manning.Id, 2019, skeetJon.Id),
            };
        }

        #region Books

        public async Task<List<Book>> GetAllBooks()
        {
            return books;
        }

        public async Task<List<Book>> GetAllBooksByAuthor(Guid id)
        {
            return books.Where(x => x.IdAuthors.Contains(id)).ToList();
        }

        public async Task<List<Book>> GetAllBooksByPublisher(Guid id)
        {
            return books.Where(x => x.IdPublisher == id).ToList();
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
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                Id = Guid.NewGuid()
            };
            authors.Add(author);
            Console.WriteLine("AddAuthor : " + author.Id);
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
            var publisher = new Publisher
            {
                Name = name,
                Id = Guid.NewGuid()
            };
            publishers.Add(publisher);
            Console.WriteLine("AddAuthor : " + publisher.Id);
            return publisher;
        }

        #endregion Publishers

        public async Task<bool> Login(UserModel model)
        {
#if DEBUG
            return true;
#endif
            return model.Name == "vchapront" && model.Password == "aze";
        }
    }
}