using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class conversaciones
    {
        public int id_conversaion { get; set; }
        public string conexion_idusuario { get; set; }
        public string conexion_idadmin { get; set; }
        public string grupo_usuarios { get; set; }
        public string mensaje { get; set; }
        public string tiempo_inicial { get; set; }
        public string tiempo_final { get; set; }
        public string fecha_Mensaje { get; set; }
        public string duracion_mensaje { get; set; }        
        public int id_usuario { get; set; }
        public int id_admin { get; set; }

        
        public string nombre_usuario { get; set; }
        public string foto_usuario { get; set; }


        public string UserName { get; set; }

        public string Message { get; set; }


    }
}
