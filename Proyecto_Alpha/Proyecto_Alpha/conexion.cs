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
            servidor = "tcp:servidor503.database.windows.net,1433";
            db = "cine";
            usuario = "rick";
            clave = "Cholita23";
            cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + db;

         //Server=tcp:servidor503.database.windows.net,1433;Initial Catalog=cine;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;


        }

    }
}
