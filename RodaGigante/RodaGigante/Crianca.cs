using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaGigante
{
    public class Crianca : Pessoa
    {
        public Crianca(string nome, int idade, Pessoa pai = null) : base(nome, idade, pai)
        {
        }
    }
}
