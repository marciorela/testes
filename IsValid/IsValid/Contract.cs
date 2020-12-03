using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsValid
{
    public class Contract : Notifiable
    {

        public Contract Requires()
        {
            return this;
        }
    }
}
