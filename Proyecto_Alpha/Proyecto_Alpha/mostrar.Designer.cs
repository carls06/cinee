namespace Proyecto_Alpha
{
    partial class mostrar
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
            this.drid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.drid)).BeginInit();
            this.SuspendLayout();
            // 
            // drid
            // 
            this.drid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.drid.Location = new System.Drawing.Point(44, 48);
            this.drid.Name = "drid";
            this.drid.Size = new System.Drawing.Size(686, 204);
            this.drid.TabIndex = 0;
            this.drid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drid_CellContentClick);
            // 
            // mostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 541);
            this.Controls.Add(this.drid);
            this.Name = "mostrar";
            this.Text = "mostrar";
            this.Load += new System.EventHandler(this.mostrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView drid;
    }
}