using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreGenealogica
{
    public class Pessoa
    {
        public Pessoa(string nome, Pessoa conjuge = null)
        {
            Nome = nome;
            Conjuge = conjuge;

            Filhos = new List<Pessoa>();
        }

        public void AddFilho(Pessoa filho)
        {
            Filhos.Add(filho);
        }

        public void Imprimir(int nivel = 0)
        {
            Console.Write($"{new String(' ', nivel * 4)} -->{Nome} ");
            if (Conjuge == null)
            {
                Console.WriteLine("é solteiro(a).");
            } 
            else
            {
                Console.WriteLine($"é casado(a) com {Conjuge.Nome} filhos:");
                foreach (var filho in Filhos)
                {
                    filho.Imprimir(nivel+1);
                }
            }
        }

        public string Nome { get; set; }
        public Pessoa Conjuge { get; set; }

        public IList<Pessoa> Filhos { get; set; }
    }
}
