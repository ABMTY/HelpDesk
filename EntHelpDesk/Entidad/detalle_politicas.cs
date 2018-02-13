using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class detalle_politicas
    {
        public int id_detalle_politica { get; set; }
        public int id_politica { get; set; }
        public int id_prioridad { get; set; }
        public int tiempo_min { get; set; }
        public int tiempo_max { get; set; }
    }
}
