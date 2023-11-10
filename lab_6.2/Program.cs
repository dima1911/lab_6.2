using System;

public class MathOperations
{
    // Перевантажений метод для додавання чисел
    public static T Add<T>(T a, T b)
    {
        dynamic valueA = a;
        dynamic valueB = b;
        return valueA + valueB;
    }

    // Перевантажений метод для додавання масивів чисел
    public static T[] Add<T>(T[] array1, T[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        T[] result = new T[array1.Length];
        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = Add(array1[i], array2[i]);
        }
        return result;
    }

    // Перевантажений метод для додавання матриць
    public static T[,] Add<T>(T[,] matrix1, T[,] matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions.");

        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        T[,] result = new T[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = Add(matrix1[i, j], matrix2[i, j]);
            }
        }
        return result;
    }

    // Перевантажений метод для додавання тензорів
    public static T[,,] Add<T>(T[,,] tensor1, T[,,] tensor2)
    {
        if (tensor1.GetLength(0) != tensor2.GetLength(0) ||
            tensor1.GetLength(1) != tensor2.GetLength(1) ||
            tensor1.GetLength(2) != tensor2.GetLength(2))
            throw new ArgumentException("Tensors must have the same dimensions.");

        int dim1 = tensor1.GetLength(0);
        int dim2 = tensor1.GetLength(1);
        int dim3 = tensor1.GetLength(2);

        T[,,] result = new T[dim1, dim2, dim3];
        for (int i = 0; i < dim1; i++)
        {
            for (int j = 0; j < dim2; j++)
            {
                for (int k = 0; k < dim3; k++)
                {
                    result[i, j, k] = Add(tensor1[i, j, k], tensor2[i, j, k]);
                }
            }
        }
        return result;
    }

    // Додайте аналогічні перевантажені методи для віднімання та множення, якщо потрібно
    public static T Subtract<T>(T a, T b)
    {
        dynamic valueA = a;
        dynamic valueB = b;
        return valueA - valueB;
    }

    public static T[] Subtract<T>(T[] array1, T[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        T[] result = new T[array1.Length];
        for (int i = 0; i < array1.Length; i++)
        {
            result[i] = Subtract(array1[i], array2[i]);
        }
        return result;
    }

    public static T[,] Subtract<T>(T[,] matrix1, T[,] matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions.");

        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        T[,] result = new T[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = Subtract(matrix1[i, j], matrix2[i, j]);
            }
        }
        return result;
    }

    public static T Multiply<T>(T a, T b)
    {
        dynamic valueA = a;
        dynamic valueB = b;
        return valueA * valueB;
    }

    public static T[] Multiply<T>(T[] array, T scalar)
    {
        T[] result = new T[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = Multiply(array[i], scalar);
        }
        return result;
    }

    public static T[,] Multiply<T>(T[,] matrix, T scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        T[,] result = new T[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = Multiply(matrix[i, j], scalar);
            }
        }
        return result;
    }

    public static T[,] Multiply<T>(T[,] matrix1, T[,] matrix2)
    {
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
            throw new ArgumentException("Number of columns in the first matrix must be equal to the number of rows in the second matrix.");

        int rows = matrix1.GetLength(0);
        int cols = matrix2.GetLength(1);
        int commonDim = matrix1.GetLength(1);

        T[,] result = new T[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = default(T);
                for (int k = 0; k < commonDim; k++)
                {
                    result[i, j] = Add(result[i, j], Multiply(matrix1[i, k], matrix2[k, j]));
                }
            }
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання
        Console.WriteLine("Addition:");
        Console.WriteLine(MathOperations.Add(2, 3));
        Console.WriteLine(MathOperations.Add(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }));
        Console.WriteLine(MathOperations.Add(new int[,] { { 1, 2 }, { 3, 4 } }, new int[,] { { 5, 6 }, { 7, 8 } }));
        Console.WriteLine(MathOperations.Add(new int[,,] { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } }, new int[,,] { { { 9, 10 }, { 11, 12 } }, { { 13, 14 }, { 15, 16 } } }));

        Console.WriteLine("\nSubtraction:");
        Console.WriteLine(MathOperations.Subtract(5, 3));
        Console.WriteLine(MathOperations.Subtract(new int[] { 4, 5, 6 }, new int[] { 1, 2, 3 }));
        Console.WriteLine(MathOperations.Subtract(new int[,] { { 5, 6 }, { 7, 8 } }, new int[,] { { 1, 2 }, { 3, 4 } }));

        Console.WriteLine("\nMultiplication:");
        Console.WriteLine(MathOperations.Multiply(2, 3));
        Console.WriteLine(MathOperations.Multiply(new int[] { 1, 2, 3 }, 2));
        Console.WriteLine(MathOperations.Multiply(new int[,] { { 1, 2 }, { 3, 4 } }, new int[,] { { 5, 6 }, { 7, 8 } }));
    }
}
