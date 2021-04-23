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
        public string[,] AFD_MTransicion; //MAtriz de Transiciones AFD
        public string nombre; //Nombre del automata
        public char[] alfabeto; //Alfabeto que acepta el automata
        public int id_acept=0; // variable que guarda el estado de aceptacion del AFN

        private List<Estado> Destados = new List<Estado>();

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
        /// Se le asigna un alias a los estados con el abecedario A,B,C... etc
        /// </summary>
        public void setLetrasEstados_AFD()
        {
            int q = 65;
            foreach(Estado e in le)
            {
                char p = (char)q;
                e.id_AFD = "" + p;
                q++;
            }
        }

        /// <summary>
        /// Genera la matriz de transiciones del automata AFD
        /// </summary>
        public void getMatrizAFD() {
            int edo = le.Count();
            int trans = alfabeto.Count();
            string c = "";
            //instancia la matriz en donde se va a guardar las transiciones del AFD
            AFD_MTransicion = new string[edo, trans];
            //Ciclos iteradores de matriz con i,j
            for (int i = 0; i < edo; i++)
            {
                for(int j=0; j<trans; j++)
                {
                    //Recorre cada transicion, buscando que transiciones tiene el estado que se esta iterando
                    foreach(Transicion t in lt)
                    {
                        //si la transicion tiene como origen al estado i entonces entra
                        if(le.ElementAt(i).id_e == t.origen.id_e)
                        {
                            if (alfabeto[j] == t.operando) // si la transicion tiene como operando al operando j  entra
                            { 
                                c = "" + t.destino.id_AFD; // asigna a una cadena el estado destino al que se llega con ese operando
                                break;
                            }
                            else
                            {
                                if(c=="")
                                c = "Φ"; // si no se llega a nada entonces se pone cadena vacia
                            }
                        }
                        else
                            c = "Φ"; // si no se llega a nada entonces se pone cadena vacia
                    }
                    AFD_MTransicion[i, j] = c; // se asigna el valor que se obtuvo a la matriz
                    c = "";
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
            id_acept = le.Last().id_e;
        }


        /// <summary>
        /// Construye el AFD con base en el AFN regresa un objeto Automata con todos los estados y transiciones del AFD 
        /// </summary>
        /// <returns></returns>
        public Automata Construccion_Subconjuntos()
        {
            Automata AFD = new Automata();
            int cont_edos_AFD = 0;
            int cont_trans_AFD = 0; 

            
            List<Estado> init = new List<Estado>(); // lista de estados cerradura de epsilon con el estado 0
            init.Add(le.First()); // se agrega el primer estado a la lista

            Estado A = new Estado(E_Cerradura(init)); // se crea el primer estado para el AFD, y se obtiene la cerradura de epsilon del estado inicial
            A.id_e = cont_edos_AFD; //se le agrega el id al primer estado del AFD
            cont_edos_AFD++;
            A.tipo_edo = "inicial";
            AFD.le.Add(A); // se agrega el primer estado al AFD
            Destados.Add(A); // Agrega el primer estado a una lista que guarda los Destados

            //Mientras haya un estado sin marcar en Destados
            while (Destados.Count() >= 1)
            {
                Estado T = Destados.First(); // Obtiene el primer elemento de la pila Destados
                Destados.RemoveAt(0); // Remueve el elemento que se esta utilizando en T
                
                foreach (char a in alfabeto) // por cada letra en el alfabeto del automata
                {
                    if(a != 'ε')
                    {
                        List<Estado> U = E_Cerradura(mover(T.estados, a)); // Obtiene la Cerradura de epsilon en una lista de estados
                        bool acept = Verifica_estado_aceptacion(U); // revisa que el estado sea un estado de aceptacion
                        if (U.Count() >= 1) // si la lista obtenida tiene al menos un elemento
                        {
                            var sorted = U.OrderBy(x => x.id_e).ToList();
                            U = sorted; //ordenar por id los estados de la lista

                            Estado U_ = new Estado(U); // se crea un nuevo estado mandando la cerradura de epsilon con una sobrecarga a la lista de estados en el objeto U_
                            U_.id_e = cont_edos_AFD;
                            cont_edos_AFD++; 

                            
                            bool dime = false;
                            int edo = 0;
                            foreach(Estado st in AFD.le) //procedimiento para checar si la cerradura de epsilon obtenida ya existe
                            {
                                if (st.estados.Count() == U.Count())
                                {
                                    int i = 0;
                                    dime = true;
                                    while (dime)
                                    {
                                        edo = AFD.le.IndexOf(st);
                                        if (!st.estados[i].Equals(U[i]))
                                            dime = false;
                                        if (i < st.estados.Count() - 1) i++;
                                        else break;
                                    }
                                    if (dime) break;
                                }
                            }
                           

                            if (!dime) // si no existe la cerradura de epsilon añade un nuevo estado
                            {
                                if (acept) // si la cadena de epsilon contenia al estado de aceptacion del AFN entonces el estado del AFD sera de aceptacion.
                                {
                                    U_.tipo_edo = "aceptación";
                                }
                                Destados.Add(U_);
                                AFD.le.Add(U_);
                            }
                            else // si ya existe toma el objeto que ya se habia creado
                            {
                                U_ = AFD.le[edo];
                            }

                            

                            Transicion tr = new Transicion(T, U_, a, cont_trans_AFD); // Hacer transicion al estado AFD que se obtuvo con la cerradura de epsilon
                            cont_trans_AFD++;

                            AFD.lt.Add(tr); // añade la transicion al AFD
                        }
                    }                   
                }
            }
            return AFD;
        }
        /// <summary>
        /// Recorre la lista de cerradura de epsilon para verificar si tiene un estado de aceptacion del AFN para ponerlo en el AFD
        /// </summary>
        /// <param name="U"></param>
        /// <returns></returns>
        public bool Verifica_estado_aceptacion(List<Estado> U)
        {
            bool a=false;

           foreach(Estado est in U)
            {
                if(est.id_e == id_acept) // verifica que algun estado en la lista de estados tenga el id del estado de aceptacion del AFN
                {
                    a = true;
                    break;
                }
            }

            return a;
        }


        /// <summary>
        /// para cada estado en la lista de estados que llega llama a la funcion que modifica la lista de estados U (cerradura de epsilon)
        /// </summary>
        /// <param name="edos"> Lista de estados </param>
        /// <returns>Cerradura de epsilon al estado que llega (lista de estados)</returns>
        private List<Estado> E_Cerradura(List<Estado> edos)
        {
            List<Estado> U = new List<Estado>();
            foreach (Estado e in edos)
                cerradura_Ep(e, U);
            return U;
        }

        /// <summary>
        /// Encuentra todos los estados que se encuentran enlazados con una transicion con ε 
        /// </summary>
        /// <param name="e">Estado actual</param>
        /// <param name="U">Lista de estados recorridos con transicion con ε</param>
        private void cerradura_Ep(Estado e, List<Estado> U)
        {
            U.Add(e);
            List<Transicion> trans_E = lt.FindAll(t => t.origen.Equals(e) && t.operando == 'ε' && U.Find(tr => tr.Equals(t.destino))==null);//lista que guarda todas las transiciones que tiene ese estado con epsilon siendo ese estado el inicial

            foreach (Transicion t in trans_E)
                cerradura_Ep(t.destino, U);
        }


        /// <summary>
        /// Regresa una lista de estados que se obtuvieron al hacer el movimiento de el Estado actual al estado al que se llega con el caracter
        /// </summary>
        /// <param name="T"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        private List<Estado> mover(List<Estado> T, char a)
        {
            List<Estado> res = new List<Estado>();
            foreach(Estado e_T in T)
            {
                List<Transicion> trans = lt.FindAll(t => t.origen.Equals(e_T) && t.operando == a);
                foreach (Transicion t in trans)
                    res.Add(t.destino);
            }
            return res;
        }

        public void setNumerosEstados_AFD()
        {
            int abc = 65;
            foreach(Estado e in le)
            {
                e.numero = abc;
                abc++;
            }
        }
    }
}
