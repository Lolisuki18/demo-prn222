using System;
using Microsoft.Extensions.DependencyInjection;

namespace Project2_IoC_Container
{
    // General interface 
    interface IMovieReader { void Read(); }
    class XMLReader : IMovieReader { public void Read() => Console.WriteLine("Read movie from XML..."); }
    class JSONReader : IMovieReader { public void Read() => Console.WriteLine("Read movie from JSON..."); }

    // Manual factory for IoC Demo 
    class ReaderFactory
    {
        public static IMovieReader Create(string type) => type == "XML" ? new XMLReader() : new JSONReader();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== PROJECT 2: IoC & CONTAINER ===");

            Console.WriteLine("1. Demo IoC Pattern (Using Factory)");

            Console.WriteLine("2. Demo ServiceCollection (Using a proper Container)");

            Console.Write("Choose: ");

            var choice = Console.ReadLine();

            if (choice == "1")

            {

                // Demo 1: IoC - No 'new', use Factory to create it
                Console.Write("Do you prefer XML or JSON?");

                string type = Console.ReadLine().ToUpper();

                IMovieReader reader = ReaderFactory.Create(type); // Reverse control here
                reader.Read();

            }

            else if (choice == "2")

            {
                // Demo 2: Container - Register and automatically inject

                var services = new ServiceCollection();

                // Register for the service: Anyone requesting IMovieReader should provide XMLReader

                services.AddTransient<IMovieReader, XMLReader>();

                var provider = services.BuildServiceProvider(); // Build the repository

                Console.WriteLine("Getting service from Container...");

                var reader = provider.GetService<IMovieReader>(); // Get it automatically

                reader.Read();

            }
            Console.ReadLine();

        }
    }
}