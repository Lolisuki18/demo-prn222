using System;

namespace Project3_DI_Patterns
{
    // Dependency 
    interface IDept { void Work(); }
    class IT : IDept { public void Work() => Console.WriteLine("IT is coding..."); }
    class HR : IDept { public void Work() => Console.WriteLine("HR is hiring..."); }

    class Employee
    {
        // 1. Constructor Injection 
        private IDept _dept;
        public Employee(IDept dept) { _dept = dept; } // Dept is required to create employee 
        public void DoWork() { Console.Write("Constructor: "); _dept.Work(); }

        // 2. Property Injection 
        public IDept PropDept { get; set;  } // Can be assigned later 

        // 3. Method Injection 
        public void AssignDept(IDept dept) { Console.Write("Method: "); dept.Work(); }
    }

    // 4. Ambient Context 
    class GlobalContext { public static IDept Current; }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== PROJECT 3: DI PATTERNS ===");

            // Demo 1: Constructor Injection 
            Console.WriteLine("\n--- 1. Constructor Injection (Most recommended) ---");
            Employee e1 = new Employee(new IT()); // Inject at creation time 
            e1.DoWork();

            // Demo 2: Property Injection 
            Console.WriteLine("\n--- 2. Property Injection ---");
            Employee e2 = new Employee(new IT());
            e2.PropDept = new HR(); // Assign later (Optional) 
            Console.Write("Property: "); e2.PropDept.Work();

            // Demo 3: Method Injection 
            Console.WriteLine("\n--- 3. Method Injection ---");
            e2.AssignDept(new IT()); // Only inject when calling the function 

            // Demo 4: Ambient Context 
            Console.WriteLine("\n--- 4. Ambient Context ---");
            GlobalContext.Current = new HR(); // Global assignment 
            Console.Write("Global: "); GlobalContext.Current.Work();

            Console.ReadLine();
        }
    }
}