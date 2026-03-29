using System;

namespace Lab6
{
    public class Task2
    {
        public static void Execute()
        {
            IProduct[] catalog = new IProduct[]
            {
                new Toy("Lego", 50.0m, "Plastic"),
                new Book("C# Basics", 25.5m, "John Doe"),
                new SportsEquipment("Dumbbells", 40.0m, 10),
                new Toy("Action Figure", 15.0m, "PVC")
            };

            Array.Sort(catalog);

            Console.WriteLine("--- Catalog Sorted by Price ---");
            foreach (var item in catalog) item.Show();

            Console.Write("\nEnter product type to search (Toy/Book/SportsEquipment): ");
            string searchType = Console.ReadLine()!;

            Console.WriteLine($"\n--- Search Results for '{searchType}' ---");
            bool found = false;
            foreach (var item in catalog)
            {
                if (item.IsTypeMatch(searchType))
                {
                    item.Show();
                    found = true;
                }
            }

            if (!found) Console.WriteLine("No items found.");
        }
    }

    public interface IProduct : IComparable<IProduct>, ICloneable
    {
        string Name { get; set; }
        decimal Price { get; set; }
        void Show();
        bool IsTypeMatch(string typeName);
    }

    public abstract class ProductBase : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductBase(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public abstract void Show();

        public bool IsTypeMatch(string typeName)
        {
            return this.GetType().Name.Equals(typeName, StringComparison.OrdinalIgnoreCase);
        }

        public int CompareTo(IProduct? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class Toy : ProductBase
    {
        public string Material { get; set; }

        public Toy(string name, decimal price, string material) : base(name, price)
        {
            Material = material;
        }

        public override void Show() => Console.WriteLine($"[Toy] {Name} - ${Price} (Material: {Material})");
    }

    public class Book : ProductBase
    {
        public string Author { get; set; }

        public Book(string name, decimal price, string author) : base(name, price)
        {
            Author = author;
        }

        public override void Show() => Console.WriteLine($"[Book] {Name} - ${Price} (Author: {Author})");
    }

    public class SportsEquipment : ProductBase
    {
        public int WeightKg { get; set; }

        public SportsEquipment(string name, decimal price, int weightKg) : base(name, price)
        {
            WeightKg = weightKg;
        }

        public override void Show() => Console.WriteLine($"[Sports] {Name} - ${Price} (Weight: {WeightKg}kg)");
    }
}