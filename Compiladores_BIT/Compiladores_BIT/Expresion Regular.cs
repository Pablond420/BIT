using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    public class Expresion_Regular
    {
        public char letra;
        public int numero;
        public char operador;
        public int tipo; //0 = operando, 1 = operador, 2 = parentesis izquierdo, 3 = parentesis derecho

        public Expresion_Regular()
        {

        }
    }
}
