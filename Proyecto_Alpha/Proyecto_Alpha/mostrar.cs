using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Proyecto_Alpha
{
    public partial class mostrar : Form
    {
        public mostrar()
        {
            InitializeComponent();
        }


        //public funcion funcionSeleccionado { get; set; }


        //public static List<funcion> mostrartodo()
        //{
        //    List<funcion> lista = new List<funcion>();

        //    using (SqlConnection coneccion = conexion.ObtenerConexion())
        //    {
        //        SqlCommand comando = new SqlCommand(string.Format("select fecha, nombrefu, descripcion from funcion"), coneccion);
        //        SqlDataReader reader = comando.ExecuteReader();

        //        while (reader.Read())
        //        {

        //            funcion ffuncion = new funcion();
        //            ffuncion.fecha = reader.GetDateTime(0);
        //            ffuncion.nombrefu = reader.GetString(1);
        //            ffuncion.descripcion = reader.GetString(2);




        //            lista.Add(ffuncion);
        //        }
        //        coneccion.Close();
        //        return lista;

        //    }
        //}

        private void mostrar_Load(object sender, EventArgs e)
        {
            if (drid.SelectedRows.Count == 1)
            {
                //Int64 Id = Convert.ToInt64(drid.CurrentRow.Cells[0].Value);
                //funcionSeleccionado = funcionDAL.mostrartodo();                    //ObtenerProductos(Id);

                //this.Close();

            }

            else
            {
                MessageBox.Show("aun no ha seleccionado un Producto", "Seleccione un Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





            }

        private void drid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }



    }

