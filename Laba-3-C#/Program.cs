using System;

namespace MatrixCalculator
{

    public class MatrixException: Exception
    {
        public MatrixException(string message) : base(message) { }
    }

    public class MatrixDimensionException : MatrixException
    {
        public MatrixDimensionException(string message) : base(message) { }
    }

    public class SingularMatrixException : MatrixException
    {
        public SingularMatrixException(string message) : base(message) { }
    }


    public class SquareMatrix
    {
        private double[,] data;
        private int size;

        public int Size => size;

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }


        public SquareMatrix(int size)
        {
            if (size <= 0)
                throw new MatrixDimensionException("Размер матрицы должен быть положительным");

            this.size = size;
            data = new double[size, size];
        }

        public SquareMatrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new MatrixDimensionException("Матрица должна быть квадратной");

            size = matrix.GetLength(0);
            data = (double[,])matrix.Clone();
        }

        public SquareMatrix(int size, int minValue, int maxValue) : this(size)
        {
            Random rand = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    data[i, j] = rand.Next(minValue, maxValue);
        }

        public SquareMatrix(int size, double minValue, double maxValue) : this(size)
        {
            Random rand = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    data[i, j] = minValue + rand.NextDouble() * (maxValue - minValue);
        }

        public SquareMatrix(SquareMatrix other) : this(other.size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    data[i, j] = other.data[i, j];
        }

        public override string ToString()
        {
            string result = $"Матрица {size}x{size}:\n";
            for(int i = 0; i < size; i++)
            {
                for (int j = 0;j < size; j++)
                {
                    result += $"{data[i, j],8:F2} ";
                }
                result += "\n";
            }
            return result;
        }




        public double Determinant()
        {
            if (size == 1)
                return data[0, 0];

            if (size == 2)
                return data[0, 0] * data[1, 1] - data[0, 1] * data[1, 0];

            double det = 0;
            for (int j = 0, j < size; j++)
            {
                det += data[0, j] * Cofactor(0, j);
            }
            return det;
        }

        private double Cofactor(int row, int col)
        {
            return Math.Pow(-1, row + col) * Minor(row, col);
        }

        private double Minor(int row, int col)
        {
            SquareMatrix subMatrix = new SquareMatrix(size - 1);
            int subI = 0, subJ = 0;

            for (int i = 0; i < size; i++)
            {
                if (i == row) continue;
                subJ = 0;
                for (int j = 0; j < size; j++)
                {
                    if (j == col) continue;
                    subMatrix[subI, subJ] = data[i, j];
                    subJ++;
                }
                subJ++;
            }
            return subMatrix.Determinant();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Матричный калькулятор");

            try
            {
                Console.WriteLine("Создание матриц");
                SquareMatrix matrix1 = new SquareMatrix(3, 1, 5);
                SquareMatrix matrix2 = new SquareMatrix(3, 1, 5);
                Console.WriteLine(matrix1);
                Console.WriteLine(matrix2);
            }
            catch 
            {
                Console.WriteLine("Ошибка");
            }

            Console.ReadKey();
        }
    }
}