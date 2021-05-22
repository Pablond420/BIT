using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{

    class EstadoLR
    {
        public List<Produccion> I;
        public int numero_edo;

        public EstadoLR()
        {
            I = new List<Produccion>();
        }


    }
}
