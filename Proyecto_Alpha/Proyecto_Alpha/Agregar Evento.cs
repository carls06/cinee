﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Globalization;

namespace Proyecto_Alpha
{
    public partial class Agregar_Evento : Form
    {

        String DireccionMusica = String.Empty;
        private SqlConnection conn;
        private SqlCommand insert;
        private string sCn;
        
        public Agregar_Evento()
        {
            InitializeComponent();
            conexion cn = new conexion();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
            conn.Open();
          
        }

        private void Agregar_Evento_Load(object sender, EventArgs e)
        {
            SqlCommand comander = new SqlCommand("SELECT fecha from funcion", conn);
            using (SqlDataReader read = comander.ExecuteReader())
            {
                while (read.Read())
                {
                    listBox1.Items.Add(read["fecha"].ToString());
                }
            }
        }

        private void btnAgre_Click(object sender, EventArgs e)
        {
            ListViewItem lista;



            if (txtFuncion.Text == "" || txtDescrip.Text == "") { MessageBox.Show("Debe agregar descripcion y nombre de pelicula"); }
            else
            {
                string s = dateFecha.Value.Date.ToString("d/M/yyyy") + " " + dateHora.Value.ToString("hh:mm:00 tt");
                if (!listBox1.Items.Contains(s)&&!listBox2.Items.Contains(s))
                {

                    string[] c = { txtFuncion.Text, dateFecha.Value.Date.ToString("yyyy/MM/dd"), dateHora.Value.Hour + ":" + dateHora.Value.Minute + ":00", txtDescrip.Text, DireccionMusica };
                    lista = new ListViewItem(c);
                    lstFecha.Items.Add(lista);


                    foreach (ListViewItem lista1 in lstFecha.Items)
                    {
                        listBox2.Items.Add(s);
                    }

                }
                else
                {
                    MessageBox.Show("Fecha y/o hora, ya reservada");
                }

               
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lista in lstFecha.SelectedItems)
            {
                lista.Remove();
            }
        }

        private void btnAddEveneto_Click(object sender, EventArgs e)
        {
            if (lstFecha.Items.Count == 0) { this.Close(); }
            else
            {
                foreach (ListViewItem lista in lstFecha.Items)
                {
                    string insertar = "insert into funcion(fecha, nombrefu, descripcion,ruta)";
                    insertar += " values(@Fecha, @Nombrefu, @Descripcion,@ruta)";
                    insert = new SqlCommand(insertar, conn);
                    insert.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.SmallDateTime));
                    insert.Parameters["@Fecha"].Value = lista.SubItems[1].Text + " " + lista.SubItems[2].Text;
                    insert.Parameters.Add(new SqlParameter("@Nombrefu", SqlDbType.VarChar));
                    insert.Parameters["@Nombrefu"].Value = lista.Text;
                    insert.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar));
                    insert.Parameters["@Descripcion"].Value = lista.SubItems[3].Text;
                    insert.Parameters.Add(new SqlParameter("@ruta", SqlDbType.VarChar));
                    insert.Parameters["@ruta"].Value = lista.SubItems[4].Text;
                
                    insert.ExecuteNonQuery();
                  
                }
                conn.Close();
                this.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DireccionMusica = openFileDialog.FileName;
            }


           
        }

        private void lstFecha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
