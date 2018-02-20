using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class detalle_ticket
    {
        public int id_detalle_ticket { get; set; }
        public int id_ticket { get; set; }
        public int id_area { get; set; }
        public int id_prioridad { get; set; }
        public int id_estado { get; set; }
        public int id_agente { get; set; }
        public string agente { get; set; }
        public string foto_agente { get; set; }
        public string fechahora_inicioticket { get; set; }
        public string fechahora_cerroticket { get; set; }
        public int id_tipo_soporte { get; set; }
        public string tipo_soporte { get; set; }
        public string area { get; set; }
        public string prioridad { get; set; }
        public string estado { get; set; }

    }
}
