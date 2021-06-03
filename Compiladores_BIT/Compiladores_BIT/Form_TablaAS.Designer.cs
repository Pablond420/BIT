
namespace Compiladores_BIT
{
    partial class Form_TablaAS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGV_tabla = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_tabla
            // 
            this.DGV_tabla.AllowUserToAddRows = false;
            this.DGV_tabla.AllowUserToDeleteRows = false;
            this.DGV_tabla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_tabla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_tabla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_tabla.ColumnHeadersHeight = 29;
            this.DGV_tabla.Location = new System.Drawing.Point(12, 12);
            this.DGV_tabla.Name = "DGV_tabla";
            this.DGV_tabla.ReadOnly = true;
            this.DGV_tabla.RowHeadersWidth = 51;
            this.DGV_tabla.Size = new System.Drawing.Size(1110, 692);
            this.DGV_tabla.TabIndex = 4;
            // 
            // Form_TablaAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1576, 758);
            this.Controls.Add(this.DGV_tabla);
            this.Name = "Form_TablaAS";
            this.Text = "Form_TablaAS";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_tabla;
    }
}