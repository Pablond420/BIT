using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    class Transicion
    {
        public Estado origen;
        public Estado destino;
        public int id_tran;
        public char operando;

        public EstadoLR origenLR;
        public EstadoLR destinoLR;
        public string operandoLR;

        public Transicion()
        {

        }

        public Transicion(Estado origen, Estado destino, char operando, int id)
        {
            this.origen = origen;
            this.destino = destino;
            this.operando = operando;
            this.id_tran = id;
        }

        public Transicion(EstadoLR origen, EstadoLR destino, string operando)
        {
            this.origenLR = origen;
            this.destinoLR = destino;
            this.operandoLR = operando;
        }
    }
}
