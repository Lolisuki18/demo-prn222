using System;
using System.Collections.Generic;

namespace Project1_SOLID
{
    // --- 1. SRP: Separate the Book class and the Printing class ---
    class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
    }

    // ===== DIP PART =====

    // Abstraction
    interface IBookPrinter
    {
        void Print(Book book);
    }

    // Low-level module
    class BookPrinter : IBookPrinter
    {
        public void Print(Book b)
        {
            Console.WriteLine($"In book: {b.Title} have price {b.Price}");
        }
    }

    // High-level module
    class BookService
    {
        private readonly IBookPrinter _printer;

        public BookService(IBookPrinter printer)
        {
            _printer = printer;
        }

        public void PrintBook(Book book)
        {
            _printer.Print(book);
        }
    }

    // --- 2. OCP: Extended file reading capabilities ---
    class Reader
    {
        public virtual void Read()
        {
            Console.WriteLine("Reading regular files...");
        }
    }

    class ExtendedReader : Reader
    {
        public override void Read()
        {
            base.Read();
            Console.WriteLine("Read more in the file extension...");
        }
    }

    // --- 3. LSP: Child class replaces parent class ---
    class TopicBook : Book
    {
        public string Topic { get; set; }
    }

    // --- 4. ISP: Interface Separation ---
    interface IBook { void Read(); }
    interface IVideo { void Watch(); }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool check = true;
            while (check)
            {
                Console.Clear();
                Console.WriteLine("=== PROJECT 1: SOLID PRINCIPLES ===");
                Console.WriteLine("1. Demo SRP (Single Responsibility)");
                Console.WriteLine("2. Demo OCP (Open / Closed)");
                Console.WriteLine("3. Demo LSP (Liskov Substitution)");
                Console.WriteLine("4. Demo ISP (Interface Segregation)");
                Console.WriteLine("5. Demo DIP (Dependency Inversion)");
                Console.Write("Select demo: ");

                switch (Console.ReadLine())
                {
                    case "1": // SRP
                        Book b1 = new Book { Title = "The Adventures of Cricket", Price = 100 };
                        Book b2 = new Book { Title = "The Lord of the Rings", Price = 200 };

                        new BookPrinter().Print(b1);
                        new BookPrinter().Print(b2);
                        break;

                    case "2": // OCP
                        Reader r = new ExtendedReader();
                        r.Read();
                        break;

                    case "3": // LSP
                        List<Book> list = new List<Book>
                        {
                            new Book { Title = "Normal Book", Price = 120 },
                            new TopicBook { Title = "Science Book", Price = 150, Topic = "Physics" }
                        };

                        foreach (var book1 in list)
                        {
                            Console.WriteLine(book1.Title);
                        }

                        Console.WriteLine("Book and TopicBook can replace each other -> LSP OK");
                        break;

                    case "4": // ISP
                        Console.WriteLine("IBook and IVideo are separated.");
                        Console.WriteLine("Classes only implement what they really need.");
                        break;

                    case "5": // DIP
                        Book book = new Book { Title = "Clean Code", Price = 300 };

                        IBookPrinter printer = new BookPrinter(); // implementation
                        BookService service = new BookService(printer); // inject abstraction

                        service.PrintBook(book);

                        Console.WriteLine("High-level module depends on abstraction -> DIP OK");
                        break;
                    default:
                        Console.WriteLine("Stop");
                        check = false;
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}
