using System;

namespace EnumToString
{
    class Program
    {
        static void Main(string[] args)
        {
            var wd = EWeekdays.Quinta;

            int v1 = (int)wd;
            string v2 = wd.ToString();

            Console.WriteLine(v1);
            Console.WriteLine(v2);

        }
    }
}
