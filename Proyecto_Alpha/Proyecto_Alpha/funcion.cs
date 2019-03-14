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

        public funcion() { }

        public funcion(DateTime Fecha, string Nombrefu, string descripcion) 
        {
            this.fecha = Fecha;
            this.nombrefu = Nombrefu;
            this.descripcion = descripcion;

        
        }
        

    }
}
