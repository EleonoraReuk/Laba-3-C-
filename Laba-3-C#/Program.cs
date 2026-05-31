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

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Матричный калькулятор");
            Console.ReadKey();
        }
    }
}