using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace Compiladores_BIT
{
    partial class Form1 : Form
    {
        public List<Expresion_Regular> er;

        public char[] regular;
        public char[] pos; // arreglo de caracteres que guarda la expresion posfija 
        
        public int cont_edos_AFN; // cuenta los estados que se han creado para que estos obtengan un id en AFN
        public int cont_trans_AFN; // cuenta las transiciones que se han creado para que estos obtengan un id en AFN
        public int cont_automatas_AFN; // cuenta los automatas que se han creado para que estos obtengan un id en AFN
        public List<Token> noClasificados;

        public List<Produccion> gramatica_Tiny; // gramatica de Tiny
        List<Produccion> gramatica_original_Tiny = new List<Produccion>(); // gramatica de Tiny

        public bool exp; // bool para saber si ya fue aplanado un boton

        public int cont_edos_LR;
        public List<EstadoLR> edosLR = new List<EstadoLR>();

        List<Elemento> gramaticales = new List<Elemento>();
        List<Elemento> grmls;
        Form_Transiciones_LR coleccion;
        List<Transicion> trs = new List<Transicion>();
        string[,] Tabla_AS;
        int iedo = 0;

        Automata AFN = null;
        Automata AFD = null;

        public Form1()
        {
            InitializeComponent();
            gramatica_Tiny = new List<Produccion>();
            er = new List<Expresion_Regular>();
            cont_edos_AFN = cont_trans_AFN = 0;
            cont_automatas_AFN = 1;
            exp = false;
            cont_edos_LR = 0;
        }

        public void Crea_Gramatica_Tiny()
        {
            Elemento enca = new Elemento();
            List<Elemento> cuer = new List<Elemento>();
            //programa -> secuencia-sent
            enca.texto = "programa";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { "$" };
            cuer.Add(new Elemento("nt", "secuencia-sent"));
            gramatica_Tiny.Add(new Produccion(enca,cuer));
            //secuencia-sent -> secuancia-sent; sentencia
            cuer.Clear();
            enca.texto = "secuencia-sent";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> {";", "end", "else", "until", "$"};
            cuer.Add(new Elemento("nt", "secuencia-sent"));
            cuer.Add(new Elemento("t", ";"));
            
            cuer.Add(new Elemento("nt", "sentencia"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //secuencia-sent -> sentencia
            cuer.Clear();
            enca.texto = "secuencia-sent";
            enca.tipo = "nt";
            cuer.Add(new Elemento("nt", "sentencia"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sentencia -> sent-if
            cuer.Clear();
            enca.texto = "sentencia";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { ";", "end", "else", "until", "$" };
            cuer.Add(new Elemento("nt", "sent-if"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sentencia -> sent-repeat
            cuer.Clear();
            enca.texto = "sentencia";
            enca.tipo = "nt";
            cuer.Add(new Elemento("nt", "sent-repeat"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sentencia -> sent-assign
            cuer.Clear();
            enca.texto = "sentencia";
            enca.tipo = "nt";
            cuer.Add(new Elemento("nt", "sent-assign"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sentencia -> sent-read
            cuer.Clear();
            enca.texto = "sentencia";
            enca.tipo = "nt";
            cuer.Add(new Elemento("nt", "sent-read"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sentencia -> sent-write
            cuer.Clear();
            enca.texto = "sentencia";
            enca.tipo = "nt";
            cuer.Add(new Elemento("nt", "sent-write"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sent-if -> if exp then secuencia-sent end
            cuer.Clear();
            enca.texto = "sent-if";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { ";", "end", "else", "until", "$" };
            cuer.Add(new Elemento("t", "if"));
            
            cuer.Add(new Elemento("nt", "exp"));
            cuer.Add(new Elemento("t", "then"));
            cuer.Add(new Elemento("nt", "secuencia-sent"));
            cuer.Add(new Elemento("t", "end"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sent-if -> if exp then secuencia-sent else secuencia-sent end
            cuer.Clear();
            enca.texto = "sent-if";
            enca.tipo = "nt";
            cuer.Add(new Elemento("t", "if"));
            cuer.Add(new Elemento("nt", "exp"));
            cuer.Add(new Elemento("t", "then"));
            cuer.Add(new Elemento("nt", "secuencia-sent"));
            cuer.Add(new Elemento("t", "else"));
            cuer.Add(new Elemento("nt", "secuencia-sent"));
            cuer.Add(new Elemento("t", "end"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sent-repeat -> repeat secuencia-sent until exp
            cuer.Clear();
            enca.texto = "sent-repeat";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { ";", "end", "else", "until", "$" };
            cuer.Add(new Elemento("t", "repeat"));
            cuer.Add(new Elemento("nt", "secuencia-sent"));
            cuer.Add(new Elemento("t", "until"));
            cuer.Add(new Elemento("nt", "exp"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sent-assign -> identificador := exp
            cuer.Clear();
            enca.texto = "sent-assign";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { ";", "end", "else", "until", "$" };
            cuer.Add(new Elemento("t", "identificador"));
            cuer.Add(new Elemento("t", ":="));
            cuer.Add(new Elemento("nt", "exp"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sent-read -> read identificador
            cuer.Clear();
            enca.texto = "sent-read";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { ";", "end", "else", "until", "$" };
            cuer.Add(new Elemento("t", "read"));
            cuer.Add(new Elemento("t", "identificador"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //sent-write -> write exp
            cuer.Clear();
            enca.texto = "sent-write";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { ";", "end", "else", "until", "$" };
            cuer.Add(new Elemento("t", "write"));
            cuer.Add(new Elemento("nt", "exp"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //exp -> exp-simple op-comp exp-simple
            cuer.Clear();
            enca.texto = "exp";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { "then", ";", "end", "else", "until", "$", ")"};
            cuer.Add(new Elemento("nt", "exp-simple"));
            cuer.Add(new Elemento("nt", "op-comp"));
            cuer.Add(new Elemento("nt", "exp-simple"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //exp -> exp-simple
            cuer.Clear();
            enca.texto = "exp";
            enca.tipo = "nt";
            cuer.Add(new Elemento("nt", "exp-simple"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //op-comp -> < 
            cuer.Clear();
            enca.texto = "op-comp";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { "(", "numero", "identificador"};
            cuer.Add(new Elemento("t", "<"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //op-comp -> > 
            cuer.Clear();
            enca.texto = "op-comp";
            enca.tipo = "nt";
            cuer.Add(new Elemento("t", ">"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //op-comp -> = 
            cuer.Clear();
            enca.texto = "op-comp";
            enca.tipo = "nt";
            cuer.Add(new Elemento("t", "="));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //exp-simple -> exp-simple opsuma term 
            cuer.Clear();
            enca.texto = "exp-simple";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> {"<", ">", "=", "then", ";", "end", "else", "until", "$", ")", "+", "-"};
            cuer.Add(new Elemento("nt", "exp-simple"));
            cuer.Add(new Elemento("nt", "opsuma"));
            cuer.Add(new Elemento("nt", "term"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //exp-simple -> term 
            cuer.Clear();
            enca.texto = "exp-simple";
            enca.tipo = "nt";
            cuer.Add(new Elemento("nt", "term"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //opsuma -> + 
            cuer.Clear();
            enca.texto = "opsuma";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { "(", "numero", "identificador" };
            cuer.Add(new Elemento("t", "+"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //opsuma -> - 
            cuer.Clear();
            enca.texto = "opsuma";
            enca.tipo = "nt";
            cuer.Add(new Elemento("t", "-"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //term -> term opmult factor 
            cuer.Clear();
            enca.texto = "term";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> {"<", ">", "=", "then", ";", "end", "else", "until", "$", ")", "+", "-", "*", "/" };
            cuer.Add(new Elemento("nt", "term"));
            cuer.Add(new Elemento("nt", "opmult"));
            cuer.Add(new Elemento("nt", "factor"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //term -> factor 
            cuer.Clear();
            enca.texto = "term";
            enca.tipo = "nt";
            cuer.Add(new Elemento("nt", "factor"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //opmult -> * 
            cuer.Clear();
            enca.texto = "opmult";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> { "(", "numero", "identificador"};
            cuer.Add(new Elemento("t", "*"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //opmult -> /
            cuer.Clear();
            enca.texto = "opmult";
            enca.tipo = "nt";
            cuer.Add(new Elemento("t", "/"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //factor -> ( exp )
            cuer.Clear();
            enca.texto = "factor";
            enca.tipo = "nt";
            enca.Siguientes = new List<string> {"<", ">", "=", "then", ";", "end", "else", "until", "$", ")", "+", "-", "*", "/"};
            cuer.Add(new Elemento("t", "("));
            cuer.Add(new Elemento("nt", "exp"));
            cuer.Add(new Elemento("t", ")"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //factor -> numero
            cuer.Clear();
            enca.texto = "factor";
            enca.tipo = "nt";
            cuer.Add(new Elemento("t", "numero"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));
            //factor -> identificador
            cuer.Clear();
            enca.texto = "factor";
            enca.tipo = "nt";
            cuer.Add(new Elemento("t", "identificador"));
            gramatica_Tiny.Add(new Produccion(enca, cuer));

            gramaticales.Add(new Elemento("t", "-"));
            gramaticales.Add(new Elemento("t", "("));
            gramaticales.Add(new Elemento("t", ")"));
            gramaticales.Add(new Elemento("t", "*"));
            gramaticales.Add(new Elemento("t", ":="));
            gramaticales.Add(new Elemento("t", "/"));
            gramaticales.Add(new Elemento("t", ";"));
            gramaticales.Add(new Elemento("t", "+"));
            gramaticales.Add(new Elemento("t", "<"));
            gramaticales.Add(new Elemento("t", "="));
            gramaticales.Add(new Elemento("t", ">"));
            gramaticales.Add(new Elemento("t", "identificador"));
            gramaticales.Add(new Elemento("t", "read"));
            gramaticales.Add(new Elemento("t", "end"));
            gramaticales.Add(new Elemento("t", "if"));
            gramaticales.Add(new Elemento("t", "numero"));
            gramaticales.Add(new Elemento("t", "repeat"));
            gramaticales.Add(new Elemento("t", "else"));
            gramaticales.Add(new Elemento("t", "then"));
            gramaticales.Add(new Elemento("t", "until"));
            gramaticales.Add(new Elemento("t", "write"));
            gramaticales.Add(new Elemento("nt", "sent-if"));
            gramaticales.Add(new Elemento("nt", "sent-repeat"));
            gramaticales.Add(new Elemento("nt", "sent-assign"));
            gramaticales.Add(new Elemento("nt", "sent-read"));
            gramaticales.Add(new Elemento("nt", "sent-write"));
            gramaticales.Add(new Elemento("nt", "programa"));
            gramaticales.Add(new Elemento("nt", "secuencia-sent"));
            gramaticales.Add(new Elemento("nt", "exp"));
            gramaticales.Add(new Elemento("nt", "factor"));
            gramaticales.Add(new Elemento("nt", "sentencia"));                  
            gramaticales.Add(new Elemento("nt", "exp-simple"));
            gramaticales.Add(new Elemento("nt", "op-comp"));
            gramaticales.Add(new Elemento("nt", "opsuma"));
            gramaticales.Add(new Elemento("nt", "term"));
            gramaticales.Add(new Elemento("nt", "opmult"));

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
            lexema_txt.Text = "";
            validar_lbl.Text = "-";
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
                haz_posfija();
                
            }

        }

        public void haz_posfija()
        {
            //Convierte el string en un arreglo de chars para después recuperarlo y asignarlo en la interfaz
            regular = text_abrir.Text.ToCharArray();
            char[] explicita = Regresa_Expresion_legible();
            regEx_explicita.Text = new string(explicita);
            pos = getPosfija(explicita);
            posfija_text.Text = new string(pos);
            posf_txt.Text = "posfija = " + posfija_text.Text;
            textBox1.Text = "posfija = " + posfija_text.Text;
            tabla_transiciones_AFN.Rows.Clear();
            tabla_transiciones_AFN.Columns.Clear();
            tabla_transiciones_AFD.Rows.Clear();
            tabla_transiciones_AFD.Columns.Clear();
            exp = false;
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
            evento_btn_ClickAFN();
        }

        public void evento_btn_ClickAFN() {

            cont_edos_AFN = cont_trans_AFN = 0;
            AFN = Automata_AFN();
            //Enumerar estados correctamente, definir inicial y final
            AFN.setNumeracionEstados();
            //Obtiene la matriz lógicamente
            AFN.getMatrizAFN();
            //Mostrar matriz de transiciones
            visualizaMatrizAFN();
        
        }

        public void visualizaMatrizAFN()
        {
            //Limpia la zona donde se contruye la matriz
            tabla_transiciones_AFN.Rows.Clear();
            tabla_transiciones_AFN.Columns.Clear();
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

        /// <summary>
        /// Realiza el procedimiento de construccion de AFD con el evento de pulsar el boton 'Construir AFS'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afd_btn_Click(object sender, EventArgs e)
        {
            if (!exp)
            {
                evento_btn_ClickAFD();
            }
        }

        public void evento_btn_ClickAFD()
        {
            int id_a = AFN.id_acept;
            AFD = AFN.Construccion_Subconjuntos();
            AFD.id_acept = id_a;
            AFD.setAlfabeto();
            AFD.setLetrasEstados_AFD();
            AFD.getMatrizAFD();
            visualizaMatrizAFD();

        }

            /// <summary>
            /// Metodo para rellenar el Data Grid View con los datos de la matriz de transiciones del AFD
            /// </summary>
            public void visualizaMatrizAFD()
        {
            tabla_transiciones_AFD.Rows.Clear();
            tabla_transiciones_AFD.Columns.Clear();
            for (int i =0; i<AFD.alfabeto.Length+1; i++)
            {
                if(i==0)
                    tabla_transiciones_AFD.Columns.Add("c" + i, "");
                else
                tabla_transiciones_AFD.Columns.Add("c" + i, AFD.alfabeto[i-1].ToString());
            }
            for(int i=0; i<AFD.le.Count();i++)
            {
                tabla_transiciones_AFD.Rows.Add();
            }

            for(int i=0; i< AFD.le.Count(); i++)
            {
                for (int j = 0; j < AFD.alfabeto.Length; j++)
                {
                    if (j == 0)
                        tabla_transiciones_AFD.Rows[i].Cells[j].Value = AFD.le.ElementAt(i).id_AFD;
                    else
                        tabla_transiciones_AFD.Rows[i].Cells[j].Value = AFD.AFD_MTransicion[i, j - 1];
                }
            }
            foreach (DataGridViewColumn col in tabla_transiciones_AFD.Columns)
            {
                col.Width = 50;
            }

        }

        /// <summary>
        /// Este metodo obtiene el texto ingresado en lexema y lo convierte a una cadena de caracteres para que sea recorrido
        /// </summary>
        /// <returns></returns>
        public bool Recorre_lexema()
        {
            bool aceptacion = false; // booleano para saber si fue o no aceptado el lexema
            string lex = lexema_txt.Text; // obtencion de lexema en interfaz
            char[] lexc = lex.ToCharArray(); // conversion de string a arreglo de caracteres

            string new_nodo = "A"; // se define en new_nodo el estado inicial del AFD, esta variable es necesaria para desplazarse en el AFD

            for(int i=0; i<lexc.Length; i++) // para cada letra en el lexema hacer
            {
                bool error = true; // booleano para verificar que si exista una transicion en el automata que se esta evaluando del lexema
                foreach(Transicion t in AFD.lt)
                {
                    if (t.origen.id_AFD.Equals(new_nodo)) // si el nodo origen de la transicion es el nodo que guarda new_nodo
                    {
                        if(t.operando == lexc[i]) // si el operando es igual a la gramatica  que se esta evaluando del lexema
                        {
                            error = false; // el error se hace falso, ya el token si esta en la transicion iterada del AFD
                            if(i == lexc.Length -1) // si ya es el ultimo elemento de la palabra del lexema
                            {
                                aceptacion = t.destino.tipo_edo.Equals("aceptación"); // verifica que el estado al que llego sea uno de aceptacion
                            }
                            new_nodo = t.destino.id_AFD; // actualiza new_nodo con el estado destino de la transicion, para moverse en el AFD
                            break;
                        }
                    }
                }
                if(error)
                  break;
            }
            return aceptacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabla_transiciones_AFD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Metodo que manda a llamar la verificacion de que el lexema se encuentre en el AFD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_validar_Click(object sender, EventArgs e)
        {
            evento_click_validar();
        }


        /// <summary>
        /// separar el evento y acciones cuando se hace el click a el boton validar
        /// </summary>
        public void evento_click_validar()
        {
            bool valido = Recorre_lexema();
            validar_lbl.Text = valido ? "Si pertenece al lenguaje de la ER" : "No pertenece al lenguaje de la ER";
            validar_lbl.ForeColor = valido ?  Color.Green : Color.Red;
        }


        private void lexema_txt_TextChanged(object sender, EventArgs e)
        {
            validar_lbl.Text = "-";
        }

        private void clasificar_Tokens_Click(object sender, EventArgs e)
        {
            //Elimina los espacios del código
            List<string> p = codigoTiny.Text.Split().ToList();
            //Elimina las cadenas vacias
            p = p.FindAll(str => !str.Equals(""));
            Tokens tokens = new Tokens(p);
            tokens.clasificaTokens();

            //Obtine todos los tokens que no fueron clasificados para recorrerlos en los AFD de letras y numeros 
            noClasificados = tokens.getTokensSinClasificar();
            //Recorre el AFD con cada token
            RecorreAFD();
            
            // calsifica los lexemas que ya fueron encontrados en el recorrido del AFD
            foreach(Token pp in noClasificados)
            {
                foreach (Token pp2 in tokens.tokens)
                {
                    if(pp.lexema.Equals(pp2.lexema))
                    {
                        pp2.nombre = pp.nombre;
                    }
                }
            }

            //Muestra la tabla en la interfaz
            tabla_token.Rows.Clear();
            for (int i = 0; i < tokens.tokens.Count(); i++)
            {
                tabla_token.Rows.Add();
                tabla_token.Rows[i].Cells[0].Value = tokens.tokens.ElementAt(i).nombre;
                tabla_token.Rows[i].Cells[1].Value = tokens.tokens.ElementAt(i).lexema;
            }
        }


        public void RecorreAFD()
        {
            text_abrir.Text = textBox2.Text;
            haz_posfija();
            evento_btn_ClickAFN();
            evento_btn_ClickAFD();
            bool valid=false;

            //recorre el lexema en el AFD del identificador y si lo identifica le pone el nombre de identificador
            foreach(Token s in noClasificados)
            {
                lexema_txt.Text = s.lexema;
                valid = Recorre_lexema();
                if(valid)
                {
                    s.nombre = "identificador";
                }
            }

            text_abrir.Text = textBox3.Text;
            haz_posfija();
            evento_btn_ClickAFN();
            evento_btn_ClickAFD();
            //Recorre el lexema pero ahora en el AFD del numero
            foreach (Token s in noClasificados)
            {
                lexema_txt.Text = s.lexema;
                valid = Recorre_lexema();
                if (valid)
                {
                    s.nombre = "número";
                }
            }
            // si no los clasifico con un nombre, les pone Error léxico.
            foreach(Token s in noClasificados)
            {
                if(s.nombre=="")
                {
                    s.nombre = "Error léxico";
                }
            }
        }

        private void Btn_Col_Can_Click(object sender, EventArgs e)
        {
            Crea_Gramatica_Tiny();
            Copia_Lista(gramatica_Tiny, gramatica_original_Tiny);
            Elementos();
            visualizaEdos();
            Btn_transiciones.Visible = true;
            Btn_Col_Can.Enabled = false;

            Analisis_Sintactico();
            Btn_TablaAS.Visible = true;
        }

        public void visualizaEdos()
        {
            DGV_edos.Rows.Clear();
            DGV_edos.Columns.Clear();
            foreach(EstadoLR elr in edosLR)
            {
                DGV_edos.Columns.Add(elr.numero_edo.ToString(), "I" + elr.numero_edo);
            }
            foreach (DataGridViewColumn dc in DGV_edos.Columns)
            {
                dc.Width = 25;
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void CreaAumentada()
        {
            List<Produccion> p = new List<Produccion>();
            Elemento punto = new Elemento("p", ".");
            Elemento el = new Elemento("aumentada", "programa'");
            Elemento ele = new Elemento("nt", "programa");
            List<Elemento> cuerp = new List<Elemento>();
            cuerp.Add(punto);
            cuerp.Add(ele);

            Produccion aum = new Produccion(el, cuerp);
            aum.Despues_del_Punto();
            p.Add(aum);
            edosLR.Add(new EstadoLR(Cerradura(p), cont_edos_LR));
            cont_edos_LR++;
        }

        public List<Produccion> Cerradura(List<Produccion> I)
        {
            List<Produccion> J = new List<Produccion>();
            Copia_Lista(I, J);
            int cont_elmn = 0;
            do
            {
                if(J.ElementAt(cont_elmn).B.tipo=="nt")
                {
                    foreach (Produccion g in gramatica_Tiny)
                    {
                        if (g.encabezado.texto.Equals(J.ElementAt(cont_elmn).B.texto))
                        {
                            Produccion pr = Insertar_Punto(g);

                            if (!Existe_prod(pr, J))
                            {
                                J.Add(pr);
                            }
                        }
                    }
                }
                cont_elmn++;

            } while (cont_elmn < J.Count());

            return J;
        }

        public bool Existe_prod(Produccion p, List<Produccion> lp)
        {
            bool ex = false;
            //en todas las producciones de J
            foreach(Produccion pr in lp)
            {
                //si el encabezado es el mismo
                if(pr.encabezado.texto.Equals(p.encabezado.texto))
                {
                    int cont = pr.cuerpo.Count();
                    if(cont == p.cuerpo.Count()) // si el numero de elementos en su cuerpo es el mismo 
                    {
                        bool pr_ig = true;
                        for(int i=0; i<cont;i++) // para cada elemento del cuerpo de la produccion 
                        {
                            if(!(pr.cuerpo.ElementAt(i).texto.Equals(p.cuerpo.ElementAt(i).texto))) // verificar que el elemento del cuerpo sea diferente
                            {
                                pr_ig = false;
                                break;
                            }
                        }
                        if(pr_ig)
                        {
                            ex = true;
                            break;
                        }
                    }
                }
            }
            return ex;
        }

        public Produccion Insertar_Punto(Produccion p)
        {
            Produccion res = new Produccion();

            res.encabezado = p.encabezado;
            res.cuerpo.Add(new Elemento("p","."));
            foreach(Elemento a in p.cuerpo)
            {
                res.cuerpo.Add(a);
            }

            res.Despues_del_Punto();
            return res;
        }

        public void Copia_Lista(List<Produccion> c, List<Produccion> d)
        {
            foreach (Produccion e in c)
            {
                d.Add(e);
            }
        }


        public List<Produccion> Ir_A(List<Produccion> I, string X)
        {
            List<Produccion> ir = new List<Produccion>();
            List<Produccion> ir2 = new List<Produccion>();
            Actualiza_B(I);
            foreach(Produccion pr in I)
            {
                if (pr.B.texto.Equals(X))
                {
                    ir.Add(new Produccion(pr.encabezado, pr.cuerpo));
                }
            }
            foreach(Produccion p in ir)
            {
                p.cuerpo = p.recorrePunto();
            }
            Actualiza_B(ir);
            if (ir.Count() > 0 )
               ir2 =  Cerradura(ir);
            return ir2;
        }
       

        public void Elementos()
        {
            
            CreaAumentada();
            int contedoLR = 0;
            do
            {
                foreach (Elemento x in gramaticales)
                {
                    List<Produccion> copiaLR = new List<Produccion>();
                    Copia_Lista(edosLR.ElementAt(contedoLR).I, copiaLR);
                    List<Produccion> res_Irs = Ir_A(copiaLR, x.texto);

                    if (res_Irs.Count > 0 && !Existe_En_C(res_Irs))
                    {
                        EstadoLR elr = new EstadoLR(res_Irs, cont_edos_LR);
                        edosLR.Add(elr);
                        cont_edos_LR++;
                        Transicion t = new Transicion(edosLR.ElementAt(contedoLR), edosLR.ElementAt(edosLR.IndexOf(elr)), x.texto);
                        trs.Add(t);
                    }
                    else if(res_Irs.Count > 0)
                    {
                        //EstadoLR rrr = edosLR.Find(edo => edo.I.Equals(res_Irs));
                        Transicion t = new Transicion(edosLR.ElementAt(contedoLR), edosLR.ElementAt(iedo), x.texto);
                        trs.Add(t);
                    }
                }
                contedoLR++;
            } while (contedoLR < edosLR.Count());
        }

        public bool Existe_En_C(List<Produccion> r)
        {
            bool res=true;
            
            foreach (EstadoLR a in edosLR)
            {
                res = true;
                if (r.Count() == a.I.Count())
                {
                    foreach (Produccion x in r)
                    {
                        if (!Existe_prod(x, a.I))
                        {
                            res = false;
                            break;
                        }
                    }
                }
                else
                    res = false;
                if (res)
                {
                    iedo = edosLR.IndexOf(a);
                    break;
                }
                    
            }
            return res;
        }

        public void Actualiza_B(List<Produccion> I)
        {
            foreach(Produccion p in I)
            {
                p.Despues_del_Punto();
            }
        }

        private void DGV_edos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Tb_Elementos.Text = "";
            lbl_cantElem.Text = "";
            
            int contElem = 1;
            string str = "";
            int edo = Convert.ToInt32(DGV_edos.Columns[DGV_edos.CurrentCell.ColumnIndex].Name);
            txt_Elementos.Text = "Elementos del estado " + "I-" + edo.ToString();
            EstadoLR select = edosLR.Find(es => es.numero_edo == edo);
            foreach(Produccion p in select.I)
            {
                string cuerpo = "";
                foreach(Elemento c in p.cuerpo)
                {
                    if (c.tipo.Equals("p"))
                        cuerpo += "• ";
                    else
                        cuerpo += c.texto+ " ";
                }
                str += contElem++.ToString() + ". " + "[ " + p.encabezado.texto + " ➞ " + cuerpo + "]"+ Environment.NewLine;
            }
            Tb_Elementos.Text = str;
            lbl_cantElem.Text = (contElem-1).ToString();
        }

        private void Btn_transiciones_Click(object sender, EventArgs e)
        {
            coleccion = new Form_Transiciones_LR(trs, edosLR, gramaticales);
            coleccion.contruyeMatrizLR();
            coleccion.Show();
        }

        private void Analisis_Sintactico()
        {
            //Inicializar la tabla de análisis sintactico de la cantidad total de estados x cantidad total de simbolos gramaticales 
            grmls = new List<Elemento>();
            bool band = false;
            foreach (Elemento el in gramaticales)
            {
                if (el.tipo.Equals("nt") && !band)
                {
                    band = true;
                    grmls.Add(new Elemento("pesos", "$"));
                }
                grmls.Add(el);
            }
            Tabla_AS = new string[edosLR.Count(), grmls.Count()];
            
            foreach(EstadoLR eLr in edosLR)
            {
                int Ii = edosLR.IndexOf(eLr);
                int pesos = grmls.FindIndex(x => x.texto.Equals("$"));
                foreach(Produccion p in eLr.I)
                {
                    //Inciso A) [A -> alfa . a beta] buscamos un terminal despues del punto
                    if (p.B.tipo.Equals("t"))
                    {
                        int a = grmls.FindIndex(x => x.texto.Equals(p.B.texto));
                        Tabla_AS[Ii, a] = "D" + ir_Aj(eLr, p.B.texto).ToString();
                    }
                    if (p.B.tipo.Equals("vacio") && !p.encabezado.tipo.Equals("aumentada"))
                    {
                        //Produccion pr = gramatica_original_Tiny.Find(x => x.encabezado.Equals(p.encabezado));
                        foreach(string sig in p.encabezado.Siguientes)
                        {
                            int a = grmls.FindIndex(x => x.texto.Equals(sig));
                            Tabla_AS[Ii, a] = "R" + Num_Prod(p).ToString();
                        }
                    }
                    if(p.B.tipo.Equals("vacio") && p.encabezado.tipo.Equals("aumentada"))
                    {
                        Tabla_AS[Ii, pesos] = "AC";
                    }
                }
            }

            //Parte que completa los Ir_A
            foreach(Transicion tr in trs)
            {
                if(grmls.Find(gr => gr.texto.Equals(tr.operandoLR)).tipo.Equals("nt"))
                {
                    int Ii = edosLR.FindIndex(t => t.Equals(tr.origenLR));
                    int a = grmls.FindIndex(g => g.texto.Equals(tr.operandoLR));
                    Tabla_AS[Ii, a] = tr.destinoLR.numero_edo.ToString();
                }
            }
        }

        private int Num_Prod(Produccion p)
        {
            //Crea una nueva producción sin punto para compararla contra alguna producción original
            List<Elemento> cuerpo = new List<Elemento>();
            foreach(Elemento c in p.cuerpo)
            {
                if(!c.tipo.Equals("p"))
                    cuerpo.Add(new Elemento(c.tipo, c.texto));
            }
            Produccion prod = new Produccion(p.encabezado, cuerpo);
            //Busca y regresa el numero de produccion con base en las producciones originales

            bool band = true;
            int ind = -1;
            foreach (Produccion pd in gramatica_original_Tiny)
            {
                if (pd.encabezado.texto.Equals(prod.encabezado.texto))
                {
                    ind = gramatica_original_Tiny.IndexOf(pd);
                    if (gramatica_original_Tiny[ind].cuerpo.Count() == prod.cuerpo.Count())
                    {
                        int j = 0;
                        foreach (Elemento el in gramatica_original_Tiny[ind].cuerpo)
                        {
                            if (!el.texto.Equals(prod.cuerpo[j].texto))
                            {
                                band = false;
                                break;
                            }
                            j++;
                        }
                        if (band) break;
                    }
                }
                
                //if (band) break;
            }
            if (ind == -1)
            {
                bool k= false;

            }
                
            return ind;
        }

        private int ir_Aj(EstadoLR i, string a)
        {
            Transicion transicion = trs.Find(t => t.origenLR.Equals(i) && t.operandoLR.Equals(a));
            return edosLR.IndexOf(transicion.destinoLR);
        }

        private void Btn_TablaAS_Click(object sender, EventArgs e)
        {
            Form_TablaAS tabla = new Form_TablaAS(Tabla_AS, grmls, edosLR.Count(), grmls.Count());
            tabla.construyeTabla();
            tabla.Show();
        }
    }
}
