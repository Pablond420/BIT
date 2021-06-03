using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiladores_BIT
{
    partial class Form_TablaAS : Form
    {
        public string[,] Tabla_AS;
        List<Elemento> gramaticales;
        int Rens = 0;
        int Cols = 0;
        public Form_TablaAS(string[,] Tabla_AS, List<Elemento> gramaticales, int Rens, int Cols)
        {
            InitializeComponent();
            this.Tabla_AS = Tabla_AS;
            this.gramaticales = gramaticales;
            this.Rens = Rens;
            this.Cols = Cols;
        }

        public void construyeTabla()
        {
            DGV_tabla.Columns.Add("", "");
            foreach (Elemento el in gramaticales)
            {
                DGV_tabla.Columns.Add("", el.texto);
            }

            for(int ren= 0; ren < Rens; ren++)
            {
                int iRow = 0;
                string[] row = new string[gramaticales.Count + 1];
                row[iRow++] = "I" + (ren+1).ToString();
                for (int col = 0; col < Cols; col++)
                {
                    row[iRow++] += Tabla_AS[ren, col];
                }
                DGV_tabla.Rows.Add(row);
            }

            foreach (DataGridViewColumn c in DGV_tabla.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
