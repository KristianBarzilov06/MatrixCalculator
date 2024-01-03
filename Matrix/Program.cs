using System.Security.Cryptography.X509Certificates;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Display random Matrix A and B, then Sum");
            Console.WriteLine("2. OtherOperation");

            string choice = Console.ReadLine();

            SumMatrix sumMatrix = new SumMatrix();

            switch (choice)
            {
                case "1":
                    sumMatrix.Sum();
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}