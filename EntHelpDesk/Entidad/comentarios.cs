﻿using System;
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
        public string fechahora_comentario { get; set; }        
        public int id_detalle_ticket { get; set; }
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public int id_tipo_usuario { get; set; }
        public string tipo_usuario { get; set; }
        public string foto { get; set; }
    }
}
