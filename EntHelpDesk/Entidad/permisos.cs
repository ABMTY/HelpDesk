﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntHelpDesk.Entidad
{
    public class permisos
    {
        public int id_permiso { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string selected { get; set; }
        public string url { get; set; }
        public int id_menu_principal { get; set; }
        public string menu { get; set; }
    }
}
