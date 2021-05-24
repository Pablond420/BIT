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
                cuerpo.Add(new Elemento(e.tipo,e.texto));
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
        
        public List<Elemento> recorrePunto()
        {
            List<Elemento> c = new List<Elemento>();
            c.Clear();
            Copia_Lista2(cuerpo, c);
            int indexPunto = c.IndexOf(c.Find(x => x.tipo.Equals("p")));
            Elemento punto = new Elemento(c.ElementAt(indexPunto).tipo, c.ElementAt(indexPunto).texto);
            Elemento next;
            if (indexPunto < c.Count() - 1)
                next = new Elemento(c.ElementAt(indexPunto + 1).tipo, c.ElementAt(indexPunto + 1).texto);
            else
                next = new Elemento("vacio", "ε");
            c[indexPunto] = next;
            if (next != null)
                c[indexPunto + 1] = punto;
            else
                c.Add(punto);

            return c;
        }

        public void Copia_Lista2(List<Elemento> c, List<Elemento> a)
        {
            foreach (Elemento e in c)
            {
                a.Add(new Elemento(e.tipo,e.texto));
            }
        }
        

    }
}
