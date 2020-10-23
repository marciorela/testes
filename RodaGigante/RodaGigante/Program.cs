using System;

namespace RodaGigante
{
    class Program
    {
        static void Main(string[] args)
        {
            var roda = new RodaGigante();

            Adulto paulo = new Adulto("Paulo", 42);

            Crianca joao = new Crianca("Joao", 5, paulo);
            Crianca maria = new Crianca("Maria", 12, paulo);

            Crianca pedro = new Crianca("Pedro", 13);
            Crianca henrique = new Crianca("Henrique", 10);

            Console.WriteLine(roda.Embarcar(2, joao, maria));
            Console.WriteLine(roda.Embarcar(2, joao, paulo));
            Console.WriteLine(roda.Embarcar(3, maria));
            Console.WriteLine(roda.Embarcar(13, pedro));
            Console.WriteLine(roda.Embarcar(16, henrique));

            roda.Status();
        }
    }
}
