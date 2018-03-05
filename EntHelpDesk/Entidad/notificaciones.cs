using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class notificaciones
    {
        public int id_notificacion { get; set; }
        public int id_ticket { get; set; }
        public string asunto { get; set; }
        public int id_usuario { get; set; }
        public int notificado { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public string tipo_notificacion { get; set; }
        public string foto { get; set; }
        public int tiempo { get; set; }
        public string nombre { get; set; }
    }
}
