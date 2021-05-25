
namespace Compiladores_BIT
{
    partial class Form_Transiciones_LR
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
            this.DGV_transiciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_transiciones)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_transiciones
            // 
            this.DGV_transiciones.AllowUserToAddRows = false;
            this.DGV_transiciones.AllowUserToDeleteRows = false;
            this.DGV_transiciones.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_transiciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_transiciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_transiciones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_transiciones.Location = new System.Drawing.Point(12, 12);
            this.DGV_transiciones.Name = "DGV_transiciones";
            this.DGV_transiciones.ReadOnly = true;
            this.DGV_transiciones.Size = new System.Drawing.Size(1375, 734);
            this.DGV_transiciones.TabIndex = 3;
            // 
            // Form_Transiciones_LR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1399, 758);
            this.Controls.Add(this.DGV_transiciones);
            this.Name = "Form_Transiciones_LR";
            this.Text = "Form_Transiciones_LR";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_transiciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_transiciones;
    }
}