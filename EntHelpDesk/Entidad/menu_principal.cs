using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class menu_principal
    {
        public int id_menu_principal { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string url_net { get; set; }
        public string icono_net { get; set; }
        public bool isactive { get; set; }
    }
}
