using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class politicas
    {
        public int id_politica { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_prioridad { get; set; }
        public string prioridad { get; set; }
        public int responder_en { get; set; }
        public int resolver_en { get; set; }
    }
}
