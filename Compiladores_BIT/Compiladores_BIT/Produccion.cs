using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    class Produccion
    {
        public Elemento encabezado = new Elemento();
        public List<Elemento> cuerpo;
        public Elemento B = new Elemento();
        public Produccion()
        {
            cuerpo = new List<Elemento>();
        }
        public Produccion(Elemento e, List<Elemento> c)
        {
            cuerpo = new List<Elemento>();
            encabezado.texto = e.texto;
            encabezado.tipo = e.tipo;
            Copia_Lista(c);
        }

        public void Copia_Lista(List<Elemento> c)
        {
            foreach(Elemento e in c)
            {
                cuerpo.Add(e);
            }
        }

        public void Despues_del_Punto()
        {
            for(int i=0; i<cuerpo.Count(); i++)
            {
                if(cuerpo.ElementAt(i).texto.Equals("."))
                {
                    if(i<cuerpo.Count()-1)
                    {
                        B.texto = cuerpo.ElementAt(i+1).texto;
                        B.tipo = cuerpo.ElementAt(i + 1).tipo;
                    }else
                    {
                        B.texto = "ϵ";
                        B.tipo = "vacio";
                    }
                }
            }

        }

        
    }
}
