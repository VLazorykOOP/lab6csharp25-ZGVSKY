using System;
using System.Runtime.Serialization;

namespace Lab6
{
    public class Task3
    {
        public static void Execute()
        {
            Console.WriteLine("--- Testing Exceptions ---");

            try
            {
                TestCustomException(-5);
            }
            catch (InvalidProductPriceException ex)
            {
                Console.WriteLine($"Caught Custom Exception: {ex.Message}");
            }

            try
            {
                throw new StackOverflowException("Simulated Stack Overflow!");
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine($"Caught Standard Exception: {ex.GetType().Name} - {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Exception handling block finished (Finally executed).");
            }
        }

        private static void TestCustomException(decimal price)
        {
            if (price < 0)
            {
                throw new InvalidProductPriceException("Product price cannot be negative.");
            }
        }
    }

    [Serializable]
    public class InvalidProductPriceException : ApplicationException
    {
        public InvalidProductPriceException() { }
        public InvalidProductPriceException(string message) : base(message) { }
        public InvalidProductPriceException(string message, Exception inner) : base(message, inner) { }
        protected InvalidProductPriceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}