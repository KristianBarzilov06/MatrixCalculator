using System.Security.Cryptography.X509Certificates;

namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("By chose operation to proceed:");
            Console.WriteLine("1. Sum      //For the sum you will need to insert two matrices");
            Console.WriteLine("2. Multiply");
            Console.WriteLine("3. Determinant");
            Console.WriteLine("4. Gaussian Elimination");

            string choice = Console.ReadLine();

            SumMatrix sumMatrix = new SumMatrix();

            switch (choice)
            {
                case "1":
                    sumMatrix.Sum();
                    break;
                case "2":
                    sumMatrix.Multiply();
                    break;
                case "3":
                    sumMatrix.Determinant();
                    break;
                case "4":
                    sumMatrix.GaussianElimination();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}