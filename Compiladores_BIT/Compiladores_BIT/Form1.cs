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
        public Form1()
        {
            InitializeComponent();
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
    }
}
