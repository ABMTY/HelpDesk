using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class tickets
    {
        public int id_ticket { get; set; }
        public int id_usuario { get; set; }
        public int id_sucursal { get; set; }
        public string sucursal { get; set; }
        public string asunto { get; set; }
        public string descripcion { get; set; }
        public string imagen { get; set; }
        public string fechahora_creacion { get; set; }
        public string estado { get; set; }
    }
}
