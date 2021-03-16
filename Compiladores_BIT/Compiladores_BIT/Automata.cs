using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_BIT
{
    class Automata
    {
        public List<Estado> le; //Lista de estados
        public List<Transicion> lt; //Lista de transiciones
        public string[,] AFN_MTransicion; //Matriz de Transiciones AFN
        public string nombre; //Nombre del automata
        public char[] alfabeto; //Alfabeto que acepta el automata

        public Automata()
        {
            le = new List<Estado>();
            lt = new List<Transicion>();
        }

        /// <summary>
        /// Determina el alfabeto que acepta un automata incluyendo epsilon (en caso de que aplique)
        /// </summary>
        public void setAlfabeto()
        {
            int contCaract = 0;
            alfabeto = new char[1];
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

        /// <summary>
        /// Obtiene la matriz de transiciones AFN
        /// </summary>
        public void getMatrizAFN()
        {
            //Configura el alfabeto
            setAlfabeto();
            //Determina estados x transiciones para dimensionar la matriz
            int estados = le.Count();
            int trans = alfabeto.Count()-1;
            AFN_MTransicion = new string[estados, trans];
            //Itera por cada estado del automata
            foreach (Estado e in le)
            {
                //Obtiene las transiciones que contengan un origen igual al estado que se esta iterando
                var lt_ = lt.FindAll(t => t.origen.Equals(e));
                int index_e = le.IndexOf(e);
                foreach (Transicion t_e in lt_)
                {
                    //Determina el índice del operando de la transicion segun el alfabeto definido
                    int indexAlf = getIndexChar(t_e.operando);
                    //Si la matriz no tiene un valor, le asigna el operando de la transicion
                    if(AFN_MTransicion[index_e, indexAlf] == null)
                        AFN_MTransicion[index_e, indexAlf] = t_e.destino.id_e.ToString();
                    //Concatena uno o mas estados para cuando un estado tiene mas de un destino
                    else if (AFN_MTransicion[index_e, indexAlf] != null && AFN_MTransicion[index_e, indexAlf] != "Φ")
                        AFN_MTransicion[index_e, indexAlf] = AFN_MTransicion[index_e, indexAlf] +","+t_e.destino.id_e.ToString();
                    //Asigna en conjunto vacio todas las transiciones que no incluyan el indice del alfabeto de la transicion actual
                    for(int x = 0; x<alfabeto.Count()-1; x++)
                    {
                        if(x != indexAlf)
                            AFN_MTransicion[index_e, x] = "Φ";
                    }
                }
            }
            //Asigna en conjunto vacio todas las transiciones con el alfabeto del estado de aceptacion del automata
            for (int x = 0; x < alfabeto.Count() - 1; x++)
            {
                    AFN_MTransicion[le.Count()-1, x] = "Φ";
            }
        }

        /// <summary>
        /// Obtiene el indice del alfabeto que denota c
        /// </summary>
        /// <param name="c">Caracter que se quiere encontrar en el alfabeto</param>
        /// <returns>Indice del alfabeto donde se encuenta c</returns>
        public int getIndexChar(char c)
        {
            for(int ch = 0; ch<alfabeto.Count(); ch++)
            {
                if (alfabeto[ch].Equals(c))
                    return ch;
            }
            return -1;
        }

        /// <summary>
        /// Determina la numeracion en los estados del automata y asigna estados iniciales y de aceptacion
        /// </summary>
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
