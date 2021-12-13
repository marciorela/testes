using System;
using System.Collections.Generic;

namespace AlteraParametro
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoas = new List<Pessoa>();

            pessoas.Add(new Pessoa()
            {
                Nome = "Joaquim",
                Idade = 30
            });

            pessoas.Add(new Pessoa()
            {
                Nome = "Maria",
                Idade = 40
            });

            pessoas.Add(new Pessoa()
            {
                Nome = "Antonieta",
                Idade = 50
            });

            Mostra(pessoas);

            Altera(pessoas);

            Mostra(pessoas);
        }

        private static void Altera(List<Pessoa> pessoas)
        {
            foreach (var pessoa in pessoas)
            {
                pessoa.Idade += 2;
            }

        }

        private static void Mostra(List<Pessoa> pessoas)
        {
            pessoas.ForEach(p =>
            {
                Console.Write(p.Nome);
                Console.Write("       ");
                Console.WriteLine(p.Idade);
            });
        }
    }

    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
