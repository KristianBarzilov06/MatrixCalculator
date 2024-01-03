using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SumMatrix
    {
        double[,] A = { { 2, -1, 3 },
                            { 4, 5, 6 },
                            { 5, 6, 7 },
        };
        double[,] B = { { 4, -1, 2 },
                            { 5, 6, 7 },
                            { 6, 7, 8 },
        };
        public void DisplayMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j]);
                    if (j < columns - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Sum()
        {
            Console.WriteLine("Matrix A:");
            DisplayMatrix(A);
            Console.WriteLine("Matrix B:");
            DisplayMatrix(B);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.WriteLine("Result:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{");
                for (int j = 0; j < 3; j++)
                {
                    A[i, j] = A[i, j] + B[i, j];
                    Console.Write(A[i, j]);
                    if (j < 2)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("}");
                Console.WriteLine();
            }
        }
    }
}
