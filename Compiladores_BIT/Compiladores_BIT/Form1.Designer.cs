
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.abrir_txt = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.validar_lbl = new System.Windows.Forms.Label();
            this.btn_validar = new System.Windows.Forms.Button();
            this.lexema_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.regEx_explicita = new System.Windows.Forms.TextBox();
            this.text_abrir = new System.Windows.Forms.TextBox();
            this.posfija_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_posfija = new System.Windows.Forms.Button();
            this.analizador_sint = new System.Windows.Forms.TabControl();
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
            this.tabTokens = new System.Windows.Forms.TabPage();
            this.tabla_token = new System.Windows.Forms.DataGridView();
            this.col_nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoTiny = new System.Windows.Forms.TextBox();
            this.clasificar_Tokens = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_cantElem = new System.Windows.Forms.Label();
            this.txt_cantElem = new System.Windows.Forms.Label();
            this.Btn_transiciones = new System.Windows.Forms.Button();
            this.Btn_Col_Can = new System.Windows.Forms.Button();
            this.txt_Elementos = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Tb_Elementos = new System.Windows.Forms.TextBox();
            this.DGV_edos = new System.Windows.Forms.DataGridView();
            this.tabPage1.SuspendLayout();
            this.analizador_sint.SuspendLayout();
            this.tabAFN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_transiciones_AFN)).BeginInit();
            this.tabAFD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_transiciones_AFD)).BeginInit();
            this.tabTokens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_token)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_edos)).BeginInit();
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
            this.label4.Size = new System.Drawing.Size(250, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Badillo Ortíz Pablo Angel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(341, 26);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ibarra Cuevas Dennise Monserrath";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FloralWhite;
            this.tabPage1.Controls.Add(this.validar_lbl);
            this.tabPage1.Controls.Add(this.btn_validar);
            this.tabPage1.Controls.Add(this.lexema_txt);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.regEx_explicita);
            this.tabPage1.Controls.Add(this.text_abrir);
            this.tabPage1.Controls.Add(this.posfija_text);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.btn_posfija);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analizador lexico";
            // 
            // validar_lbl
            // 
            this.validar_lbl.AutoSize = true;
            this.validar_lbl.Font = new System.Drawing.Font("Montserrat", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validar_lbl.ForeColor = System.Drawing.Color.Black;
            this.validar_lbl.Location = new System.Drawing.Point(22, 369);
            this.validar_lbl.Name = "validar_lbl";
            this.validar_lbl.Size = new System.Drawing.Size(19, 26);
            this.validar_lbl.TabIndex = 11;
            this.validar_lbl.Text = "-";
            // 
            // btn_validar
            // 
            this.btn_validar.BackColor = System.Drawing.Color.Khaki;
            this.btn_validar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_validar.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_validar.Location = new System.Drawing.Point(457, 313);
            this.btn_validar.Name = "btn_validar";
            this.btn_validar.Size = new System.Drawing.Size(94, 34);
            this.btn_validar.TabIndex = 10;
            this.btn_validar.Text = "Validar";
            this.btn_validar.UseVisualStyleBackColor = false;
            this.btn_validar.Click += new System.EventHandler(this.btn_validar_Click);
            // 
            // lexema_txt
            // 
            this.lexema_txt.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lexema_txt.Location = new System.Drawing.Point(26, 313);
            this.lexema_txt.Multiline = true;
            this.lexema_txt.Name = "lexema_txt";
            this.lexema_txt.Size = new System.Drawing.Size(409, 34);
            this.lexema_txt.TabIndex = 9;
            this.lexema_txt.TextChanged += new System.EventHandler(this.lexema_txt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "Lexema:";
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
            this.label2.Size = new System.Drawing.Size(66, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Posfija:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
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
            this.btn_posfija.Size = new System.Drawing.Size(224, 34);
            this.btn_posfija.TabIndex = 4;
            this.btn_posfija.Text = "Representación posfija";
            this.btn_posfija.UseVisualStyleBackColor = false;
            this.btn_posfija.Click += new System.EventHandler(this.btn_posfija_Click);
            // 
            // analizador_sint
            // 
            this.analizador_sint.Controls.Add(this.tabPage1);
            this.analizador_sint.Controls.Add(this.tabAFN);
            this.analizador_sint.Controls.Add(this.tabAFD);
            this.analizador_sint.Controls.Add(this.tabTokens);
            this.analizador_sint.Controls.Add(this.tabPage2);
            this.analizador_sint.Font = new System.Drawing.Font("Montserrat", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analizador_sint.Location = new System.Drawing.Point(0, 91);
            this.analizador_sint.Name = "analizador_sint";
            this.analizador_sint.SelectedIndex = 0;
            this.analizador_sint.Size = new System.Drawing.Size(696, 485);
            this.analizador_sint.TabIndex = 5;
            // 
            // tabAFN
            // 
            this.tabAFN.Controls.Add(this.posf_txt);
            this.tabAFN.Controls.Add(this.pos_txt);
            this.tabAFN.Controls.Add(this.afn_btn);
            this.tabAFN.Controls.Add(this.tabla_transiciones_AFN);
            this.tabAFN.Location = new System.Drawing.Point(4, 24);
            this.tabAFN.Name = "tabAFN";
            this.tabAFN.Padding = new System.Windows.Forms.Padding(3);
            this.tabAFN.Size = new System.Drawing.Size(688, 457);
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
            this.pos_txt.Size = new System.Drawing.Size(0, 22);
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
            this.tabAFD.Location = new System.Drawing.Point(4, 24);
            this.tabAFD.Margin = new System.Windows.Forms.Padding(2);
            this.tabAFD.Name = "tabAFD";
            this.tabAFD.Padding = new System.Windows.Forms.Padding(2);
            this.tabAFD.Size = new System.Drawing.Size(688, 457);
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
            this.label6.Size = new System.Drawing.Size(0, 22);
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
            // tabTokens
            // 
            this.tabTokens.Controls.Add(this.tabla_token);
            this.tabTokens.Controls.Add(this.codigoTiny);
            this.tabTokens.Controls.Add(this.clasificar_Tokens);
            this.tabTokens.Controls.Add(this.label10);
            this.tabTokens.Controls.Add(this.textBox3);
            this.tabTokens.Controls.Add(this.label9);
            this.tabTokens.Controls.Add(this.textBox2);
            this.tabTokens.Controls.Add(this.label8);
            this.tabTokens.Location = new System.Drawing.Point(4, 24);
            this.tabTokens.Name = "tabTokens";
            this.tabTokens.Padding = new System.Windows.Forms.Padding(3);
            this.tabTokens.Size = new System.Drawing.Size(688, 457);
            this.tabTokens.TabIndex = 3;
            this.tabTokens.Text = "Tokens";
            this.tabTokens.UseVisualStyleBackColor = true;
            // 
            // tabla_token
            // 
            this.tabla_token.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla_token.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_nom,
            this.col_lex});
            this.tabla_token.Location = new System.Drawing.Point(353, 106);
            this.tabla_token.Name = "tabla_token";
            this.tabla_token.Size = new System.Drawing.Size(328, 312);
            this.tabla_token.TabIndex = 14;
            // 
            // col_nom
            // 
            this.col_nom.HeaderText = "Nombre";
            this.col_nom.Name = "col_nom";
            // 
            // col_lex
            // 
            this.col_lex.HeaderText = "Lexema";
            this.col_lex.Name = "col_lex";
            // 
            // codigoTiny
            // 
            this.codigoTiny.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoTiny.Location = new System.Drawing.Point(8, 106);
            this.codigoTiny.Multiline = true;
            this.codigoTiny.Name = "codigoTiny";
            this.codigoTiny.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.codigoTiny.Size = new System.Drawing.Size(339, 312);
            this.codigoTiny.TabIndex = 13;
            // 
            // clasificar_Tokens
            // 
            this.clasificar_Tokens.BackColor = System.Drawing.Color.Khaki;
            this.clasificar_Tokens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clasificar_Tokens.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clasificar_Tokens.Location = new System.Drawing.Point(479, 67);
            this.clasificar_Tokens.Name = "clasificar_Tokens";
            this.clasificar_Tokens.Size = new System.Drawing.Size(175, 34);
            this.clasificar_Tokens.TabIndex = 11;
            this.clasificar_Tokens.Text = "Clasifica Tokens";
            this.clasificar_Tokens.UseVisualStyleBackColor = false;
            this.clasificar_Tokens.Click += new System.EventHandler(this.clasificar_Tokens_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 22);
            this.label10.TabIndex = 10;
            this.label10.Text = "Programa en lenguaje TINY:";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(481, 19);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(138, 34);
            this.textBox3.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(376, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 22);
            this.label9.TabIndex = 9;
            this.label9.Text = "Número:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(171, 17);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 34);
            this.textBox2.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Identificador:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.lbl_cantElem);
            this.tabPage2.Controls.Add(this.txt_cantElem);
            this.tabPage2.Controls.Add(this.Btn_transiciones);
            this.tabPage2.Controls.Add(this.Btn_Col_Can);
            this.tabPage2.Controls.Add(this.txt_Elementos);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.Tb_Elementos);
            this.tabPage2.Controls.Add(this.DGV_edos);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(688, 457);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Analisis sintáctico LR(0)";
            // 
            // lbl_cantElem
            // 
            this.lbl_cantElem.AutoSize = true;
            this.lbl_cantElem.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cantElem.Location = new System.Drawing.Point(632, 159);
            this.lbl_cantElem.Name = "lbl_cantElem";
            this.lbl_cantElem.Size = new System.Drawing.Size(0, 22);
            this.lbl_cantElem.TabIndex = 12;
            // 
            // txt_cantElem
            // 
            this.txt_cantElem.AutoSize = true;
            this.txt_cantElem.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cantElem.Location = new System.Drawing.Point(425, 159);
            this.txt_cantElem.Name = "txt_cantElem";
            this.txt_cantElem.Size = new System.Drawing.Size(204, 22);
            this.txt_cantElem.TabIndex = 11;
            this.txt_cantElem.Text = "Cantidad de Elementos:";
            // 
            // Btn_transiciones
            // 
            this.Btn_transiciones.BackColor = System.Drawing.Color.Khaki;
            this.Btn_transiciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_transiciones.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_transiciones.Location = new System.Drawing.Point(413, 6);
            this.Btn_transiciones.Name = "Btn_transiciones";
            this.Btn_transiciones.Size = new System.Drawing.Size(268, 34);
            this.Btn_transiciones.TabIndex = 10;
            this.Btn_transiciones.Text = "Tabla de Transiciones Autómata";
            this.Btn_transiciones.UseVisualStyleBackColor = false;
            this.Btn_transiciones.Visible = false;
            this.Btn_transiciones.Click += new System.EventHandler(this.Btn_transiciones_Click);
            // 
            // Btn_Col_Can
            // 
            this.Btn_Col_Can.BackColor = System.Drawing.Color.Khaki;
            this.Btn_Col_Can.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Col_Can.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Col_Can.Location = new System.Drawing.Point(8, 7);
            this.Btn_Col_Can.Name = "Btn_Col_Can";
            this.Btn_Col_Can.Size = new System.Drawing.Size(268, 34);
            this.Btn_Col_Can.TabIndex = 9;
            this.Btn_Col_Can.Text = "Construir Colección Canónica LR";
            this.Btn_Col_Can.UseVisualStyleBackColor = false;
            this.Btn_Col_Can.Click += new System.EventHandler(this.Btn_Col_Can_Click);
            // 
            // txt_Elementos
            // 
            this.txt_Elementos.AutoSize = true;
            this.txt_Elementos.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Elementos.Location = new System.Drawing.Point(9, 159);
            this.txt_Elementos.Name = "txt_Elementos";
            this.txt_Elementos.Size = new System.Drawing.Size(98, 22);
            this.txt_Elementos.TabIndex = 8;
            this.txt_Elementos.Text = "Elementos";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 22);
            this.label12.TabIndex = 7;
            this.label12.Text = "Estados";
            // 
            // Tb_Elementos
            // 
            this.Tb_Elementos.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tb_Elementos.Location = new System.Drawing.Point(8, 184);
            this.Tb_Elementos.Multiline = true;
            this.Tb_Elementos.Name = "Tb_Elementos";
            this.Tb_Elementos.ReadOnly = true;
            this.Tb_Elementos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tb_Elementos.Size = new System.Drawing.Size(673, 262);
            this.Tb_Elementos.TabIndex = 3;
            // 
            // DGV_edos
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_edos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_edos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_edos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_edos.Location = new System.Drawing.Point(8, 73);
            this.DGV_edos.Name = "DGV_edos";
            this.DGV_edos.Size = new System.Drawing.Size(673, 66);
            this.DGV_edos.TabIndex = 2;
            this.DGV_edos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_edos_CellClick);
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
            this.Controls.Add(this.analizador_sint);
            this.Name = "Form1";
            this.Text = "Compiladores e interpretes";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.analizador_sint.ResumeLayout(false);
            this.tabAFN.ResumeLayout(false);
            this.tabAFN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_transiciones_AFN)).EndInit();
            this.tabAFD.ResumeLayout(false);
            this.tabAFD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_transiciones_AFD)).EndInit();
            this.tabTokens.ResumeLayout(false);
            this.tabTokens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_token)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_edos)).EndInit();
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
        private System.Windows.Forms.TabControl analizador_sint;
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
        private System.Windows.Forms.Button btn_validar;
        private System.Windows.Forms.TextBox lexema_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label validar_lbl;
        private System.Windows.Forms.TabPage tabTokens;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button clasificar_Tokens;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox codigoTiny;
        private System.Windows.Forms.DataGridView tabla_token;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_lex;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DGV_edos;
        private System.Windows.Forms.Label txt_Elementos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Tb_Elementos;
        private System.Windows.Forms.Button Btn_transiciones;
        private System.Windows.Forms.Button Btn_Col_Can;
        private System.Windows.Forms.Label lbl_cantElem;
        private System.Windows.Forms.Label txt_cantElem;
    }
}

