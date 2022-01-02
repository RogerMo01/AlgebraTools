using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraTools
{
    public class Matrix
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int[,] Elements { get; private set; }

        public Matrix(int rows, int columns) => Elements = new int[rows, columns];

        public int GetElementAt(int row, int column)
        {
            return Elements[row, column];
        }

        public void SetElementAt(int value, int row, int column)
        {
            Elements[row, column] = value;
        }

        public static Matrix AddMatrices(Matrix matrixA, Matrix matrixB)
        {
            HandleException(matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns, "Matrices cannot be added");

            Matrix result = new Matrix(matrixA.Rows, matrixA.Columns);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result.Elements[i, j] = matrixA.Elements[i, j] + matrixB.Elements[i, j];
                }
            }

            return result;
        }

        public static Matrix MultiplyMatrices(Matrix matrixA, Matrix matrixB)
        {
            HandleException(matrixA.Rows != matrixB.Columns, "Matrices cannot be added");

            Matrix result = new Matrix(matrixA.Rows, matrixA.Columns);

            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixB.Columns; j++)
                {
                    for (int k = 0; k < matrixA.Columns; k++)
                    {
                        result.Elements[i, j] += matrixA.Elements[i, k] * matrixB.Elements[k, j];
                    }
                }
            }

            return result;
        }

        public static Matrix GetTransposed(Matrix matrix)
        {
            Matrix transposedMatrix = new Matrix(matrix.Rows, matrix.Columns);

            for (int i = 0; i < matrix.Columns; i++)
            {
                for (int j = 0; j < matrix.Rows; j++)
                {
                    transposedMatrix.Elements[i, j] = matrix.Elements[j, i];
                }
            }

            return transposedMatrix;
        }

        public static bool IsSymmetrical(Matrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
                return false;

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix.Elements[i, j] != matrix.Elements[j, i])
                        return false;
                }
            }

            return true;
        }

        public static bool IsMagicSquare(Matrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
                return false;

            int diagonal1 = 0;
            int diagonal2 = 0;

            //Diagonals
            for (int i = 0; i < matrix.Rows; i++)
            {
                diagonal1 += matrix.Elements[i, i];
                diagonal2 += matrix.Elements[i, (matrix.Rows - 1) - i];
            }
            if (diagonal1 != diagonal2)
                return false;

            for (int i = 0; i < matrix.Columns; i++)
            {
                int quantity = 0;

                //Verticals
                for (int j = 0; j < matrix.Rows; j++)
                {
                    quantity += matrix.Elements[j, i];
                }
                if (quantity != diagonal1)
                    return false;

                quantity = 0;

                // Horizontals
                for (int k = 0; k < matrix.Rows; k++)
                {
                    quantity += matrix.Elements[i, k];
                }
                if (quantity != diagonal1)
                    return false;
            }

            return true;
        }

        public static void HandleException(bool condition, string message)
        {
            if (condition)
                throw new Exception(message);            
        }

        public static bool AreSameDimension(Matrix matrixA, Matrix matrixB)
        {
            return (matrixA.Elements.GetLength(0) == matrixB.Elements.GetLength(0) && matrixA.Elements.GetLength(1) == matrixB.Elements.GetLength(1));
        }
    }
}
