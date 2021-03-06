﻿using EntHelpDesk.Entidad;
using PerHelpDesk.Sevicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Servicios
{
    public class CtrlComentarios
    {
        PerComentarios PerComentarios;

        public List<comentarios> Lista;

        public CtrlComentarios()
        {
            PerComentarios = new PerComentarios();
        }
        public List<comentarios> ObtenerTodos()
        {
            return (List<comentarios>)new PerComentarios().ObtenerTodos();
        }
        public comentarios Obtener(int id_comentario)
        {
            return (comentarios)new PerComentarios().Obtener(id_comentario);
        }
        public List<comentarios> ObtenerPorDetalle(int id_detalle_ticket)
        {
            return (List<comentarios>)new PerComentarios().ObtenerPorDetalle(id_detalle_ticket);
        }
        public bool Insertar(comentarios Entidad)
        {
            return PerComentarios.Insertar(Entidad);
        }

        public bool Actualizar(comentarios Entidad)
        {
            return PerComentarios.Update(Entidad);
        }

        public bool Eliminar(int id_comentario)
        {
            return PerComentarios.Delete(id_comentario);
        }
    }
}
