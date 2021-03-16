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
        public string[,] AFN_MTransicion;
        public string nombre;
        public char[] alfabeto;

        public Automata()
        {
            le = new List<Estado>();
            lt = new List<Transicion>();
        }

        public void setAlfabeto()
        {
            int contCaract = 0;
            alfabeto = new char[1];
            //var unicoAlfab = 
            foreach(Transicion t_e in lt)
            {
                int iOp = getIndexChar(t_e.operando);
                if(iOp == -1)
                {
                    alfabeto[contCaract++] = t_e.operando;
                    Array.Resize(ref alfabeto, alfabeto.Count() + 1);
                        
                    
                }
            }
        }

        public void getMatrizAFN()
        {
            setAlfabeto();
            int estados = le.Count();
            int trans = alfabeto.Count()-1;
            AFN_MTransicion = new string[estados, trans];
            foreach (Estado e in le)
            {
                var lt_ = lt.FindAll(t => t.origen.Equals(e));
                int index_e = le.IndexOf(e);
                foreach (Transicion t_e in lt_)
                {
                    int indexAlf = getIndexChar(t_e.operando);
                    if(AFN_MTransicion[index_e, indexAlf] == null)
                        AFN_MTransicion[index_e, indexAlf] = t_e.destino.id_e.ToString();
                    else if (AFN_MTransicion[index_e, indexAlf] != null && AFN_MTransicion[index_e, indexAlf] != "Φ")
                        AFN_MTransicion[index_e, indexAlf] = AFN_MTransicion[index_e, indexAlf] +","+t_e.destino.id_e.ToString();
                    for(int x = 0; x<alfabeto.Count()-1; x++)
                    {
                        if(x != indexAlf)
                            AFN_MTransicion[index_e, x] = "Φ";
                    }
                }
            }
            for (int x = 0; x < alfabeto.Count() - 1; x++)
            {
                    AFN_MTransicion[le.Count()-1, x] = "Φ";
            }
        }

        public int getIndexChar(char c)
        {
            for(int ch = 0; ch<alfabeto.Count(); ch++)
            {
                if (alfabeto[ch].Equals(c))
                    return ch;
            }
            return -1;
        }

        public void setNumeracionEstados()
        {
            int id_Edo = 0;
            foreach(Estado e in le)
            {
                e.id_e = id_Edo;
                if (id_Edo == 0)
                    e.tipo_edo = "inicial";
                id_Edo++;
            }
            le.Last().tipo_edo = "aceptación";
        }
    }
}
