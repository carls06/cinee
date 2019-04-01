namespace Proyecto_Alpha
{
    partial class Agregar_Evento
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
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.dateHora = new System.Windows.Forms.DateTimePicker();
            this.txtFuncion = new System.Windows.Forms.TextBox();
            this.btnAgre = new System.Windows.Forms.Button();
            this.lstFecha = new System.Windows.Forms.ListView();
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Hora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descrip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAddEveneto = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.btnbmusic = new System.Windows.Forms.Button();
            this.ruta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateFecha
            // 
            this.dateFecha.Checked = false;
            this.dateFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFecha.Location = new System.Drawing.Point(154, 76);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.ShowUpDown = true;
            this.dateFecha.Size = new System.Drawing.Size(95, 20);
            this.dateFecha.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre de la Función: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Elija Fecha de Función";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Elija Hora";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnbmusic);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDescrip);
            this.groupBox1.Controls.Add(this.dateHora);
            this.groupBox1.Controls.Add(this.txtFuncion);
            this.groupBox1.Controls.Add(this.btnAgre);
            this.groupBox1.Controls.Add(this.lstFecha);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 380);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregando Funciones";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Descripcion:";
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(283, 58);
            this.txtDescrip.Multiline = true;
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(181, 75);
            this.txtDescrip.TabIndex = 15;
            // 
            // dateHora
            // 
            this.dateHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateHora.Location = new System.Drawing.Point(154, 113);
            this.dateHora.Name = "dateHora";
            this.dateHora.ShowUpDown = true;
            this.dateHora.Size = new System.Drawing.Size(95, 20);
            this.dateHora.TabIndex = 14;
            // 
            // txtFuncion
            // 
            this.txtFuncion.Location = new System.Drawing.Point(149, 26);
            this.txtFuncion.Name = "txtFuncion";
            this.txtFuncion.Size = new System.Drawing.Size(100, 20);
            this.txtFuncion.TabIndex = 13;
            // 
            // btnAgre
            // 
            this.btnAgre.Location = new System.Drawing.Point(496, 216);
            this.btnAgre.Name = "btnAgre";
            this.btnAgre.Size = new System.Drawing.Size(75, 23);
            this.btnAgre.TabIndex = 12;
            this.btnAgre.Text = "Agregar";
            this.btnAgre.UseVisualStyleBackColor = true;
            this.btnAgre.Click += new System.EventHandler(this.btnAgre_Click);
            // 
            // lstFecha
            // 
            this.lstFecha.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nombre,
            this.Fecha,
            this.Hora,
            this.Descrip,
            this.ruta});
            this.lstFecha.Location = new System.Drawing.Point(6, 216);
            this.lstFecha.Name = "lstFecha";
            this.lstFecha.Size = new System.Drawing.Size(483, 147);
            this.lstFecha.TabIndex = 11;
            this.lstFecha.UseCompatibleStateImageBehavior = false;
            this.lstFecha.View = System.Windows.Forms.View.Details;
            this.lstFecha.SelectedIndexChanged += new System.EventHandler(this.lstFecha_SelectedIndexChanged);
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            this.Nombre.Width = 140;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 80;
            // 
            // Hora
            // 
            this.Hora.Text = "Hora";
            this.Hora.Width = 80;
            // 
            // Descrip
            // 
            this.Descrip.Text = "Descripción";
            this.Descrip.Width = 82;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(495, 245);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAddEveneto
            // 
            this.btnAddEveneto.Location = new System.Drawing.Point(414, 428);
            this.btnAddEveneto.Name = "btnAddEveneto";
            this.btnAddEveneto.Size = new System.Drawing.Size(75, 23);
            this.btnAddEveneto.TabIndex = 8;
            this.btnAddEveneto.Text = "Finalizar";
            this.btnAddEveneto.UseVisualStyleBackColor = true;
            this.btnAddEveneto.Click += new System.EventHandler(this.btnAddEveneto_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(334, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 56);
            this.listBox1.TabIndex = 15;
            this.listBox1.Visible = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Agregar musica";
            // 
            // btnbmusic
            // 
            this.btnbmusic.Location = new System.Drawing.Point(283, 153);
            this.btnbmusic.Name = "btnbmusic";
            this.btnbmusic.Size = new System.Drawing.Size(75, 23);
            this.btnbmusic.TabIndex = 18;
            this.btnbmusic.Text = "Buscar";
            this.btnbmusic.UseVisualStyleBackColor = true;
            this.btnbmusic.Click += new System.EventHandler(this.button1_Click);
            // 
            // ruta
            // 
            this.ruta.Text = "ruta";
            // 
            // Agregar_Evento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 463);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnAddEveneto);
            this.Controls.Add(this.groupBox1);
            this.Name = "Agregar_Evento";
            this.Text = "Agregar_Evento";
            this.Load += new System.EventHandler(this.Agregar_Evento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAddEveneto;
        private System.Windows.Forms.ListView lstFecha;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.ColumnHeader Hora;
        private System.Windows.Forms.Button btnAgre;
        private System.Windows.Forms.TextBox txtFuncion;
        private System.Windows.Forms.DateTimePicker dateHora;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.ColumnHeader Descrip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnbmusic;
        private System.Windows.Forms.ColumnHeader ruta;
    }
}