using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaGigante
{
    public abstract class Pessoa
    {
        protected Pessoa(string nome, int idade, Pessoa pai = null)
        {
            Nome = nome;
            Idade = idade;
            Pai = pai;
        }

        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa Pai { get; set; }
    }
}
