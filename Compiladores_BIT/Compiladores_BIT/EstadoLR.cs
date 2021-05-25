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

        public EstadoLR(List<Produccion> a, int n)
        {
            I = new List<Produccion>();
            Copia_Lista(a);
            numero_edo = n;
        }

        public void Copia_Lista(List<Produccion> c)
        {
            foreach (Produccion e in c)
            {
                I.Add(e);
            }
        }


    }
}
