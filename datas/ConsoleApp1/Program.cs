using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d1 = DateTime.Parse("2020-07-23 10:34:00");
            DateTime d2 = DateTime.Parse("2020-07-25 10:34:00");

            var dias = (d2 - d1).TotalDays;

            Console.WriteLine(dias);
        }
    }
}
