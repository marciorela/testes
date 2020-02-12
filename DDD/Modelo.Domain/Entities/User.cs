using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Nome { get; set; }

        public string BirthDate { get; set; }

        public string Cpf { get; set; }
    }
}
