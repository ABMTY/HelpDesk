using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class tipo_usuario
    {
        public int id_tipo_usuario { get; set; }
        public string nombre { get; set; }
        public List<detalle_permiso> permisos_tipo_usuario { get; set; }
    }
}
