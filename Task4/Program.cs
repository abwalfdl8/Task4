using System.Net;

namespace Task4
{
    internal class Program
    {
        class Book
        {
            public Book(string title, string author, string nISBN, bool isAvailable = true)
            {
                Title = title;
                Author = author;
                ISBN = nISBN;
                IsAvailable = isAvailable;
            }

            public string Title { get; private set; }
            public string Author { get; private set; }
            public string ISBN { get; private set; }
            public bool IsAvailable { get; set; }







        }
        class Library
        {


            private List<Book> Books = new List<Book>();



            //methods
            public void AddBook(Book book)
            {

                Books.Add(book);
                Console.WriteLine($"the book >> \"{book.Title}\" : Adding to the library ");

            }

            public Book SearchBook(string title)
            {
                for (int i = 0; i < Books.Count; i++)
                {
                    if (title.ToLower() == Books[i].Title.ToLower())
                    {
                        return Books[i];
                    }


                }

                return null;

            }

            public bool BorrowBook(string title)
            {
                Book book = SearchBook(title);

                if (book != null && book.IsAvailable)
                {
                    book.IsAvailable = false;
                    Console.WriteLine($"the book :\" {book.Title} \" is borrowed ");
                    return true;
                }

                Console.WriteLine("the book is not avaliable now ");
                return false;

            }


            public bool ReturnBook(string title)
            {
                Book book = SearchBook(title);

                if (book != null && !book.IsAvailable)
                {
                    book.IsAvailable = true;
                    Console.WriteLine($"\"{book.Title}\" returned to the library");
                    return true;
                }
                Console.WriteLine($"can not return book because is not found or not borrowed");
                return false;
            }
        }



        static void Main(string[] args)
        {

            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
            Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084");
            Book book3 = new Book("1984", "George Orwell", "9780451524935");
          
            Library library = new Library();

            // Adding books to the library
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            Console.WriteLine("\n********************************************************\n");
            //search for book
            Book foundBook = library.SearchBook("the great gatsby");
            if (foundBook != null)
            {
                Console.WriteLine($"the book >> \"{foundBook.Title}\" is founded in the library");

            }
            else
            {
                Console.WriteLine($"the book you search about is not found ");
            }
            Console.WriteLine("\n********************************************************\n");

            //borrowing books

            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter");
            Console.WriteLine("\n********************************************************\n");
            // Returning books
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter");
            Console.WriteLine("\n********************************************************\n");




        }


      


    }
}

