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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Матричный калькулятор");
            Console.ReadKey();
        }
    }
}