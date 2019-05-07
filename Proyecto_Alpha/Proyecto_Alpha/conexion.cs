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
            servidor = "sql5007.site4now.net,1433";
            db = "DB_A472CA_mauricio503";
            usuario = "DB_A472CA_mauricio503_admin";
            clave = "ve22421193";
            cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + db;

            //Server=tcp:servidor503.database.windows.net,1433;Initial Catalog=cine;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
            //Provider=sqloledb;Data Source=SQL5007,1433;Initial Catalog=DB_A472CA_mauricio503;User Id=DB_A472CA_mauricio503_admin;Password=ve22421193;

        }

    }
}
