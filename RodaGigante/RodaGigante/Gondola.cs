using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaGigante
{
    public class Gondola
    {
        public Gondola(Pessoa pessoa1, Pessoa pessoa2)
        {
            Pessoa1 = pessoa1;
            Pessoa2 = pessoa2;
        }

        public Pessoa Pessoa1 { get; set; }
        public Pessoa Pessoa2 { get; set; }
    }
}
