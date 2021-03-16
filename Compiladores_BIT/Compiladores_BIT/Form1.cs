using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Compiladores_BIT
{
    partial class Form1 : Form
    {
        public char[] regular;
        public List<Expresion_Regular> er;
        public char[] pos; // arreglo de caracteres que guarda la expresion posfija 
        public int cont_edos_AFN; // cuenta los estados que se han creado para que estos obtengan un id en AFN
        public int cont_trans_AFN; // cuenta las transiciones que se han creado para que estos obtengan un id en AFN
        public int cont_automatas_AFN; // cuenta los automatas que se han creado para que estos obtengan un id en AFN
        Automata AFN = null;

        public Form1()
        {
            InitializeComponent();
            er = new List<Expresion_Regular>();
            cont_edos_AFN = cont_trans_AFN = 0;
            cont_automatas_AFN = 1;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        /// <summary>
        /// Controlador del evento (click) del botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Limpia cualquier valor interpretado anteriormente
            regEx_explicita.Text = "";
            posfija_text.Text = "";
            //Agrega un controlador en la interfaz de abrir explorador de archivos
            //Asigna el directorio inicial
            abrir_txt.InitialDirectory = "C:/";
            //Determina el filtro para archivos .txt únicamente
            abrir_txt.Filter = "txt files (*.txt)|*.txt";

            //Si se abre correctamente la ventana de diálogo
            if (abrir_txt.ShowDialog() == DialogResult.OK)
            {
                //Inicializa un stream (flujo) de datos
                StreamReader txt = new StreamReader(abrir_txt.FileName, Encoding.UTF8);
                //Lee el txt hasta el final
                string texto = txt.ReadToEnd();
                txt.Close(); //Cierra el archivo
                text_abrir.Text = texto; //Asigna el texto extraído del stream al cuadro de texto de la interfaz
            }
        }

        private void btn_posfija_Click(object sender, EventArgs e)
        {
            if (text_abrir.Text != "")
            {
                //Convierte el string en un arreglo de chars para después recuperarlo y asignarlo en la interfaz
                regular = text_abrir.Text.ToCharArray();
                char[] explicita = Regresa_Expresion_legible();
                regEx_explicita.Text = new string(explicita);
                pos = getPosfija(explicita);
                posfija_text.Text = new string(pos);
                tabla_transiciones_AFN.Rows.Clear();
                tabla_transiciones_AFN.Columns.Clear();
            }
        }

        /// <summary>
        /// Convierte una expresión regular a su equivalente notación explícita.
        /// </summary>
        /// <returns></returns>
        public char[] Regresa_Expresion_legible()
        {
            char[] aux = new char[1000];
            int cont_caract = 0;
            bool corchetes = false;
            for (int i = 0; i < regular.Length; i++)
            {
                if (regular[i] == '[' || corchetes)
                {
                    //Levanta corchete para seguir con la dinámica hasta encontrar el corchete derecho
                    corchetes = true;

                    if (regular[i] == '[')
                    {
                        //Convierte el corchete en paréntesis para comenzar a distribuir en caso de ser RANGO o NO
                        aux[cont_caract] = '(';
                        cont_caract++;
                    }
                    else
                    {
                        //Si encuentra corchete derecho, termina el rango y concatena un paréntesis derecho
                        if (regular[i] == ']')
                        {
                            //Avisa que el rango ha terminado
                            corchetes = false;
                            aux[cont_caract] = ')';
                            cont_caract++;

                            if(i != regular.Length - 1)
                            {
                                int val_ascii = (int)regular[i + 1];
                                if ((val_ascii >= 97 && val_ascii <= 122) || val_ascii == 40 || val_ascii == 91 || (val_ascii >= 48 && val_ascii <= 57) || val_ascii == 46)
                                {
                                    //Agrega concatenacion en el arreglo auxiliar de la posfija
                                    aux[cont_caract] = '&';
                                    cont_caract++;
                                }
                            }
                        }
                        else
                        {
                            int val_ascii = (int)regular[i];

                            //Si el caracter en la expresion regular es de [a-z] o un número [0-9]
                            if ((val_ascii >= 97 && val_ascii <= 122) || (val_ascii >= 48 && val_ascii <= 57) || val_ascii==46)
                            {
                                //Concatena en la exp explicita
                                aux[cont_caract] = regular[i];
                                cont_caract++;

                                //Verifica que se trata de un rango '-'
                                if (regular[i + 1] == '-')
                                {
                                    //Obtiene el numero max del rango
                                    int val_ascii_aux = regular[i + 2];

                                    //Itera hasta llegar al valor maximo del rango desde el valor inicial
                                    for (int p = val_ascii + 1; p <= val_ascii_aux; p++)
                                    {
                                        aux[cont_caract] = '|';
                                        cont_caract++;
                                        aux[cont_caract] = (char)p;
                                        cont_caract++;
                                    }
                                    //Avisa que el rango ha terminado
                                    corchetes = false;
                                    aux[cont_caract] = ')';
                                    cont_caract++;
                                    i = i + 3;

                                }
                                else
                                {
                                    //Aplica selección de alternativas al caracter dentro del corchete
                                    if (regular[i + 1] != ']')
                                    {
                                        aux[cont_caract] = '|';
                                        cont_caract++;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    aux[cont_caract] = regular[i];
                    cont_caract++;

                    // las letras del abecedario van en val_ascii >= 97 && val_ascii <= 122
                    // Comprueba que el caracter no sea seleccion de alternativas o parentesis izquiero, un rango o corchete izquierdo, estos casos N/A concatenacion
                    if (regular[i] != '(' && regular[i] != '[' && regular[i] != '-' && regular[i] != '|')
                    {
                        if (i != regular.Length - 1)
                        {
                            int val_ascii = (int)regular[i + 1];

                            //CONDICION PARA CONCATENAR
                            //Si el siguiente caracter en la expresion regular es de [a-z] o un paréntesis izquierdo, o un corchete izquierdo o un número [0-9]
                            if ((val_ascii >= 97 && val_ascii <= 122) || val_ascii == 40 || val_ascii == 91 || (val_ascii >= 48 && val_ascii <= 57) || val_ascii == 46)
                            {
                                //Agrega concatenacion en el arreglo auxiliar de la posfija
                                aux[cont_caract] = '&';
                                cont_caract++;
                            }
                        }
                    }
                }
            }

            //Obtiene la expresion con tamaño acotado
            char[] legible = new char[cont_caract + 1];
            Array.Copy(aux, 0, legible, 0, cont_caract + 1);

            return legible;
        }

        /// <summary>
        /// Convierte una expresión infija a su representación en posfija
        /// </summary>
        /// <param name="regEx"></param>
        /// <returns></returns>
        public char[] getPosfija(char[] regEx)
        {
            //Inicializa variables de pila y posfija
            char[] posfija = new char[1000];
            char[] pila = new char[1000];
            int i = 0, p = 0, iAux = 0;
            //Mientras no sea fin de la expresión infija
            while (i < regEx.Length)
            {
                //Obtiene el código ascii del caracter
                int valAscii = (int)regEx[i];
                //Si la expresión tiene un '/0' rompe el ciclo y termina la conversion
                if (valAscii == 0)
                    break;
                //Si es un paréntesis izquierdo
                if (valAscii == 40)
                    pila[p++] = regEx[i];
                //Si es un paréntesis derecho
                else if (valAscii == 41)
                {
                    //Extrae los valores de la pila y despliega hasta encontrar un paréntesis izquierdo, el cual no despliega
                    while (pila[p-1] != '(' && p >= 0)
                    {
                        posfija[iAux++] = pila[--p];
                        pila[p] = (char)0;
                    }
                    pila[--p] = (char)0;
                }
                //Si es un operando del alfabeto
                else if ((valAscii >= 97 && valAscii <= 122) || (valAscii >= 48 && valAscii <= 57) || valAscii == 46)
                    posfija[iAux++] = regEx[i];
                else
                {
                    //Si es un operador
                    bool band = true;
                    while (band)
                    {
                        //Si la pila esta vacia, o el tope de la pila es un parentesis izquierdo
                        //O el operador que se va a insertar tiene mayor prioridad que el tope de la pila
                        if (p == 0 || pila[p-1] == '(' || mayorPrioridad(pila[p-1], regEx[i]))
                        {
                            //Se inserta el operador en la pila
                            pila[p++] = regEx[i];
                            band = false;
                        }
                        //Extrae el tope de la pila y despliega en posfija
                        else
                            posfija[iAux++] = pila[--p];
                    }
                }
                i++;
            }
            //Extrae todos los elementos de la pila y los despliega en posfija
            while (p > 0)
                posfija[iAux++] = pila[--p];

            //Obtiene la expresion con tamaño acotado
            char[] auxPosF = new char[iAux];
            Array.Copy(posfija, 0, auxPosF, 0, iAux);

            return auxPosF;
        }

        /// <summary>
        /// Determina la prioridad de operandos en expresiones regulares
        /// </summary>
        /// <param name="tope">Primer elemento en la pila de operadores</param>
        /// <param name="operador">Operador que se desea insertar</param>
        /// <returns></returns>
        private bool mayorPrioridad(char tope, char operador)
        {
            bool res = false;
            //Si el operador que se inserta es * o + o ?, es de prioridad mas alta
            //Si el tope es * o + o ? no hay otro operador con mayor prioridad
            //Si los operadores son iguales, no existe mayor prioridad entre ellos
            res = (operador == '+' || operador == '*' || operador == '?' ? true :
                tope.Equals(operador) || operador == '|' && tope == '&' || tope == '+' || tope == '*' || tope == '?' ? false : true);

            return res;
        }
        /// <summary>
        /// Crea el automata AFN en una lista
        /// </summary>
        public Automata Automata_AFN()
        {
            //crear PILA
            List<Automata> pila = new List<Automata>();
            pila.Clear();
            //verifica que la expresion posfija ya se haya creado
            if(posfija_text.Text != "")
            {
                for(int i=0; i<pos.Length; i++)
                {
                    /*
                      pila.Count() - 1 === tope de la pila
                      pila.Count() - 2 === Uno antes del tope de pila
                     */

                    switch (Evalua_Caracter(pos[i]))
                    {
                        case 0:
                            MessageBox.Show("Hay un caracter no reconocido");
                            break;
                        case 1: // es un caracter del abecedario, un operando
                            pila.Add(CreaAutomataBase(pos[i]));
                            break;
                        case 2:  // el caracter es un ampersand o concatenacion
                            pila.Add(OperacionConcatenacion(pila.ElementAt(pila.Count() - 2), pila.ElementAt(pila.Count() - 1)));
                            pila.RemoveAt(pila.Count() - 2);
                            pila.RemoveAt(pila.Count() - 2);
                            break;
                        case 3: // el caracter es un pipe o seleccion alternativas
                            pila.Add(OperacionSeleccionAlternativas(pila.ElementAt(pila.Count() - 2), pila.ElementAt(pila.Count() - 1)));
                            pila.RemoveAt(pila.Count() - 2);
                            pila.RemoveAt(pila.Count() - 2);
                            break;
                        case 4: // el caracter es un mas o una cerradura positiva
                            pila.Add(OperacionCerraduraPositiva(pila.ElementAt(pila.Count() - 1)));
                            pila.RemoveAt(pila.Count() - 2);
                            break;
                        case 5: // el caracter es un asterisco o una cerradura de kleene
                            pila.Add(OperacionCerraduraKleene(pila.ElementAt(pila.Count() - 1)));
                            pila.RemoveAt(pila.Count() - 2);
                            break;
                        case 6: // el caracter es una interrogacion o cero una instancia
                            pila.Add(OperacionCeroInstancia(pila.ElementAt(pila.Count() - 1)));
                            pila.RemoveAt(pila.Count() - 2);
                            break;
                    }
                }
            }

            return pila.Last();
        }

        /// <summary>
        /// Regresa un automata resultado de aplicar la operacion Cero o una instancia del algoritmo de thompson
        /// </summary>
        /// <param name="rn"> Ingresa el automata que se le quiere aplicar la operacion, tope de la pila del algoritmo</param>
        /// <returns>nuevo automata</returns>
        public Automata OperacionCeroInstancia(Automata rn)
        {
            Automata copia = Copia_auto(rn);
            // Crear dos estados nuevos que iran uno al inicio y otro al final
            Estado e1 = new Estado();
            Estado e2 = new Estado();
            e1.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            e2.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            //Crear las dos transiciones que uniran los dos estados creados 

            //Agregar al final y al inicio los nuevos estados en el automata que se le esta aplicando
            copia.le.Insert(0, e1); //principio
            copia.le.Add(e2); // fin

            //Agregar las nuevas transiciones de los estados que se acaban de agregar
            Transicion t2 = new Transicion();
            t2.origen = copia.le.ElementAt(0);
            t2.destino = copia.le.ElementAt(1);
            t2.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t2.operando = 'ε';
            copia.lt.Add(t2);


            Transicion t3 = new Transicion();
            t3.origen = copia.le.ElementAt(copia.le.Count() - 2);
            t3.destino = copia.le.ElementAt(copia.le.Count() - 1);
            t3.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t3.operando = 'ε';
            copia.lt.Add(t3);

            //Transicion que une a los nuevos estados agregados
            Transicion t4 = new Transicion();
            t4.origen = copia.le.ElementAt(0);
            t4.destino = copia.le.ElementAt(copia.le.Count() - 1);
            t4.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t4.operando = 'ε';
            copia.lt.Add(t4);

            return copia;
        }

        /// <summary>
        /// Regresa un automata resultado de aplicar la operacion cerradura positiva del algoritmo de thompson
        /// </summary>
        /// <param name="rn"> Ingresa el automata que se le quiere aplicar la operacion, tope de la pila del algoritmo</param>
        /// <returns>nuevo automata</returns>
        public Automata OperacionCerraduraPositiva(Automata rn)
        {
            Automata copia = Copia_auto(rn);
            // Crear dos estados nuevos que iran uno al inicio y otro al final
            Estado e1 = new Estado();
            Estado e2 = new Estado();
            e1.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            e2.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            //Crear las dos transiciones que uniran los dos estados creados y la transicion que regresa del ultimo estado al primero
            Transicion t1 = new Transicion(); // primero la transicion que une al ultimo con el primero con epsilon o cadena vacia
            t1.origen = copia.le.ElementAt(copia.le.Count()-1);
            t1.destino = copia.le.ElementAt(0);
            t1.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t1.operando = 'ε';
            copia.lt.Add(t1);
            //Despues agregar al final y al inicio los nuevos estados en el automata que se le esta aplicando
            copia.le.Insert(0, e1); //principio
            copia.le.Add(e2); // fin

            //Agregar las nuevas transiciones de los estados que se acaban de agregar
            Transicion t2 = new Transicion();
            t2.origen = copia.le.ElementAt(0);
            t2.destino = copia.le.ElementAt(1);
            t2.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t2.operando = 'ε';
            copia.lt.Add(t2);

            
            Transicion t3 = new Transicion();
            t3.origen = copia.le.ElementAt(copia.le.Count() - 2);
            t3.destino = copia.le.ElementAt(copia.le.Count() - 1);
            t3.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t3.operando = 'ε';
            copia.lt.Add(t3);

            return copia;
        }

        /// <summary>
        /// Regresa un automata resultado de aplicar la operacion cerradura de kleene del algoritmo de thompson
        /// </summary>
        /// <param name="rn"> Ingresa el automata que se le quiere aplicar la operacion, tope de la pila del algoritmo</param>
        /// <returns>nuevo automata</returns>
        public Automata OperacionCerraduraKleene(Automata rn)
        {
            Automata copia = Copia_auto(rn);
            // Crear dos estados nuevos que iran uno al inicio y otro al final
            Estado e1 = new Estado();
            Estado e2 = new Estado();
            e1.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            e2.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            //Crear las dos transiciones que uniran los dos estados creados y la transicion que regresa del ultimo estado al primero y la transicion de los ultimos creados
            Transicion t1 = new Transicion(); // primero la transicion que une al ultimo con el primero con epsilon o cadena vacia
            t1.origen = copia.le.ElementAt(copia.le.Count() - 1);
            t1.destino = copia.le.ElementAt(0);
            t1.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t1.operando = 'ε';
            copia.lt.Add(t1);
            //Despues agregar al final y al inicio los nuevos estados en el automata que se le esta aplicando
            copia.le.Insert(0, e1); //principio
            copia.le.Add(e2); // fin

            //Agregar las nuevas transiciones de los estados que se acaban de agregar
            Transicion t2 = new Transicion();
            t2.origen = copia.le.ElementAt(0);
            t2.destino = copia.le.ElementAt(1);
            t2.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t2.operando = 'ε';
            copia.lt.Add(t2);


            Transicion t3 = new Transicion();
            t3.origen = copia.le.ElementAt(copia.le.Count() - 2);
            t3.destino = copia.le.ElementAt(copia.le.Count() - 1);
            t3.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t3.operando = 'ε';
            copia.lt.Add(t3);

            //Transicion que une a los nuevos estados agregados
            Transicion t4 = new Transicion();
            t4.origen = copia.le.ElementAt(0);
            t4.destino = copia.le.ElementAt(copia.le.Count() - 1);
            t4.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t4.operando = 'ε';
            copia.lt.Add(t4);

            return copia;
        }


        /// <summary>
        /// Copia las listas en otro objeto para evitar errores de que se le apliquen cambios a los dos objetos por duplicidad
        /// </summary>
        /// <param name="rn">recibe automata a copiar</param>
        /// <returns>copia del automata que llego</returns>
        public Automata Copia_auto(Automata rn)
        {
            Automata copia = new Automata();
            foreach (Estado e in rn.le)
            {
                copia.le.Add(e);
            }
            foreach (Transicion t in rn.lt)
            {
                copia.lt.Add(t);
            }
            copia.nombre = "r" + cont_automatas_AFN;
            cont_automatas_AFN++;
            return copia;
        }

        /// <summary>
        /// Crea el automata base de un caracter valido 
        /// </summary>
        /// <param name="pos">Recibe el caracter actual de la expresion posfija</param>
        /// <returns>regresa el automata de ese caracter</returns>
        public Automata CreaAutomataBase( char pos)
        {
            //El automata base de un  caracter valido se compone con dos estados y una transicion con dicho caracter
            Estado e1 = new Estado();
            Estado e2 = new Estado();
            e1.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            e2.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            //El automata base de un caracter valido necesita una transicion que una a los dos estados
            Transicion t1 = new Transicion();
            t1.origen = e1;
            t1.destino = e2;
            t1.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t1.operando = pos;
            //Creacion del automata, se guarda en una clase sus estados y transiciones
            Automata bas = new Automata();
            bas.nombre = "r" + cont_automatas_AFN;
            cont_automatas_AFN++;
            bas.le.Add(e1);
            bas.le.Add(e2);
            bas.lt.Add(t1);

            return bas;

        }

        /// <summary>
        /// Este metodo regresa todos el tipo de caracter actual de la posfija
        /// </summary>
        /// <param name="a">caracter actual de expresion posfija</param>
        /// <returns>regresa un entero que indica el tipo de caracter segun el numero que regrese</returns>
        public int Evalua_Caracter(char a)
        {
            int valor = 0;
            int val_ascii = (int)a;// guarda el valor ASCII en numero entero del caracter seleccionado
            if ((val_ascii >= 97 && val_ascii <= 122) || (val_ascii >= 48 && val_ascii <= 57) || val_ascii == 46) // verifica que el valor entero ASCII obtenido se encuentre en el alfabeto para verificar que sea un operando valido
                valor = 1; // es un caracter del abecedario, un operando
            else
                if (val_ascii == 38)
                valor = 2; // el caracter es un ampersand o concatenacion
            else
                    if (val_ascii == 124)
                valor = 3; // el caracter es un pipe o seleccion alternativas
            else
                    if (val_ascii == 43)
                valor = 4; // el caracter es un mas o una cerradura positiva
            else
                    if (val_ascii == 42)
                valor = 5; // el caracter es un asterisco o una cerradura de kleene
            else
                    if (val_ascii == 63)
                valor = 6; // el caracter es una interrogacion o cero una instancia


            return valor;
        }

        /// <summary>
        /// Aplica concatenacion en 2 automatas siguiendo el algoritmo de Thompson
        /// </summary>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <returns></returns>
        public Automata OperacionConcatenacion(Automata r1, Automata r2)
        {
            Automata r3 = new Automata();
            //Obtiene los estados de aceptacion e inicial del primer y segundo automata respectivamente, para posteriormente hacer la concatenacion
            Estado acept_r1 = r1.le.Last();
            Estado inicial_r2 = r2.le.First();

            Automata r1_copy = Copia_auto(r1);
            Automata r2_copy = Copia_auto(r2);

            //Agrega todos los estados del primer automata menos el de aceptacion (o el ultimo)
            for (int i = 0; i <= r1_copy.le.Count()-2; i++)
            {
                r3.le.Add(r1_copy.le.ElementAt(i));
            }
            //Agrega todos las transiciones del primer automata
            for (int i = 0; i <= r1_copy.lt.Count()-1; i++)
            {
                r3.lt.Add(r1_copy.lt.ElementAt(i));
            }
            //Agrega todos los estados del segundo automata 
            for (int i = 0; i <= r2_copy.le.Count() - 1; i++)
            {
                r3.le.Add(r2_copy.le.ElementAt(i));
            }
            //Agrega todos las transiciones del segundo automata
            for (int i = 0; i <= r2_copy.lt.Count() - 1; i++)
            {
                r3.lt.Add(r2_copy.lt.ElementAt(i));
            }

            //Genera la transicion para formar la concatencacion
            List<Transicion> r1_t_acept = r3.lt.FindAll(t => t.destino.Equals(acept_r1));

            Estado nuevo_acep = r3.le.Find(e => e.Equals(inicial_r2));
            foreach (Transicion t in r1_t_acept)
            {
                t.destino = nuevo_acep;
            }
                

            r3.nombre = "r"+cont_automatas_AFN;
            cont_automatas_AFN++;
            return r3;
        }

        /// <summary>
        /// Aplica seleccion de alternativas en 2 automatas siguiendo el algoritmo de Thompson
        /// </summary>
        /// <param name="r1">Automata operando 1</param>
        /// <param name="r2">Automata operando 2</param>
        /// <returns>Automata resultante con seleccion de alternativas aplicado</returns>
        public Automata OperacionSeleccionAlternativas(Automata r1, Automata r2)
        {
            Automata r3 = new Automata();
            //Agrega todos los estados del primer automata
            for (int i = 0; i <= r1.le.Count() - 1; i++)
                r3.le.Add(r1.le.ElementAt(i));
            //Agrega todos las transiciones del primer automata
            for (int i = 0; i <= r1.lt.Count() - 1; i++)
                r3.lt.Add(r1.lt.ElementAt(i));
            //Agrega todos los estados del segundo automata 
            for (int i = 0; i <= r2.le.Count() - 1; i++)
                r3.le.Add(r2.le.ElementAt(i));
            //Agrega todos las transiciones del segundo automata
            for (int i = 0; i <= r2.lt.Count() - 1; i++)
                r3.lt.Add(r2.lt.ElementAt(i));

            // Crear dos estados nuevos que iran uno al inicio y otro al final
            Estado e1 = new Estado();
            Estado e2 = new Estado();
            e1.id_e = cont_edos_AFN;
            cont_edos_AFN++;
            e2.id_e = cont_edos_AFN;
            cont_edos_AFN++;

            //Crear las dos transiciones que uniran al automata r1
            Transicion t1_r1 = new Transicion();
            Transicion t2_r1 = new Transicion();
            t1_r1.origen = e1;
            t1_r1.destino = r1.le.First();
            t2_r1.origen = r1.le.Last();
            t2_r1.destino = e2;
            t1_r1.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t2_r1.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t1_r1.operando = 'ε';
            t2_r1.operando = 'ε';
            r3.lt.Add(t1_r1);
            r3.lt.Add(t2_r1);

            //Crear las dos transiciones que uniran al automata r2
            Transicion t1_r2 = new Transicion();
            Transicion t2_r2 = new Transicion();
            t1_r2.origen = e1;
            t1_r2.destino = r2.le.First();
            t2_r2.origen = r2.le.Last();
            t2_r2.destino = e2;
            t1_r2.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t2_r2.id_tran = cont_trans_AFN;
            cont_trans_AFN++;
            t1_r2.operando = 'ε';
            t2_r2.operando = 'ε';
            r3.lt.Add(t1_r2);
            r3.lt.Add(t2_r2);

            //Despues agregar al final y al inicio los nuevos estados en el automata resultante
            r3.le.Insert(0, e1); //principio
            r3.le.Add(e2); // fin

            r3.nombre = "r" + cont_automatas_AFN;
            cont_automatas_AFN++;
            return r3;
        }

        private void afn_btn_Click(object sender, EventArgs e)
        {
            AFN = Automata_AFN();

            //Enumerar estados correctamente, definir inicial y final
            AFN.setNumeracionEstados();

            //Obtiene la matriz lógicamente
            AFN.getMatrizAFN();

            //Mostrar matriz de transiciones
            visualizaMatriz();
        }

        public void visualizaMatriz()
        {
            //Agrega columnas y renglones al data gris view de la interfaz segun la matriz que se obtuvo del AFN
            tabla_transiciones_AFN.Columns.Add("", "");
            foreach (char c in AFN.alfabeto)
            {
                tabla_transiciones_AFN.Columns.Add("", c.ToString());
            }
            foreach (DataGridViewColumn col in tabla_transiciones_AFN.Columns)
            {
                col.Width = 50;
            }
            //Determina el tamaño de la matriz con base en las dimensiones
            int lim_edos = AFN.AFN_MTransicion.GetLength(0);
            int lim_abc = AFN.AFN_MTransicion.GetLength(1);

            //Recupera datos y los vacia en el data grid view
            for(int i = 0; i < lim_edos; i++)
            {
                string[] row = new string[AFN.alfabeto.Count()];
                row[0] = i.ToString();
                for (int j = 0; j < lim_abc; j++)
                {
                    row[j+1] = AFN.AFN_MTransicion[i, j].ToString();
                }
                tabla_transiciones_AFN.Rows.Add(row);
            }
        }
    }
}
