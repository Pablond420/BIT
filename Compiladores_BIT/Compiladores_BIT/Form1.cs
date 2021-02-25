using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Compiladores_BIT
{
    public partial class Form1 : Form
    {
        public char[] regular;
        public List<Expresion_Regular> er;
        public Form1()
        {
            InitializeComponent();
            er = new List<Expresion_Regular>();
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
            //Agrega un controlador en la interfaz de abrir explorador de archivos
            //Asigna el directorio inicial
            abrir_txt.InitialDirectory = "C:/";
            //Determina el filtro para archivos .txt únicamente
            abrir_txt.Filter = "txt files (*.txt)|*.txt";

            //Si se abre correctamente la ventana de diálogo
            if (abrir_txt.ShowDialog()==DialogResult.OK)
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
            if(text_abrir.Text!="")
            {
                //Convierte el string en un arreglo de chars para después recuperarlo y asignarlo en la interfaz
                regular = text_abrir.Text.ToCharArray();
                string regEx_explicit = new string(Regresa_Expresion_legible());
                posfija_text.Text = regEx_explicit;
            }
        }


        public char[] Regresa_Expresion_legible()
        {
            char[] aux = new char[1000];
            int cont_caract = 0;
            bool corchetes = false;
            for(int i=0; i<regular.Length;i++)
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
                        }
                        else
                        {
                            int val_ascii = (int)regular[i];

                            //Si el caracter en la expresion regular es de [a-z] o un número [0-9]
                            if ((val_ascii >= 97 && val_ascii <= 122) || (val_ascii >= 48 && val_ascii <= 57))
                            {
                                //Concatena en la exp explicita
                                aux[cont_caract] = regular[i];
                                cont_caract++;

                                //Verifica que se trata de un rango '-'
                                if(regular[i+1] == '-')
                                {
                                    //Obtiene el numero max del rango
                                    int val_ascii_aux = regular[i + 2];

                                    //Itera hasta llegar al valor maximo del rango desde el valor inicial
                                    for(int p=val_ascii+1; p<=val_ascii_aux;p++)
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
                            if ((val_ascii >= 97 && val_ascii <= 122) || val_ascii == 40 || val_ascii == 91 || (val_ascii >= 48 && val_ascii <= 57))
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
    }
}
