using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    class Estado
    {
        public int id_e;
        public int numero;
        public string tipo_edo;
        public string id_AFD;
        public List<Estado> estados;

        public Estado()
        {
            tipo_edo = "normal";
        }

        //Estado del AFD (Que tiene un conjunto de estados AFN)
        public Estado(List<Estado> estados)
        {
            tipo_edo = "normal";
            this.estados = estados;
        }
    }
}
