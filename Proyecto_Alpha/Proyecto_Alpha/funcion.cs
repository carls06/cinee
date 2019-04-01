using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Alpha
{
    class funcion
    {
        public DateTime fecha { get; set; }
        public string nombrefu { get; set; }
        public string descripcion { get; set; }
        public string ruta { get; set; }

        public funcion() { }

        public funcion(DateTime Fecha, string Nombrefu, string descripcion, string ruta) 
        {
            this.fecha = Fecha;
            this.nombrefu = Nombrefu;
            this.descripcion = descripcion;
            this.ruta = ruta;
        
        }
        

    }
}
