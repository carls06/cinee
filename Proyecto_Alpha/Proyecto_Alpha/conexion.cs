using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Proyecto_Alpha
{
    class conexion
    {
        public string servidor, usuario, clave, db, cadena;
        public void conec()
        {
            servidor = "SQL5008.site4now.net,1433";
            db = "DB_A464EC_cine";
            usuario = "DB_A464EC_cine_admin";
            clave = "hola1234";
            cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + db;

         
        }

    }
}
