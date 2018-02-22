using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class detalle_permiso : menu_principal
    {
        public int id_detalle_permiso { get; set; }
        public int id_tipo_usuario { get; set; }
        public int id_permiso { get; set; }
        public string permiso { get; set; }
        public string url { get; set; }
        public string menu_principal { get; set; }
    }
}
