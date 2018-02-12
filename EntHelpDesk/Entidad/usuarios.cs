using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class usuarios
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public int telefono { get; set; }
        public int ext { get; set; }
        public string foto { get; set; }
        public int id_area { get; set; }
        public int id_sucursal { get; set; }
        public int id_tipo_usuario { get; set; }
        public string area { get; set; }
        public string sucursal { get; set; }
        public string tipo_usuario { get; set; }
        public List<detalle_permiso> permisos_usuario { get; set; }
    }
}
