using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class comentarios
    {
        public int id_comentario { get; set; }
        public string comentario { get; set; }
        public string imagen { get; set; }
        public DateTime fechahora_comentario { get; set; }        
        public int id_detalle_ticket { get; set; }
    }
}
