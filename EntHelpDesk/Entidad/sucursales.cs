using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class sucursales
    {
        public int id_sucursal { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int id_zona { get; set; }
        public string zona { get; set; }
    }
}
