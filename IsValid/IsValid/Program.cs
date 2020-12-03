using System;

namespace IsValid
{
    class Program
    {
        static void Main(string[] args)
        {
            var funcionario = new Funcionario();

            Console.WriteLine("=====================================================");
            funcionario.ShowNotifications();

            Console.WriteLine("=====================================================");
            funcionario.Email = "a";
            funcionario.ShowNotifications();

            Console.WriteLine("=====================================================");
            funcionario.Email = "aaaa@aaa.com.br";
            funcionario.ShowNotifications();
        }
    }
}
