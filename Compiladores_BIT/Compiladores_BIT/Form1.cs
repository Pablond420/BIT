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

        private void button2_Click(object sender, EventArgs e)
        {
            abrir_txt.InitialDirectory = "C:/";

            if(abrir_txt.ShowDialog()==DialogResult.OK)
            {
                StreamReader txt = new StreamReader(abrir_txt.FileName, Encoding.UTF8);
                string texto = txt.ReadToEnd();
                txt.Close();
                text_abrir.Text = texto;
            }
        }
    }
}
