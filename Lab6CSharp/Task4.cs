using System;
using System.Collections;

namespace Lab6
{
    public class Task4
    {
        public static void Execute()
        {
            ProductCatalog catalog = new ProductCatalog();
            catalog.Add(new Toy("Car", 10.0m, "Metal"));
            catalog.Add(new Book("C# Advanced", 30.0m, "Jane Doe"));
            catalog.Add(new SportsEquipment("Ball", 15.0m, 1));

            Console.WriteLine("--- Iterating through Custom Collection using foreach ---");
            foreach (IProduct product in catalog)
            {
                product.Show();
            }
        }
    }

    public class ProductCatalog : IEnumerable, IEnumerator
    {
        private IProduct[] _products = new IProduct[10];
        private int _count = 0;
        private int _position = -1;

        public void Add(IProduct product)
        {
            if (_count < _products.Length)
            {
                _products[_count++] = product;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _count);
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current
        {
            get
            {
                if (_position < 0 || _position >= _count)
                    throw new InvalidOperationException();
                return _products[_position];
            }
        }
    }
}