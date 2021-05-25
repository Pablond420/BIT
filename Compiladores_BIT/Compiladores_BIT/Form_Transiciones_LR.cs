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
    partial class Form_Transiciones_LR : Form
    {
        List<Transicion> trs;
        List<EstadoLR> edosLR;
        List<Elemento> gramaticales;

        public Form_Transiciones_LR(List<Transicion> trs, List<EstadoLR> edosLR, List<Elemento> gramaticales)
        {
            InitializeComponent();
            this.trs = trs;
            this.edosLR = edosLR;
            this.gramaticales = gramaticales;
        }

        public void contruyeMatrizLR()
        {
            DGV_transiciones.Columns.Add("", "");
            foreach (Elemento el in gramaticales)
            {
                DGV_transiciones.Columns.Add("", el.texto);
            }

            foreach (EstadoLR e in edosLR)
            {
                int iRow = 0;
                string[] row = new string[gramaticales.Count+1];
                row[iRow++] = "I" + e.numero_edo.ToString();
                List<Transicion> tr_Edo = trs.FindAll(t => t.origenLR.Equals(e));
                foreach (Elemento el in gramaticales)
                {
                    foreach(Transicion t in tr_Edo)
                    {
                        if (t.operandoLR.Equals(el.texto))
                        {
                            row[iRow] = t.destinoLR.numero_edo.ToString();
                        }
                    }
                    if(row[iRow] == null) row[iRow] = "Φ";
                    iRow++;
                }
                DGV_transiciones.Rows.Add(row);
            }

            foreach(DataGridViewColumn c in DGV_transiciones.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
