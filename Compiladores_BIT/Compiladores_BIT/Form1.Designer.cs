
namespace Compiladores_BIT
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.abrir_txt = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.regEx_explicita = new System.Windows.Forms.TextBox();
            this.text_abrir = new System.Windows.Forms.TextBox();
            this.posfija_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_posfija = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAFN = new System.Windows.Forms.TabPage();
            this.posf_txt = new System.Windows.Forms.TextBox();
            this.pos_txt = new System.Windows.Forms.Label();
            this.afn_btn = new System.Windows.Forms.Button();
            this.tabla_transiciones_AFN = new System.Windows.Forms.DataGridView();
            this.tabAFD = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.afd_btn = new System.Windows.Forms.Button();
            this.tabla_transiciones_AFD = new System.Windows.Forms.DataGridView();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAFN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_transiciones_AFN)).BeginInit();
            this.tabAFD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_transiciones_AFD)).BeginInit();
            this.SuspendLayout();
            // 
            // abrir_txt
            // 
            this.abrir_txt.FileName = "openFileDialog1";
            this.abrir_txt.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(545, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "Compiladores e Intérpretes A - Equipo BIT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(189, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Badillo Ortíz Pablo Angel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(342, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ibarra Cuevas Dennise Monserrath";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FloralWhite;
            this.tabPage1.Controls.Add(this.regEx_explicita);
            this.tabPage1.Controls.Add(this.text_abrir);
            this.tabPage1.Controls.Add(this.posfija_text);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.btn_posfija);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analizador lexico";
            // 
            // regEx_explicita
            // 
            this.regEx_explicita.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regEx_explicita.Location = new System.Drawing.Point(25, 112);
            this.regEx_explicita.Multiline = true;
            this.regEx_explicita.Name = "regEx_explicita";
            this.regEx_explicita.ReadOnly = true;
            this.regEx_explicita.Size = new System.Drawing.Size(409, 34);
            this.regEx_explicita.TabIndex = 7;
            // 
            // text_abrir
            // 
            this.text_abrir.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_abrir.Location = new System.Drawing.Point(25, 75);
            this.text_abrir.Multiline = true;
            this.text_abrir.Name = "text_abrir";
            this.text_abrir.Size = new System.Drawing.Size(409, 34);
            this.text_abrir.TabIndex = 2;
            // 
            // posfija_text
            // 
            this.posfija_text.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posfija_text.Location = new System.Drawing.Point(25, 197);
            this.posfija_text.Multiline = true;
            this.posfija_text.Name = "posfija_text";
            this.posfija_text.ReadOnly = true;
            this.posfija_text.Size = new System.Drawing.Size(410, 34);
            this.posfija_text.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Posfija:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Expresión regular:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Khaki;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(25, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Abrir archivo";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_posfija
            // 
            this.btn_posfija.BackColor = System.Drawing.Color.Khaki;
            this.btn_posfija.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_posfija.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_posfija.Location = new System.Drawing.Point(457, 75);
            this.btn_posfija.Name = "btn_posfija";
            this.btn_posfija.Size = new System.Drawing.Size(175, 34);
            this.btn_posfija.TabIndex = 4;
            this.btn_posfija.Text = "Representación posfija";
            this.btn_posfija.UseVisualStyleBackColor = false;
            this.btn_posfija.Click += new System.EventHandler(this.btn_posfija_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabAFN);
            this.tabControl1.Controls.Add(this.tabAFD);
            this.tabControl1.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 91);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 485);
            this.tabControl1.TabIndex = 5;
            // 
            // tabAFN
            // 
            this.tabAFN.Controls.Add(this.posf_txt);
            this.tabAFN.Controls.Add(this.pos_txt);
            this.tabAFN.Controls.Add(this.afn_btn);
            this.tabAFN.Controls.Add(this.tabla_transiciones_AFN);
            this.tabAFN.Location = new System.Drawing.Point(4, 23);
            this.tabAFN.Name = "tabAFN";
            this.tabAFN.Padding = new System.Windows.Forms.Padding(3);
            this.tabAFN.Size = new System.Drawing.Size(688, 458);
            this.tabAFN.TabIndex = 1;
            this.tabAFN.Text = "AFN";
            this.tabAFN.UseVisualStyleBackColor = true;
            // 
            // posf_txt
            // 
            this.posf_txt.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posf_txt.Location = new System.Drawing.Point(12, 13);
            this.posf_txt.Name = "posf_txt";
            this.posf_txt.Size = new System.Drawing.Size(439, 27);
            this.posf_txt.TabIndex = 7;
            // 
            // pos_txt
            // 
            this.pos_txt.AutoSize = true;
            this.pos_txt.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pos_txt.Location = new System.Drawing.Point(8, 18);
            this.pos_txt.Name = "pos_txt";
            this.pos_txt.Size = new System.Drawing.Size(0, 19);
            this.pos_txt.TabIndex = 6;
            // 
            // afn_btn
            // 
            this.afn_btn.BackColor = System.Drawing.Color.Khaki;
            this.afn_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.afn_btn.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afn_btn.Location = new System.Drawing.Point(478, 6);
            this.afn_btn.Name = "afn_btn";
            this.afn_btn.Size = new System.Drawing.Size(175, 34);
            this.afn_btn.TabIndex = 5;
            this.afn_btn.Text = "Contruir AFN";
            this.afn_btn.UseVisualStyleBackColor = false;
            this.afn_btn.Click += new System.EventHandler(this.afn_btn_Click);
            // 
            // tabla_transiciones_AFN
            // 
            this.tabla_transiciones_AFN.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabla_transiciones_AFN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_transiciones_AFN.Location = new System.Drawing.Point(6, 71);
            this.tabla_transiciones_AFN.Name = "tabla_transiciones_AFN";
            this.tabla_transiciones_AFN.RowHeadersWidth = 51;
            this.tabla_transiciones_AFN.Size = new System.Drawing.Size(675, 381);
            this.tabla_transiciones_AFN.TabIndex = 0;
            // 
            // tabAFD
            // 
            this.tabAFD.Controls.Add(this.textBox1);
            this.tabAFD.Controls.Add(this.label6);
            this.tabAFD.Controls.Add(this.afd_btn);
            this.tabAFD.Controls.Add(this.tabla_transiciones_AFD);
            this.tabAFD.Location = new System.Drawing.Point(4, 23);
            this.tabAFD.Margin = new System.Windows.Forms.Padding(2);
            this.tabAFD.Name = "tabAFD";
            this.tabAFD.Padding = new System.Windows.Forms.Padding(2);
            this.tabAFD.Size = new System.Drawing.Size(688, 458);
            this.tabAFD.TabIndex = 2;
            this.tabAFD.Text = "AFD";
            this.tabAFD.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(11, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(439, 27);
            this.textBox1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 19);
            this.label6.TabIndex = 10;
            // 
            // afd_btn
            // 
            this.afd_btn.BackColor = System.Drawing.Color.Khaki;
            this.afd_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.afd_btn.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afd_btn.Location = new System.Drawing.Point(477, 6);
            this.afd_btn.Name = "afd_btn";
            this.afd_btn.Size = new System.Drawing.Size(175, 34);
            this.afd_btn.TabIndex = 9;
            this.afd_btn.Text = "Contruir AFD";
            this.afd_btn.UseVisualStyleBackColor = false;
            this.afd_btn.Click += new System.EventHandler(this.afd_btn_Click);
            // 
            // tabla_transiciones_AFD
            // 
            this.tabla_transiciones_AFD.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabla_transiciones_AFD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_transiciones_AFD.Location = new System.Drawing.Point(5, 72);
            this.tabla_transiciones_AFD.Name = "tabla_transiciones_AFD";
            this.tabla_transiciones_AFD.RowHeadersWidth = 51;
            this.tabla_transiciones_AFD.Size = new System.Drawing.Size(676, 375);
            this.tabla_transiciones_AFD.TabIndex = 8;
            this.tabla_transiciones_AFD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_transiciones_AFD_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(697, 573);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Compiladores e interpretes";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabAFN.ResumeLayout(false);
            this.tabAFN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_transiciones_AFN)).EndInit();
            this.tabAFD.ResumeLayout(false);
            this.tabAFD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_transiciones_AFD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog abrir_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox regEx_explicita;
        private System.Windows.Forms.TextBox text_abrir;
        private System.Windows.Forms.TextBox posfija_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_posfija;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAFN;
        private System.Windows.Forms.DataGridView tabla_transiciones_AFN;
        private System.Windows.Forms.Button afn_btn;
        private System.Windows.Forms.Label pos_txt;
        private System.Windows.Forms.TextBox posf_txt;
        private System.Windows.Forms.TabPage tabAFD;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button afd_btn;
        private System.Windows.Forms.DataGridView tabla_transiciones_AFD;
    }
}

