using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    class Elemento
    {
        public string tipo;
        public string texto;
        public List<string> Siguientes = new List<string>();

        public Elemento(string ti, string te)
        {
            tipo = ti;
            texto = te;
        }
        public Elemento()
        {

        }
        public Elemento(string ti, string te, List<string> Sig)
        {
            tipo = ti;
            texto = te;
            Siguientes = Sig;
        }
    }
}
