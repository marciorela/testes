using System;

namespace Formats
{
    class Program
    {
        static void Main(string[] args)
        {
            Double valor = 1345.87;

            Console.WriteLine($"{valor}");
            Console.WriteLine($"{valor:n2}");
            Console.WriteLine($"{valor,12:n2}");
        }
    }
}
