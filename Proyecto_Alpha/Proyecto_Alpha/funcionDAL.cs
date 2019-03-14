using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Proyecto_Alpha
{
    class funcionDAL
    {
        public static List<funcion> mostrartodo()
        {
            List<funcion> lista = new List<funcion>();

            using (SqlConnection coneccion = conexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("select fecha, nombrefu, descripcion from funcion"), coneccion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    funcion ffuncion = new funcion();
                    ffuncion.fecha = reader.GetDateTime(0);
                    ffuncion.nombrefu = reader.GetString(1);
                    ffuncion.descripcion = reader.GetString(2);




                    lista.Add(ffuncion);
                }
                coneccion.Close();
                return lista;

            }
        }


        public static List<funcion> BuscarProductos(String pNombre)
        {
            List<funcion> Lista = new List<funcion>();
            using (SqlConnection coneccion = conexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Select idproducto, idproveedor, nombre, descripcion, preciunitario,cantidad,porcentajeganancia from producto where nombre like '{0}%'", pNombre), coneccion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    funcion ffuncion = new funcion();
                    ffuncion.fecha = reader.GetDateTime(0);
                    ffuncion.nombrefu = reader.GetString(1);
                    ffuncion.descripcion = reader.GetString(2);


                    Lista.Add(ffuncion);
                }
                coneccion.Close();
                return Lista;

            }
        }
    }
}
