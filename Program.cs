using System;
using System.Collections.Generic;

class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
}

class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void ViewAllBooks()
    {
        Console.WriteLine("All Books in the Library:");
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Available: {(book.IsAvailable ? "Yes" : "No")}");
        }
    }

    public void SearchBookById(int bookId)
    {
        var book = books.Find(b => b.BookId == bookId);
        if (book != null)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Available: {(book.IsAvailable ? "Yes" : "No")}");
        }
        else
        {
            Console.WriteLine("Book not found with the given ID.");
        }
    }

    public void SearchBookByTitle(string title)
    {
        var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Available: {(book.IsAvailable ? "Yes" : "No")}");
        }
        else
        {
            Console.WriteLine("Book not found with the given title.");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\nLibrary Management System Menu:");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. View All Books in the Library");
            Console.WriteLine("3. Search the book by ID");
            Console.WriteLine("4. Search the book by Title");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choiceStr = Console.ReadLine();

            if (!int.TryParse(choiceStr, out int choice))
            {
                Console.WriteLine("Invalid choice. Please enter a valid option.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Book ID: ");
                    int bookId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Title Name: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Author Name: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter Genre: ");
                    string genre = Console.ReadLine();
                    Book newBook = new Book
                    {
                        BookId = bookId,
                        Title = title,
                        Author = author,
                        Genre = genre,
                        IsAvailable = true
                    };
                    library.AddBook(newBook);
                    Console.WriteLine("Book added successfully!");
                    break;

                case 2:
                    library.ViewAllBooks();
                    break;

                case 3:
                    Console.Write("Enter Book ID to search: ");
                    int searchId = int.Parse(Console.ReadLine());
                    library.SearchBookById(searchId);
                    break;

                case 4:
                    Console.Write("Enter Book Title to search: ");
                    string searchTitle = Console.ReadLine();
                    library.SearchBookByTitle(searchTitle);
                    break;

                case 5:
                    Console.WriteLine("Exiting Library Management System...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
