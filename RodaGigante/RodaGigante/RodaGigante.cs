using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaGigante
{
    public class RodaGigante
    {
        public Gondola[] Gondolas { get; set; } = new Gondola[20];

        public string Embarcar(int numeroGondola, Pessoa pessoa1, Pessoa pessoa2 = null)
        {
            if (Gondolas[numeroGondola] != null)
            {
                return "Gondola já ocupada.";
            }

            if (pessoa1.Idade < 12 && (pessoa2 == null || pessoa2 != null && pessoa1.Pai != pessoa2))
            {
                return $"ERRO: {pessoa1.Nome} é menor de 12 e o pai não está junto.";
            }
            else if (pessoa1.Idade < 12 && pessoa2 != null && pessoa1.Pai != pessoa2)
            {
                return $"ERRO: {pessoa2.Nome} não é o pai de {pessoa1.Nome}";
            }
            else if (pessoa1.Idade < 12 && pessoa1.Pai == null)
            {
                return $"ERRO: {pessoa1.Nome} é menor de 12 anos e não sabemos quem é o pai.";
            }

            Gondolas[numeroGondola - 1] = new Gondola(pessoa1, pessoa2);

            return "Ok";
        }

        public void Status()
        {
            for (var i = 0; i < Gondolas.Length; i++)
            {
                Console.Write(i + 1);
                Console.Write("       ");
                if (Gondolas[i] == null)
                {
                    Console.WriteLine("(vazia)");
                }
                else
                {
                    if (Gondolas[i].Pessoa2 == null)
                    {
                        Console.WriteLine($"Somente {Gondolas[i].Pessoa1.Nome}");
                    }
                    else
                    {
                        Console.WriteLine($"{Gondolas[i].Pessoa1.Nome} e {Gondolas[i].Pessoa2.Nome}");
                    }
                }
            }
        }
    }
}
