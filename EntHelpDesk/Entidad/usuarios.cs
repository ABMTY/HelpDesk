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
        public string user_name { get; set; }
        public string password { get; set; }
        public string nombre_completo { get { return nombre +" "+ apellidos; } }
        public List<detalle_permiso> permisos_usuario { get; set; }
        public tipo_usuario ent_tipo_usuario { get; set; }
        public int codigo_admin { get; set; }

        public string ConnectionId { get; set; }
        public string UserGroup { get; set; }
        //if freeflag==0 ==> Busy
        //if freeflag==1 ==> Free
        public string freeflag { get; set; }
        //if tpflag==2 ==> User Admin
        //if tpflag==0 ==> User Member
        //if tpflag==1 ==> Admin
        public string tpflag { get; set; }        
        public int AdminID { get; set; }
    }
}
