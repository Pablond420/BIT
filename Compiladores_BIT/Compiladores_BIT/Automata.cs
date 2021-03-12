using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    class Automata
    {
        public List<Estado> le;
        public List<Transicion> lt;
        public string nombre;
        public Automata()
        {
            le = new List<Estado>();
            lt = new List<Transicion>();
        }

    }
}
