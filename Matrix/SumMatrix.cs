using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SumMatrix
    {
        private double[,] A;
        private double[,] B;
        public void GetMatrixInput(ref double[,] matrix, string matrixName)
        {
            Console.WriteLine($"Enter values for Matrix {matrixName}:");

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"Enter value for [{i + 1},{j + 1}]: ");
                    while (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }
        }
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
            A = new double[3, 3];
            B = new double[3, 3];

            GetMatrixInput(ref A, "A");
            GetMatrixInput(ref B, "B");

            Console.WriteLine("Matrix A:");
            DisplayMatrix(A);
            Console.WriteLine("Matrix B:");
            DisplayMatrix(B);

            Console.WriteLine("Press any key to sum the matrices...");
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

        public void Multiply()
        {
            A = new double[3, 3];
            GetMatrixInput(ref A, "A");
            Console.WriteLine("Matrix A:");
            DisplayMatrix(A);
            Console.WriteLine("Choose a number to multiply the matrix with:");
            double num = double.Parse(Console.ReadLine());
            Console.WriteLine("Press any key to multiply the matrix...");
            Console.ReadKey();
            for (int i = 0; i < 3; i++)
            {
                Console.Write("{");
                for (int j = 0; j < 3; j++)
                {
                    A[i, j] = A[i, j] * num;
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
        public double Determinant()
        {
            A = new double[3, 3];
            GetMatrixInput(ref A, "A");
            Console.WriteLine("Matrix A:");
            DisplayMatrix(A);
            Console.WriteLine("Press any key to find the determinant of the matrix...");
            Console.ReadKey();
            if (A.GetLength(0) != 3 || A.GetLength(1) != 3)
            {
                throw new ArgumentException("Input matrix must be a 3x3 matrix.");
            }

            double determinant =
            A[0, 0] * (A[1, 1] * A[2, 2] - A[1, 2] * A[2, 1]) -
            A[0, 1] * (A[1, 0] * A[2, 2] - A[1, 2] * A[2, 0]) +
            A[0, 2] * (A[1, 0] * A[2, 1] - A[1, 1] * A[2, 0]);

            Console.WriteLine($"Determinant of Matrix A is: {determinant}");

            return determinant;
        }
        public void GaussianElimination()
        {
            A = new double[3, 4];
            GetMatrixInput(ref A, "A");
            Console.WriteLine("Values Matrix A:");
            DisplayMatrix(A);
            Console.WriteLine("Press any key to perform Gaussian Elimination...");
            Console.ReadKey();

            int rowCount = A.GetLength(0);
            int colCount = A.GetLength(1) - 1;

            for (int i = 0; i < rowCount; i++)
            {
                int pivotRow = i;
                for (int k = i + 1; k < rowCount; k++)
                {
                    if (Math.Abs(A[k, i]) > Math.Abs(A[pivotRow, i]))
                    {
                        pivotRow = k;
                    }
                }

                if (Math.Abs(A[pivotRow, i]) < 1e-10)
                {
                    Console.WriteLine("The system is inconsistent or has infinitely many solutions.");
                    return;
                }

                if (pivotRow != i)
                {
                    for (int k = 0; k <= colCount; k++)
                    {
                        double temp = A[i, k];
                        A[i, k] = A[pivotRow, k];
                        A[pivotRow, k] = temp;
                    }
                }

                for (int j = i + 1; j < rowCount; j++)
                {
                    double factor = A[j, i] / A[i, i];
                    for (int k = i; k <= colCount; k++)
                    {
                        A[j, k] -= factor * A[i, k];
                    }
                }
            }

            Console.WriteLine("And the Matrix after Gaussian Elimination:");
            DisplayMatrix(A);

            double[] solutions = new double[rowCount];
            for (int i = rowCount - 1; i >= 0; i--)
            {
                double sum = 0.0;
                for (int j = i + 1; j < rowCount; j++)
                {
                    sum += A[i, j] * solutions[j];
                }
                solutions[i] = (A[i, colCount] - sum) / A[i, i];
            }

            Console.WriteLine("Solutions:");
            for (int i = 0; i < rowCount; i++)
            {
                Console.WriteLine($"x{i + 1} = {solutions[i]:F2}");
            }
        }
    }
}
