using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project1_SOLID
{
    // --- 1. SRP: Separate the Book class and the Printing class ---
    class Book { 
        public string Title { get; set; }
        public int Price { get; set; }
    }
  
    class BookPrinter
    {
        public void Print(Book b) => Console.WriteLine($"In book: {b.Title} have price {b.Price} ");
    }

    // ---2. OCP: Extended file reading capabilities ---
    class Reader { public virtual void Read() => Console.WriteLine("Reading regular files..."); }
    class ExtendedReader : Reader
    {
        public override void Read() { base.Read(); Console.WriteLine("Read more in the file extension..."); }
    }

    // ---3. LSP: Child class replaces parent class---
    class TopicBook : Book { public string Topic { get; set; } }

    // --- 4. ISP: Interface Separation ---
    interface IBook { void Read(); }
    interface IVideo { void Watch(); } //New videos require watching, books don't.

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PROJECT 1: SOLID PRINCIPLES ===");
                Console.WriteLine("1. Demo SRP (Single Task)");
                Console.WriteLine("2. Demo OCP (Open/Close)");
                Console.WriteLine("3. Demo LSP (Liskov Replacement)");
                Console.WriteLine("4. Demo ISP (Interface Separation)");

                Console.Write("Select demo: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Book b = new Book { Title = "The Adventures of Cricket" , Price = 100};
                        Book a = new Book { Title = "The Lord of the Rings", Price = 200 };
                        new BookPrinter().Print(a);
                        new BookPrinter().Print(b);// Classes are printed separately, and books are also printed separately.
                        break;
                    case "2":
                        Reader r = new ExtendedReader(); // Use extension classes
                        r.Read();
                        break;
                    case "3":
                        List<Book> list = new List<Book> { new Book(), new TopicBook() };
                        Console.WriteLine("List containing both Book and TopicBook runs smoothly -> LSP OK.");
                        break;
                    case "4":
                        Console.WriteLine("The interfaces have been separated: IBook is separate, IVideo is separate. The code does not have any redundant functions.");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}